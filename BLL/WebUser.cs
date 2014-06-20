using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
namespace Song.BLL
{
	/// <summary>
	/// WebUser
	/// </summary>
	public partial class WebUser
	{
		private readonly Song.DAL.WebUser dal=new Song.DAL.WebUser();
		public WebUser()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.WebUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Song.Model.WebUser model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Song.Model.WebUser GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Song.Model.WebUser GetModelByCache(int id)
		{
			
			string CacheKey = "WebUserModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Song.Model.WebUser)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Song.Model.WebUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Song.Model.WebUser> DataTableToList(DataTable dt)
		{
			List<Song.Model.WebUser> modelList = new List<Song.Model.WebUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Song.Model.WebUser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Song.Model.WebUser();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["username"]!=null && dt.Rows[n]["username"].ToString()!="")
					{
					model.username=dt.Rows[n]["username"].ToString();
					}
					if(dt.Rows[n]["password"]!=null && dt.Rows[n]["password"].ToString()!="")
					{
					model.password=dt.Rows[n]["password"].ToString();
					}
					if(dt.Rows[n]["companyname"]!=null && dt.Rows[n]["companyname"].ToString()!="")
					{
					model.companyname=dt.Rows[n]["companyname"].ToString();
					}
					if(dt.Rows[n]["email"]!=null && dt.Rows[n]["email"].ToString()!="")
					{
					model.email=dt.Rows[n]["email"].ToString();
					}
					if(dt.Rows[n]["mobile"]!=null && dt.Rows[n]["mobile"].ToString()!="")
					{
					model.mobile=dt.Rows[n]["mobile"].ToString();
					}
					if(dt.Rows[n]["qq"]!=null && dt.Rows[n]["qq"].ToString()!="")
					{
					model.qq=dt.Rows[n]["qq"].ToString();
					}
					if(dt.Rows[n]["address"]!=null && dt.Rows[n]["address"].ToString()!="")
					{
					model.address=dt.Rows[n]["address"].ToString();
					}
					if(dt.Rows[n]["userlv"]!=null && dt.Rows[n]["userlv"].ToString()!="")
					{
						model.userlv=int.Parse(dt.Rows[n]["userlv"].ToString());
					}
					if(dt.Rows[n]["userstate"]!=null && dt.Rows[n]["userstate"].ToString()!="")
					{
						if((dt.Rows[n]["userstate"].ToString()=="1")||(dt.Rows[n]["userstate"].ToString().ToLower()=="true"))
						{
						model.userstate=true;
						}
						else
						{
							model.userstate=false;
						}
					}
					if(dt.Rows[n]["timeinfo"]!=null && dt.Rows[n]["timeinfo"].ToString()!="")
					{
						model.timeinfo=DateTime.Parse(dt.Rows[n]["timeinfo"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}


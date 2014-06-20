using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
namespace Song.BLL
{
	/// <summary>
	/// companyInformation
	/// </summary>
	public partial class companyInformation
	{
		private readonly Song.DAL.companyInformation dal=new Song.DAL.companyInformation();
		public companyInformation()
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
		public bool Add(Song.Model.companyInformation model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Song.Model.companyInformation model)
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
		public Song.Model.companyInformation GetModel(String id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Song.Model.companyInformation GetModelByCache(String id)
		{
			
			string CacheKey = "companyInformationModel-" + id;
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
			return (Song.Model.companyInformation)objModel;
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
		public List<Song.Model.companyInformation> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Song.Model.companyInformation> DataTableToList(DataTable dt)
		{
			List<Song.Model.companyInformation> modelList = new List<Song.Model.companyInformation>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Song.Model.companyInformation model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Song.Model.companyInformation();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["pid"]!=null && dt.Rows[n]["pid"].ToString()!="")
					{
						model.pid=int.Parse(dt.Rows[n]["pid"].ToString());
					}
					if(dt.Rows[n]["menuname"]!=null && dt.Rows[n]["menuname"].ToString()!="")
					{
					model.menuname=dt.Rows[n]["menuname"].ToString();
					}
					if(dt.Rows[n]["information"]!=null && dt.Rows[n]["information"].ToString()!="")
					{
					model.information=dt.Rows[n]["information"].ToString();
					}
					if(dt.Rows[n]["infocn"]!=null && dt.Rows[n]["infocn"].ToString()!="")
					{
					model.infocn=dt.Rows[n]["infocn"].ToString();
					}
					if(dt.Rows[n]["updateTime"]!=null && dt.Rows[n]["updateTime"].ToString()!="")
					{
						model.updateTime=DateTime.Parse(dt.Rows[n]["updateTime"].ToString());
					}
					if(dt.Rows[n]["weblanguage"]!=null && dt.Rows[n]["weblanguage"].ToString()!="")
					{
					model.weblanguage=dt.Rows[n]["weblanguage"].ToString();
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


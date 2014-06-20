using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
namespace Song.BLL
{
	/// <summary>
	/// userorders
	/// </summary>
	public partial class userorders
	{
		private readonly Song.DAL.userorders dal=new Song.DAL.userorders();
		public userorders()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.userorders model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Song.Model.userorders model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Song.Model.userorders GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Song.Model.userorders GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "userordersModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Song.Model.userorders)objModel;
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
		public List<Song.Model.userorders> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Song.Model.userorders> DataTableToList(DataTable dt)
		{
			List<Song.Model.userorders> modelList = new List<Song.Model.userorders>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Song.Model.userorders model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Song.Model.userorders();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["orderno"]!=null && dt.Rows[n]["orderno"].ToString()!="")
					{
						model.orderno=int.Parse(dt.Rows[n]["orderno"].ToString());
					}
					if(dt.Rows[n]["ordercontent"]!=null && dt.Rows[n]["ordercontent"].ToString()!="")
					{
					model.ordercontent=dt.Rows[n]["ordercontent"].ToString();
					}
					if(dt.Rows[n]["username"]!=null && dt.Rows[n]["username"].ToString()!="")
					{
					model.username=dt.Rows[n]["username"].ToString();
					}
					if(dt.Rows[n]["ordertime"]!=null && dt.Rows[n]["ordertime"].ToString()!="")
					{
						model.ordertime=DateTime.Parse(dt.Rows[n]["ordertime"].ToString());
					}
					if(dt.Rows[n]["consignee"]!=null && dt.Rows[n]["consignee"].ToString()!="")
					{
					model.consignee=dt.Rows[n]["consignee"].ToString();
					}
					if(dt.Rows[n]["email"]!=null && dt.Rows[n]["email"].ToString()!="")
					{
					model.email=dt.Rows[n]["email"].ToString();
					}
					if(dt.Rows[n]["address"]!=null && dt.Rows[n]["address"].ToString()!="")
					{
					model.address=dt.Rows[n]["address"].ToString();
					}
					if(dt.Rows[n]["tel"]!=null && dt.Rows[n]["tel"].ToString()!="")
					{
					model.tel=dt.Rows[n]["tel"].ToString();
					}
					if(dt.Rows[n]["mobile"]!=null && dt.Rows[n]["mobile"].ToString()!="")
					{
					model.mobile=dt.Rows[n]["mobile"].ToString();
					}
					if(dt.Rows[n]["zipcode"]!=null && dt.Rows[n]["zipcode"].ToString()!="")
					{
					model.zipcode=dt.Rows[n]["zipcode"].ToString();
					}
					if(dt.Rows[n]["best_time"]!=null && dt.Rows[n]["best_time"].ToString()!="")
					{
					model.best_time=dt.Rows[n]["best_time"].ToString();
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


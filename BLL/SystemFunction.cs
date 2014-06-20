using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
namespace Song.BLL
{
	/// <summary>
	/// SystemFunction
	/// </summary>
	public partial class SystemFunction
	{
		private readonly Song.DAL.SystemFunction dal=new Song.DAL.SystemFunction();
		public SystemFunction()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.SystemFunction model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Song.Model.SystemFunction model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(String id)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Song.Model.SystemFunction GetModel(String id)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Song.Model.SystemFunction GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "SystemFunctionModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel("");
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Song.Model.SystemFunction)objModel;
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
		public List<Song.Model.SystemFunction> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Song.Model.SystemFunction> DataTableToList(DataTable dt)
		{
			List<Song.Model.SystemFunction> modelList = new List<Song.Model.SystemFunction>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Song.Model.SystemFunction model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Song.Model.SystemFunction();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["title"]!=null && dt.Rows[n]["title"].ToString()!="")
					{
					model.title=dt.Rows[n]["title"].ToString();
					}
					if(dt.Rows[n]["url"]!=null && dt.Rows[n]["url"].ToString()!="")
					{
					model.url=dt.Rows[n]["url"].ToString();
					}
					if(dt.Rows[n]["isShow"]!=null && dt.Rows[n]["isShow"].ToString()!="")
					{
					model.isShow=dt.Rows[n]["isShow"].ToString();
					}
					if(dt.Rows[n]["info"]!=null && dt.Rows[n]["info"].ToString()!="")
					{
					model.info=dt.Rows[n]["info"].ToString();
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


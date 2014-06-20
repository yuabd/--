using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
namespace Song.BLL
{
	/// <summary>
	/// webconfig
	/// </summary>
	public partial class webconfig
	{
		private readonly Song.DAL.webconfig dal=new Song.DAL.webconfig();
		public webconfig()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.webconfig model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Song.Model.webconfig model)
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
        public Song.Model.webconfig GetModel(String id)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Song.Model.webconfig GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "webconfigModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel("1");
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Song.Model.webconfig)objModel;
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
		public List<Song.Model.webconfig> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Song.Model.webconfig> DataTableToList(DataTable dt)
		{
			List<Song.Model.webconfig> modelList = new List<Song.Model.webconfig>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Song.Model.webconfig model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Song.Model.webconfig();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["webname"]!=null && dt.Rows[n]["webname"].ToString()!="")
					{
					model.webname=dt.Rows[n]["webname"].ToString();
					}
					if(dt.Rows[n]["webkey1"]!=null && dt.Rows[n]["webkey1"].ToString()!="")
					{
					model.webkey1=dt.Rows[n]["webkey1"].ToString();
					}
					if(dt.Rows[n]["webkey2"]!=null && dt.Rows[n]["webkey2"].ToString()!="")
					{
					model.webkey2=dt.Rows[n]["webkey2"].ToString();
					}
					if(dt.Rows[n]["webkey3"]!=null && dt.Rows[n]["webkey3"].ToString()!="")
					{
					model.webkey3=dt.Rows[n]["webkey3"].ToString();
					}
					if(dt.Rows[n]["webemail"]!=null && dt.Rows[n]["webemail"].ToString()!="")
					{
					model.webemail=dt.Rows[n]["webemail"].ToString();
					}
					if(dt.Rows[n]["webadd"]!=null && dt.Rows[n]["webadd"].ToString()!="")
					{
					model.webadd=dt.Rows[n]["webadd"].ToString();
					}
					if(dt.Rows[n]["webcode"]!=null && dt.Rows[n]["webcode"].ToString()!="")
					{
					model.webcode=dt.Rows[n]["webcode"].ToString();
					}
					if(dt.Rows[n]["webtel"]!=null && dt.Rows[n]["webtel"].ToString()!="")
					{
					model.webtel=dt.Rows[n]["webtel"].ToString();
					}
					if(dt.Rows[n]["webfax"]!=null && dt.Rows[n]["webfax"].ToString()!="")
					{
					model.webfax=dt.Rows[n]["webfax"].ToString();
					}
					if(dt.Rows[n]["webcopyright"]!=null && dt.Rows[n]["webcopyright"].ToString()!="")
					{
					model.webcopyright=dt.Rows[n]["webcopyright"].ToString();
					}
					if(dt.Rows[n]["webicp"]!=null && dt.Rows[n]["webicp"].ToString()!="")
					{
					model.webicp=dt.Rows[n]["webicp"].ToString();
					}
					if(dt.Rows[n]["qq1"]!=null && dt.Rows[n]["qq1"].ToString()!="")
					{
					model.qq1=dt.Rows[n]["qq1"].ToString();
					}
					if(dt.Rows[n]["qq2"]!=null && dt.Rows[n]["qq2"].ToString()!="")
					{
					model.qq2=dt.Rows[n]["qq2"].ToString();
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


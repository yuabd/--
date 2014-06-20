using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
namespace Song.BLL
{
	/// <summary>
	/// FieldRule
	/// </summary>
	public partial class FieldRule
	{
		private readonly Song.DAL.FieldRule dal=new Song.DAL.FieldRule();
		public FieldRule()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.FieldRule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Song.Model.FieldRule model)
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
		public Song.Model.FieldRule GetModel(String id)
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Song.Model.FieldRule GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "FieldRuleModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel("0");
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Song.Model.FieldRule)objModel;
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
		public List<Song.Model.FieldRule> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Song.Model.FieldRule> DataTableToList(DataTable dt)
		{
			List<Song.Model.FieldRule> modelList = new List<Song.Model.FieldRule>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Song.Model.FieldRule model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Song.Model.FieldRule();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["RuleName"]!=null && dt.Rows[n]["RuleName"].ToString()!="")
					{
					model.RuleName=dt.Rows[n]["RuleName"].ToString();
					}
					if(dt.Rows[n]["RulePower"]!=null && dt.Rows[n]["RulePower"].ToString()!="")
					{
					model.RulePower=dt.Rows[n]["RulePower"].ToString();
					}
					if(dt.Rows[n]["xmlname"]!=null && dt.Rows[n]["xmlname"].ToString()!="")
					{
					model.xmlname=dt.Rows[n]["xmlname"].ToString();
					}
					if(dt.Rows[n]["RuleType"]!=null && dt.Rows[n]["RuleType"].ToString()!="")
					{
					model.RuleType=dt.Rows[n]["RuleType"].ToString();
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


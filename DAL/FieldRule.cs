using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
	/// <summary>
	/// 数据访问类:FieldRule
	/// </summary>
	public partial class FieldRule
	{
		public FieldRule()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.FieldRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FieldRule(");
			strSql.Append("RuleName,RulePower,xmlname,RuleType)");
			strSql.Append(" values (");
			strSql.Append("@RuleName,@RulePower,@xmlname,@RuleType)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@RuleName", OleDbType.VarChar,20),
					new OleDbParameter("@RulePower", OleDbType.VarChar,0),
					new OleDbParameter("@xmlname", OleDbType.VarChar,10),
					new OleDbParameter("@RuleType", OleDbType.VarChar,10)};
			parameters[0].Value = model.RuleName;
			parameters[1].Value = model.RulePower;
			parameters[2].Value = model.xmlname;
			parameters[3].Value = model.RuleType;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Song.Model.FieldRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FieldRule set ");
			strSql.Append("RuleName=@RuleName,");
			strSql.Append("RulePower=@RulePower,");
			strSql.Append("xmlname=@xmlname,");
			strSql.Append("RuleType=@RuleType");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@RuleName", OleDbType.VarChar,20),
					new OleDbParameter("@RulePower", OleDbType.VarChar,0),
					new OleDbParameter("@xmlname", OleDbType.VarChar,10),
					new OleDbParameter("@RuleType", OleDbType.VarChar,10),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.RuleName;
			parameters[1].Value = model.RulePower;
			parameters[2].Value = model.xmlname;
			parameters[3].Value = model.RuleType;
			parameters[4].Value = model.id;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(String id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FieldRule ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
                new OleDbParameter("@id",OleDbType.VarChar,5)
			};
            parameters[0].Value = id;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Song.Model.FieldRule GetModel(String id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,RuleName,RulePower,xmlname,RuleType from FieldRule ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
             new OleDbParameter("@id",OleDbType.VarChar,5)
			};
            parameters[0].Value = id;

			Song.Model.FieldRule model=new Song.Model.FieldRule();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RuleName"]!=null && ds.Tables[0].Rows[0]["RuleName"].ToString()!="")
				{
					model.RuleName=ds.Tables[0].Rows[0]["RuleName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RulePower"]!=null && ds.Tables[0].Rows[0]["RulePower"].ToString()!="")
				{
					model.RulePower=ds.Tables[0].Rows[0]["RulePower"].ToString();
				}
				if(ds.Tables[0].Rows[0]["xmlname"]!=null && ds.Tables[0].Rows[0]["xmlname"].ToString()!="")
				{
					model.xmlname=ds.Tables[0].Rows[0]["xmlname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RuleType"]!=null && ds.Tables[0].Rows[0]["RuleType"].ToString()!="")
				{
					model.RuleType=ds.Tables[0].Rows[0]["RuleType"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,RuleName,RulePower,xmlname,RuleType ");
			strSql.Append(" FROM FieldRule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM FieldRule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from FieldRule T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "FieldRule";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}


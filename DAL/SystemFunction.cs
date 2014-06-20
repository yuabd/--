using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
	/// <summary>
	/// 数据访问类:SystemFunction
	/// </summary>
	public partial class SystemFunction
	{
		public SystemFunction()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.SystemFunction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SystemFunction(");
			strSql.Append("title,url,isShow,info)");
			strSql.Append(" values (");
			strSql.Append("@title,@url,@isShow,@info)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@title", OleDbType.VarChar,20),
					new OleDbParameter("@url", OleDbType.VarChar,0),
					new OleDbParameter("@isShow", OleDbType.VarChar,50),
					new OleDbParameter("@info", OleDbType.VarChar,0)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.url;
			parameters[2].Value = model.isShow;
			parameters[3].Value = model.info;

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
		public bool Update(Song.Model.SystemFunction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SystemFunction set ");
			strSql.Append("title=@title,");
			strSql.Append("url=@url,");
			strSql.Append("isShow=@isShow,");
			strSql.Append("info=@info");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@title", OleDbType.VarChar,20),
					new OleDbParameter("@url", OleDbType.VarChar,0),
					new OleDbParameter("@isShow", OleDbType.VarChar,50),
					new OleDbParameter("@info", OleDbType.VarChar,0),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.url;
			parameters[2].Value = model.isShow;
			parameters[3].Value = model.info;
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
			strSql.Append("delete from SystemFunction ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
               new OleDbParameter("@id", OleDbType.VarChar,5)
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
		public Song.Model.SystemFunction GetModel(String id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,url,isShow,info from SystemFunction ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
               new OleDbParameter("@id",OleDbType.VarChar,5)
			};
            parameters[0].Value = id;

			Song.Model.SystemFunction model=new Song.Model.SystemFunction();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["url"]!=null && ds.Tables[0].Rows[0]["url"].ToString()!="")
				{
					model.url=ds.Tables[0].Rows[0]["url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["isShow"]!=null && ds.Tables[0].Rows[0]["isShow"].ToString()!="")
				{
					model.isShow=ds.Tables[0].Rows[0]["isShow"].ToString();
				}
				if(ds.Tables[0].Rows[0]["info"]!=null && ds.Tables[0].Rows[0]["info"].ToString()!="")
				{
					model.info=ds.Tables[0].Rows[0]["info"].ToString();
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
			strSql.Append("select id,title,url,isShow,info ");
			strSql.Append(" FROM SystemFunction ");
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
			strSql.Append("select count(1) FROM SystemFunction ");
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
			strSql.Append(")AS Row, T.*  from SystemFunction T ");
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
			parameters[0].Value = "SystemFunction";
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


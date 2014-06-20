using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
	/// <summary>
	/// 数据访问类:newstype
	/// </summary>
	public partial class newstype
	{
		public newstype()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("id", "newstype"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from newstype");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
			parameters[0].Value = id;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.newstype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into newstype(");
			strSql.Append("pid,fid,title,entitle,content,encontent)");
			strSql.Append(" values (");
			strSql.Append("@pid,@fid,@title,@entitle,@content,@encontent)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@fid", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@entitle", OleDbType.VarChar,50),
					new OleDbParameter("@content", OleDbType.VarChar,50),
					new OleDbParameter("@encontent", OleDbType.VarChar,0)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.fid;
			parameters[2].Value = model.title;
			parameters[3].Value = model.entitle;
			parameters[4].Value = model.content;
			parameters[5].Value = model.encontent;

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
		public bool Update(Song.Model.newstype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update newstype set ");
			strSql.Append("pid=@pid,");
			strSql.Append("fid=@fid,");
			strSql.Append("title=@title,");
			strSql.Append("entitle=@entitle,");
			strSql.Append("content=@content,");
			strSql.Append("encontent=@encontent");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@fid", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@entitle", OleDbType.VarChar,50),
					new OleDbParameter("@content", OleDbType.VarChar,0),
					new OleDbParameter("@encontent", OleDbType.VarChar,0),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.fid;
			parameters[2].Value = model.title;
			parameters[3].Value = model.entitle;
			parameters[4].Value = model.content;
			parameters[5].Value = model.encontent;
			parameters[6].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from newstype ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from newstype ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
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
		public Song.Model.newstype GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,pid,fid,title,entitle,content,encontent from newstype ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
			parameters[0].Value = id;

			Song.Model.newstype model=new Song.Model.newstype();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pid"]!=null && ds.Tables[0].Rows[0]["pid"].ToString()!="")
				{
					model.pid=int.Parse(ds.Tables[0].Rows[0]["pid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["fid"]!=null && ds.Tables[0].Rows[0]["fid"].ToString()!="")
				{
					model.fid=int.Parse(ds.Tables[0].Rows[0]["fid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["entitle"]!=null && ds.Tables[0].Rows[0]["entitle"].ToString()!="")
				{
					model.entitle=ds.Tables[0].Rows[0]["entitle"].ToString();
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["encontent"]!=null && ds.Tables[0].Rows[0]["encontent"].ToString()!="")
				{
					model.encontent=ds.Tables[0].Rows[0]["encontent"].ToString();
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
			strSql.Append("select id,pid,fid,title,entitle,content,encontent ");
			strSql.Append(" FROM newstype ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where 1=1 "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM newstype ");
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
			strSql.Append(")AS Row, T.*  from newstype T ");
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
			parameters[0].Value = "newstype";
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


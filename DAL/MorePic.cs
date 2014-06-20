using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
	/// <summary>
	/// 数据访问类:MorePic
	/// </summary>
	public partial class MorePic
	{
		public MorePic()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("id", "MorePic"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MorePic");
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
		public bool Add(Song.Model.MorePic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MorePic(");
			strSql.Append("pid,photono,Title,Detail,Pic,timeinfo)");
			strSql.Append(" values (");
			strSql.Append("@pid,@photono,@Title,@Detail,@Pic,@timeinfo)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@photono", OleDbType.VarChar,50),
					new OleDbParameter("@Title", OleDbType.VarChar,50),
					new OleDbParameter("@Detail", OleDbType.VarChar,0),
					new OleDbParameter("@Pic", OleDbType.VarChar,50),
					new OleDbParameter("@timeinfo", OleDbType.Date)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.photono;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Detail;
			parameters[4].Value = model.Pic;
			parameters[5].Value = model.timeinfo;

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
		public bool Update(Song.Model.MorePic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MorePic set ");
			strSql.Append("pid=@pid,");
			strSql.Append("photono=@photono,");
			strSql.Append("Title=@Title,");
			strSql.Append("Detail=@Detail,");
			strSql.Append("Pic=@Pic,");
			strSql.Append("timeinfo=@timeinfo");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@photono", OleDbType.VarChar,50),
					new OleDbParameter("@Title", OleDbType.VarChar,50),
					new OleDbParameter("@Detail", OleDbType.VarChar,0),
					new OleDbParameter("@Pic", OleDbType.VarChar,50),
					new OleDbParameter("@timeinfo", OleDbType.Date),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.photono;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Detail;
			parameters[4].Value = model.Pic;
			parameters[5].Value = model.timeinfo;
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

        public bool Update(string strUpdateField, string strUpdateWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MorePic set ");
            if (strUpdateField != "")
                strSql.Append(strUpdateField);
            if (strUpdateWhere != "")
                strSql.Append(" where " + strUpdateWhere);

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
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
			strSql.Append("delete from MorePic ");
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
			strSql.Append("delete from MorePic ");
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
		public Song.Model.MorePic GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,pid,photono,Title,Detail,Pic,timeinfo from MorePic ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
			parameters[0].Value = id;

			Song.Model.MorePic model=new Song.Model.MorePic();
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
				if(ds.Tables[0].Rows[0]["photono"]!=null && ds.Tables[0].Rows[0]["photono"].ToString()!="")
				{
					model.photono=ds.Tables[0].Rows[0]["photono"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Title"]!=null && ds.Tables[0].Rows[0]["Title"].ToString()!="")
				{
					model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Detail"]!=null && ds.Tables[0].Rows[0]["Detail"].ToString()!="")
				{
					model.Detail=ds.Tables[0].Rows[0]["Detail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Pic"]!=null && ds.Tables[0].Rows[0]["Pic"].ToString()!="")
				{
					model.Pic=ds.Tables[0].Rows[0]["Pic"].ToString();
				}
				if(ds.Tables[0].Rows[0]["timeinfo"]!=null && ds.Tables[0].Rows[0]["timeinfo"].ToString()!="")
				{
					model.timeinfo=DateTime.Parse(ds.Tables[0].Rows[0]["timeinfo"].ToString());
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
			strSql.Append("select id,pid,photono,Title,Detail,Pic,timeinfo ");
			strSql.Append(" FROM MorePic ");
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
			strSql.Append("select count(1) FROM MorePic ");
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
			strSql.Append(")AS Row, T.*  from MorePic T ");
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
			parameters[0].Value = "MorePic";
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


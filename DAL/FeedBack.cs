using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
	/// <summary>
	/// 数据访问类:FeedBack
	/// </summary>
	public partial class FeedBack
	{
		public FeedBack()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("id", "FeedBack"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FeedBack");
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
		public bool Add(Song.Model.FeedBack model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FeedBack(");
            strSql.Append("pid,type,companyName,userName,jobs,phone,mobile,email,address,content,timeinfo,FeedState,FeedBackType,weblanguage)");
			strSql.Append(" values (");
            strSql.Append("@pid,@type,@companyName,@userName,@jobs,@phone,@mobile,@email,@address,@content,@timeinfo,@FeedState,@FeedBackType,@weblanguage)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@type", OleDbType.VarChar,50),
					new OleDbParameter("@companyName", OleDbType.VarChar,255),
					new OleDbParameter("@userName", OleDbType.VarChar,50),
					new OleDbParameter("@jobs", OleDbType.VarChar,50),
					new OleDbParameter("@phone", OleDbType.VarChar,50),
					new OleDbParameter("@mobile", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,0),
					new OleDbParameter("@content", OleDbType.VarChar,0),
					new OleDbParameter("@timeinfo", OleDbType.Date),
					new OleDbParameter("@FeedState", OleDbType.Integer,4),
					new OleDbParameter("@FeedBackType", OleDbType.VarChar,50),
                    new OleDbParameter("@weblanguage", OleDbType.VarChar,50)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.type;
			parameters[2].Value = model.companyName;
			parameters[3].Value = model.userName;
			parameters[4].Value = model.jobs;
			parameters[5].Value = model.phone;
			parameters[6].Value = model.mobile;
			parameters[7].Value = model.email;
			parameters[8].Value = model.address;
			parameters[9].Value = model.content;
			parameters[10].Value = model.timeinfo;
			parameters[11].Value = model.FeedState;
			parameters[12].Value = model.FeedBackType;
            parameters[13].Value = model.weblanguage;
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
		public bool Update(Song.Model.FeedBack model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FeedBack set ");
			strSql.Append("pid=@pid,");
			strSql.Append("type=@type,");
			strSql.Append("companyName=@companyName,");
			strSql.Append("userName=@userName,");
			strSql.Append("jobs=@jobs,");
			strSql.Append("phone=@phone,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("email=@email,");
			strSql.Append("address=@address,");
			strSql.Append("content=@content,");
			strSql.Append("timeinfo=@timeinfo,");
			strSql.Append("FeedState=@FeedState,");
            strSql.Append("FeedBackType=@FeedBackType,");
            strSql.Append("weblanguage=@weblanguage");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@type", OleDbType.VarChar,50),
					new OleDbParameter("@companyName", OleDbType.VarChar,255),
					new OleDbParameter("@userName", OleDbType.VarChar,50),
					new OleDbParameter("@jobs", OleDbType.VarChar,50),
					new OleDbParameter("@phone", OleDbType.VarChar,50),
					new OleDbParameter("@mobile", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,0),
					new OleDbParameter("@content", OleDbType.VarChar,0),
					new OleDbParameter("@timeinfo", OleDbType.Date),
					new OleDbParameter("@FeedState", OleDbType.Integer,4),
					new OleDbParameter("@FeedBackType", OleDbType.VarChar,50),
                    new OleDbParameter("@weblanguage", OleDbType.VarChar,50),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.pid;
			parameters[1].Value = model.type;
			parameters[2].Value = model.companyName;
			parameters[3].Value = model.userName;
			parameters[4].Value = model.jobs;
			parameters[5].Value = model.phone;
			parameters[6].Value = model.mobile;
			parameters[7].Value = model.email;
			parameters[8].Value = model.address;
			parameters[9].Value = model.content;
			parameters[10].Value = model.timeinfo;
			parameters[11].Value = model.FeedState;
            parameters[12].Value = model.FeedBackType;
            parameters[13].Value = model.weblanguage;
            parameters[14].Value = model.id;

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
			strSql.Append("delete from FeedBack ");
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
			strSql.Append("delete from FeedBack ");
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
		public Song.Model.FeedBack GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,pid,type,companyName,userName,jobs,phone,mobile,email,address,content,timeinfo,FeedState,FeedBackType,weblanguage from FeedBack ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
			parameters[0].Value = id;

			Song.Model.FeedBack model=new Song.Model.FeedBack();
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
				if(ds.Tables[0].Rows[0]["type"]!=null && ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=ds.Tables[0].Rows[0]["type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["companyName"]!=null && ds.Tables[0].Rows[0]["companyName"].ToString()!="")
				{
					model.companyName=ds.Tables[0].Rows[0]["companyName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["userName"]!=null && ds.Tables[0].Rows[0]["userName"].ToString()!="")
				{
					model.userName=ds.Tables[0].Rows[0]["userName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["jobs"]!=null && ds.Tables[0].Rows[0]["jobs"].ToString()!="")
				{
					model.jobs=ds.Tables[0].Rows[0]["jobs"].ToString();
				}
				if(ds.Tables[0].Rows[0]["phone"]!=null && ds.Tables[0].Rows[0]["phone"].ToString()!="")
				{
					model.phone=ds.Tables[0].Rows[0]["phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mobile"]!=null && ds.Tables[0].Rows[0]["mobile"].ToString()!="")
				{
					model.mobile=ds.Tables[0].Rows[0]["mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["email"]!=null && ds.Tables[0].Rows[0]["email"].ToString()!="")
				{
					model.email=ds.Tables[0].Rows[0]["email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["address"]!=null && ds.Tables[0].Rows[0]["address"].ToString()!="")
				{
					model.address=ds.Tables[0].Rows[0]["address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["timeinfo"]!=null && ds.Tables[0].Rows[0]["timeinfo"].ToString()!="")
				{
					model.timeinfo=DateTime.Parse(ds.Tables[0].Rows[0]["timeinfo"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FeedState"]!=null && ds.Tables[0].Rows[0]["FeedState"].ToString()!="")
				{
					model.FeedState=int.Parse(ds.Tables[0].Rows[0]["FeedState"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FeedBackType"]!=null && ds.Tables[0].Rows[0]["FeedBackType"].ToString()!="")
				{
					model.FeedBackType=ds.Tables[0].Rows[0]["FeedBackType"].ToString();
				}
                if (ds.Tables[0].Rows[0]["weblanguage"] != null && ds.Tables[0].Rows[0]["weblanguage"].ToString() != "")
                {
                    model.weblanguage = ds.Tables[0].Rows[0]["weblanguage"].ToString();
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
            strSql.Append("select id,pid,type,companyName,userName,jobs,phone,mobile,email,address,content,timeinfo,FeedState,FeedBackType,weblanguage ");
			strSql.Append(" FROM FeedBack ");
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
			strSql.Append("select count(1) FROM FeedBack ");
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
			strSql.Append(")AS Row, T.*  from FeedBack T ");
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
			parameters[0].Value = "FeedBack";
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


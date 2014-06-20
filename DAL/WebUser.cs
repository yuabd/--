using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
	/// <summary>
	/// 数据访问类:WebUser
	/// </summary>
	public partial class WebUser
	{
		public WebUser()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("id", "WebUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WebUser");
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
		public bool Add(Song.Model.WebUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WebUser(");
			strSql.Append("[username],[password],[companyname],[email],[mobile],[qq],[address],[userlv],[userstate],[timeinfo])");
			strSql.Append(" values (");
			strSql.Append("@username,@password,@companyname,@email,@mobile,@qq,@address,@userlv,@userstate,@timeinfo)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@username", OleDbType.VarChar,50),
					new OleDbParameter("@password", OleDbType.VarChar,50),
					new OleDbParameter("@companyname", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@mobile", OleDbType.VarChar,50),
					new OleDbParameter("@qq", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,50),
					new OleDbParameter("@userlv", OleDbType.Integer,4),
					new OleDbParameter("@userstate", OleDbType.Boolean,1),
					new OleDbParameter("@timeinfo", OleDbType.Date)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.password;
			parameters[2].Value = model.companyname;
			parameters[3].Value = model.email;
			parameters[4].Value = model.mobile;
			parameters[5].Value = model.qq;
			parameters[6].Value = model.address;
			parameters[7].Value = model.userlv;
			parameters[8].Value = model.userstate;
			parameters[9].Value = model.timeinfo;

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
		public bool Update(Song.Model.WebUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WebUser set ");
			strSql.Append("username=@username,");
			strSql.Append("password=@password,");
			strSql.Append("companyname=@companyname,");
			strSql.Append("email=@email,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("qq=@qq,");
			strSql.Append("address=@address,");
			strSql.Append("userlv=@userlv,");
			strSql.Append("userstate=@userstate,");
			strSql.Append("timeinfo=@timeinfo");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@username", OleDbType.VarChar,50),
					new OleDbParameter("@password", OleDbType.VarChar,50),
					new OleDbParameter("@companyname", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@mobile", OleDbType.VarChar,50),
					new OleDbParameter("@qq", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,50),
					new OleDbParameter("@userlv", OleDbType.Integer,4),
					new OleDbParameter("@userstate", OleDbType.Boolean,1),
					new OleDbParameter("@timeinfo", OleDbType.Date),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.password;
			parameters[2].Value = model.companyname;
			parameters[3].Value = model.email;
			parameters[4].Value = model.mobile;
			parameters[5].Value = model.qq;
			parameters[6].Value = model.address;
			parameters[7].Value = model.userlv;
			parameters[8].Value = model.userstate;
			parameters[9].Value = model.timeinfo;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from WebUser ");
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
			strSql.Append("delete from WebUser ");
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
		public Song.Model.WebUser GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,username,password,companyname,email,mobile,qq,address,userlv,userstate,timeinfo from WebUser ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
			parameters[0].Value = id;

			Song.Model.WebUser model=new Song.Model.WebUser();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["username"]!=null && ds.Tables[0].Rows[0]["username"].ToString()!="")
				{
					model.username=ds.Tables[0].Rows[0]["username"].ToString();
				}
				if(ds.Tables[0].Rows[0]["password"]!=null && ds.Tables[0].Rows[0]["password"].ToString()!="")
				{
					model.password=ds.Tables[0].Rows[0]["password"].ToString();
				}
				if(ds.Tables[0].Rows[0]["companyname"]!=null && ds.Tables[0].Rows[0]["companyname"].ToString()!="")
				{
					model.companyname=ds.Tables[0].Rows[0]["companyname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["email"]!=null && ds.Tables[0].Rows[0]["email"].ToString()!="")
				{
					model.email=ds.Tables[0].Rows[0]["email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mobile"]!=null && ds.Tables[0].Rows[0]["mobile"].ToString()!="")
				{
					model.mobile=ds.Tables[0].Rows[0]["mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qq"]!=null && ds.Tables[0].Rows[0]["qq"].ToString()!="")
				{
					model.qq=ds.Tables[0].Rows[0]["qq"].ToString();
				}
				if(ds.Tables[0].Rows[0]["address"]!=null && ds.Tables[0].Rows[0]["address"].ToString()!="")
				{
					model.address=ds.Tables[0].Rows[0]["address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["userlv"]!=null && ds.Tables[0].Rows[0]["userlv"].ToString()!="")
				{
					model.userlv=int.Parse(ds.Tables[0].Rows[0]["userlv"].ToString());
				}
				if(ds.Tables[0].Rows[0]["userstate"]!=null && ds.Tables[0].Rows[0]["userstate"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["userstate"].ToString()=="1")||(ds.Tables[0].Rows[0]["userstate"].ToString().ToLower()=="true"))
					{
						model.userstate=true;
					}
					else
					{
						model.userstate=false;
					}
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
			strSql.Append("select id,username,password,companyname,email,mobile,qq,address,userlv,userstate,timeinfo ");
			strSql.Append(" FROM WebUser ");
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
			strSql.Append("select count(1) FROM WebUser ");
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
			strSql.Append(")AS Row, T.*  from WebUser T ");
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
			parameters[0].Value = "WebUser";
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


using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
	/// <summary>
	/// 数据访问类:webconfig
	/// </summary>
	public partial class webconfig
	{
		public webconfig()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.webconfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into webconfig(");
			strSql.Append("webname,webkey1,webkey2,webkey3,webemail,webadd,webcode,webtel,webfax,webcopyright,webicp,qq1,qq2,weblanguage)");
			strSql.Append(" values (");
			strSql.Append("@webname,@webkey1,@webkey2,@webkey3,@webemail,@webadd,@webcode,@webtel,@webfax,@webcopyright,@webicp,@qq1,@qq2,@weblanguage)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@webname", OleDbType.VarChar,50),
					new OleDbParameter("@webkey1", OleDbType.VarChar,0),
					new OleDbParameter("@webkey2", OleDbType.VarChar,0),
					new OleDbParameter("@webkey3", OleDbType.VarChar,0),
					new OleDbParameter("@webemail", OleDbType.VarChar,50),
					new OleDbParameter("@webadd", OleDbType.VarChar,0),
					new OleDbParameter("@webcode", OleDbType.VarChar,50),
					new OleDbParameter("@webtel", OleDbType.VarChar,50),
					new OleDbParameter("@webfax", OleDbType.VarChar,50),
					new OleDbParameter("@webcopyright", OleDbType.VarChar,0),
					new OleDbParameter("@webicp", OleDbType.VarChar,50),
					new OleDbParameter("@qq1", OleDbType.VarChar,50),
					new OleDbParameter("@qq2", OleDbType.VarChar,50),
					new OleDbParameter("@weblanguage", OleDbType.VarChar,50)};
			parameters[0].Value = model.webname;
			parameters[1].Value = model.webkey1;
			parameters[2].Value = model.webkey2;
			parameters[3].Value = model.webkey3;
			parameters[4].Value = model.webemail;
			parameters[5].Value = model.webadd;
			parameters[6].Value = model.webcode;
			parameters[7].Value = model.webtel;
			parameters[8].Value = model.webfax;
			parameters[9].Value = model.webcopyright;
			parameters[10].Value = model.webicp;
			parameters[11].Value = model.qq1;
			parameters[12].Value = model.qq2;
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
		public bool Update(Song.Model.webconfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update webconfig set ");
			strSql.Append("webname=@webname,");
			strSql.Append("webkey1=@webkey1,");
			strSql.Append("webkey2=@webkey2,");
			strSql.Append("webkey3=@webkey3,");
			strSql.Append("webemail=@webemail,");
			strSql.Append("webadd=@webadd,");
			strSql.Append("webcode=@webcode,");
			strSql.Append("webtel=@webtel,");
			strSql.Append("webfax=@webfax,");
			strSql.Append("webcopyright=@webcopyright,");
			strSql.Append("webicp=@webicp,");
			strSql.Append("qq1=@qq1,");
			strSql.Append("qq2=@qq2,");
			strSql.Append("weblanguage=@weblanguage");
            strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@webname", OleDbType.VarChar,50),
					new OleDbParameter("@webkey1", OleDbType.VarChar,0),
					new OleDbParameter("@webkey2", OleDbType.VarChar,0),
					new OleDbParameter("@webkey3", OleDbType.VarChar,0),
					new OleDbParameter("@webemail", OleDbType.VarChar,50),
					new OleDbParameter("@webadd", OleDbType.VarChar,0),
					new OleDbParameter("@webcode", OleDbType.VarChar,50),
					new OleDbParameter("@webtel", OleDbType.VarChar,50),
					new OleDbParameter("@webfax", OleDbType.VarChar,50),
					new OleDbParameter("@webcopyright", OleDbType.VarChar,0),
					new OleDbParameter("@webicp", OleDbType.VarChar,50),
					new OleDbParameter("@qq1", OleDbType.VarChar,50),
					new OleDbParameter("@qq2", OleDbType.VarChar,50),
					new OleDbParameter("@weblanguage", OleDbType.VarChar,50),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.webname;
			parameters[1].Value = model.webkey1;
			parameters[2].Value = model.webkey2;
			parameters[3].Value = model.webkey3;
			parameters[4].Value = model.webemail;
			parameters[5].Value = model.webadd;
			parameters[6].Value = model.webcode;
			parameters[7].Value = model.webtel;
			parameters[8].Value = model.webfax;
			parameters[9].Value = model.webcopyright;
			parameters[10].Value = model.webicp;
			parameters[11].Value = model.qq1;
			parameters[12].Value = model.qq2;
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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from webconfig ");
			strSql.Append(" where ");
			OleDbParameter[] parameters = {
			};

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
		public Song.Model.webconfig GetModel(String id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,webname,webkey1,webkey2,webkey3,webemail,webadd,webcode,webtel,webfax,webcopyright,webicp,qq1,qq2,weblanguage from webconfig ");
			strSql.Append(" where id=@id");
			OleDbParameter[] parameters = {
                 new OleDbParameter("@id", OleDbType.VarChar,5)     
			};
            parameters[0].Value = id;

			Song.Model.webconfig model=new Song.Model.webconfig();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["webname"]!=null && ds.Tables[0].Rows[0]["webname"].ToString()!="")
				{
					model.webname=ds.Tables[0].Rows[0]["webname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webkey1"]!=null && ds.Tables[0].Rows[0]["webkey1"].ToString()!="")
				{
					model.webkey1=ds.Tables[0].Rows[0]["webkey1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webkey2"]!=null && ds.Tables[0].Rows[0]["webkey2"].ToString()!="")
				{
					model.webkey2=ds.Tables[0].Rows[0]["webkey2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webkey3"]!=null && ds.Tables[0].Rows[0]["webkey3"].ToString()!="")
				{
					model.webkey3=ds.Tables[0].Rows[0]["webkey3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webemail"]!=null && ds.Tables[0].Rows[0]["webemail"].ToString()!="")
				{
					model.webemail=ds.Tables[0].Rows[0]["webemail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webadd"]!=null && ds.Tables[0].Rows[0]["webadd"].ToString()!="")
				{
					model.webadd=ds.Tables[0].Rows[0]["webadd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webcode"]!=null && ds.Tables[0].Rows[0]["webcode"].ToString()!="")
				{
					model.webcode=ds.Tables[0].Rows[0]["webcode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webtel"]!=null && ds.Tables[0].Rows[0]["webtel"].ToString()!="")
				{
					model.webtel=ds.Tables[0].Rows[0]["webtel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webfax"]!=null && ds.Tables[0].Rows[0]["webfax"].ToString()!="")
				{
					model.webfax=ds.Tables[0].Rows[0]["webfax"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webcopyright"]!=null && ds.Tables[0].Rows[0]["webcopyright"].ToString()!="")
				{
					model.webcopyright=ds.Tables[0].Rows[0]["webcopyright"].ToString();
				}
				if(ds.Tables[0].Rows[0]["webicp"]!=null && ds.Tables[0].Rows[0]["webicp"].ToString()!="")
				{
					model.webicp=ds.Tables[0].Rows[0]["webicp"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qq1"]!=null && ds.Tables[0].Rows[0]["qq1"].ToString()!="")
				{
					model.qq1=ds.Tables[0].Rows[0]["qq1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["qq2"]!=null && ds.Tables[0].Rows[0]["qq2"].ToString()!="")
				{
					model.qq2=ds.Tables[0].Rows[0]["qq2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["weblanguage"]!=null && ds.Tables[0].Rows[0]["weblanguage"].ToString()!="")
				{
					model.weblanguage=ds.Tables[0].Rows[0]["weblanguage"].ToString();
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
			strSql.Append("select id,webname,webkey1,webkey2,webkey3,webemail,webadd,webcode,webtel,webfax,webcopyright,webicp,qq1,qq2,weblanguage ");
			strSql.Append(" FROM webconfig ");
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
			strSql.Append("select count(1) FROM webconfig ");
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
			strSql.Append(")AS Row, T.*  from webconfig T ");
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
			parameters[0].Value = "webconfig";
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


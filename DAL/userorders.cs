using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
	/// <summary>
	/// 数据访问类:userorders
	/// </summary>
	public partial class userorders
	{
		public userorders()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Song.Model.userorders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into userorders(");
			strSql.Append("orderno,ordercontent,username,ordertime,consignee,email,address,tel,mobile,zipcode,best_time,weblanguage)");
			strSql.Append(" values (");
			strSql.Append("@orderno,@ordercontent,@username,@ordertime,@consignee,@email,@address,@tel,@mobile,@zipcode,@best_time,@weblanguage)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@orderno", OleDbType.Integer,4),
					new OleDbParameter("@ordercontent", OleDbType.VarChar,0),
					new OleDbParameter("@username", OleDbType.VarChar,50),
					new OleDbParameter("@ordertime", OleDbType.Date),
					new OleDbParameter("@consignee", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,0),
					new OleDbParameter("@tel", OleDbType.VarChar,50),
					new OleDbParameter("@mobile", OleDbType.VarChar,50),
					new OleDbParameter("@zipcode", OleDbType.VarChar,50),
					new OleDbParameter("@best_time", OleDbType.VarChar,50),
					new OleDbParameter("@weblanguage", OleDbType.VarChar,50)};
			parameters[0].Value = model.orderno;
			parameters[1].Value = model.ordercontent;
			parameters[2].Value = model.username;
			parameters[3].Value = model.ordertime;
			parameters[4].Value = model.consignee;
			parameters[5].Value = model.email;
			parameters[6].Value = model.address;
			parameters[7].Value = model.tel;
			parameters[8].Value = model.mobile;
			parameters[9].Value = model.zipcode;
			parameters[10].Value = model.best_time;
			parameters[11].Value = model.weblanguage;

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
		public bool Update(Song.Model.userorders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update userorders set ");
			strSql.Append("orderno=@orderno,");
			strSql.Append("ordercontent=@ordercontent,");
			strSql.Append("username=@username,");
			strSql.Append("ordertime=@ordertime,");
			strSql.Append("consignee=@consignee,");
			strSql.Append("email=@email,");
			strSql.Append("address=@address,");
			strSql.Append("tel=@tel,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("zipcode=@zipcode,");
			strSql.Append("best_time=@best_time,");
			strSql.Append("weblanguage=@weblanguage");
			strSql.Append(" where ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@orderno", OleDbType.Integer,4),
					new OleDbParameter("@ordercontent", OleDbType.VarChar,0),
					new OleDbParameter("@username", OleDbType.VarChar,50),
					new OleDbParameter("@ordertime", OleDbType.Date),
					new OleDbParameter("@consignee", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,0),
					new OleDbParameter("@tel", OleDbType.VarChar,50),
					new OleDbParameter("@mobile", OleDbType.VarChar,50),
					new OleDbParameter("@zipcode", OleDbType.VarChar,50),
					new OleDbParameter("@best_time", OleDbType.VarChar,50),
					new OleDbParameter("@weblanguage", OleDbType.VarChar,50),
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = model.orderno;
			parameters[1].Value = model.ordercontent;
			parameters[2].Value = model.username;
			parameters[3].Value = model.ordertime;
			parameters[4].Value = model.consignee;
			parameters[5].Value = model.email;
			parameters[6].Value = model.address;
			parameters[7].Value = model.tel;
			parameters[8].Value = model.mobile;
			parameters[9].Value = model.zipcode;
			parameters[10].Value = model.best_time;
			parameters[11].Value = model.weblanguage;
			parameters[12].Value = model.id;

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
			strSql.Append("delete from userorders ");
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
		public Song.Model.userorders GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,orderno,ordercontent,username,ordertime,consignee,email,address,tel,mobile,zipcode,best_time,weblanguage from userorders ");
			strSql.Append(" where ");
			OleDbParameter[] parameters = {
			};

			Song.Model.userorders model=new Song.Model.userorders();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["orderno"]!=null && ds.Tables[0].Rows[0]["orderno"].ToString()!="")
				{
					model.orderno=int.Parse(ds.Tables[0].Rows[0]["orderno"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ordercontent"]!=null && ds.Tables[0].Rows[0]["ordercontent"].ToString()!="")
				{
					model.ordercontent=ds.Tables[0].Rows[0]["ordercontent"].ToString();
				}
				if(ds.Tables[0].Rows[0]["username"]!=null && ds.Tables[0].Rows[0]["username"].ToString()!="")
				{
					model.username=ds.Tables[0].Rows[0]["username"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ordertime"]!=null && ds.Tables[0].Rows[0]["ordertime"].ToString()!="")
				{
					model.ordertime=DateTime.Parse(ds.Tables[0].Rows[0]["ordertime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["consignee"]!=null && ds.Tables[0].Rows[0]["consignee"].ToString()!="")
				{
					model.consignee=ds.Tables[0].Rows[0]["consignee"].ToString();
				}
				if(ds.Tables[0].Rows[0]["email"]!=null && ds.Tables[0].Rows[0]["email"].ToString()!="")
				{
					model.email=ds.Tables[0].Rows[0]["email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["address"]!=null && ds.Tables[0].Rows[0]["address"].ToString()!="")
				{
					model.address=ds.Tables[0].Rows[0]["address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tel"]!=null && ds.Tables[0].Rows[0]["tel"].ToString()!="")
				{
					model.tel=ds.Tables[0].Rows[0]["tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mobile"]!=null && ds.Tables[0].Rows[0]["mobile"].ToString()!="")
				{
					model.mobile=ds.Tables[0].Rows[0]["mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["zipcode"]!=null && ds.Tables[0].Rows[0]["zipcode"].ToString()!="")
				{
					model.zipcode=ds.Tables[0].Rows[0]["zipcode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["best_time"]!=null && ds.Tables[0].Rows[0]["best_time"].ToString()!="")
				{
					model.best_time=ds.Tables[0].Rows[0]["best_time"].ToString();
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
			strSql.Append("select id,orderno,ordercontent,username,ordertime,consignee,email,address,tel,mobile,zipcode,best_time,weblanguage ");
			strSql.Append(" FROM userorders ");
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
			strSql.Append("select count(1) FROM userorders ");
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
			strSql.Append(")AS Row, T.*  from userorders T ");
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
			parameters[0].Value = "userorders";
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


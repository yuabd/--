using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
    /// <summary>
    /// 数据访问类:companyInformation
    /// </summary>
    public partial class companyInformation
    {
        public companyInformation()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "companyInformation");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from companyInformation");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Song.Model.companyInformation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into companyInformation(");
            strSql.Append("pid,menuname,information,infocn,updateTime,weblanguage,pic)");
            strSql.Append(" values (");
            strSql.Append("@pid,@menuname,@information,@infocn,@updateTime,@weblanguage,@pic)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@menuname", OleDbType.VarChar,0),
					new OleDbParameter("@information", OleDbType.VarChar,0),
					new OleDbParameter("@infocn", OleDbType.VarChar,0),
					new OleDbParameter("@updateTime", OleDbType.Date),
					new OleDbParameter("@weblanguage", OleDbType.VarChar,0),
                    new OleDbParameter("@pic", OleDbType.VarChar,0)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.menuname;
            parameters[2].Value = model.information;
            parameters[3].Value = model.infocn;
            parameters[4].Value = model.updateTime;
            parameters[5].Value = model.weblanguage;
            parameters[6].Value = model.pic;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Song.Model.companyInformation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update companyInformation set ");
            strSql.Append("pid=@pid,");
            strSql.Append("menuname=@menuname,");
            strSql.Append("information=@information,");
            strSql.Append("infocn=@infocn,");
            strSql.Append("updateTime=@updateTime,");
            strSql.Append("weblanguage=@weblanguage,");
            strSql.Append("pic=@pic");
            strSql.Append(" where pid=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@menuname", OleDbType.VarChar,0),
					new OleDbParameter("@information", OleDbType.VarChar,0),
					new OleDbParameter("@infocn", OleDbType.VarChar,0),
					new OleDbParameter("@updateTime", OleDbType.Date),
					new OleDbParameter("@weblanguage", OleDbType.VarChar,0),
                    new OleDbParameter("@pic", OleDbType.VarChar,0),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.menuname;
            parameters[2].Value = model.information;
            parameters[3].Value = model.infocn;
            parameters[4].Value = model.updateTime;
            parameters[5].Value = model.weblanguage;
            parameters[6].Value = model.pic;
            parameters[7].Value = model.id;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from companyInformation ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from companyInformation ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public Song.Model.companyInformation GetModel(String id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pid,menuname,information,infocn,updateTime,weblanguage,pic from companyInformation ");
            strSql.Append(" where pid=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.VarChar,4)
			};
            parameters[0].Value = id;

            Song.Model.companyInformation model = new Song.Model.companyInformation();
            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(strSql.ToString(), parameters);
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    if (dr["id"] != null && dr["id"].ToString() != "")
                    {
                        model.id = int.Parse(dr["id"].ToString());
                    }
                    if (dr["pid"] != null && dr["pid"].ToString() != "")
                    {
                        model.pid = int.Parse(dr["pid"].ToString());
                    }
                    if (dr["menuname"] != null && dr["menuname"].ToString() != "")
                    {
                        model.menuname = dr["menuname"].ToString();
                    }
                    if (dr["information"] != null && dr["information"].ToString() != "")
                    {
                        model.information = dr["information"].ToString();
                    }
                    if (dr["infocn"] != null && dr["infocn"].ToString() != "")
                    {
                        model.infocn = dr["infocn"].ToString();
                    }
                    if (dr["updateTime"] != null && dr["updateTime"].ToString() != "")
                    {
                        model.updateTime = DateTime.Parse(dr["updateTime"].ToString());
                    }
                    if (dr["weblanguage"] != null && dr["weblanguage"].ToString() != "")
                    {
                        model.weblanguage = dr["weblanguage"].ToString();
                    }
                    if (dr["pic"] != null && dr["pic"].ToString() != "")
                    {
                        model.pic = dr["pic"].ToString();
                    }
                }
            }
            dr.Close();
            dr.Dispose();
            return model;

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pid,menuname,information,infocn,updateTime,weblanguage ");
            strSql.Append(" FROM companyInformation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM companyInformation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from companyInformation T ");
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
            parameters[0].Value = "companyInformation";
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


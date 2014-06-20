using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
    /// <summary>
    /// 数据访问类:manage
    /// </summary>
    public partial class manage
    {
        public manage()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "manage");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from manage");
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
        public bool Add(Song.Model.manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into manage(");
            strSql.Append("[adminname],[adminpassword],[adminlv],[regtime],[weblanguage],[strName],[strLoginIP],[dtmLoginTime],[intStatus],[intLoginNum],[intType])");
            strSql.Append(" values (");
            strSql.Append("@adminname,@adminpassword,@adminlv,@regtime,@weblanguage,@strName,@strLoginIP,@dtmLoginTime,@intStatus,@intLoginNum,@intType)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@adminname", OleDbType.VarChar,50),
					new OleDbParameter("@adminpassword", OleDbType.VarChar,50),
					new OleDbParameter("@adminlv", OleDbType.VarChar,0),
					new OleDbParameter("@regtime", OleDbType.Date),
					new OleDbParameter("@weblanguage", OleDbType.VarChar,50),
					new OleDbParameter("@strName", OleDbType.VarChar,50),
					new OleDbParameter("@strLoginIP", OleDbType.VarChar,50),
					new OleDbParameter("@dtmLoginTime", OleDbType.Date),
					new OleDbParameter("@intStatus", OleDbType.Integer,4),
					new OleDbParameter("@intLoginNum", OleDbType.Integer,4),
                    new OleDbParameter("@intType", OleDbType.Integer,4)};
            parameters[0].Value = model.adminname;
            parameters[1].Value = model.adminpassword;
            parameters[2].Value = model.adminlv;
            parameters[3].Value = model.regtime;
            parameters[4].Value = model.weblanguage;
            parameters[5].Value = model.strName;
            parameters[6].Value = model.strLoginIP;
            parameters[7].Value = model.dtmLoginTime;
            parameters[8].Value = model.intStatus;
            parameters[9].Value = model.intLoginNum;
            parameters[10].Value = model.intType;
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
        public bool Update(Song.Model.manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update manage set ");
            strSql.Append("adminname=@adminname,");
            strSql.Append("adminpassword=@adminpassword,");
            strSql.Append("adminlv=@adminlv,");
            strSql.Append("regtime=@regtime,");
            strSql.Append("weblanguage=@weblanguage,");
            strSql.Append("strName=@strName,");
            strSql.Append("strLoginIP=@strLoginIP,");
            strSql.Append("dtmLoginTime=@dtmLoginTime,");
            strSql.Append("intStatus=@intStatus,");
            strSql.Append("intLoginNum=@intLoginNum,");
            strSql.Append("intType=@intType");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@adminname", OleDbType.VarChar,50),
					new OleDbParameter("@adminpassword", OleDbType.VarChar,50),
					new OleDbParameter("@adminlv", OleDbType.VarChar,0),
					new OleDbParameter("@regtime", OleDbType.Date),
					new OleDbParameter("@weblanguage", OleDbType.VarChar,50),
					new OleDbParameter("@strName", OleDbType.VarChar,50),
					new OleDbParameter("@strLoginIP", OleDbType.VarChar,50),
					new OleDbParameter("@dtmLoginTime", OleDbType.Date),
					new OleDbParameter("@intStatus", OleDbType.Integer,4),
					new OleDbParameter("@intLoginNum", OleDbType.Integer,4),
                    new OleDbParameter("@intType", OleDbType.Integer,4),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.adminname;
            parameters[1].Value = model.adminpassword;
            parameters[2].Value = model.adminlv;
            parameters[3].Value = model.regtime;
            parameters[4].Value = model.weblanguage;
            parameters[5].Value = model.strName;
            parameters[6].Value = model.strLoginIP;
            parameters[7].Value = model.dtmLoginTime;
            parameters[8].Value = model.intStatus;
            parameters[9].Value = model.intLoginNum;
            parameters[10].Value = model.intType;
            parameters[11].Value = model.id;

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
        /// 条件按需更新,适用于批量
        /// </summary>
        /// <param name="updates">需要更新的字段[ f1=xxx,f2=xxx]</param>
        /// <param name="express">条件[参数顺序要与前一个参数一致ID=xxx]</param>
        /// <returns></returns>
        public bool Update(string updates, string express)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update manage set ");
            if (updates != "")
                strSql.Append(updates);
            if (express != "")
                strSql.Append(" where " + express);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from manage ");
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
            strSql.Append("delete from manage ");
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
        public Song.Model.manage GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [id],[adminname],[adminpassword],[adminlv],[regtime],[weblanguage],[strName],[strLoginIP],[dtmLoginTime],[intStatus],[intLoginNum],[intType] from manage ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

            Song.Model.manage model = new Song.Model.manage();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Song.Model.manage DataRowToModel(DataRow row)
        {
            Song.Model.manage model = new Song.Model.manage();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["adminname"] != null)
                {
                    model.adminname = row["adminname"].ToString();
                }
                if (row["adminpassword"] != null)
                {
                    model.adminpassword = row["adminpassword"].ToString();
                }
                if (row["adminlv"] != null)
                {
                    model.adminlv = row["adminlv"].ToString();
                }
                if (row["regtime"] != null && row["regtime"].ToString() != "")
                {
                    model.regtime = DateTime.Parse(row["regtime"].ToString());
                }
                if (row["weblanguage"] != null)
                {
                    model.weblanguage = row["weblanguage"].ToString();
                }
                if (row["strName"] != null)
                {
                    model.strName = row["strName"].ToString();
                }
                if (row["strLoginIP"] != null)
                {
                    model.strLoginIP = row["strLoginIP"].ToString();
                }
                if (row["dtmLoginTime"] != null && row["dtmLoginTime"].ToString() != "")
                {
                    model.dtmLoginTime = DateTime.Parse(row["dtmLoginTime"].ToString());
                }
                if (row["intStatus"] != null && row["intStatus"].ToString() != "")
                {
                    model.intStatus = int.Parse(row["intStatus"].ToString());
                }
                if (row["intLoginNum"] != null && row["intLoginNum"].ToString() != "")
                {
                    model.intLoginNum = int.Parse(row["intLoginNum"].ToString());
                } 
                if (row["intType"] != null && row["intType"].ToString() != "")
                {
                    model.intType = int.Parse(row["intType"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [id],[adminname],[adminpassword],[adminlv],[regtime],[weblanguage],[strName],[strLoginIP],[dtmLoginTime],[intStatus],[intLoginNum],[intType] ");
            strSql.Append(" FROM manage ");
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
            strSql.Append("select count(1) FROM manage ");
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
            strSql.Append(")AS Row, T.*  from manage T ");
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
            parameters[0].Value = "manage";
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


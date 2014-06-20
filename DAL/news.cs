using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
    /// <summary>
    /// 数据访问类:news
    /// </summary>
    public partial class news
    {
        public news()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "news");
        }

        public int GetMaxOrMinID(string MaxOrMin, string strWhere)
        {
            string strsql = "select " + MaxOrMin + "(id) from news ";
            if (strWhere != "")
                strsql += " where " + strWhere;
            object obj = DbHelperOleDb.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from news");
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
        public bool Add(Song.Model.news model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into news(");
            strSql.Append("pid,title,entitle,isShow,newstype,photo,content,encontent,timeinfo,orderid,hit,moreno,links,key1,key2,text1,text2,text3)");
            strSql.Append(" values (");
            strSql.Append("@pid,@title,@entitle,@isShow,@newstype,@photo,@content,@encontent,@timeinfo,@orderid,@hit,@moreno,@links,@key1,@key2,@text1,@text2,@text3)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@entitle", OleDbType.VarChar,50),
					new OleDbParameter("@isShow", OleDbType.Boolean,1),
					new OleDbParameter("@newstype", OleDbType.Integer,4),
					new OleDbParameter("@photo", OleDbType.VarChar,50),
					new OleDbParameter("@content", OleDbType.VarChar,0),
					new OleDbParameter("@encontent", OleDbType.VarChar,0),
					new OleDbParameter("@timeinfo", OleDbType.Date),
					new OleDbParameter("@orderid", OleDbType.Integer,4),
					new OleDbParameter("@hit", OleDbType.Integer,4),
					new OleDbParameter("@moreno", OleDbType.VarChar,50),
					new OleDbParameter("@links", OleDbType.VarChar,0),
					new OleDbParameter("@key1", OleDbType.VarChar,0),
					new OleDbParameter("@key2", OleDbType.VarChar,0),
					new OleDbParameter("@text1", OleDbType.VarChar,50),
					new OleDbParameter("@text2", OleDbType.VarChar,50),
					new OleDbParameter("@text3", OleDbType.VarChar,0)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.entitle;
            parameters[3].Value = model.isShow;
            parameters[4].Value = model.newstype;
            parameters[5].Value = model.photo;
            parameters[6].Value = model.content;
            parameters[7].Value = model.encontent;
            parameters[8].Value = model.timeinfo;
            parameters[9].Value = model.orderid;
            parameters[10].Value = model.hit;
            parameters[11].Value = model.moreno;
            parameters[12].Value = model.links;
            parameters[13].Value = model.key1;
            parameters[14].Value = model.key2;
            parameters[15].Value = model.text1;
            parameters[16].Value = model.text2;
            parameters[17].Value = model.text3;

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
        public bool Update(Song.Model.news model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update news set ");
            strSql.Append("pid=@pid,");
            strSql.Append("title=@title,");
            strSql.Append("entitle=@entitle,");
            strSql.Append("isShow=@isShow,");
            strSql.Append("newstype=@newstype,");
            strSql.Append("photo=@photo,");
            strSql.Append("content=@content,");
            strSql.Append("encontent=@encontent,");
            strSql.Append("timeinfo=@timeinfo,");
            strSql.Append("orderid=@orderid,");
            strSql.Append("hit=@hit,");
            strSql.Append("moreno=@moreno,");
            strSql.Append("links=@links,");
            strSql.Append("key1=@key1,");
            strSql.Append("key2=@key2,");
            strSql.Append("text1=@text1,");
            strSql.Append("text2=@text2,");
            strSql.Append("text3=@text3");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@entitle", OleDbType.VarChar,50),
					new OleDbParameter("@isShow", OleDbType.Boolean,1),
					new OleDbParameter("@newstype", OleDbType.Integer,4),
					new OleDbParameter("@photo", OleDbType.VarChar,50),
					new OleDbParameter("@content", OleDbType.VarChar,0),
					new OleDbParameter("@encontent", OleDbType.VarChar,0),
					new OleDbParameter("@timeinfo", OleDbType.Date),
					new OleDbParameter("@orderid", OleDbType.Integer,4),
					new OleDbParameter("@hit", OleDbType.Integer,4),
					new OleDbParameter("@moreno", OleDbType.VarChar,50),
					new OleDbParameter("@links", OleDbType.VarChar,0),
					new OleDbParameter("@key1", OleDbType.VarChar,0),
					new OleDbParameter("@key2", OleDbType.VarChar,0),
					new OleDbParameter("@text1", OleDbType.VarChar,50),
					new OleDbParameter("@text2", OleDbType.VarChar,50),
					new OleDbParameter("@text3", OleDbType.VarChar,0),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.entitle;
            parameters[3].Value = model.isShow;
            parameters[4].Value = model.newstype;
            parameters[5].Value = model.photo;
            parameters[6].Value = model.content;
            parameters[7].Value = model.encontent;
            parameters[8].Value = model.timeinfo;
            parameters[9].Value = model.orderid;
            parameters[10].Value = model.hit;
            parameters[11].Value = model.moreno;
            parameters[12].Value = model.links;
            parameters[13].Value = model.key1;
            parameters[14].Value = model.key2;
            parameters[15].Value = model.text1;
            parameters[16].Value = model.text2;
            parameters[17].Value = model.text3;
            parameters[18].Value = model.id;

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
        /// 更新数据
        /// </summary>
        public bool Update(string where, string wheres)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update news set ");
            if (where != "")
                strSql.Append(where);
            if (wheres != "")
                strSql.Append(" where " + wheres);

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
            strSql.Append("delete from news ");
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
            strSql.Append("delete from news ");
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
        public Song.Model.news GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pid,title,entitle,isShow,newstype,photo,content,encontent,timeinfo,orderid,hit,moreno,links,key1,key2,text1,text2,text3 from news ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

            Song.Model.news model = new Song.Model.news();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pid"] != null && ds.Tables[0].Rows[0]["pid"].ToString() != "")
                {
                    model.pid = int.Parse(ds.Tables[0].Rows[0]["pid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["entitle"] != null && ds.Tables[0].Rows[0]["entitle"].ToString() != "")
                {
                    model.entitle = ds.Tables[0].Rows[0]["entitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isShow"] != null && ds.Tables[0].Rows[0]["isShow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isShow"].ToString() == "1") || (ds.Tables[0].Rows[0]["isShow"].ToString().ToLower() == "true"))
                    {
                        model.isShow = true;
                    }
                    else
                    {
                        model.isShow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["newstype"] != null && ds.Tables[0].Rows[0]["newstype"].ToString() != "")
                {
                    model.newstype = int.Parse(ds.Tables[0].Rows[0]["newstype"].ToString());
                }
                if (ds.Tables[0].Rows[0]["photo"] != null && ds.Tables[0].Rows[0]["photo"].ToString() != "")
                {
                    model.photo = ds.Tables[0].Rows[0]["photo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["encontent"] != null && ds.Tables[0].Rows[0]["encontent"].ToString() != "")
                {
                    model.encontent = ds.Tables[0].Rows[0]["encontent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["timeinfo"] != null && ds.Tables[0].Rows[0]["timeinfo"].ToString() != "")
                {
                    model.timeinfo = DateTime.Parse(ds.Tables[0].Rows[0]["timeinfo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderid"] != null && ds.Tables[0].Rows[0]["orderid"].ToString() != "")
                {
                    model.orderid = int.Parse(ds.Tables[0].Rows[0]["orderid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hit"] != null && ds.Tables[0].Rows[0]["hit"].ToString() != "")
                {
                    model.hit = int.Parse(ds.Tables[0].Rows[0]["hit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["moreno"] != null && ds.Tables[0].Rows[0]["moreno"].ToString() != "")
                {
                    model.moreno = ds.Tables[0].Rows[0]["moreno"].ToString();
                }
                if (ds.Tables[0].Rows[0]["links"] != null && ds.Tables[0].Rows[0]["links"].ToString() != "")
                {
                    model.links = ds.Tables[0].Rows[0]["links"].ToString();
                }
                if (ds.Tables[0].Rows[0]["key1"] != null && ds.Tables[0].Rows[0]["key1"].ToString() != "")
                {
                    model.key1 = ds.Tables[0].Rows[0]["key1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["key2"] != null && ds.Tables[0].Rows[0]["key2"].ToString() != "")
                {
                    model.key2 = ds.Tables[0].Rows[0]["key2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["text1"] != null && ds.Tables[0].Rows[0]["text1"].ToString() != "")
                {
                    model.text1 = ds.Tables[0].Rows[0]["text1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["text2"] != null && ds.Tables[0].Rows[0]["text2"].ToString() != "")
                {
                    model.text2 = ds.Tables[0].Rows[0]["text2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["text3"] != null && ds.Tables[0].Rows[0]["text3"].ToString() != "")
                {
                    model.text3 = ds.Tables[0].Rows[0]["text3"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Song.Model.news GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pid,title,entitle,isShow,newstype,photo,content,encontent,timeinfo,orderid,hit,moreno,links,key1,key2,text1,text2,text3 from news ");
            if (where != "")
                strSql.Append(" where " + where);

            Song.Model.news model = new Song.Model.news();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pid"] != null && ds.Tables[0].Rows[0]["pid"].ToString() != "")
                {
                    model.pid = int.Parse(ds.Tables[0].Rows[0]["pid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["entitle"] != null && ds.Tables[0].Rows[0]["entitle"].ToString() != "")
                {
                    model.entitle = ds.Tables[0].Rows[0]["entitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isShow"] != null && ds.Tables[0].Rows[0]["isShow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isShow"].ToString() == "1") || (ds.Tables[0].Rows[0]["isShow"].ToString().ToLower() == "true"))
                    {
                        model.isShow = true;
                    }
                    else
                    {
                        model.isShow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["newstype"] != null && ds.Tables[0].Rows[0]["newstype"].ToString() != "")
                {
                    model.newstype = int.Parse(ds.Tables[0].Rows[0]["newstype"].ToString());
                }
                if (ds.Tables[0].Rows[0]["photo"] != null && ds.Tables[0].Rows[0]["photo"].ToString() != "")
                {
                    model.photo = ds.Tables[0].Rows[0]["photo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["encontent"] != null && ds.Tables[0].Rows[0]["encontent"].ToString() != "")
                {
                    model.encontent = ds.Tables[0].Rows[0]["encontent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["timeinfo"] != null && ds.Tables[0].Rows[0]["timeinfo"].ToString() != "")
                {
                    model.timeinfo = DateTime.Parse(ds.Tables[0].Rows[0]["timeinfo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderid"] != null && ds.Tables[0].Rows[0]["orderid"].ToString() != "")
                {
                    model.orderid = int.Parse(ds.Tables[0].Rows[0]["orderid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hit"] != null && ds.Tables[0].Rows[0]["hit"].ToString() != "")
                {
                    model.hit = int.Parse(ds.Tables[0].Rows[0]["hit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["moreno"] != null && ds.Tables[0].Rows[0]["moreno"].ToString() != "")
                {
                    model.moreno = ds.Tables[0].Rows[0]["moreno"].ToString();
                }
                if (ds.Tables[0].Rows[0]["links"] != null && ds.Tables[0].Rows[0]["links"].ToString() != "")
                {
                    model.links = ds.Tables[0].Rows[0]["links"].ToString();
                }
                if (ds.Tables[0].Rows[0]["key1"] != null && ds.Tables[0].Rows[0]["key1"].ToString() != "")
                {
                    model.key1 = ds.Tables[0].Rows[0]["key1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["key2"] != null && ds.Tables[0].Rows[0]["key2"].ToString() != "")
                {
                    model.key2 = ds.Tables[0].Rows[0]["key2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["text1"] != null && ds.Tables[0].Rows[0]["text1"].ToString() != "")
                {
                    model.text1 = ds.Tables[0].Rows[0]["text1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["text2"] != null && ds.Tables[0].Rows[0]["text2"].ToString() != "")
                {
                    model.text2 = ds.Tables[0].Rows[0]["text2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["text3"] != null && ds.Tables[0].Rows[0]["text3"].ToString() != "")
                {
                    model.text3 = ds.Tables[0].Rows[0]["text3"].ToString();
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
        public DataSet GetList(string strWhere, int intNum = 0)
        {
            StringBuilder strSql = new StringBuilder();
            if (intNum > 0)
                strSql.Append("select top " + intNum + " id,pid,title,entitle,isShow,newstype,photo,content,encontent,timeinfo,orderid,hit,moreno,links,key1,key2,text1,text2,text3 ");
            else
                strSql.Append("select id,pid,title,entitle,isShow,newstype,photo,content,encontent,timeinfo,orderid,hit,moreno,links,key1,key2,text1,text2,text3 ");
            strSql.Append(" FROM news ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        public OleDbDataReader GetReader(int num, String sqlWhere)
        {
            String sql = "";
            if (num > 0)
                sql = " select top " + num.ToString() + " id,pid,title,entitle,isShow,newstype,photo,content,encontent,timeinfo,orderid,hit,moreno,links,key1,key2,text1,text2,text3 from news where 1=1 " + sqlWhere;
            else
                sql = " select id,pid,title,entitle,isShow,newstype,photo,content,encontent,timeinfo,orderid,hit,moreno,links,key1,key2,text1,text2,text3 from news where 1=1 " + sqlWhere;
            return DbHelperOleDb.ExecuteReader(sql);
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM news ");
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
            strSql.Append(")AS Row, T.*  from news T ");
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
            parameters[0].Value = "news";
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


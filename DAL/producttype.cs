using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
    /// <summary>
    /// 数据访问类:producttype
    /// </summary>
    public partial class producttype
    {
        public producttype()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "producttype") + 1;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from producttype");
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
        public bool Add(Song.Model.producttype model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into producttype(");
            strSql.Append("pid,title,entitle,fid,content,encontent,photo,orderid,text1,text2,text3,text4)");
            strSql.Append(" values (");
            strSql.Append("@pid,@title,@entitle,@fid,@content,@encontent,@photo,@orderid,@text1,@text2,@text3,@text4)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@entitle", OleDbType.VarChar,50),
					new OleDbParameter("@fid", OleDbType.Integer,4),
					new OleDbParameter("@content", OleDbType.VarChar,0),
					new OleDbParameter("@encontent", OleDbType.VarChar,50),
					new OleDbParameter("@photo", OleDbType.VarChar,0),
					new OleDbParameter("@orderid", OleDbType.Integer,4),
					new OleDbParameter("@text1", OleDbType.VarChar,50),
					new OleDbParameter("@text2", OleDbType.VarChar,50),
					new OleDbParameter("@text3", OleDbType.VarChar,50),
					new OleDbParameter("@text4", OleDbType.VarChar,0)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.entitle;
            parameters[3].Value = model.fid;
            parameters[4].Value = model.content;
            parameters[5].Value = model.encontent;
            parameters[6].Value = model.photo;
            parameters[7].Value = model.orderid;
            parameters[8].Value = model.text1;
            parameters[9].Value = model.text2;
            parameters[10].Value = model.text3;
            parameters[11].Value = model.text4;

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
        public bool Update(Song.Model.producttype model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update producttype set ");
            strSql.Append("pid=@pid,");
            strSql.Append("title=@title,");
            strSql.Append("entitle=@entitle,");
            strSql.Append("fid=@fid,");
            strSql.Append("content=@content,");
            strSql.Append("encontent=@encontent,");
            strSql.Append("photo=@photo,");
            strSql.Append("orderid=@orderid,");
            strSql.Append("text1=@text1,");
            strSql.Append("text2=@text2,");
            strSql.Append("text3=@text3,");
            strSql.Append("text4=@text4");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@entitle", OleDbType.VarChar,50),
					new OleDbParameter("@fid", OleDbType.Integer,4),
					new OleDbParameter("@content", OleDbType.VarChar,0),
					new OleDbParameter("@encontent", OleDbType.VarChar,50),
					new OleDbParameter("@photo", OleDbType.VarChar,0),
					new OleDbParameter("@orderid", OleDbType.Integer,4),
					new OleDbParameter("@text1", OleDbType.VarChar,50),
					new OleDbParameter("@text2", OleDbType.VarChar,50),
					new OleDbParameter("@text3", OleDbType.VarChar,50),
					new OleDbParameter("@text4", OleDbType.VarChar,0),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.entitle;
            parameters[3].Value = model.fid;
            parameters[4].Value = model.content;
            parameters[5].Value = model.encontent;
            parameters[6].Value = model.photo;
            parameters[7].Value = model.orderid;
            parameters[8].Value = model.text1;
            parameters[9].Value = model.text2;
            parameters[10].Value = model.text3;
            parameters[11].Value = model.text4;
            parameters[12].Value = model.id;

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
            strSql.Append("delete from producttype ");
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
            strSql.Append("delete from producttype ");
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
        public Song.Model.producttype GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pid,title,entitle,fid,content,encontent,photo,orderid,text1,text2,text3,text4 from producttype ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

            Song.Model.producttype model = new Song.Model.producttype();
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
                if (ds.Tables[0].Rows[0]["fid"] != null && ds.Tables[0].Rows[0]["fid"].ToString() != "")
                {
                    model.fid = int.Parse(ds.Tables[0].Rows[0]["fid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["encontent"] != null && ds.Tables[0].Rows[0]["encontent"].ToString() != "")
                {
                    model.encontent = ds.Tables[0].Rows[0]["encontent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["photo"] != null && ds.Tables[0].Rows[0]["photo"].ToString() != "")
                {
                    model.photo = ds.Tables[0].Rows[0]["photo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["orderid"] != null && ds.Tables[0].Rows[0]["orderid"].ToString() != "")
                {
                    model.orderid = int.Parse(ds.Tables[0].Rows[0]["orderid"].ToString());
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
                if (ds.Tables[0].Rows[0]["text4"] != null && ds.Tables[0].Rows[0]["text4"].ToString() != "")
                {
                    model.text4 = ds.Tables[0].Rows[0]["text4"].ToString();
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
                strSql.Append("select top " + intNum + " id,pid,title,entitle,fid,content,encontent,photo,orderid,text1,text2,text3,text4 ");
            else
                strSql.Append("select id,pid,title,entitle,fid,content,encontent,photo,orderid,text1,text2,text3,text4 ");
            strSql.Append(" FROM producttype ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1  " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        public OleDbDataReader GetReader(String sqlWhere)
        {
            String sql = " select id,title,photo,fid from producttype where 1=1 " + sqlWhere;
            return DbHelperOleDb.ExecuteReader(sql);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM producttype ");
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
            strSql.Append(")AS Row, T.*  from producttype T ");
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
            parameters[0].Value = "producttype";
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


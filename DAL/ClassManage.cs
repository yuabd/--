using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
using Song.Model;
using Maticsoft.Common;
namespace Song.DAL
{
    /// <summary>
    /// 数据访问类:ClassManage
    /// </summary>
    public partial class ClassManage
    {
        public ClassManage()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Song.Model.ClassManage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ClassManage(");
            strSql.Append("ClassName,EnName,ClassUrl,keywords,description,ClassInfo,pic,PageId,Fid,orderid,funid,urlparm,isSelf,isShow,LinkUrl)");
            strSql.Append(" values (");
            strSql.Append("@ClassName,@EnName,@ClassUrl,@keywords,@description,@ClassInfo,@pic,@PageId,@Fid,@orderid,@funid,@urlparm,@isSelf,@isShow,@LinkUrl)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ClassName", OleDbType.VarChar,0),
                    new OleDbParameter("@EnName", OleDbType.VarChar,0),
					new OleDbParameter("@ClassUrl", OleDbType.VarChar,0),
					new OleDbParameter("@keywords", OleDbType.VarChar,0),
					new OleDbParameter("@description", OleDbType.VarChar,0),
					new OleDbParameter("@ClassInfo", OleDbType.VarChar,0),
					new OleDbParameter("@pic", OleDbType.VarChar,20),
					new OleDbParameter("@PageId", OleDbType.Integer,4),
					new OleDbParameter("@Fid", OleDbType.Integer,4),
					new OleDbParameter("@orderid", OleDbType.Integer,4),
					new OleDbParameter("@funid", OleDbType.Integer,4),
					new OleDbParameter("@urlparm", OleDbType.VarChar,50),
					new OleDbParameter("@isSelf", OleDbType.Boolean,1),
					new OleDbParameter("@isShow", OleDbType.Boolean,1),new OleDbParameter("@LinkUrl", OleDbType.VarChar,0)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.EnName;
            parameters[2].Value = model.ClassUrl;
            parameters[3].Value = model.keywords;
            parameters[4].Value = model.description;
            parameters[5].Value = model.ClassInfo;
            parameters[6].Value = model.pic;
            parameters[7].Value = model.PageId;
            parameters[8].Value = model.Fid;
            parameters[9].Value = model.orderid;
            parameters[10].Value = model.funid;
            parameters[11].Value = model.urlparm;
            parameters[12].Value = model.isSelf;
            parameters[13].Value = model.isShow;
            parameters[14].Value = model.LinkUrl;

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
        public bool Update(Song.Model.ClassManage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ClassManage set ");
            strSql.Append("ClassName=@ClassName,");
            strSql.Append("EnName=@EnName,");
            strSql.Append("ClassUrl=@ClassUrl,");
            strSql.Append("keywords=@keywords,");
            strSql.Append("description=@description,");
            strSql.Append("ClassInfo=@ClassInfo,");
            strSql.Append("pic=@pic,");
            strSql.Append("PageId=@PageId,");
            strSql.Append("Fid=@Fid,");
            strSql.Append("orderid=@orderid,");
            strSql.Append("funid=@funid,");
            strSql.Append("urlparm=@urlparm,");
            strSql.Append("isSelf=@isSelf,");
            strSql.Append("isShow=@isShow,");
            strSql.Append("LinkUrl=@LinkUrl");
            strSql.Append(" where ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ClassName", OleDbType.VarChar,0),
                    new OleDbParameter("@EnName", OleDbType.VarChar,0),
					new OleDbParameter("@ClassUrl", OleDbType.VarChar,0),
					new OleDbParameter("@keywords", OleDbType.VarChar,0),
					new OleDbParameter("@description", OleDbType.VarChar,0),
					new OleDbParameter("@ClassInfo", OleDbType.VarChar,0),
					new OleDbParameter("@pic", OleDbType.VarChar,20),
					new OleDbParameter("@PageId", OleDbType.Integer,4),
					new OleDbParameter("@Fid", OleDbType.Integer,4),
					new OleDbParameter("@orderid", OleDbType.Integer,4),
					new OleDbParameter("@funid", OleDbType.Integer,4),
					new OleDbParameter("@urlparm", OleDbType.VarChar,50),
					new OleDbParameter("@isSelf", OleDbType.Boolean,1),
					new OleDbParameter("@isShow", OleDbType.Boolean,1),
                    new OleDbParameter("@LinkUrl", OleDbType.VarChar,0),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.EnName;
            parameters[2].Value = model.ClassUrl;
            parameters[3].Value = model.keywords;
            parameters[4].Value = model.description;
            parameters[5].Value = model.ClassInfo;
            parameters[6].Value = model.pic;
            parameters[7].Value = model.PageId;
            parameters[8].Value = model.Fid;
            parameters[9].Value = model.orderid;
            parameters[10].Value = model.funid;
            parameters[11].Value = model.urlparm;
            parameters[12].Value = model.isSelf;
            parameters[13].Value = model.isShow;
            parameters[14].Value = model.LinkUrl;
            parameters[15].Value = model.id;

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
        public bool Delete(String id)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ClassManage ");
            strSql.Append(" where id=@id or Fid=@Fid");
            OleDbParameter[] parameters = {
                new OleDbParameter("@id",OleDbType.VarChar,5),
                new OleDbParameter("@Fid",OleDbType.VarChar,5)
			};
            parameters[0].Value = id;
            parameters[1].Value = id;

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
        /// 得到一个对象实体
        /// </summary>
        public Song.Model.ClassManage GetModel(int? id = 0)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ClassName,EnName,ClassUrl,keywords,description,ClassInfo,pic,PageId,Fid,orderid,funid,urlparm,isSelf,isShow,LinkUrl from ClassManage ");
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            if (id.Uint() != 0)
            {
                strSql.Append(" where id=@id");
                parameters.Add(new OleDbParameter("@id", OleDbType.Integer, 4));
                parameters[0].Value = id;
                //parameters[]
            }
            
            Song.Model.ClassManage model = new Song.Model.ClassManage();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters.ToArray());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClassName"] != null && ds.Tables[0].Rows[0]["ClassName"].ToString() != "")
                {
                    model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EnName"] != null && ds.Tables[0].Rows[0]["EnName"].ToString() != "")
                {
                    model.EnName = ds.Tables[0].Rows[0]["EnName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClassUrl"] != null && ds.Tables[0].Rows[0]["ClassUrl"].ToString() != "")
                {
                    model.ClassUrl = ds.Tables[0].Rows[0]["ClassUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["keywords"] != null && ds.Tables[0].Rows[0]["keywords"].ToString() != "")
                {
                    model.keywords = ds.Tables[0].Rows[0]["keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["description"] != null && ds.Tables[0].Rows[0]["description"].ToString() != "")
                {
                    model.description = ds.Tables[0].Rows[0]["description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClassInfo"] != null && ds.Tables[0].Rows[0]["ClassInfo"].ToString() != "")
                {
                    model.ClassInfo = ds.Tables[0].Rows[0]["ClassInfo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pic"] != null && ds.Tables[0].Rows[0]["pic"].ToString() != "")
                {
                    model.pic = ds.Tables[0].Rows[0]["pic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PageId"] != null && ds.Tables[0].Rows[0]["PageId"].ToString() != "")
                {
                    model.PageId = int.Parse(ds.Tables[0].Rows[0]["PageId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Fid"] != null && ds.Tables[0].Rows[0]["Fid"].ToString() != "")
                {
                    model.Fid = int.Parse(ds.Tables[0].Rows[0]["Fid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderid"] != null && ds.Tables[0].Rows[0]["orderid"].ToString() != "")
                {
                    model.orderid = int.Parse(ds.Tables[0].Rows[0]["orderid"].ToString());
                } if (ds.Tables[0].Rows[0]["keywords"] != null && ds.Tables[0].Rows[0]["keywords"].ToString() != "")
                {
                    model.keywords = ds.Tables[0].Rows[0]["keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["funid"] != null && ds.Tables[0].Rows[0]["funid"].ToString() != "")
                {
                    model.funid = int.Parse(ds.Tables[0].Rows[0]["funid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["urlparm"] != null && ds.Tables[0].Rows[0]["urlparm"].ToString() != "")
                {
                    model.urlparm = ds.Tables[0].Rows[0]["urlparm"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isSelf"] != null && ds.Tables[0].Rows[0]["isSelf"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isSelf"].ToString() == "1") || (ds.Tables[0].Rows[0]["isSelf"].ToString().ToLower() == "true"))
                    {
                        model.isSelf = true;
                    }
                    else
                    {
                        model.isSelf = false;
                    }
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
                if (ds.Tables[0].Rows[0]["LinkUrl"] != null && ds.Tables[0].Rows[0]["LinkUrl"].ToString() != "")
                {
                    model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ClassName,EnName,ClassUrl,keywords,description,ClassInfo,pic,PageId,Fid,orderid,funid,urlparm,isSelf,isShow,LinkUrl ");
            strSql.Append(" FROM ClassManage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1  " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public OleDbDataReader GetReader(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ClassName,PageId,LinkUrl ");
            strSql.Append(" FROM ClassManage where isShow=true  " + strWhere);
            return DbHelperOleDb.ExecuteReader(strSql.ToString());
        }

        /// <summary>
        /// 获取下级ID
        /// </summary>
        /// <returns></returns>
        public string GetNodeID(int Fid)
        {
            String sql = "select id from ClassManage where Fid =" + Fid;
            DataTable dt = DbHelperOleDb.Query(sql).Tables[0];
            String idList = "0";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                idList = idList + "," + dt.Rows[i]["id"];
            }
            return idList;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ClassManage ");
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
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from ClassManage T ");
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
            parameters[0].Value = "ClassManage";
            parameters[1].Value = "";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/


        /// <summary>
        /// 获取DataRead数据
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public List<Song.Model.ClassManage> GetReaderList(String sqlWhere)
        {
            List<Song.Model.ClassManage> modelList = new List<Model.ClassManage>();
            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select * from ClassManage where  isShow=True " + sqlWhere + " order by orderid asc,id asc");

            Song.Model.ClassManage model;
            while (dr.Read())
            {
                model = new Song.Model.ClassManage();
                if (dr["id"] != null && dr["id"].ToString() != "")
                {
                    model.id = int.Parse(dr["id"].ToString());
                }
                if (dr["ClassName"] != null && dr["ClassName"].ToString() != "")
                {
                    model.ClassName = dr["ClassName"].ToString();
                }
                if (dr["EnName"] != null && dr["EnName"].ToString() != "")
                {
                    model.EnName = dr["EnName"].ToString();
                }
                if (dr["ClassUrl"] != null && dr["ClassUrl"].ToString() != "")
                {
                    model.ClassUrl = dr["ClassUrl"].ToString();
                }
                if (dr["keywords"] != null && dr["keywords"].ToString() != "")
                {
                    model.keywords = dr["keywords"].ToString();
                }
                if (dr["description"] != null && dr["description"].ToString() != "")
                {
                    model.description = dr["description"].ToString();
                }
                if (dr["ClassInfo"] != null && dr["ClassInfo"].ToString() != "")
                {
                    model.ClassInfo = dr["ClassInfo"].ToString();
                }
                if (dr["pic"] != null && dr["pic"].ToString() != "")
                {
                    model.pic = dr["pic"].ToString();
                }
                if (dr["PageId"] != null && dr["PageId"].ToString() != "")
                {
                    model.PageId = int.Parse(dr["PageId"].ToString());
                }
                if (dr["Fid"] != null && dr["Fid"].ToString() != "")
                {
                    model.Fid = int.Parse(dr["Fid"].ToString());
                }
                if (dr["orderid"] != null && dr["orderid"].ToString() != "")
                {
                    model.orderid = int.Parse(dr["orderid"].ToString());
                }
                if (dr["funid"] != null && dr["funid"].ToString() != "")
                {
                    model.funid = int.Parse(dr["funid"].ToString());
                }
                if (dr["urlparm"] != null && dr["urlparm"].ToString() != "")
                {
                    model.urlparm = dr["urlparm"].ToString();
                }
                if (dr["isSelf"] != null && dr["isSelf"].ToString() != "")
                {
                    if ((dr["isSelf"].ToString() == "1") || (dr["isSelf"].ToString().ToLower() == "true"))
                    {
                        model.isSelf = true;
                    }
                    else
                    {
                        model.isSelf = false;
                    }
                }
                if (dr["isShow"] != null && dr["isShow"].ToString() != "")
                {
                    if ((dr["isShow"].ToString() == "1") || (dr["isShow"].ToString().ToLower() == "true"))
                    {
                        model.isShow = true;
                    }
                    else
                    {
                        model.isShow = false;
                    }
                }
                if (dr["LinkUrl"] != null && dr["LinkUrl"].ToString() != "")
                {
                    model.LinkUrl = dr["LinkUrl"].ToString();
                }
            }
            dr.Close();
            dr.Dispose();
            return modelList;
        }

        #endregion  Method
    }
}


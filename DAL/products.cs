using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
    /// <summary>
    /// 数据访问类:products
    /// </summary>
    public partial class products
    {
        public products()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "products");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from products");
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
        public bool Add(Song.Model.products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into products(");
            strSql.Append("pid,title,entitle,prono,brand,protype,type2,type3,type4,photo,price,saleprice,isshow,isnew,ishot,isrecom,timeinfo,features,content,encontent,key1,key2,text1,text2,text3,text4,orderid,hit,moreno)");
            strSql.Append(" values (");
            strSql.Append("@pid,@title,@entitle,@prono,@brand,@protype,@type2,@type3,@type4,@photo,@price,@saleprice,@isshow,@isnew,@ishot,@isrecom,@timeinfo,@features,@content,@encontent,@key1,@key2,@text1,@text2,@text3,@text4,@orderid,@hit,@moreno)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@entitle", OleDbType.VarChar,50),
					new OleDbParameter("@prono", OleDbType.VarChar,50),
					new OleDbParameter("@brand", OleDbType.VarChar,50),
					new OleDbParameter("@protype", OleDbType.Integer,4),
					new OleDbParameter("@type2", OleDbType.VarChar,50),
					new OleDbParameter("@type3", OleDbType.VarChar,50),
					new OleDbParameter("@type4", OleDbType.VarChar,50),
					new OleDbParameter("@photo", OleDbType.VarChar,0),
					new OleDbParameter("@price", OleDbType.VarChar,50),
					new OleDbParameter("@saleprice", OleDbType.VarChar,50),
					new OleDbParameter("@isshow", OleDbType.Boolean,1),
					new OleDbParameter("@isnew", OleDbType.Boolean,1),
					new OleDbParameter("@ishot", OleDbType.Boolean,1),
					new OleDbParameter("@isrecom", OleDbType.Boolean,1),
					new OleDbParameter("@timeinfo", OleDbType.Date),
					new OleDbParameter("@features", OleDbType.VarChar,0),
					new OleDbParameter("@content", OleDbType.VarChar,0),
					new OleDbParameter("@encontent", OleDbType.VarChar,0),
					new OleDbParameter("@key1", OleDbType.VarChar,0),
					new OleDbParameter("@key2", OleDbType.VarChar,0),
					new OleDbParameter("@text1", OleDbType.VarChar,50),
					new OleDbParameter("@text2", OleDbType.VarChar,50),
					new OleDbParameter("@text3", OleDbType.VarChar,50),
					new OleDbParameter("@text4", OleDbType.VarChar,0),
					new OleDbParameter("@orderid", OleDbType.Integer,4),
					new OleDbParameter("@hit", OleDbType.Integer,4),
					new OleDbParameter("@moreno", OleDbType.VarChar,50)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.entitle;
            parameters[3].Value = model.prono;
            parameters[4].Value = model.brand;
            parameters[5].Value = model.protype;
            parameters[6].Value = model.type2;
            parameters[7].Value = model.type3;
            parameters[8].Value = model.type4;
            parameters[9].Value = model.photo;
            parameters[10].Value = model.price;
            parameters[11].Value = model.saleprice;
            parameters[12].Value = model.isshow;
            parameters[13].Value = model.isnew;
            parameters[14].Value = model.ishot;
            parameters[15].Value = model.isrecom;
            parameters[16].Value = model.timeinfo;
            parameters[17].Value = model.features;
            parameters[18].Value = model.content;
            parameters[19].Value = model.encontent;
            parameters[20].Value = model.key1;
            parameters[21].Value = model.key2;
            parameters[22].Value = model.text1;
            parameters[23].Value = model.text2;
            parameters[24].Value = model.text3;
            parameters[25].Value = model.text4;
            parameters[26].Value = model.orderid;
            parameters[27].Value = model.hit;
            parameters[28].Value = model.moreno;

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
        public bool Update(Song.Model.products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update products set ");
            strSql.Append("pid=@pid,");
            strSql.Append("title=@title,");
            strSql.Append("entitle=@entitle,");
            strSql.Append("prono=@prono,");
            strSql.Append("brand=@brand,");
            strSql.Append("protype=@protype,");
            strSql.Append("type2=@type2,");
            strSql.Append("type3=@type3,");
            strSql.Append("type4=@type4,");
            strSql.Append("photo=@photo,");
            strSql.Append("price=@price,");
            strSql.Append("saleprice=@saleprice,");
            strSql.Append("isshow=@isshow,");
            strSql.Append("isnew=@isnew,");
            strSql.Append("ishot=@ishot,");
            strSql.Append("isrecom=@isrecom,");
            strSql.Append("timeinfo=@timeinfo,");
            strSql.Append("features=@features,");
            strSql.Append("content=@content,");
            strSql.Append("encontent=@encontent,");
            strSql.Append("key1=@key1,");
            strSql.Append("key2=@key2,");
            strSql.Append("text1=@text1,");
            strSql.Append("text2=@text2,");
            strSql.Append("text3=@text3,");
            strSql.Append("text4=@text4,");
            strSql.Append("orderid=@orderid,");
            strSql.Append("hit=@hit,");
            strSql.Append("moreno=@moreno");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,50),
					new OleDbParameter("@entitle", OleDbType.VarChar,50),
					new OleDbParameter("@prono", OleDbType.VarChar,50),
					new OleDbParameter("@brand", OleDbType.VarChar,50),
					new OleDbParameter("@protype", OleDbType.Integer,4),
					new OleDbParameter("@type2", OleDbType.VarChar,50),
					new OleDbParameter("@type3", OleDbType.VarChar,50),
					new OleDbParameter("@type4", OleDbType.VarChar,50),
					new OleDbParameter("@photo", OleDbType.VarChar,0),
					new OleDbParameter("@price", OleDbType.VarChar,50),
					new OleDbParameter("@saleprice", OleDbType.VarChar,50),
					new OleDbParameter("@isshow", OleDbType.Boolean,1),
					new OleDbParameter("@isnew", OleDbType.Boolean,1),
					new OleDbParameter("@ishot", OleDbType.Boolean,1),
					new OleDbParameter("@isrecom", OleDbType.Boolean,1),
					new OleDbParameter("@timeinfo", OleDbType.Date),
					new OleDbParameter("@features", OleDbType.VarChar,0),
					new OleDbParameter("@content", OleDbType.VarChar,0),
					new OleDbParameter("@encontent", OleDbType.VarChar,0),
					new OleDbParameter("@key1", OleDbType.VarChar,0),
					new OleDbParameter("@key2", OleDbType.VarChar,0),
					new OleDbParameter("@text1", OleDbType.VarChar,50),
					new OleDbParameter("@text2", OleDbType.VarChar,50),
					new OleDbParameter("@text3", OleDbType.VarChar,50),
					new OleDbParameter("@text4", OleDbType.VarChar,0),
					new OleDbParameter("@orderid", OleDbType.Integer,4),
					new OleDbParameter("@hit", OleDbType.Integer,4),
					new OleDbParameter("@moreno", OleDbType.VarChar,50),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.entitle;
            parameters[3].Value = model.prono;
            parameters[4].Value = model.brand;
            parameters[5].Value = model.protype;
            parameters[6].Value = model.type2;
            parameters[7].Value = model.type3;
            parameters[8].Value = model.type4;
            parameters[9].Value = model.photo;
            parameters[10].Value = model.price;
            parameters[11].Value = model.saleprice;
            parameters[12].Value = model.isshow;
            parameters[13].Value = model.isnew;
            parameters[14].Value = model.ishot;
            parameters[15].Value = model.isrecom;
            parameters[16].Value = model.timeinfo;
            parameters[17].Value = model.features;
            parameters[18].Value = model.content;
            parameters[19].Value = model.encontent;
            parameters[20].Value = model.key1;
            parameters[21].Value = model.key2;
            parameters[22].Value = model.text1;
            parameters[23].Value = model.text2;
            parameters[24].Value = model.text3;
            parameters[25].Value = model.text4;
            parameters[26].Value = model.orderid;
            parameters[27].Value = model.hit;
            parameters[28].Value = model.moreno;
            parameters[29].Value = model.id;

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
            strSql.Append("update products set ");
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
            strSql.Append("delete from products ");
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
            strSql.Append("delete from products ");
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
        public Song.Model.products GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pid,title,entitle,prono,brand,protype,type2,type3,type4,photo,price,saleprice,isshow,isnew,ishot,isrecom,timeinfo,features,content,encontent,key1,key2,text1,text2,text3,text4,orderid,hit,moreno from products ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

            Song.Model.products model = new Song.Model.products();
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
                if (ds.Tables[0].Rows[0]["prono"] != null && ds.Tables[0].Rows[0]["prono"].ToString() != "")
                {
                    model.prono = ds.Tables[0].Rows[0]["prono"].ToString();
                }
                if (ds.Tables[0].Rows[0]["brand"] != null && ds.Tables[0].Rows[0]["brand"].ToString() != "")
                {
                    model.brand = ds.Tables[0].Rows[0]["brand"].ToString();
                }
                if (ds.Tables[0].Rows[0]["protype"] != null && ds.Tables[0].Rows[0]["protype"].ToString() != "")
                {
                    model.protype = int.Parse(ds.Tables[0].Rows[0]["protype"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type2"] != null && ds.Tables[0].Rows[0]["type2"].ToString() != "")
                {
                    model.type2 = ds.Tables[0].Rows[0]["type2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["type3"] != null && ds.Tables[0].Rows[0]["type3"].ToString() != "")
                {
                    model.type3 = ds.Tables[0].Rows[0]["type3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["type4"] != null && ds.Tables[0].Rows[0]["type4"].ToString() != "")
                {
                    model.type4 = ds.Tables[0].Rows[0]["type4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["photo"] != null && ds.Tables[0].Rows[0]["photo"].ToString() != "")
                {
                    model.photo = ds.Tables[0].Rows[0]["photo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["price"] != null && ds.Tables[0].Rows[0]["price"].ToString() != "")
                {
                    model.price = ds.Tables[0].Rows[0]["price"].ToString();
                }
                if (ds.Tables[0].Rows[0]["saleprice"] != null && ds.Tables[0].Rows[0]["saleprice"].ToString() != "")
                {
                    model.saleprice = ds.Tables[0].Rows[0]["saleprice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isshow"] != null && ds.Tables[0].Rows[0]["isshow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isshow"].ToString() == "1") || (ds.Tables[0].Rows[0]["isshow"].ToString().ToLower() == "true"))
                    {
                        model.isshow = true;
                    }
                    else
                    {
                        model.isshow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["isnew"] != null && ds.Tables[0].Rows[0]["isnew"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isnew"].ToString() == "1") || (ds.Tables[0].Rows[0]["isnew"].ToString().ToLower() == "true"))
                    {
                        model.isnew = true;
                    }
                    else
                    {
                        model.isnew = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ishot"] != null && ds.Tables[0].Rows[0]["ishot"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ishot"].ToString() == "1") || (ds.Tables[0].Rows[0]["ishot"].ToString().ToLower() == "true"))
                    {
                        model.ishot = true;
                    }
                    else
                    {
                        model.ishot = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["isrecom"] != null && ds.Tables[0].Rows[0]["isrecom"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isrecom"].ToString() == "1") || (ds.Tables[0].Rows[0]["isrecom"].ToString().ToLower() == "true"))
                    {
                        model.isrecom = true;
                    }
                    else
                    {
                        model.isrecom = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["timeinfo"] != null && ds.Tables[0].Rows[0]["timeinfo"].ToString() != "")
                {
                    model.timeinfo = DateTime.Parse(ds.Tables[0].Rows[0]["timeinfo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["features"] != null && ds.Tables[0].Rows[0]["features"].ToString() != "")
                {
                    model.features = ds.Tables[0].Rows[0]["features"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["encontent"] != null && ds.Tables[0].Rows[0]["encontent"].ToString() != "")
                {
                    model.encontent = ds.Tables[0].Rows[0]["encontent"].ToString();
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
                if (ds.Tables[0].Rows[0]["text4"] != null && ds.Tables[0].Rows[0]["text4"].ToString() != "")
                {
                    model.text4 = ds.Tables[0].Rows[0]["text4"].ToString();
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
            strSql.Append("select id,pid,title,entitle,prono,brand,protype,type2,type3,type4,photo,price,saleprice,isshow,isnew,ishot,isrecom,timeinfo,features,content,encontent,key1,key2,text1,text2,text3,text4,orderid,hit,moreno ");
            strSql.Append(" FROM products ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int intNum, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            if (intNum > 0)
                strSql.Append("select top " + intNum + " id,pid,title,entitle,prono,brand,protype,type2,type3,type4,photo,price,saleprice,isshow,isnew,ishot,isrecom,timeinfo,features,content,encontent,key1,key2,text1,text2,text3,text4,orderid,hit,moreno ");
            else
                strSql.Append("select id,pid,title,entitle,prono,brand,protype,type2,type3,type4,photo,price,saleprice,isshow,isnew,ishot,isrecom,timeinfo,features,content,encontent,key1,key2,text1,text2,text3,text4,orderid,hit,moreno ");
            strSql.Append(" FROM products ");
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
                sql = " select top " + num.ToString() + " id,pid,title,photo,saleprice from products where 1=1 " + sqlWhere;
            else
                sql = " select  id,pid,title,photo,saleprice from products where 1=1 " + sqlWhere;
            return DbHelperOleDb.ExecuteReader(sql);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM products ");
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
            strSql.Append(")AS Row, T.*  from products T ");
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
            parameters[0].Value = "products";
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


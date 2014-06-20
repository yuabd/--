using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Song.DAL
{
    /// <summary>
    /// 数据访问类:Jobs
    /// </summary>
    public partial class Jobs
    {
        public Jobs()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "Jobs");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Jobs");
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
        public bool Add(Song.Model.Jobs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Jobs(");
            strSql.Append("[pid],[Title],[Num],[Sex],[WorkAdd],[TimeInfo],[JobUnit],[Money],[Content],[isShow],[CompanyName],[JobDescription],[JobDuration],[Contact],[ContactTel],[Education],[WorkExperience],[SPic],[BPic],[isRecommend],[ContactUs],[CompanyProfile])");
            strSql.Append(" values (");
            strSql.Append("@pid,@Title,@Num,@Sex,@WorkAdd,@TimeInfo,@JobUnit,@Money,@Content,@isShow,@CompanyName,@JobDescription,@JobDuration,@Contact,@ContactTel,@Education,@WorkExperience,@SPic,@BPic,@isRecommend,@ContactUs,@CompanyProfile)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@Title", OleDbType.VarChar,255),
					new OleDbParameter("@Num", OleDbType.VarChar,50),
					new OleDbParameter("@Sex", OleDbType.VarChar,255),
					new OleDbParameter("@WorkAdd", OleDbType.VarChar,50),
					new OleDbParameter("@TimeInfo", OleDbType.Date),
					new OleDbParameter("@JobUnit", OleDbType.VarChar,50),
					new OleDbParameter("@Money", OleDbType.VarChar,255),
					new OleDbParameter("@Content", OleDbType.VarChar,0),
					new OleDbParameter("@isShow", OleDbType.Boolean,1),
					new OleDbParameter("@CompanyName", OleDbType.VarChar,255),
					new OleDbParameter("@JobDescription", OleDbType.VarChar,0),
					new OleDbParameter("@JobDuration", OleDbType.VarChar,255),
					new OleDbParameter("@Contact", OleDbType.VarChar,50),
					new OleDbParameter("@ContactTel", OleDbType.VarChar,50),
					new OleDbParameter("@Education", OleDbType.VarChar,50),
					new OleDbParameter("@WorkExperience", OleDbType.VarChar,255),
                    new OleDbParameter("@SPic", OleDbType.VarChar,255),
                    new OleDbParameter("@BPic", OleDbType.VarChar,255),
                    new OleDbParameter("@isRecommend", OleDbType.Boolean,1),
                    new OleDbParameter("@ContactUs", OleDbType.VarChar,0),
                    new OleDbParameter("@CompanyProfile", OleDbType.VarChar,0)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Num;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.WorkAdd;
            parameters[5].Value = model.TimeInfo;
            parameters[6].Value = model.JobUnit;
            parameters[7].Value = model.Money;
            parameters[8].Value = model.Content;
            parameters[9].Value = model.isShow;
            parameters[10].Value = model.CompanyName;
            parameters[11].Value = model.JobDescription;
            parameters[12].Value = model.JobDuration;
            parameters[13].Value = model.Contact;
            parameters[14].Value = model.ContactTel;
            parameters[15].Value = model.Education;
            parameters[16].Value = model.WorkExperience;
            parameters[17].Value = model.SPic;
            parameters[18].Value = model.BPic;
            parameters[19].Value = model.isRecommend;
            parameters[20].Value = model.ContactUs;
            parameters[21].Value = model.CompanyProfile;

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
        public bool Update(Song.Model.Jobs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Jobs set ");
            strSql.Append("[pid]=@pid,");
            strSql.Append("[Title]=@Title,");
            strSql.Append("[Num]=@Num,");
            strSql.Append("[Sex]=@Sex,");
            strSql.Append("[WorkAdd]=@WorkAdd,");
            strSql.Append("[TimeInfo]=@TimeInfo,");
            strSql.Append("[JobUnit]=@JobUnit,");
            strSql.Append("[Money]=@Money,");
            strSql.Append("[Content]=@Content,");
            strSql.Append("[isShow]=@isShow,");
            strSql.Append("[CompanyName]=@CompanyName,");
            strSql.Append("[JobDescription]=@JobDescription,");
            strSql.Append("[JobDuration]=@JobDuration,");
            strSql.Append("[Contact]=@Contact,");
            strSql.Append("[ContactTel]=@ContactTel,");
            strSql.Append("[Education]=@Education,");
            strSql.Append("[WorkExperience]=@WorkExperience,");
            strSql.Append("[SPic]=@SPic,");
            strSql.Append("[BPic]=@BPic,");
            strSql.Append("[isRecommend]=@isRecommend,");
            strSql.Append("[ContactUs]=@ContactUs,");
            strSql.Append("[CompanyProfile]=@CompanyProfile");
            strSql.Append(" where [id]=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@pid", OleDbType.Integer,4),
					new OleDbParameter("@Title", OleDbType.VarChar,255),
					new OleDbParameter("@Num", OleDbType.VarChar,50),
					new OleDbParameter("@Sex", OleDbType.VarChar,255),
					new OleDbParameter("@WorkAdd", OleDbType.VarChar,50),
					new OleDbParameter("@TimeInfo", OleDbType.Date),
					new OleDbParameter("@JobUnit", OleDbType.VarChar,50),
					new OleDbParameter("@Money", OleDbType.VarChar,255),
					new OleDbParameter("@Content", OleDbType.VarChar,0),
					new OleDbParameter("@isShow", OleDbType.Boolean,1),
					new OleDbParameter("@CompanyName", OleDbType.VarChar,255),
					new OleDbParameter("@JobDescription", OleDbType.VarChar,0),
					new OleDbParameter("@JobDuration", OleDbType.VarChar,255),
					new OleDbParameter("@Contact", OleDbType.VarChar,50),
					new OleDbParameter("@ContactTel", OleDbType.VarChar,50),
					new OleDbParameter("@Education", OleDbType.VarChar,50),
					new OleDbParameter("@WorkExperience", OleDbType.VarChar,255),
                    new OleDbParameter("@SPic", OleDbType.VarChar,255),
                    new OleDbParameter("@BPic", OleDbType.VarChar,255),
                    new OleDbParameter("@isRecommend", OleDbType.Boolean,1),
                    new OleDbParameter("@ContactUs", OleDbType.VarChar,0),
                    new OleDbParameter("@CompanyProfile", OleDbType.VarChar,0),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.pid;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Num;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.WorkAdd;
            parameters[5].Value = model.TimeInfo;
            parameters[6].Value = model.JobUnit;
            parameters[7].Value = model.Money;
            parameters[8].Value = model.Content;
            parameters[9].Value = model.isShow;
            parameters[10].Value = model.CompanyName;
            parameters[11].Value = model.JobDescription;
            parameters[12].Value = model.JobDuration;
            parameters[13].Value = model.Contact;
            parameters[14].Value = model.ContactTel;
            parameters[15].Value = model.Education;
            parameters[16].Value = model.WorkExperience;
            parameters[17].Value = model.SPic;
            parameters[18].Value = model.BPic;
            parameters[19].Value = model.isRecommend;
            parameters[20].Value = model.ContactUs;
            parameters[21].Value = model.CompanyProfile;
            parameters[22].Value = model.id;

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
            strSql.Append("delete from Jobs ");
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
        /// 条件按需更新,适用于批量
        /// </summary>
        /// <param name="updates">需要更新的字段[ f1=xxx,f2=xxx]</param>
        /// <param name="express">条件[参数顺序要与前一个参数一致ID=xxx]</param>
        /// <returns></returns>
        public bool Update(string updates, string express)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Jobs set ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Jobs ");
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
        public Song.Model.Jobs GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [id],[pid],[Title],[Num],[Sex],[WorkAdd],[TimeInfo],[JobUnit],[Money],[Content],[isShow],[CompanyName],[JobDescription],[JobDuration],[Contact],[ContactTel],[Education],[WorkExperience],[SPic],[BPic],[isRecommend],[ContactUs],[CompanyProfile] from Jobs ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)
			};
            parameters[0].Value = id;

            Song.Model.Jobs model = new Song.Model.Jobs();
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
        public Song.Model.Jobs DataRowToModel(DataRow row)
        {
            Song.Model.Jobs model = new Song.Model.Jobs();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["pid"] != null && row["pid"].ToString() != "")
                {
                    model.pid = int.Parse(row["pid"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Num"] != null)
                {
                    model.Num = row["Num"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["WorkAdd"] != null)
                {
                    model.WorkAdd = row["WorkAdd"].ToString();
                }
                if (row["TimeInfo"] != null && row["TimeInfo"].ToString() != "")
                {
                    model.TimeInfo = DateTime.Parse(row["TimeInfo"].ToString());
                }
                if (row["JobUnit"] != null)
                {
                    model.JobUnit = row["JobUnit"].ToString();
                }
                if (row["Money"] != null)
                {
                    model.Money = row["Money"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["isShow"] != null && row["isShow"].ToString() != "")
                {
                    if ((row["isShow"].ToString() == "1") || (row["isShow"].ToString().ToLower() == "true"))
                    {
                        model.isShow = true;
                    }
                    else
                    {
                        model.isShow = false;
                    }
                }
                if (row["CompanyName"] != null)
                {
                    model.CompanyName = row["CompanyName"].ToString();
                }
                if (row["JobDescription"] != null)
                {
                    model.JobDescription = row["JobDescription"].ToString();
                }
                if (row["JobDuration"] != null)
                {
                    model.JobDuration = row["JobDuration"].ToString();
                }
                if (row["Contact"] != null)
                {
                    model.Contact = row["Contact"].ToString();
                }
                if (row["ContactTel"] != null)
                {
                    model.ContactTel = row["ContactTel"].ToString();
                }
                if (row["Education"] != null)
                {
                    model.Education = row["Education"].ToString();
                }
                if (row["WorkExperience"] != null)
                {
                    model.WorkExperience = row["WorkExperience"].ToString();
                }
                if (row["SPic"] != null)
                {
                    model.SPic = row["SPic"].ToString();
                }
                if (row["BPic"] != null)
                {
                    model.BPic = row["BPic"].ToString();
                }
                if (row["isRecommend"] != null && row["isRecommend"].ToString() != "")
                {
                    if ((row["isRecommend"].ToString() == "1") || (row["isRecommend"].ToString().ToLower() == "true"))
                    {
                        model.isRecommend = true;
                    }
                    else
                    {
                        model.isRecommend = false;
                    }
                }
                if (row["ContactUs"] != null)
                {
                    model.ContactUs = row["ContactUs"].ToString();
                }
                if (row["CompanyProfile"] != null)
                {
                    model.CompanyProfile = row["CompanyProfile"].ToString();
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
            strSql.Append("select [id],[pid],[Title],[Num],[Sex],[WorkAdd],[TimeInfo],[JobUnit],[Money],[Content],[isShow],[CompanyName],[JobDescription],[JobDuration],[Contact],[ContactTel],[Education],[WorkExperience],[SPic],[BPic],[isRecommend],[ContactUs],[CompanyProfile] ");
            strSql.Append(" FROM Jobs ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
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
                strSql.Append("select top " + intNum + " [id],[pid],[Title],[Num],[Sex],[WorkAdd],[TimeInfo],[JobUnit],[Money],[Content],[isShow],[CompanyName],[JobDescription],[JobDuration],[Contact],[ContactTel],[Education],[WorkExperience],[SPic],[BPic],[isRecommend],[ContactUs],[CompanyProfile] ");
            else
                strSql.Append("select [id],[pid],[Title],[Num],[Sex],[WorkAdd],[TimeInfo],[JobUnit],[Money],[Content],[isShow],[CompanyName],[JobDescription],[JobDuration],[Contact],[ContactTel],[Education],[WorkExperience],[SPic],[BPic],[isRecommend],[ContactUs],[CompanyProfile] ");
            strSql.Append(" FROM Jobs ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Jobs ");
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
            strSql.Append(")AS Row, T.*  from Jobs T ");
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
            parameters[0].Value = "Jobs";
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


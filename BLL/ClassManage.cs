using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using Song.Model;
using System.Data.OleDb;


namespace Song.BLL
{
    /// <summary>
    /// ClassManage
    /// </summary>
    public partial class ClassManage
    {
        private readonly Song.DAL.ClassManage dal = new Song.DAL.ClassManage();
        public ClassManage()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Song.Model.ClassManage model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Song.Model.ClassManage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(String id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Song.Model.ClassManage GetModel(int id)
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Song.Model.ClassManage GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "ClassManageModel-";
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel();
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Song.Model.ClassManage)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public OleDbDataReader GetReader(String strWhere)
        {
            return dal.GetReader(strWhere);
        }

        /// <summary>
        /// 获取下级ID
        /// </summary>
        /// <returns></returns>
        public string GetNodeID(int Fid)
        {
            return dal.GetNodeID(Fid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.ClassManage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.ClassManage> DataTableToList(DataTable dt)
        {
            List<Song.Model.ClassManage> modelList = new List<Song.Model.ClassManage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Song.Model.ClassManage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Song.Model.ClassManage();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["ClassName"] != null && dt.Rows[n]["ClassName"].ToString() != "")
                    {
                        model.ClassName = dt.Rows[n]["ClassName"].ToString();
                    }
                    if (dt.Rows[n]["EnName"] != null && dt.Rows[n]["EnName"].ToString() != "")
                    {
                        model.EnName = dt.Rows[n]["EnName"].ToString();
                    }
                    if (dt.Rows[n]["ClassUrl"] != null && dt.Rows[n]["ClassUrl"].ToString() != "")
                    {
                        model.ClassUrl = dt.Rows[n]["ClassUrl"].ToString();
                    }
                    if (dt.Rows[n]["keywords"] != null && dt.Rows[n]["keywords"].ToString() != "")
                    {
                        model.keywords = dt.Rows[n]["keywords"].ToString();
                    }
                    if (dt.Rows[n]["description"] != null && dt.Rows[n]["description"].ToString() != "")
                    {
                        model.description = dt.Rows[n]["description"].ToString();
                    }
                    if (dt.Rows[n]["ClassInfo"] != null && dt.Rows[n]["ClassInfo"].ToString() != "")
                    {
                        model.ClassInfo = dt.Rows[n]["ClassInfo"].ToString();
                    }
                    if (dt.Rows[n]["pic"] != null && dt.Rows[n]["pic"].ToString() != "")
                    {
                        model.pic = dt.Rows[n]["pic"].ToString();
                    }
                    if (dt.Rows[n]["PageId"] != null && dt.Rows[n]["PageId"].ToString() != "")
                    {
                        model.PageId = int.Parse(dt.Rows[n]["PageId"].ToString());
                    }
                    if (dt.Rows[n]["Fid"] != null && dt.Rows[n]["Fid"].ToString() != "")
                    {
                        model.Fid = int.Parse(dt.Rows[n]["Fid"].ToString());
                    }
                    if (dt.Rows[n]["orderid"] != null && dt.Rows[n]["orderid"].ToString() != "")
                    {
                        model.orderid = int.Parse(dt.Rows[n]["orderid"].ToString());
                    }
                    if (dt.Rows[n]["funid"] != null && dt.Rows[n]["funid"].ToString() != "")
                    {
                        model.funid = int.Parse(dt.Rows[n]["funid"].ToString());
                    }
                    if (dt.Rows[n]["urlparm"] != null && dt.Rows[n]["urlparm"].ToString() != "")
                    {
                        model.urlparm = dt.Rows[n]["urlparm"].ToString();
                    }
                    if (dt.Rows[n]["isSelf"] != null && dt.Rows[n]["isSelf"].ToString() != "")
                    {
                        if ((dt.Rows[n]["isSelf"].ToString() == "1") || (dt.Rows[n]["isSelf"].ToString().ToLower() == "true"))
                        {
                            model.isSelf = true;
                        }
                        else
                        {
                            model.isSelf = false;
                        }
                    }
                    if (dt.Rows[n]["isShow"] != null && dt.Rows[n]["isShow"].ToString() != "")
                    {
                        if ((dt.Rows[n]["isShow"].ToString() == "1") || (dt.Rows[n]["isShow"].ToString().ToLower() == "true"))
                        {
                            model.isShow = true;
                        }
                        else
                        {
                            model.isShow = false;
                        }
                    }
                    if (dt.Rows[n]["LinkUrl"] != null && dt.Rows[n]["LinkUrl"].ToString() != "")
                    {
                        model.LinkUrl = dt.Rows[n]["LinkUrl"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取DataRead数据
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public List<Song.Model.ClassManage> GetReaderList(String Field, String sqlWhere)
        {
            return dal.GetReaderList(sqlWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}


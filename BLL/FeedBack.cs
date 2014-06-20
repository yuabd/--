using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
namespace Song.BLL
{
    /// <summary>
    /// FeedBack
    /// </summary>
    public partial class FeedBack
    {
        private readonly Song.DAL.FeedBack dal = new Song.DAL.FeedBack();
        public FeedBack()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Song.Model.FeedBack model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Song.Model.FeedBack model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Song.Model.FeedBack GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Song.Model.FeedBack GetModelByCache(int id)
        {

            string CacheKey = "FeedBackModel-" + id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Song.Model.FeedBack)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.FeedBack> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.FeedBack> DataTableToList(DataTable dt)
        {
            List<Song.Model.FeedBack> modelList = new List<Song.Model.FeedBack>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Song.Model.FeedBack model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Song.Model.FeedBack();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["pid"] != null && dt.Rows[n]["pid"].ToString() != "")
                    {
                        model.pid = int.Parse(dt.Rows[n]["pid"].ToString());
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = dt.Rows[n]["type"].ToString();
                    }
                    if (dt.Rows[n]["companyName"] != null && dt.Rows[n]["companyName"].ToString() != "")
                    {
                        model.companyName = dt.Rows[n]["companyName"].ToString();
                    }
                    if (dt.Rows[n]["userName"] != null && dt.Rows[n]["userName"].ToString() != "")
                    {
                        model.userName = dt.Rows[n]["userName"].ToString();
                    }
                    if (dt.Rows[n]["jobs"] != null && dt.Rows[n]["jobs"].ToString() != "")
                    {
                        model.jobs = dt.Rows[n]["jobs"].ToString();
                    }
                    if (dt.Rows[n]["phone"] != null && dt.Rows[n]["phone"].ToString() != "")
                    {
                        model.phone = dt.Rows[n]["phone"].ToString();
                    }
                    if (dt.Rows[n]["mobile"] != null && dt.Rows[n]["mobile"].ToString() != "")
                    {
                        model.mobile = dt.Rows[n]["mobile"].ToString();
                    }
                    if (dt.Rows[n]["email"] != null && dt.Rows[n]["email"].ToString() != "")
                    {
                        model.email = dt.Rows[n]["email"].ToString();
                    }
                    if (dt.Rows[n]["address"] != null && dt.Rows[n]["address"].ToString() != "")
                    {
                        model.address = dt.Rows[n]["address"].ToString();
                    }
                    if (dt.Rows[n]["content"] != null && dt.Rows[n]["content"].ToString() != "")
                    {
                        model.content = dt.Rows[n]["content"].ToString();
                    }
                    if (dt.Rows[n]["timeinfo"] != null && dt.Rows[n]["timeinfo"].ToString() != "")
                    {
                        model.timeinfo = DateTime.Parse(dt.Rows[n]["timeinfo"].ToString());
                    }
                    if (dt.Rows[n]["FeedState"] != null && dt.Rows[n]["FeedState"].ToString() != "")
                    {
                        model.FeedState = int.Parse(dt.Rows[n]["FeedState"].ToString());
                    }
                    if (dt.Rows[n]["FeedBackType"] != null && dt.Rows[n]["FeedBackType"].ToString() != "")
                    {
                        model.FeedBackType = dt.Rows[n]["FeedBackType"].ToString();
                    }
                    if (dt.Rows[n]["weblanguage"] != null && dt.Rows[n]["weblanguage"].ToString() != "")
                    {
                        model.weblanguage = dt.Rows[n]["weblanguage"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
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


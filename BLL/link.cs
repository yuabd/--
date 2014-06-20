using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
namespace Song.BLL
{
    /// <summary>
    /// link
    /// </summary>
    public partial class link
    {
        private readonly Song.DAL.link dal = new Song.DAL.link();
        public link()
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
        public bool Add(Song.Model.link model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Song.Model.link model)
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
        public Song.Model.link GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Song.Model.link GetModelByCache(int id)
        {

            string CacheKey = "linkModel-" + id;
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
            return (Song.Model.link)objModel;
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
        public DataSet GetList(int intNum, string strWhere)
        {
            return dal.GetList(intNum, strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.link> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.link> DataTableToList(DataTable dt)
        {
            List<Song.Model.link> modelList = new List<Song.Model.link>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Song.Model.link model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Song.Model.link();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["Pid"] != null && dt.Rows[n]["Pid"].ToString() != "")
                    {
                        model.Pid = int.Parse(dt.Rows[n]["Pid"].ToString());
                    }
                    if (dt.Rows[n]["typename"] != null && dt.Rows[n]["typename"].ToString() != "")
                    {
                        model.typename = dt.Rows[n]["typename"].ToString();
                    }
                    if (dt.Rows[n]["url"] != null && dt.Rows[n]["url"].ToString() != "")
                    {
                        model.url = dt.Rows[n]["url"].ToString();
                    }
                    if (dt.Rows[n]["PicUrl"] != null && dt.Rows[n]["PicUrl"].ToString() != "")
                    {
                        model.PicUrl = dt.Rows[n]["PicUrl"].ToString();
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


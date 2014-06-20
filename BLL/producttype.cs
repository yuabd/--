using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
using System.Data.OleDb;

namespace Song.BLL
{
    /// <summary>
    /// producttype
    /// </summary>
    public partial class producttype
    {
        private readonly Song.DAL.producttype dal = new Song.DAL.producttype();
        public producttype()
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
        public bool Add(Song.Model.producttype model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Song.Model.producttype model)
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
        public Song.Model.producttype GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Song.Model.producttype GetModelByCache(int id)
        {

            string CacheKey = "producttypeModel-" + id;
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
            return (Song.Model.producttype)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, int intNum = 0)
        {
            return dal.GetList(strWhere, intNum);
        }

        public OleDbDataReader GetReader(String sqlWhere)
        {
            return dal.GetReader(sqlWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.producttype> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.producttype> DataTableToList(DataTable dt)
        {
            List<Song.Model.producttype> modelList = new List<Song.Model.producttype>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Song.Model.producttype model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Song.Model.producttype();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["pid"] != null && dt.Rows[n]["pid"].ToString() != "")
                    {
                        model.pid = int.Parse(dt.Rows[n]["pid"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["entitle"] != null && dt.Rows[n]["entitle"].ToString() != "")
                    {
                        model.entitle = dt.Rows[n]["entitle"].ToString();
                    }
                    if (dt.Rows[n]["fid"] != null && dt.Rows[n]["fid"].ToString() != "")
                    {
                        model.fid = int.Parse(dt.Rows[n]["fid"].ToString());
                    }
                    if (dt.Rows[n]["content"] != null && dt.Rows[n]["content"].ToString() != "")
                    {
                        model.content = dt.Rows[n]["content"].ToString();
                    }
                    if (dt.Rows[n]["encontent"] != null && dt.Rows[n]["encontent"].ToString() != "")
                    {
                        model.encontent = dt.Rows[n]["encontent"].ToString();
                    }
                    if (dt.Rows[n]["photo"] != null && dt.Rows[n]["photo"].ToString() != "")
                    {
                        model.photo = dt.Rows[n]["photo"].ToString();
                    }
                    if (dt.Rows[n]["orderid"] != null && dt.Rows[n]["orderid"].ToString() != "")
                    {
                        model.orderid = int.Parse(dt.Rows[n]["orderid"].ToString());
                    }
                    if (dt.Rows[n]["text1"] != null && dt.Rows[n]["text1"].ToString() != "")
                    {
                        model.text1 = dt.Rows[n]["text1"].ToString();
                    }
                    if (dt.Rows[n]["text2"] != null && dt.Rows[n]["text2"].ToString() != "")
                    {
                        model.text2 = dt.Rows[n]["text2"].ToString();
                    }
                    if (dt.Rows[n]["text3"] != null && dt.Rows[n]["text3"].ToString() != "")
                    {
                        model.text3 = dt.Rows[n]["text3"].ToString();
                    }
                    if (dt.Rows[n]["text4"] != null && dt.Rows[n]["text4"].ToString() != "")
                    {
                        model.text4 = dt.Rows[n]["text4"].ToString();
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


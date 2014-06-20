using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
using System.Data.OleDb;
namespace Song.BLL
{
    /// <summary>
    /// news
    /// </summary>
    public partial class news
    {
        private readonly Song.DAL.news dal = new Song.DAL.news();
        public news()
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
        /// 获取最大或最小ID
        /// </summary>
        /// <param name="MaxOrMin">大或小：大max 小Min</param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetMaxOrMinID(string MaxOrMin, string strWhere)
        {
            return dal.GetMaxOrMinID(MaxOrMin, strWhere);
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
        public bool Add(Song.Model.news model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Song.Model.news model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public bool Update(string where, string wheres)
        {
            return dal.Update(where, wheres);
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
        public Song.Model.news GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Song.Model.news GetModel(string where)
        {
            return dal.GetModel(where);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Song.Model.news GetModelByCache(int id)
        {

            string CacheKey = "newsModel-" + id;
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
            return (Song.Model.news)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, int intNum = 0)
        {
            return dal.GetList(strWhere, intNum);
        }
        /// <summary>
        /// OleDbDataReader
        /// </summary>
        /// <param name="num"></param>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public OleDbDataReader GetReader(int num, String sqlWhere)
        {
            return dal.GetReader(num, sqlWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.news> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.news> DataTableToList(DataTable dt)
        {
            List<Song.Model.news> modelList = new List<Song.Model.news>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Song.Model.news model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Song.Model.news();
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
                    if (dt.Rows[n]["newstype"] != null && dt.Rows[n]["newstype"].ToString() != "")
                    {
                        model.newstype = int.Parse(dt.Rows[n]["newstype"].ToString());
                    }
                    if (dt.Rows[n]["photo"] != null && dt.Rows[n]["photo"].ToString() != "")
                    {
                        model.photo = dt.Rows[n]["photo"].ToString();
                    }
                    if (dt.Rows[n]["content"] != null && dt.Rows[n]["content"].ToString() != "")
                    {
                        model.content = dt.Rows[n]["content"].ToString();
                    }
                    if (dt.Rows[n]["encontent"] != null && dt.Rows[n]["encontent"].ToString() != "")
                    {
                        model.encontent = dt.Rows[n]["encontent"].ToString();
                    }
                    if (dt.Rows[n]["timeinfo"] != null && dt.Rows[n]["timeinfo"].ToString() != "")
                    {
                        model.timeinfo = DateTime.Parse(dt.Rows[n]["timeinfo"].ToString());
                    }
                    if (dt.Rows[n]["orderid"] != null && dt.Rows[n]["orderid"].ToString() != "")
                    {
                        model.orderid = int.Parse(dt.Rows[n]["orderid"].ToString());
                    }
                    if (dt.Rows[n]["hit"] != null && dt.Rows[n]["hit"].ToString() != "")
                    {
                        model.hit = int.Parse(dt.Rows[n]["hit"].ToString());
                    }
                    if (dt.Rows[n]["moreno"] != null && dt.Rows[n]["moreno"].ToString() != "")
                    {
                        model.moreno = dt.Rows[n]["moreno"].ToString();
                    }
                    if (dt.Rows[n]["links"] != null && dt.Rows[n]["links"].ToString() != "")
                    {
                        model.links = dt.Rows[n]["links"].ToString();
                    }
                    if (dt.Rows[n]["key1"] != null && dt.Rows[n]["key1"].ToString() != "")
                    {
                        model.key1 = dt.Rows[n]["key1"].ToString();
                    }
                    if (dt.Rows[n]["key2"] != null && dt.Rows[n]["key2"].ToString() != "")
                    {
                        model.key2 = dt.Rows[n]["key2"].ToString();
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


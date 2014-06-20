using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Song.Model;
using System.Data.OleDb;
namespace Song.BLL
{
    /// <summary>
    /// products
    /// </summary>
    public partial class products
    {
        private readonly Song.DAL.products dal = new Song.DAL.products();
        public products()
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
        public bool Add(Song.Model.products model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Song.Model.products model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public bool Update(string updates, string express)
        {
            return dal.Update(updates, express);
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
        public Song.Model.products GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Song.Model.products GetModelByCache(int id)
        {

            string CacheKey = "productsModel-" + id;
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
            return (Song.Model.products)objModel;
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
        /// 获取前几条数据
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
        public List<Song.Model.products> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Song.Model.products> DataTableToList(DataTable dt)
        {
            List<Song.Model.products> modelList = new List<Song.Model.products>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Song.Model.products model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Song.Model.products();
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
                    if (dt.Rows[n]["prono"] != null && dt.Rows[n]["prono"].ToString() != "")
                    {
                        model.prono = dt.Rows[n]["prono"].ToString();
                    }
                    if (dt.Rows[n]["brand"] != null && dt.Rows[n]["brand"].ToString() != "")
                    {
                        model.brand = dt.Rows[n]["brand"].ToString();
                    }
                    if (dt.Rows[n]["protype"] != null && dt.Rows[n]["protype"].ToString() != "")
                    {
                        model.protype = int.Parse(dt.Rows[n]["protype"].ToString());
                    }
                    if (dt.Rows[n]["type2"] != null && dt.Rows[n]["type2"].ToString() != "")
                    {
                        model.type2 = dt.Rows[n]["type2"].ToString();
                    }
                    if (dt.Rows[n]["type3"] != null && dt.Rows[n]["type3"].ToString() != "")
                    {
                        model.type3 = dt.Rows[n]["type3"].ToString();
                    }
                    if (dt.Rows[n]["type4"] != null && dt.Rows[n]["type4"].ToString() != "")
                    {
                        model.type4 = dt.Rows[n]["type4"].ToString();
                    }
                    if (dt.Rows[n]["photo"] != null && dt.Rows[n]["photo"].ToString() != "")
                    {
                        model.photo = dt.Rows[n]["photo"].ToString();
                    }
                    if (dt.Rows[n]["price"] != null && dt.Rows[n]["price"].ToString() != "")
                    {
                        model.price = dt.Rows[n]["price"].ToString();
                    }
                    if (dt.Rows[n]["saleprice"] != null && dt.Rows[n]["saleprice"].ToString() != "")
                    {
                        model.saleprice = dt.Rows[n]["saleprice"].ToString();
                    }
                    if (dt.Rows[n]["isshow"] != null && dt.Rows[n]["isshow"].ToString() != "")
                    {
                        if ((dt.Rows[n]["isshow"].ToString() == "1") || (dt.Rows[n]["isshow"].ToString().ToLower() == "true"))
                        {
                            model.isshow = true;
                        }
                        else
                        {
                            model.isshow = false;
                        }
                    }
                    if (dt.Rows[n]["isnew"] != null && dt.Rows[n]["isnew"].ToString() != "")
                    {
                        if ((dt.Rows[n]["isnew"].ToString() == "1") || (dt.Rows[n]["isnew"].ToString().ToLower() == "true"))
                        {
                            model.isnew = true;
                        }
                        else
                        {
                            model.isnew = false;
                        }
                    }
                    if (dt.Rows[n]["ishot"] != null && dt.Rows[n]["ishot"].ToString() != "")
                    {
                        if ((dt.Rows[n]["ishot"].ToString() == "1") || (dt.Rows[n]["ishot"].ToString().ToLower() == "true"))
                        {
                            model.ishot = true;
                        }
                        else
                        {
                            model.ishot = false;
                        }
                    }
                    if (dt.Rows[n]["isrecom"] != null && dt.Rows[n]["isrecom"].ToString() != "")
                    {
                        if ((dt.Rows[n]["isrecom"].ToString() == "1") || (dt.Rows[n]["isrecom"].ToString().ToLower() == "true"))
                        {
                            model.isrecom = true;
                        }
                        else
                        {
                            model.isrecom = false;
                        }
                    }
                    if (dt.Rows[n]["timeinfo"] != null && dt.Rows[n]["timeinfo"].ToString() != "")
                    {
                        model.timeinfo = DateTime.Parse(dt.Rows[n]["timeinfo"].ToString());
                    }
                    if (dt.Rows[n]["features"] != null && dt.Rows[n]["features"].ToString() != "")
                    {
                        model.features = dt.Rows[n]["features"].ToString();
                    }
                    if (dt.Rows[n]["content"] != null && dt.Rows[n]["content"].ToString() != "")
                    {
                        model.content = dt.Rows[n]["content"].ToString();
                    }
                    if (dt.Rows[n]["encontent"] != null && dt.Rows[n]["encontent"].ToString() != "")
                    {
                        model.encontent = dt.Rows[n]["encontent"].ToString();
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
                    if (dt.Rows[n]["text4"] != null && dt.Rows[n]["text4"].ToString() != "")
                    {
                        model.text4 = dt.Rows[n]["text4"].ToString();
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


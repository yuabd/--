using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using Maticsoft.DBUtility;

namespace Maticsoft.Common
{
    public class ManageCom
    {
        webcommand webcom = new webcommand();
        public ManageCom()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region 列表排序

        /// <summary>
        /// 列表排序 - 升序
        /// </summary>
        /// <param name="action">操作方式</param>
        /// <param name="OrderField">排序字段(默认为orderid)</param>
        /// <param name="TableName">表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="rid">当前排序id</param>
        /// <param name="cid">当前id</param>
        /// <param name="TargetUrl">更新完后跳转的页面</param>
        public void UpOrDown(String action, String OrderField, String TableName, String strWhere, String rid, String cid, String TargetUrl)
        {
            String msg = "";
            if (OrderField == null || OrderField == "")//当字段为空时，赋予默认字段
            {
                OrderField = "orderid";
            }
            if (TableName != null && TableName != "")
            {
                String sql = " select top 1 id," + OrderField + " from " + TableName + " where  1=1 ";

                switch (action)
                {
                    case "up"://升
                        sql += " and " + OrderField + " < " + rid + " ";
                        break;
                    case "down"://降
                        sql += " and " + OrderField + " > " + rid + " ";
                        break;
                }

                if (strWhere != null && strWhere != "" && strWhere != " " && strWhere != "   ")
                {
                    sql += " and " + strWhere;
                }

                switch (action)
                {
                    case "up"://升
                        sql += " order by " + OrderField + " desc ";
                        //msg = "第一条";
                        msg = "最后一条";
                        break;
                    case "down"://降
                        sql += " order by " + OrderField + " asc ";
                        //msg = "最后一条";
                        msg = "第一条";
                        break;
                }

                OleDbDataReader dr = DbHelperOleDb.ExecuteReader(sql);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String tmp_id = dr["id"].ToString();
                        String tmp_orderid = dr[OrderField].ToString();
                        DbHelperOleDb.Query(" update " + TableName + " set " + OrderField + " = " + tmp_orderid + "  where id=" + cid + " ");//更新排序ID
                        DbHelperOleDb.Query(" update " + TableName + " set " + OrderField + " = " + rid + " where id=" + tmp_id + " ");//更新排序ID

                        //生成静态页
                        CreatHtml cr = new CreatHtml();
                        cr.Nei_Create(webcom.WebHost() + "/manage/Left.aspx", "left.html");//创建

                        webcommand.Alert("", TargetUrl);
                    }
                }
                else
                {
                    webcommand.Alert("抱歉，已经在" + msg + "了！", TargetUrl);
                }

                dr.Close();
                dr.Dispose();
            }
        }

        #endregion

        #region 生成序列号编号

        public static String CreateNo()
        {
            Random random = new Random();
            return DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(100000);
        }

        #endregion

        #region 查询是否包含
        public String ReturnCheck(String key, String model)
        {
            String action = System.Web.HttpContext.Current.Request.QueryString["action"];
            String id = System.Web.HttpContext.Current.Request.QueryString["id"];
            String str = "", power = "";
            //if (webcom.GetAdminInfo() == false)
            //{
            switch (action)
            {
                case "edit":

                    String sql = " select RulePower from FieldRule where id =" + id;
                    power = DbHelperOleDb.GetScalar(sql);
                    if (power.IndexOf(key) > -1)
                    {
                        switch (model)
                        {
                            case "tr":
                                str = "style='display:block'";
                                break;

                            case "checkbox":
                                str = "checked='checked'";
                                break;
                        }
                    }
                    else
                    {
                        switch (model)
                        {
                            case "tr":
                                str = "style='display:none'";
                                break;
                            default:
                                str = "";
                                break;
                        }
                    }
                    break;

            }

            return str;
        }
        #endregion

        #region 显示字段

        public String ShowField(String key, String FieldList)
        {
            String str = "";
            if (FieldList.IndexOf(key) > -1)
            {
                //str = "style='display:block'";
                str = "";
            }
            else
            {
                str = "style='display:none'";
            }
            return str;
        }

        #endregion

        #region 判断CheckBox是否被选中

        /// <summary>
        /// 判断CheckBox是否被选中
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static String IsCheck(CheckBox box)
        {
            if (box.Checked == true)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        #endregion

        #region 限制字符串

        public static String MarkString(String str, int len)
        {
            if (str != "")
            {
                if (str.Length > len)
                {
                    str = str.Substring(0, len) + "..";
                }
            }
            return str;
        }

        #endregion
    }
}

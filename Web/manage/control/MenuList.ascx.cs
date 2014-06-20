using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text;
using Maticsoft.DBUtility;
using System.Collections;

namespace Song.Web.manage.control
{
    public partial class MenuList : System.Web.UI.UserControl
    {
        protected String powerlist = "", action = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Request.QueryString["action"];

            if (action == "lv3")
            {
                //LoadLv3();
            }
            else
            {
                if (string.IsNullOrEmpty(Session["adminid"] + ""))
                    return;
                BLL.manage ubll = new BLL.manage();
                string[] strUserP = ubll.GetModel(Convert.ToInt32(Session["adminid"] + "")).adminlv.Split(',');
                OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select id,ClassName from ClassManage where Fid = 0 and isShow=True order by orderid asc,id asc ");
                StringBuilder str = new StringBuilder();
                while (dr.Read())
                {
                    if (bolAnswer(dr["id"] + "Select", strUserP))
                    {
                        str.Append("<h1 class=\"type\">");
                        str.Append("<a href=\"javascript:void(0)\">" + dr["ClassName"].ToString() + "</a></h1>");
                        str.Append("<div class=\"content\">");
                        str.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
                        str.Append("<tr>");
                        str.Append("<td>");
                        str.Append("<img src=\"images/menu_topline.gif\" width=\"182\" height=\"5\" />");
                        str.Append("</td>");
                        str.Append("</tr>");
                        str.Append("</table>");
                        str.Append("<ul class=\"MM\">");
                        str.Append(ReturnType(Convert.ToString(dr["id"]), strUserP));
                        str.Append("</ul>");
                        str.Append("</div>");
                    }
                }
                this.Menu.Text = Convert.ToString(str);
                dr.Close();
                dr.Dispose();
            }
        }

        #region 根据大类显示小类

        protected String ReturnType(String fid, string[] strUserP)
        {

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select id,isSelf,PageId,funid,ClassName from ClassManage where Fid = " + fid + " and isShow=true order by orderid asc,id asc ");
            StringBuilder str = new StringBuilder();
            String pid = "";

            while (dr.Read())
            {
                if (Convert.ToBoolean(dr["isSelf"]) == true)
                {
                    pid = Convert.ToString(dr["id"]);
                }
                else
                {
                    pid = fid;
                }

                //if (CheckPower(Convert.ToString(dr["id"]))==true)//产看是否有该权限
                //{
                if (bolAnswer(dr["id"] + "Select", strUserP))
                {
                    str.Append("<li><a " + GetUrl(dr["PageId"].ToString(), pid, dr["funid"].ToString()) + "\" target=\"main\">" + dr["ClassName"].ToString() + "</a>");
                    str.Append("<div class='lv3' id='l" + dr["id"].ToString() + "'>");
                    str.Append(ReturnType2(Convert.ToString(dr["id"]), strUserP));
                    str.Append("</div>");
                    str.Append("</li>");
                }
                //}
            }
            dr.Close();
            dr.Dispose();

            return Convert.ToString(str);
        }

        #endregion

        #region 加载第三级类

        protected void LoadLv3()
        {
            String id = Request.QueryString["id"];
            if (id != null && id != "")
            {
                String tmp = ReturnType2(id);
                Response.Write(tmp);
            }

        }

        #endregion

        #region 根据小类显示第三级类

        protected String ReturnType2(String fid, string[] strUserP = null)
        {

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select id,isSelf,PageId,funid,ClassName from ClassManage where Fid = " + fid + " and isShow=true order by orderid asc,id asc ");
            StringBuilder str = new StringBuilder();
            String pid = "";

            while (dr.Read())
            {
                if (Convert.ToBoolean(dr["isSelf"]) == true)
                {
                    pid = Convert.ToString(dr["id"]);
                }
                else
                {
                    pid = fid;
                }

                //if (CheckPower(Convert.ToString(dr["id"]))==true)//产看是否有该权限
                //{
                if (bolAnswer(dr["id"] + "Select", strUserP))
                {
                    str.Append("<a class='link1' " + GetUrl(dr["PageId"].ToString(), pid, dr["funid"].ToString()) + "\" target=\"main\"> -- " + dr["ClassName"].ToString() + "</a>");
                }
                //}
            }
            dr.Close();
            dr.Dispose();

            return Convert.ToString(str);
        }

        #endregion

        #region 获取栏目对应链接地址

        protected String GetUrl(String pageid, String pid, String mid)
        {
            if (pageid != "" && pageid != "0")
            {
                String sql = " select url from SystemFunction Where id= " + pageid;
                string strurl = DbHelperOleDb.GetScalar(sql);
                if (strurl.LastIndexOf('?') == -1)
                    return "href=\"" + strurl + "?pid=" + pid + "&mid=" + mid + "";
                else
                    return "href=\"" + strurl + "&pid=" + pid + "&mid=" + mid + "";
            }
            else
            {
                return "href=\"javaScript:void(0)\" onClick=\"ShowMenu('" + pid + "');\"";
            }
        }

        #endregion

        protected Boolean CheckPower(String powerid)
        {

            if (powerlist.IndexOf("," + powerid + ",") > -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool bolAnswer(string answer, string[] correctList)
        {
            bool Correct = true;
            if (!((IList)correctList).Contains(answer))
            {
                Correct = false;
            }
            return Correct;
        }
    }
}
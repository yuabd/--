using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Text;
using Maticsoft.Common;
using Maticsoft.DBUtility;


public partial class webadmin_AjaxWebService : System.Web.UI.Page
{
    webcommand webcom = new webcommand();
    public String id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        String come = Request.QueryString["come"];
        id = Request.QueryString["id"];
        switch (come)
        {
            case "menu":
                UploadClass();
                break;
            case "lv3":
                LoadLv3();
                break;
            default:
                Response.Write("无任何处理事件！");
                break;
        }
    }

    #region 修改栏目管理

    public void UploadClass()
    {
        String name = HttpUtility.UrlDecode(Request.QueryString["name"]);
        String enname = HttpUtility.UrlDecode(Request.QueryString["enname"]);
        String fun = Request.QueryString["fun"];
        String pageid = Request.QueryString["pageid"];
        String isSelf = Request.QueryString["isSelf"];
        String isShow = Request.QueryString["isShow"];
        String LinkUrl = Request.QueryString["LinkUrl"];
        if (Convert.ToBoolean(isSelf) == true)
        {
            isSelf = "1";
        }
        else
        {
            isSelf = "0";
        }

        if (Convert.ToBoolean(isShow) == true)
        {
            isShow = "1";
        }
        else
        {
            isShow = "0";
        }

        String sql = " update ClassManage set ClassName = '" + name + "',enname = '" + enname + "',funid = " + fun + ",PageId=" + pageid + ",isSelf=" + isSelf + ",isShow=" + isShow + ",LinkUrl='" + LinkUrl + "' where id= " + id;
        DbHelperOleDb.Query(sql);

        //生成静态页
        CreatHtml cr = new CreatHtml();
        cr.Nei_Create(webcom.WebHost() + "/manage/Left.aspx", "left.html");//创建

        Response.Write("数据修改成功！");
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

    protected String ReturnType2(String fid)
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
            str.Append("<a class='link1' " + GetUrl(dr["PageId"].ToString(), pid, dr["funid"].ToString()) + "\" target=\"main\"> -- " + dr["ClassName"].ToString() + "</a>");
            //}
        }
        dr.Close();
        dr.Dispose();

        return Convert.ToString(str);
    }

    protected String GetUrl(String pageid, String pid, String mid)
    {
        if (pageid != "" && pageid != "0")
        {
            String sql = " select url from SystemFunction Where id= " + pageid;
            return "href=\"" + DbHelperOleDb.GetScalar(sql) + "?pid=" + pid + "&mid=" + mid + "";
        }
        else
        {
            return "href=\"javaScript:void(0)\" onClick=\"ShowMenu('" + pid + "');\"";
        }
    }

    #endregion

}

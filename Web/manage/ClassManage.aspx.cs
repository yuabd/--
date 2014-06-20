using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using Maticsoft.Common;
using Maticsoft.DBUtility;

namespace Song.Web.manage
{
    public partial class ClassManage : System.Web.UI.Page
    {
        public String Fid = "0", rid = "", id = "";
        webcommand webcom = new webcommand();
        FormatHtml fh = new FormatHtml();
        BLL.ClassManage bllClassManage = new BLL.ClassManage();
        Model.ClassManage modelClassManage = new Model.ClassManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查是否登录
            webcommand.CheckUserLogin();
            String action = "";
            if (!string.IsNullOrEmpty(Request.QueryString["action"]))
                action = Request.QueryString["action"];
            if (!string.IsNullOrEmpty(Request.QueryString["Fid"]))
                Fid = Request.QueryString["Fid"];
            if (!string.IsNullOrEmpty(Request.QueryString["rid"]))
                rid = Request.QueryString["rid"];//排序ID
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                id = Request.QueryString["id"];//当前数据ID

            if (!IsPostBack)
            {
                switch (action) //判断操作列别 添加/修改/删除
                {
                    case "deletetype":
                        loaddeletetype();
                        break;
                    case "up"://往前移一位
                        uptype();
                        break;
                    case "down"://往前移一位
                        downtype();
                        break;
                    default:
                        loadtypelist();//返回列表
                        break;

                }
            }
        }

        #region 生成静态页
        protected void html()
        {
            //CreatHtml cr = new CreatHtml();
            //cr.Nei_Create(webcom.WebHost() + "/manage/Left.aspx", "left.html");//创建
        }
        #endregion

        #region 排序 》升序
        protected void uptype()
        {
            ManageCom MCom = new ManageCom();

            if (rid != null && rid != "")
            {
                MCom.UpOrDown("up", "", "ClassManage", " Fid = " + Fid + " ", rid, id, "ClassManage.aspx?Fid=" + Fid);
            }
        }
        #endregion

        #region 排序 》降序
        protected void downtype()
        {
            ManageCom MCom = new ManageCom();

            if (rid != null && rid != "")
            {
                MCom.UpOrDown("down", "", "ClassManage", " Fid = " + Fid + " ", rid, id, "ClassManage.aspx?Fid=" + Fid);
            }
        }
        #endregion

        protected void loadtypelist() //加载列别列表
        {
            if (Fid == null || Fid == "")
            {
                Fid = "0";
            }
            DataSet ds = bllClassManage.GetList(" and Fid=" + Fid + " order by orderid asc,id asc");

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.newstypelist.DataSource = ds;
                this.newstypelist.DataBind();
            }
            else
            {
                this.nodate.Text = "暂无相关数据！</b></font>";
            }
        }


        public void loaddeletetype()//删除类别
        {
            bllClassManage.Delete(id);
            html();
            MessageBox.ShowAndRedirect(this, "删除成功！", "ClassManage.aspx?Fid=" + Fid + "");
        }


        #region 显示子类个数
        public String TotalNum(String id)
        {
            return " ( <font style='#ccc'>共：" + webcom.GetClassNum(id) + " 子栏目</font> ) ";
        }
        #endregion

        #region 返回类别名称

        public String TabClassName()
        {
            if (Fid != null && Fid != "")
            {
                String name = webcom.GetClassName(Fid);
                if (name != "")
                {
                    return " >> " + name;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 获取功能列表

        public String ReturnDrop(String id, String funid)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            if (id != null && id != "")
            {
                OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select id,RuleName from FieldRule ");
                str.Append("<select name=\"s_" + id + "\" id=\"f_" + id + "\">");
                str.Append("<option value=0 >选择字段组</option>");
                while (dr.Read())
                {
                    str.Append(" <option value=\"" + dr["id"] + "\"");
                    if (funid == dr["id"].ToString())
                    {
                        str.Append(" selected=\"selected\" ");
                    }
                    str.Append(">" + dr["RuleName"].ToString() + "</option>");
                }
                str.Append("</select>");
                dr.Close();
                dr.Dispose();
            }
            //else
            //{
            //    str.Append("[栏目标题]");
            //}

            return str.ToString();
        }

        public String ClassList(String id, String pageid)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            if (id != null && id != "" && Fid != "0")
            {
                OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select id,title from SystemFunction  ");
                str.Append("<select name=\"p_" + id + "\" id=\"p_" + id + "\">");
                str.Append("<option value=0 >无页面</option>");
                while (dr.Read())
                {
                    str.Append(" <option value=\"" + dr["id"] + "\"");
                    if (pageid == dr["id"].ToString())
                    {
                        str.Append(" selected=\"selected\" ");
                    }
                    str.Append(">" + dr["title"] + "</option>");
                }
                str.Append("</select>");
                dr.Close();
                dr.Dispose();
            }
            else
            {
                str.Append("[栏目标题]<input type=\"hidden\"  id=\"p_" + id + "\" value='0' />");
            }

            return str.ToString();
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            String maxid = webcom.GetMax("ClassManage");
            modelClassManage.ClassName = fh.ToDBStr(this.ClassName.Text);
            modelClassManage.EnName = fh.ToDBStr(this.EnName.Text);
            modelClassManage.ClassUrl = "";
            modelClassManage.keywords = "";
            modelClassManage.description = "";
            modelClassManage.ClassInfo = "";
            modelClassManage.pic = "";
            modelClassManage.PageId = 0;
            modelClassManage.Fid = Convert.ToInt32(Fid);
            modelClassManage.orderid = Convert.ToInt32(maxid);
            modelClassManage.funid = 0;
            modelClassManage.urlparm = "";
            modelClassManage.LinkUrl = "#";
            modelClassManage.isSelf = false;
            modelClassManage.isShow = true;

            Song.BLL.ClassManage bll = new Song.BLL.ClassManage();
            bll.Add(modelClassManage);
            html();
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加栏目成功！", "ClassManage.aspx?Fid=" + Fid + "");
        }

        protected void newstypelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {

            }
        }
    }
}
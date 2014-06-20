using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using System.Data;
using System.Collections;

namespace Song.Web.manage
{
    public partial class newstype : System.Web.UI.Page
    {
        webcommand webcom = new webcommand();
        FormatHtml fh = new FormatHtml();
        BLL.newstype bll = new BLL.newstype();
        Model.newstype model = new Model.newstype();
        public String ComUrl = "", pid = "", action = "", id = "", ClassName = "", shownew = "display: none";
        private string[] strUserP = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();
            BLL.manage ubll = new BLL.manage();
            strUserP = ubll.GetModel(Convert.ToInt32(Session["adminid"] + "")).adminlv.Split(',');
            action = Request.QueryString["action"];
            id = Request.QueryString["id"];
            pid = Request.QueryString["pid"];
            ClassName = webcom.GetClassName(pid);
            ComUrl = "pid=" + pid;
            if (pid == "132")
                shownew = "";
            if (!bolAnswer(pid + "Add", strUserP))
            {
                Button1.Enabled = false;
                Button1.Attributes.Add("disabled", "disabled");
            }
            if (!IsPostBack)
            {
                switch (action) //判断操作列别 添加/修改/删除
                {

                    case "edittype":

                        loadedittype();

                        break;
                    case "deletetype":
                        loaddeletetype();
                        break;
                    default:
                        //这个无限极分类逻辑会稍微有点乱，但是总体是为了SQL的查询效率。
                        loadtypelist();//返回列表
                        break;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)//添加信息类别
        {
            model.pid = Convert.ToInt32(pid);
            model.fid = 0;
            model.title = fh.ToDBStr(this.title.Text);
            model.entitle = "";
            model.content = this.idorder.Text.Trim();
            model.encontent = "";

            bll.Add(model);
            MessageBox.ShowAndRedirect(this, "添加信息类别成功！", "newstype.aspx?" + ComUrl);
        }

        protected void loadtypelist() //加载类别列表
        {
            DataSet ds = bll.GetList(" and pid=" + pid);
            this.newstypelist.DataSource = ds;
            this.newstypelist.DataBind();//绑定数据
        }

        public void loadedittype()
        {
            model = bll.GetModel(Convert.ToInt32(id));
            this.edit_title.Text = model.title;
            this.TextBox1.Text = model.content;
        }

        public void loaddeletetype()//删除类别
        {
           bll.Delete(Convert.ToInt32(id));
            MessageBox.ShowAndRedirect(this, "删除类别成功！", "newstype.aspx?" + ComUrl);
        }


        protected void edit_button_Click(object sender, EventArgs e)
        {
            model.pid = Convert.ToInt32(pid);
            model.fid = 0;
            model.title = fh.ToDBStr(this.edit_title.Text);
            model.entitle = "";
            model.content = this.TextBox1.Text.Trim();
            model.encontent = "";
            model.id = Convert.ToInt32(id);
            bll.Update(model);

            MessageBox.ShowAndRedirect(this, "修改信息类别成功！", "newstype.aspx?" + ComUrl);
        }

        protected void manageproductlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            BLL.newstype bll = new BLL.newstype();
            switch (e.CommandName)
            {
                case "Del":
                    bll.Delete(Convert.ToInt32(id));
                    break;
                case "Update":
                    Response.Redirect("newstype.aspx?" + ComUrl + "&action=edittype&id=" + id);
                    break;
            }
            loadtypelist();
        }

        protected void manageproductlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                LinkButton btn = (LinkButton)e.Item.FindControl("lbtn_Del");
                if (!bolAnswer(pid + "Del", strUserP))
                {
                    btn.Enabled = false;
                    btn.Attributes.Add("disabled", "disabled");
                }
                else
                    btn.Attributes.Add("onclick", "javascript:return confirm('您确定要删除此信息？删除后将不可恢复！')");

                btn = (LinkButton)e.Item.FindControl("lbtn_Update");
                if (!bolAnswer(pid + "Update", strUserP))
                {
                    btn.Enabled = false;
                    btn.Attributes.Add("disabled", "disabled");
                }
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
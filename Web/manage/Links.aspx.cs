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
using System.Collections;

namespace Song.Web.manage
{
    public partial class Links : System.Web.UI.Page
    {
        webcommand webcom = new webcommand();
        FormatHtml fh = new FormatHtml();
        Song.Model.link model = new Song.Model.link();
        Song.BLL.link bll = new Song.BLL.link();
        protected String action = "", id = "", pid = "0", mid = "0";
        FileControl fc = new FileControl();
        private string[] strUserP = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();
            BLL.manage ubll = new BLL.manage();
            strUserP = ubll.GetModel(Convert.ToInt32(Session["adminid"] + "")).adminlv.Split(',');
            action = Request.QueryString["action"];
            mid = Request.QueryString["mid"];
            id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                pid = Request.QueryString["pid"];
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
                        loadtypelist();
                        break;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)//添加信息链接
        {
            model.Pid = Convert.ToInt32(Request.QueryString["pid"]);
            model.typename = fh.ToDBStr(this.typename.Text);
            model.url = fh.ToDBStr(this.url.Text);
            String filepath = "";
            //上传图片 小图 开始
            if (this.productphotobig1.HasFile)//当有图片的时候
            {
                filepath = fc.CreateSimPic(this.productphotobig1, "", 161, 81, 161, 81);
            }
            else
            {
                filepath = this.productphotobigid1.Value;
            }
            model.PicUrl = filepath;
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加链接成功！", "Links.aspx?pid=" + pid + "&mid=" + mid);
        }

        protected void loadtypelist() //加载链接列表
        {
            DataSet ds = bll.GetList(" and pid=" + Request.QueryString["pid"] + " order by id desc");
            this.linklist.DataSource = ds;
            this.linklist.DataBind();//绑定数据
        }

        public void loadedittype()
        {
            model = bll.GetModel(Convert.ToInt32(id));
            if (model != null)
            {
                this.edit_typename.Text = model.typename;
                this.edit_url.Text = model.url;
            }
        }

        public void loaddeletetype()//删除链接
        {
            bll.Delete(Convert.ToInt32(id));
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "删除链接成功！", "Links.aspx?pid=" + pid + "&mid=" + mid);
        }

        protected void edit_button_Click(object sender, EventArgs e)
        {
            model.typename = fh.ToDBStr(this.edit_typename.Text);
            model.url = fh.ToDBStr(this.edit_url.Text);
            model.id = Convert.ToInt32(id);
            bll.Update(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改链接成功！", "Links.aspx?pid=" + pid + "&mid=" + mid);
        }

        protected void manageproductlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            BLL.link bll = new BLL.link();
            switch (e.CommandName)
            {
                case "Del":
                    bll.Delete(Convert.ToInt32(id));
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
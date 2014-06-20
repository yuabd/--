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
    public partial class producttype : System.Web.UI.Page
    {
        webcommand webcom = new webcommand();
        FormatHtml fh = new FormatHtml();
        FileControl fc = new FileControl();
        Song.BLL.producttype bll = new BLL.producttype();
        Song.Model.producttype model = new Song.Model.producttype();
        protected String topid = "", pid = "", id = "", showsname = "style=\"display: none\"", ComUrl = "";
        private string[] strUserP = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();
            BLL.manage ubll = new BLL.manage();
            strUserP = ubll.GetModel(Convert.ToInt32(Session["adminid"] + "")).adminlv.Split(',');
            topid = Request.QueryString["topid"];
            pid = Request.QueryString["pid"];
            id = Request.QueryString["id"];
            ComUrl = "pid=" + pid + "&topid=" + topid;
            if (pid == "140")
                showsname = "";
            if (topid == null || topid == "")
            {
                topid = "0";
            }
            if (!bolAnswer(pid + "Add", strUserP))
            {
                Button1.Enabled = false;
                Button1.Attributes.Add("disabled", "disabled");
            }
            String action = Request.QueryString["action"];
            if (!IsPostBack)
            {
                switch (action) //判断操作列别 添加/修改/删除
                {

                    case "edittype":
                        loadedittype();
                        break;
                    case "deletetype":
                        loaddeletetype();
                        loadtypelist();
                        break;
                    default:
                        loadtypelist();//返回列表
                        break;

                }
            }


        }
        protected void Button1_Click(object sender, EventArgs e)//添加类别
        {
            FileControl fc = new FileControl();
            String photo = fc.UploadPic(this.FileUpload1, "Pic");

            model.pid = Convert.ToInt32(pid);
            model.title = fh.ToDBStr(this.typename.Text);
            model.entitle = fh.ToDBStr(this.enname.Text);
            model.fid = Convert.ToInt32(topid);
            model.content = this.productcontent.Value;
            model.encontent = key1.Value;
            model.photo = photo;
            model.orderid = Convert.ToInt32(webcom.GetMax("producttype"));
            model.text1 = "";
            model.text2 = "";
            model.text3 = "";
            model.text4 = key2.Value;

            Song.BLL.producttype bll = new Song.BLL.producttype();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加类别成功！", "producttype.aspx?pid=" + pid + "&topid=" + topid);
        }

        protected void loadtypelist() //加载列别列表
        {
            DataSet ds = bll.GetList(" and pid=" + pid + " and fid=" + topid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.newstypelist.DataSource = ds;
                this.newstypelist.DataBind();
            }
            else
            {
                this.nodate.Text = "暂无分类，请添加分类！";
            }

        }

        public void loadedittype()//编辑类别
        {
            model = bll.GetModel(Convert.ToInt32(id));
            if (model != null)
            {
                this.edit_typename.Text = model.title;
                this.edit_enname.Text = model.entitle;
                this.productcontent2.Value = model.content;

                String _photo = model.photo;
                if (_photo != null && _photo != "" && _photo != "nophoto")
                {
                    this.hid_photo.Value = _photo;
                    this.show_photo.Text = "<img src='/UploadFile/Pic/" + _photo + "' height='80px' />";
                }
                Textarea1.Value = model.encontent;
                Textarea2.Value = model.text4;
            }
        }

        public void loaddeletetype()//删除类别
        {
            bll.Delete(Convert.ToInt32(id));
        }

        #region 检测图片

        public String CheckPic(String photo)
        {
            String tmp = "";

            if (photo != "" && photo != "nophoto")
            {
                tmp = "/UploadFile/Pic/" + photo;
            }
            else
            {
                tmp = "images/nopic.jpg";
            }

            return tmp;
        }

        #endregion

        protected void edit_button_Click(object sender, EventArgs e)
        {
            //String photo = fc.CreateSimPic(this.FilePhoto, "", 189, 142, 370, 200);
            String photo = fc.UploadPic(this.FilePhoto, "pic");
            if (photo == null || photo == "")
            {
                photo = this.hid_photo.Value;
            }

            model.pid = Convert.ToInt32(pid);
            model.title = fh.ToDBStr(this.edit_typename.Text);
            model.entitle = fh.ToDBStr(this.edit_enname.Text);
            model.fid = Convert.ToInt32(topid);
            model.content = this.productcontent.Value;
            model.encontent = "";
            model.photo = photo;
            model.orderid = Convert.ToInt32(webcom.GetMax("producttype"));
            model.text1 = "";
            model.text2 = "";
            model.text3 = "";
            model.text4 = "";
            model.id = Convert.ToInt32(id);

            bll.Update(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改类别成功！", "producttype.aspx?pid=" + pid + "&topid=" + topid);
        }

        protected void manageproductlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            BLL.producttype bll = new BLL.producttype();
            switch (e.CommandName)
            {
                case "Del":
                    bll.Delete(Convert.ToInt32(id));
                    break;
                case "Update":
                    Response.Redirect("producttype.aspx?pid=" + pid + "&topid=" + topid + "&action=edittype&id=" + id);
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
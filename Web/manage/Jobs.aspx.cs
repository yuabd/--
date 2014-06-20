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
    public partial class Jobs : System.Web.UI.Page
    {
        public String webshow = "", ComUrl = "", action = "", pid = "", id = "";
        webcommand webcom = new webcommand();
        FormatHtml fh = new FormatHtml();
        BLL.Jobs bll = new BLL.Jobs();
        Model.Jobs model = new Model.Jobs();
        FileControl fc = new FileControl();
        private string[] strUserP = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();
            BLL.manage ubll = new BLL.manage();
            strUserP = ubll.GetModel(Convert.ToInt32(Session["adminid"] + "")).adminlv.Split(',');
            action = Request.QueryString["action"];
            webshow = Request.QueryString["show"];
            pid = Request.QueryString["pid"];
            id = Request.QueryString["id"];
            ComUrl += "pid=" + pid;

            if (!bolAnswer(pid + "Add", strUserP))
            {
                Button2.Enabled = false;
                Button2.Attributes.Add("disabled", "disabled");
                Button1.Enabled = false;
                Button1.Attributes.Add("disabled", "disabled");
            }
            if (!bolAnswer(pid + "Del", strUserP))
            {
                delectmessage.Enabled = false;
                delectmessage.Attributes.Add("disabled", "disabled");
            }

            switch (action)
            {
                case "add"://添加招聘
                    break;

                case "edit":
                    if (!IsPostBack)
                    {
                        loadedit();
                    }
                    break;
                case "del":
                    DelInfo();
                    break;
                default://管理招聘
                    loadproductlist();//加载招聘列表
                    break;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            String filepath = "", filepathbig = "";

            //上传图片 小图 开始
            if (this.productphotobig1.HasFile)//当有图片的时候
            {
                filepath = fc.CreateSimPic(this.productphotobig1, "", 140, 105, 140, 105);
            }
            else
            {
                filepath = this.productphotobigid1.Value;
            }
            //上传图片 小图 开始
            if (this.productphotobig2.HasFile)//当有图片的时候
            {
                filepathbig = fc.CreateSimPic(this.productphotobig2, "", 230, 120, 230, 120);
            }
            else
            {
                filepathbig = this.productphotobigid2.Value;
            }
            Boolean isShow = false, isR = false;
            //判断是否显示招聘
            if (this.isShow.Checked)
            {
                isShow = true;
            }
            //判断是否推荐招聘
            if (this.isR.Checked)
            {
                isR = true;
            }
            model.pid = Convert.ToInt32(pid);
            model.CompanyName = txtCompanyName.Text;
            model.Title = txtTitle.Text;
            model.Num = txtNum.Text;
            model.Sex = "";
            model.Money = txtMoney.Text;
            model.TimeInfo = DateTime.Now;
            model.WorkExperience = txtWorkExperience.Text;
            model.Education = txtEducation.Text;
            model.JobDuration = txtJobDuration.Text;
            model.JobUnit = txtJobUnit.Text;
            model.Contact = txtContact.Text;
            model.ContactTel = txtContactTel.Text;
            model.WorkAdd = txtWorkAdd.Text;
            model.JobDescription = txtJobDescription.Text;
            model.isShow = isShow;
            model.SPic = filepath;
            model.BPic = filepathbig;
            model.isRecommend = isR;
            model.Content = fh.ToDBStr(Content.Value);
            model.ContactUs = fh.ToDBStr(ContactUs.Value);
            model.CompanyProfile = fh.ToDBStr(CompanyProfile.Value);
            if (action == "add")
            {
                bll.Add(model);
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加数据成功！", "Jobs.aspx?" + ComUrl + "&action=manage&show=" + webshow);
            }
            else
            {
                model.id = Convert.ToInt32(id);
                bll.Update(model);
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改数据成功！", "Jobs.aspx?" + ComUrl + "&action=manage&show=" + webshow);
            }

        }

        //显示数据时 调用
        protected void loadproductlist()
        {

            DataSet ds = bll.GetList(" order by id desc");

            //分页 开始
            int curpage;//当前分页
            if (Request.QueryString["page"] != null && Convert.ToInt32(Request.QueryString["page"]) > 0)
            {
                curpage = Convert.ToInt32(Request.QueryString["page"]);
            }
            else
            {
                curpage = 1;
            }

            String manageString = "&action=manage&show=" + webshow;
            PagedDataSource ps = new PagedDataSource();//创建分页实例
            ps.DataSource = ds.Tables[0].DefaultView;//绑定分页的数据源
            ps.AllowPaging = true; //是否启用分页功能
            ps.PageSize = 15;//每页显示的条数

            this.nowpage.Text = curpage.ToString();//当前页
            this.allpage.Text = ps.PageCount.ToString();//总页数

            this.pagenum.Text = ps.PageSize.ToString();//每页显示的条数
            this.totalpage.Text = ps.DataSourceCount.ToString();//数据的总数
            ps.CurrentPageIndex = curpage - 1;//设置当前页的索引


            this.manageproductlist.DataSource = ps;//将数据源与控件绑定
            this.manageproductlist.DataBind();//绑定数据源  

            //上一页
            if (!ps.IsFirstPage)
            {

                this.homepage.NavigateUrl = Request.CurrentExecutionFilePath + "?" + ComUrl + "&page=1" + manageString;
                this.prepage.NavigateUrl = Request.CurrentExecutionFilePath + "?" + ComUrl + "&page=" + Convert.ToString(curpage - 1) + manageString;
            }

            //下一页
            if (!ps.IsLastPage)
            {
                this.endpage.NavigateUrl = Request.CurrentExecutionFilePath + "?" + ComUrl + "&page=" + Convert.ToString(ps.PageCount) + manageString;
                this.nextpage.NavigateUrl = Request.CurrentExecutionFilePath + "?" + ComUrl + "&page=" + Convert.ToString(curpage + 1) + manageString;
            }

            //分页 结束

        }

        #region 删除数据

        protected void DelInfo()
        {
            bll.Delete(Convert.ToInt32(id));
            MessageBox.ShowAndRedirect(this, "删除数据成功！", "Jobs.aspx?" + ComUrl + "&action=manage&show=" + webshow);
        }

        #endregion

        protected void delectmessage_Click(object sender, EventArgs e)
        {
            bll.DeleteList(Request.Form["selectmessage"]);
            MessageBox.ShowAndRedirect(this, "删除数据成功！", "Jobs.aspx?" + ComUrl + "&action=manage&show=" + webshow);
        }

        //当处于修改数据时调用 
        protected void loadedit()
        {
            model = bll.GetModel(Convert.ToInt32(id));
            txtCompanyName.Text = model.CompanyName;
            txtTitle.Text = model.Title;
            txtNum.Text = model.Num;
            txtMoney.Text = model.Money;
            txtWorkExperience.Text = model.WorkExperience;
            txtEducation.Text = model.Education;
            txtJobDuration.Text = model.JobDuration;
            txtJobUnit.Text = model.JobUnit;
            txtContact.Text = model.Contact;
            txtContactTel.Text = model.ContactTel;
            txtWorkAdd.Text = model.WorkAdd;
            txtJobDescription.Text = model.JobDescription;
            ContactUs.Value = model.ContactUs;
            CompanyProfile.Value = model.CompanyProfile;
            String _photo1 = model.SPic;
            if (_photo1 != "" && _photo1 != "nophoto")
            {
                this.show_photo1.Text = "<img src='/UploadFile/Spic/" + _photo1 + "' height='80px' />";
                productphotobigid1.Value = _photo1;
            }
            String _photo2 = model.BPic;
            if (_photo2 != "" && _photo2 != "nophoto")
            {
                this.show_photo2.Text = "<img src='/UploadFile/Spic/" + _photo2 + "' height='80px' />";
                productphotobigid2.Value = _photo2;
            }
            if (Convert.ToBoolean(model.isShow) == true)
            {
                isShow.Checked = true;//判断显示或者隐藏
            }
            else
            {
                isShow.Checked = false;
            }
            Content.Value = model.Content;
            Button1.Text = "修改信息";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Jobs.aspx?" + ComUrl + "&action=add");
        }

        protected void manageproductlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            BLL.Jobs bll = new BLL.Jobs();
            switch (e.CommandName)
            {
                case "isShow":
                    bll.Update(" isShow=False ", " id=" + id + " ");
                    break;
                case "Show":
                    bll.Update(" isShow=True ", " id=" + id + " ");
                    break;
                case "Del":
                    bll.Delete(Convert.ToInt32(id));
                    break;
                case "Update":
                    Response.Redirect("Jobs.aspx?" + ComUrl + "&action=edit&show=" + webshow + "&id=" + id);
                    break;
            }
            loadproductlist();
        }

        protected void manageproductlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                System.Data.DataRowView view = (System.Data.DataRowView)e.Item.DataItem;
                bool isShow = Convert.ToBoolean(view["isShow"]);
                LinkButton btn = (LinkButton)e.Item.FindControl("Lbtn_Show");
                if (!bolAnswer(pid + "Update", strUserP))
                {
                    btn.Enabled = false;
                    btn.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    if (isShow)
                    {
                        btn.Text = "屏蔽";
                        btn.CommandName = "isShow";
                    }
                    else
                    {
                        btn.Text = "显示";
                        btn.CommandName = "Show";
                    }
                }
                btn = (LinkButton)e.Item.FindControl("lbtn_Del");
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
    }
}
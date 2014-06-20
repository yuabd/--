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
    public partial class ManageList : System.Web.UI.Page
    {
        BLL.manage bll = new BLL.manage();
        Model.manage model = new Model.manage();
        webcommand webcom = new webcommand();
        protected String pid = "";
        private string[] strUserP = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            webcommand.CheckUserLogin();
            BLL.manage ubll = new BLL.manage();
            strUserP = ubll.GetModel(Convert.ToInt32(Session["adminid"] + "")).adminlv.Split(',');
            pid = Request.QueryString["pid"];
            this.delectmessage.Attributes.Add("onclick", "zConfirm()");
            if (!bolAnswer(pid + "Add", strUserP))
            {
                delectmessage.Enabled = false;
                delectmessage.Attributes.Add("disabled", "disabled");
            }
            String action = Request.QueryString["action"];

            if (!IsPostBack)
            {
                switch (action)
                {
                    default:
                        loadproductlist();//加载产品列表
                        break;
                }
            }
        }


        //显示数据时 调用
        protected void loadproductlist()
        {

            String sql = "select  * from manage order by id desc";
            DataSet ds = DbHelperOleDb.Query(sql);

            //分页 开始
            int curpage;//当前分页
            if (Request.QueryString["page"] != null && Request.QueryString["page"] != "")
            {
                curpage = Convert.ToInt32(Request.QueryString["page"]);
            }
            else
            {
                curpage = 1;
            }

            String manageString = "&action=manage&pid=" + pid;
            PagedDataSource ps = new PagedDataSource();//创建分页实例
            ps.DataSource = ds.Tables[0].DefaultView;//绑定分页的数据源
            ps.AllowPaging = true; //是否启用分页功能
            ps.PageSize = 10;//每页显示的条数

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

                this.homepage.NavigateUrl = Request.CurrentExecutionFilePath + "?page=1" + manageString;
                this.prepage.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(curpage - 1) + manageString;
            }

            //下一页
            if (!ps.IsLastPage)
            {
                this.endpage.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(ps.PageCount) + manageString;
                this.nextpage.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(curpage + 1) + manageString;
            }

            //分页 结束

        }
        protected void delectmessage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx?pid=" + pid);
        }

        protected void manageproductlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            BLL.manage bll = new BLL.manage();
            switch (e.CommandName)
            {
                case "Locking":
                    bll.Update(" intStatus=1 ", " id=" + id + " ");
                    break;
                case "Lock":
                    bll.Update(" intStatus=0 ", " id=" + id + " ");
                    break;
                case "Del":
                    bll.Delete(Convert.ToInt32(id));
                    break;
                case "Update":
                    Response.Redirect("resetpassword.aspx?pid=" + pid + "&Uid=" + id);
                    break;
                case "Purview":
                    Response.Redirect("SitePurview.aspx?pid=" + pid + "&Uid=" + id);
                    break;
            }
            loadproductlist();
        }

        protected void manageproductlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                System.Data.DataRowView view = (System.Data.DataRowView)e.Item.DataItem;
                int intStatus = Convert.ToInt32(view["intStatus"]);
                int intType = Convert.ToInt32(view["intType"]);
                LinkButton btn = (LinkButton)e.Item.FindControl("lbtn_Del");
                if (intType == 0)
                {
                    btn.Enabled = false;
                    btn.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    if (!bolAnswer(pid + "Del", strUserP))
                    {
                        btn.Enabled = false;
                        btn.Attributes.Add("disabled", "disabled");
                    }
                    else
                        btn.Attributes.Add("onclick", "javascript:return confirm('您确定要删除此信息？删除后将不可恢复！')");
                }
                btn = (LinkButton)e.Item.FindControl("lbtn_Locking");
                if (intType == 0)
                {
                    btn.Enabled = false;
                    btn.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    if (!bolAnswer(pid + "Update", strUserP))
                    {
                        btn.Enabled = false;
                        btn.Attributes.Add("disabled", "disabled");
                    }
                    else
                    {
                        if (intStatus == 0)
                        {
                            btn.Text = "锁定";
                            btn.CommandName = "Locking";
                        }
                        else
                        {
                            btn.Text = "启用";
                            btn.CommandName = "Lock";
                        }
                    }
                }
                btn = (LinkButton)e.Item.FindControl("lbtn_Update");
                if (intType == 0)
                {
                    btn.Enabled = false;
                    btn.Attributes.Add("disabled", "disabled");
                }
                else if (!bolAnswer(pid + "Update", strUserP))
                {
                    btn.Enabled = false;
                    btn.Attributes.Add("disabled", "disabled");
                }
                //btn = (LinkButton)e.Item.FindControl("lbtn_Purview");
                //if (intType == 0)
                //{
                //    btn.Enabled = false;
                //    btn.Attributes.Add("disabled", "disabled");
                //}
                //else if (!bolAnswer(pid + "Update", strUserP))
                //{
                //    btn.Enabled = false;
                //    btn.Attributes.Add("disabled", "disabled");
                //}
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
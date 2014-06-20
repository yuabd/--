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
    public partial class FeedBack : System.Web.UI.Page
    {
        BLL.FeedBack bll = new BLL.FeedBack();
        Model.FeedBack model = new Model.FeedBack();
        webcommand webcom = new webcommand();
        protected String pid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            webcommand.CheckUserLogin();
            pid = Request.QueryString["pid"];
            this.delectmessage.Attributes.Add("onclick", "zConfirm()");

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

            String sql = "select  * from FeedBack where  pid=" + pid + " order by id desc";
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
            bll.DeleteList(Request.Form["selectmessage"]);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "删除数据成功！", "FeedBack.aspx?pid=" + pid);
        }

    }
}
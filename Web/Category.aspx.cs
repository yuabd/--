using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;

namespace Song.Web
{
    public partial class Category : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            bindData();
        }


        protected void bindData()
        {
            string id = Request.QueryString["id"];
            webcommand webcom = new webcommand();
            
            BLL.news bll = new BLL.news();
            System.Text.StringBuilder sqlStr = new System.Text.StringBuilder();

            sqlStr.Append(" pid=" + id + " ");
            DataTable dt = bll.GetList(sqlStr.ToString()).Tables[0];
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 24;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            int count = dt.Rows.Count;//记录数
            AspNetPager1.RecordCount = count;
            this.Repeater1.DataSource = pds;
            this.Repeater1.DataBind();
            dt.Dispose();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindData();
        }
    }
}
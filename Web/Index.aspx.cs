using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.OleDb;

namespace Song.Web
{
    public partial class Index : System.Web.UI.Page
    {
        public int d = 1, w = 1, m = 1, margin0 = 1;
        public string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HotSlider();
            bindData();
        }

        protected void HotSlider()
        {
            webcommand webcom = new webcommand();
            
            BLL.news bll = new BLL.news();
            System.Text.StringBuilder sqlStr = new System.Text.StringBuilder();

            sqlStr.Append(" order by hit desc");

            var dr = bll.GetReader(5, sqlStr.ToString());
            DataTable dt = new DataTable();
            dt.Load(dr);
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();

            this.Repeater2.DataSource = dt;
            this.Repeater2.DataBind();

            //按日获取热门
            var dr1 = bll.GetReader(10, " and timeinfo >= format(now(),'yyyy-mm-dd 00:00:00') and timeinfo <= format(now(),'yyyy-mm-dd 23:59:59') order by hit desc");
            this.Repeater4.DataSource = dr1;
            this.Repeater4.DataBind();
            //获取一周热门
            var dr2 = bll.GetReader(10, " and timeinfo >= format(dateAdd('d',-7, now()),'yyyy-mm-dd 00:00:00') and timeinfo <= format(now(),'yyyy-mm-dd 23:59:59') order by hit desc");
            this.Repeater5.DataSource = dr2;
            this.Repeater5.DataBind();
            //获取一月热门
            var dr3 = bll.GetReader(10, " and timeinfo >= format(dateAdd('m',-1, now()),'yyyy-mm-dd 00:00:00') and timeinfo <= format(now(),'yyyy-mm-dd 23:59:59') order by hit desc");
            this.Repeater6.DataSource = dr3;
            this.Repeater6.DataBind();
        }

        protected void bindData()
        {
            webcommand webcom = new webcommand();
            String key = Request.QueryString["key"];
            System.Text.StringBuilder sqlWhere = new System.Text.StringBuilder();
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            System.Text.StringBuilder sqlStr = new System.Text.StringBuilder();
            sql.Append("select count(id) from news where 1=1 ");

            //if (pid != null && pid != "")
            //{
            //    sqlWhere.Append(" and pid=" + pid);
            //}

            //if (keyword != null && keyword != "")
            //{
            //    sqlWhere.Append(" and title like '%" + Server.UrlDecode(keyword) + "%' ");
            //}

            sql.Append(sqlWhere.ToString());
            int CountData = Convert.ToInt32(DbHelperOleDb.GetScalar(sql.ToString()));//当前总条数
            int CurrentPage = this.AspNetPager1.CurrentPageIndex;//当前页
            //curpage = Convert.ToString(CurrentPage);
            //totalpage = AspNetPager1.PageCount.ToString();//总页数
            this.AspNetPager1.RecordCount = CountData;
            int pageIndex = CurrentPage - 1;
            int pageSize = this.AspNetPager1.PageSize = 12;

            this.AspNetPager1.RecordCount = CountData;
            this.AspNetPager1.PageSize = 12;

            if (CountData == 0)
            {
                this.nolist.Text = "· 抱歉，暂无相关信息！";
            }
            if (pageIndex == 0)
            {
                sqlStr.Append("select top " + pageSize.ToString() + " id,title,newstype,photo,content,isShow,timeinfo,orderid from news where 1=1  ");
            }
            else
            {
                sqlStr.Append("select top " + pageSize.ToString() + " id,title,newstype,photo,content,isShow,timeinfo,orderid from news where id not in( select top " + Convert.ToString(pageIndex * pageSize) + " id from news where 1=1 " + Convert.ToString(sqlWhere) + "  order by orderid desc, id desc )   ");
            }

            var dr = DbHelperOleDb.ExecuteReader(sqlStr.ToString());
            var dt = new DataTable();
            dt.Load(dr);
            Repeater3.DataSource = dt;
            Repeater3.DataBind();
        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindData();
        }
    }
}
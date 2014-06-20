using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.DBUtility;

namespace Song.Web
{
    public partial class Detail : System.Web.UI.Page
    {
        public Song.Model.ClassManage nav = new Model.ClassManage();
        public Song.Model.news news = new Model.news();
        //public BLL.news news = new BLL.news();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetNews();
            //nav = GetNav();
        }

        void GetNews()
        {
            var id = Request.QueryString["id"].Uint();

            news = new BLL.news().GetModel(id);
            
            if (news != null)
            {
                //news.hit += 1;

                //new BLL.news().Update(news);

                var str = "update news set hit = hit + 1 where id = " + id;
                DbHelperOleDb.ExecuteSql(str);

                nav = new BLL.ClassManage().GetModel(news.pid.Uint());
            }
        }
    }
}
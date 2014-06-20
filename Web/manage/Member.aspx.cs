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
    public partial class Member : System.Web.UI.Page
    {
        webcommand webcom = new webcommand();
        BLL.WebUser bll = new BLL.WebUser();
        protected String pid = "", id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();

            String action = Request.QueryString["action"];
            id = Request.QueryString["id"];
            pid = Request.QueryString["pid"];

            if (!IsPostBack)
            {
                switch (action)
                {
                    case "delete":
                        loaddeletetype();
                        break;
                    case "check":
                        CheckUser();
                        break;
                    case "uncheck":
                        unCheckUser();
                        break;
                    default:
                        loadtypelist();
                        break;
                }

            }

        }

        protected void loadtypelist() //加载链接列表
        {
            DataSet ds = bll.GetList("");
            this.linklist.DataSource = ds;
            this.linklist.DataBind();//绑定数据
        }

        #region 审核会员

        protected void CheckUser()
        {
            if (id != null && id != "")
            {
            DbHelperOleDb.Query("update webuser set userstate=true where id=" + id);
            MessageBox.ShowAndRedirect(this, "操作成功！", "Member.aspx");
            }
        }

        #endregion

        #region 审核会员

        protected void unCheckUser()
        {
            if (id != null && id != "")
            {
                DbHelperOleDb.Query("update webuser set userstate=false where id=" + id);
                MessageBox.ShowAndRedirect(this, "操作成功！", "Member.aspx");
            }
        }

        #endregion


        public void loaddeletetype()//删除链接
        {
            if (id != null && id != "")
            {
             bll.Delete(Convert.ToInt32(id));
             MessageBox.ShowAndRedirect(this, "删除链接成功！", "Member.aspx");
            }
        }
    }
}
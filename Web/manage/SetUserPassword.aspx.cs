using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.DBUtility;

namespace Song.Web.manage
{
    public partial class SetUserPassword : System.Web.UI.Page
    {
        webcommand webcom = new webcommand();
        public string strID = "0", pid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();
            if (!string.IsNullOrEmpty(Request.QueryString["Uid"]))
                strID = Request.QueryString["Uid"];

            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                pid = Request.QueryString["pid"];
            if (!IsPostBack)
            {
                binUserInfo();
            }
        }

        void binUserInfo()
        {
            BLL.WebUser bll = new BLL.WebUser();
            Model.WebUser model = new Model.WebUser();
            model = bll.GetModel(Convert.ToInt32(strID));
            if (model != null)
            {
                txtLoginName.Text = model.email;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            String curadmin = webcommand.GetAdminName();
            String newpassword = this.newpassword.Text.Trim();//新密码
            newpassword = webcom.FormatPwd(newpassword);
            String sql = " ";
            if (strID != null && strID != "" && Convert.ToInt32(strID) > 0)
            {
                sql = "update WebUser set [password]='" + newpassword + "' where id = " + strID + " ";
                DbHelperOleDb.ExecuteSql(sql);
                MessageBox.ShowAndRedirect(this, "修改成功！", "Member.aspx?pid=" + pid);
            }
            else
            {
                MessageBox.ShowAndRedirect(this, "抱歉，修改失败！", "SetUserPassword.aspx?pid=" + pid + "&Uid=" + strID);
            }

        }
    }
}
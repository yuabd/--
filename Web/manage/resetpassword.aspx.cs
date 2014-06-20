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
    public partial class resetpassword : System.Web.UI.Page
    {
        webcommand webcom = new webcommand();
        public string strID = "0", pid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();
            if (!string.IsNullOrEmpty(Request.QueryString["Uid"]))
                strID = Request.QueryString["Uid"];
            else if (!string.IsNullOrEmpty(Session["adminid"] + ""))
                strID = Session["adminid"] + "";
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                pid = Request.QueryString["pid"];
            if (!IsPostBack)
            {
                binUserInfo();
            }
        }

        void binUserInfo()
        {
            BLL.manage bll = new BLL.manage();
            Model.manage model = new Model.manage();
            model = bll.GetModel(Convert.ToInt32(strID));
            if (model != null)
            {
                txtName.Text = model.strName;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            String curadmin = webcommand.GetAdminName();
            String strName = this.txtName.Text.Trim();//姓名
            String newpassword = this.txtnewpassword.Text.Trim();//新密码

            newpassword = webcom.FormatPwd(newpassword);

            String sql = " ";
            if (strID != null && strID != "" && Convert.ToInt32(strID) > 0)
            {
                if (!string.IsNullOrEmpty(txtnewpassword.Text.Trim()))
                    sql = "update manage set strName='" + txtName.Text + "',adminpassword ='" + newpassword + "' where id = " + strID + " ";
                else
                    sql = "update manage set strName='" + txtName.Text + "' where id = " + strID + " ";
                DbHelperOleDb.ExecuteSql(sql);
                MessageBox.ShowAndRedirect(this, "修改成功！", "ManageList.aspx?pid=" + pid);
            }
            else
            {
                MessageBox.ShowAndRedirect(this, "抱歉，修改失败！", "resetpassword.aspx?pid=" + pid + "&Uid=" + strID);
            }

        }
    }
}
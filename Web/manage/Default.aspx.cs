using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Song.Web.manage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FormatHtml fh = new FormatHtml();
                //webcommand webcom = new webcommand();
                //String adminname = fh.NoHTML("admin");
                //String adminpassword = webcom.FormatPwd(fh.NoHTML("admin"));
                //String code = fh.NoHTML(this.CheckCode.Text.Trim());
                //webcom.CheckUserPwd(adminname, adminpassword, "Main.aspx", "Default.aspx", "admin");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormatHtml fh = new FormatHtml();
            webcommand webcom = new webcommand();
            String adminname = fh.NoHTML(this.username.Text.Trim());
            String adminpassword = webcom.FormatPwd(fh.NoHTML(this.password.Text.Trim()));
            String code = fh.NoHTML(this.CheckCode.Text.Trim());
            if (String.Compare(Request.Cookies["CheckCode"].Value, code, true) != 0)
            {
                Page.RegisterStartupScript("", "<script>alert('抱歉！您输入的验证码错误，请重新输入！');</script>");
            }
            else
            {
                webcom.CheckUserPwd(adminname, adminpassword, "Main.aspx", "Default.aspx", "admin");//检查登录
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //webcommand.Alert("", "Default.aspx");
        }
    }
}
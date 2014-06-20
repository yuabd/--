using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace Song.Web.manage
{
    public partial class AddUser : System.Web.UI.Page
    {
        public string pid = "0";
        webcommand webcom = new webcommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                pid = Request.QueryString["pid"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.manage bll = new BLL.manage();
            Model.manage model = new Model.manage();
            model.adminname = txtLoginName.Text.Trim();
            model.adminpassword = webcom.FormatPwd(txtnewpassword.Text.Trim());
            model.adminlv = "";
            model.regtime = DateTime.Now;
            model.weblanguage = "en";
            model.strName = txtName.Text;
            model.strLoginIP = "——";
            model.dtmLoginTime = DateTime.Now;
            model.intStatus = 0;
            model.intLoginNum = 0;
            model.intType = 1;
            bll.Add(model);
            MessageBox.ShowAndRedirect(this, "修改成功！", "ManageList.aspx?pid=" + pid);
        }
    }
}
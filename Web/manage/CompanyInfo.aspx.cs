using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Maticsoft.Common;
using Maticsoft.DBUtility;

namespace Song.Web.manage
{
    public partial class CompanyInfo : System.Web.UI.Page
    {
        webcommand webcom = new webcommand();
        FileControl fc = new FileControl();
        BLL.companyInformation bll = new BLL.companyInformation();
        Model.companyInformation model = new Model.companyInformation();
        public String pid = "", ClassName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();
            pid = Request.QueryString["pid"];
            //ClassName = webcom.GetClassName(pid);
            //this.menuname.Text = ClassName;
 
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }
 
        protected void LoadInfo()
        {
            model = bll.GetModel(pid);
            if (model != null)
            {
                this.menuname.Text = model.menuname;
                this.information.Value = model.information;
                this.key1.Value = model.infocn;
                this.key2.Value = model.weblanguage;
                this.updatetime.Text = model.updateTime.ToString();
                this.hid_pic.Value = model.pic;
                if (model.pic != null && model.pic != "" && model.pic != "nophoto")
                {
                    this.show_Pic.Text = "<img src='/UploadFile/Spic/"+ model.pic +"' height='60px' />";
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //查询该ID是否存在
            String sql = " select count(id) from companyInformation Where pid=" + pid;
            String _isSave = DbHelperOleDb.GetScalar(sql);

            FormatHtml fh = new FormatHtml();
            model.id = Convert.ToInt32(pid);
            model.pid = Convert.ToInt32(pid);
            model.menuname = fh.ToDBStr(this.menuname.Text);
            model.information = fh.ToDBStr(this.information.Value);
            model.infocn = fh.ToDBStr(this.key1.Value);
            model.updateTime = DateTime.Now;
            model.weblanguage = key2.Value;

            if (this.Pic.HasFile)
            {
                model.pic = fc.CreateSimPic(this.Pic, "");
            }
            else
            {
                model.pic = this.hid_pic.Value;
            }

            if ( Convert.ToInt32(_isSave)>0 )
            {
                //修改
                bll.Update(model);
                MessageBox.ShowAndRedirect(this, "保存成功！", "?pid=" + pid);
            }
            else
            {
                //添加
                bll.Add(model);
                MessageBox.ShowAndRedirect(this, "保存成功！", "?pid=" + pid);
            }

        }

    }
}
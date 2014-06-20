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
    public partial class SystemFunction : System.Web.UI.Page
    {
        BLL.SystemFunction bll = new BLL.SystemFunction();
        Model.SystemFunction model = new Model.SystemFunction();
         FormatHtml fh = new FormatHtml();

        public String action = "", parm = "", bid = "", rid = "", id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查是否登录
            webcommand.CheckUserLogin();
            action = Request.QueryString["action"];//操作字符
            id = Request.QueryString["id"];

            switch (action) //判断操作列别 添加/修改/删除
            {
                case "edittype"://编辑
                    if (!IsPostBack)
                    {
                        loadedittype();
                        this.Submit1.Visible = true;
                    }
                    break;
                case "deletetype"://删除
                    loaddeletetype();
                    break;
                default:
                    loadtypelist();//返回列表
                    this.btAddInfo.Visible = true;
                    break;
            }

        }

        protected void loadtypelist() //加载类别列表
        {
            DataSet ds = bll.GetList("");
            this.NList.DataSource = ds;
            this.NList.DataBind();
        }

        public void loadedittype()
        {
            model = bll.GetModel(id);
            this.title.Text = model.title;
            this.url.Text = model.url;
        }

        public void loaddeletetype()//删除类别
        {
            String sql = "delete from SystemFunction where id = " + id;
            DbHelperOleDb.Query(sql);
            this.Page.RegisterStartupScript("", "<script>alert('删除功能成功');window.location.href = '?bid=" + bid + "'</script>");
        }

        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
            model.id = Convert.ToInt32(id);
            model.title = fh.ToDBStr(this.title.Text);
            model.url = fh.ToDBStr(this.url.Text);
            model.isShow = "1";
            model.info = "";

            bll.Update(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "?bid=" + bid + "");
        }
        protected void btAddInfo_ServerClick(object sender, EventArgs e)
        {
            model.id = Convert.ToInt32(id);
            model.title = fh.ToDBStr(this.title.Text);
            model.url = fh.ToDBStr(this.url.Text);
            model.isShow = "1";
            model.info = "";

            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加成功！", "?bid=" + bid + "");
        }
    }
}
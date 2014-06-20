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
    public partial class FieldRunList : System.Web.UI.Page
    {
        webcommand webcom = new webcommand();
        BLL.FieldRule bll = new BLL.FieldRule();
        Model.FieldRule model = new Model.FieldRule();
        public String CurFunction = "", id = "", action="";
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查是否登录
            webcommand.CheckUserLogin();

            action = Request.QueryString["action"];
            id = Request.QueryString["id"];
            CurFunction = Request.QueryString["fun"];
            if (CurFunction == null || CurFunction == "")
            {
                CurFunction = this.FunctionList.SelectedValue;
            }

            ShowPanel(CurFunction);//显示对应模块

            if (!IsPostBack)
            {
                switch (action)
                {
                    case "add":
                        BindList();
                        loadadd();
                        break;
                    case "edit":
                        BindList();
                        loadedit();
                        break;
                    case "del":
                        loaddel();
                        break;
                    default:
                        loadpower();
                        break;
                }
            }
        }


        protected void loadedit()
        {

            model = bll.GetModel(id);
            this.zuname.Value =  model.RuleName;
            this.curstate.Value = "edit";
            this.curid.Value = id;
            this.Button1.Value = "修 改";
        }

        #region 绑定下拉框

        protected void BindList()
        {
            String sql = "select * from SystemFunction ";
            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(sql);
            webcom.BindDropDownList(this.FunctionList, dr, "title", "id", "--请选择功能--");
            dr.Close();
            dr.Dispose();

            if (CurFunction != null && CurFunction != "")
            {
                this.FunctionList.SelectedValue = CurFunction;
                BindList(CurFunction);
            }
            dr.Close();
            dr.Dispose();
        }

        #endregion


        #region 删除组别

        protected void loaddel()
        {
            if (id != null && id != "")
            {
                bll.Delete(id);
            }
        }

        #endregion


        protected void loadadd()
        {
            this.curstate.Value = "add";
        }

        //显示权限列表时，隐藏部分字段
        protected void loadpower()
        {
            this.addrule.Visible = false;
            this.Button1.Visible = false;
            this.Label1.Text = "您的具体权限为：";
        }

        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            String fun = this.FunctionList.SelectedValue;
            String power = Request.Form["power"];
            if (power != null && power != "")
            {
                power = "|" + power.Replace(',', '|') + "|";
            }

            FormatHtml fh = new FormatHtml();
            String rulename = fh.NoHTML(this.zuname.Value.Trim());
            
            model.RuleName = rulename;
            model.RulePower = power;
            model.xmlname = "";
            model.RuleType = this.FunctionList.SelectedValue;

            if (action == "add")
            {
                bll.Add(model);
                MessageBox.ShowAndRedirect(this, "添加字段组成功！", "FieldRunList.aspx?action=add&fun=" + fun + "&id=" + id);
            }
            else
            {
                model.id = Convert.ToInt32(id);
                bll.Update(model);
                MessageBox.ShowAndRedirect(this, "修改字段组成功！", "FieldRunList.aspx?action=add&fun=" + fun + "&id=" + id);
            }

        }

        public String ReturnCheck(String key)
        {
            ManageCom mc = new ManageCom();
            return mc.ReturnCheck(key, "checkbox");
        }


        protected void FunctionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String function = this.FunctionList.SelectedValue;
            ShowPanel(function);//显示对应模块
            this.zuname.Value = "";//清空组名称
            CurFunction = function;//重新复制
            this.FunctionList.SelectedValue = function;
            BindList(function);

        }

        //绑定组别列表
        protected void BindList(String fun)
        {
            String sql = "select * from FieldRule where RuleType = '" + fun + "' ";
            webcom.BindReaderControl(this.productlist, sql);//绑定数据列表
        }

        #region 显示对应模块

        protected void ShowPanel(String fun)
        {
            SetControl();//设置控件
            if (fun != "")
            {
                switch (fun)
                {

                    case "3":
                        this.panel_news.Visible = true;//新闻管理
                        break;
                    case "4":
                        this.panel_product.Visible = true;//产品管理
                        break;

                }
            }
        }

        #endregion

        #region 设置当前页面控件

        protected void SetControl()
        {
            int nControl = Page.Controls.Count;
            for (int i = 0; i < nControl; i++)
            {
                foreach (System.Web.UI.Control control in Page.Controls[i].Controls)
                {
                    if (control is Panel)
                    {
                        (control as Panel).Visible = false;//隐藏所有Panel控件
                    }
                }
            }
        }

        #endregion
    }
}
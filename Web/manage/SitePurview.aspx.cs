using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Collections;

namespace Song.Web.manage
{
    public partial class SitePurview : System.Web.UI.Page
    {
        public string strUid = "0", pid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                pid = Request.QueryString["pid"];
            if (!string.IsNullOrEmpty(Request.QueryString["Uid"]))
                strUid = Request.QueryString["Uid"];
        }

        public string binClass()
        {
            BLL.manage ubll = new BLL.manage();
            string[] strUserP = ubll.GetModel(Convert.ToInt32(strUid)).adminlv.Split(',');
            System.Text.StringBuilder strTemplate = new System.Text.StringBuilder();
            BLL.ClassManage bll = new BLL.ClassManage();
            List<Model.ClassManage> modelList = new List<Model.ClassManage>();
            modelList = bll.GetModelList(" and Fid=0 order by orderid ");

            foreach (Model.ClassManage model in modelList)
            {
                string NodeID = bll.GetNodeID(model.id);
                strTemplate.Append("<tr><td align=\"left\"><img src=\"images/ftv2node.gif\" onclick=\"Stretch(this, '" + NodeID + "')\" />" + model.ClassName);
                if (bolAnswer(model.id + "Select", strUserP))
                    strTemplate.Append("</td><td align=\"left\"><input id=\"" + model.id + "Select\" name=\"Setcheckbox\" value=\"" + model.id + "Select\" checked=\"checked\" onclick=\"AllCheck(this,'" + model.id + "','" + NodeID + "')\" type=\"checkbox\" />访问&nbsp;&nbsp;&nbsp;&nbsp;");
                else
                    strTemplate.Append("</td><td align=\"left\"><input id=\"" + model.id + "Select\" name=\"Setcheckbox\" value=\"" + model.id + "Select\" onclick=\"AllCheck(this,'" + model.id + "','" + NodeID + "')\" type=\"checkbox\" />访问&nbsp;&nbsp;&nbsp;&nbsp;");
                if (bolAnswer(model.id + "Add", strUserP))
                    strTemplate.Append("<input id=\"" + model.id + "Add\" name=\"Setcheckbox\" value=\"" + model.id + "Add\" type=\"checkbox\" checked=\"checked\" onclick=\"SelectCheck('" + model.id + "Select')\"/>添加&nbsp;&nbsp;&nbsp;&nbsp;");
                else
                    strTemplate.Append("<input id=\"" + model.id + "Add\" name=\"Setcheckbox\" value=\"" + model.id + "Add\" type=\"checkbox\" onclick=\"SelectCheck('" + model.id + "Select')\"/>添加&nbsp;&nbsp;&nbsp;&nbsp;");
                if (bolAnswer(model.id + "Update", strUserP))
                    strTemplate.Append("<input id=\"" + model.id + "Update\" name=\"Setcheckbox\" value=\"" + model.id + "Update\" type=\"checkbox\" checked=\"checked\" onclick=\"SelectCheck('" + model.id + "Select')\"/>修改&nbsp;&nbsp;&nbsp;&nbsp;");
                else
                    strTemplate.Append("<input id=\"" + model.id + "Update\" name=\"Setcheckbox\" value=\"" + model.id + "Update\" type=\"checkbox\" onclick=\"SelectCheck('" + model.id + "Select')\"/>修改&nbsp;&nbsp;&nbsp;&nbsp;");
                if (bolAnswer(model.id + "Del", strUserP))
                    strTemplate.Append("<input id=\"" + model.id + "Del\" name=\"Setcheckbox\" value=\"" + model.id + "Del\" type=\"checkbox\" checked=\"checked\" onclick=\"SelectCheck('" + model.id + "Select')\"/>删除</td></tr>");
                else
                    strTemplate.Append("<input id=\"" + model.id + "Del\" name=\"Setcheckbox\" value=\"" + model.id + "Del\" type=\"checkbox\" onclick=\"SelectCheck('" + model.id + "Select')\"/>删除</td></tr>");
                strTemplate.Append(BinNodeClass(model.id, strUserP));
            }
            return strTemplate.ToString();
        }

        private string BinNodeClass(int Fid, string[] strUserP)
        {
            System.Text.StringBuilder strTemplate = new System.Text.StringBuilder();
            BLL.ClassManage bll = new BLL.ClassManage();
            List<Model.ClassManage> modelList = new List<Model.ClassManage>();
            modelList = bll.GetModelList(" and Fid=" + Fid + " order by orderid ");
            foreach (Model.ClassManage model in modelList)
            {
                strTemplate.Append("<tr id=\"" + model.id + "\"><td align=\"left\"><img src=\"images/tree_Line.gif\" /><img src=\"images/tree_End.gif\" />" + model.ClassName);
                if (bolAnswer(model.id + "Select", strUserP))
                    strTemplate.Append("</td><td align=\"left\"><input id=\"" + model.id + "Select\" name=\"Setcheckbox\" value=\"" + model.id + "Select\" checked=\"checked\" onclick=\"SelfCheck(this,'" + model.id + "')\" type=\"checkbox\" />访问&nbsp;&nbsp;&nbsp;&nbsp;");
                else
                    strTemplate.Append("</td><td align=\"left\"><input id=\"" + model.id + "Select\" name=\"Setcheckbox\" value=\"" + model.id + "Select\" onclick=\"SelfCheck(this,'" + model.id + "')\" type=\"checkbox\" />访问&nbsp;&nbsp;&nbsp;&nbsp;");
                if (bolAnswer(model.id + "Add", strUserP))
                    strTemplate.Append("<input id=\"" + model.id + "Add\" name=\"Setcheckbox\" value=\"" + model.id + "Add\" type=\"checkbox\" checked=\"checked\" onclick=\"SelectCheck('" + model.id + "Select')\"/>添加&nbsp;&nbsp;&nbsp;&nbsp;");
                else
                    strTemplate.Append("<input id=\"" + model.id + "Add\" name=\"Setcheckbox\" value=\"" + model.id + "Add\" type=\"checkbox\" onclick=\"SelectCheck('" + model.id + "Select')\"/>添加&nbsp;&nbsp;&nbsp;&nbsp;");
                if (bolAnswer(model.id + "Update", strUserP))
                    strTemplate.Append("<input id=\"" + model.id + "Update\" name=\"Setcheckbox\" value=\"" + model.id + "Update\" type=\"checkbox\" checked=\"checked\" onclick=\"SelectCheck('" + model.id + "Select')\"/>修改&nbsp;&nbsp;&nbsp;&nbsp;");
                else
                    strTemplate.Append("<input id=\"" + model.id + "Update\" name=\"Setcheckbox\" value=\"" + model.id + "Update\" type=\"checkbox\" onclick=\"SelectCheck('" + model.id + "Select')\"/>修改&nbsp;&nbsp;&nbsp;&nbsp;");
                if (bolAnswer(model.id + "Del", strUserP))
                    strTemplate.Append("<input id=\"" + model.id + "Del\" name=\"Setcheckbox\" value=\"" + model.id + "Del\" type=\"checkbox\" checked=\"checked\" onclick=\"SelectCheck('" + model.id + "Select')\"/>删除");
                else
                    strTemplate.Append("<input id=\"" + model.id + "Del\" name=\"Setcheckbox\" value=\"" + model.id + "Del\" type=\"checkbox\" onclick=\"SelectCheck('" + model.id + "Select')\"/>删除");

                strTemplate.Append("</td></tr>");
            }
            return strTemplate.ToString();
        }

        protected void delectmessage_Click(object sender, EventArgs e)
        {
            BLL.manage bll = new BLL.manage();
            bll.Update(" adminlv='" + txtList.Text + "' ", " id=" + strUid + " ");
            MessageBox.ShowAndRedirect(this, "修改成功！", "ManageList.aspx?pid=" + pid);
        }

        public static bool bolAnswer(string answer, string[] correctList)
        {
            bool Correct = true;
            if (!((IList)correctList).Contains(answer))
            {
                Correct = false;
            }
            return Correct;
        }
    }
}
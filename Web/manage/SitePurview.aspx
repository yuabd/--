<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SitePurview.aspx.cs" Inherits="Song.Web.manage.SitePurview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站信息管理</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
    <script src="js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../inc/showdailog/Dialog.js"></script>
    <script type="text/javascript" src="../inc/showdailog/js.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="17" valign="top" background="images/mail_leftbg.gif">
                    <img src="images/left-top-right.gif" width="17" height="29" />
                </td>
                <td valign="top" background="images/content-bg.gif">
                    <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg"
                        id="table2">
                        <tr>
                            <td height="31">
                                <div class="titlebt">
                                    权限管理</div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="16" valign="top" background="images/mail_rightbg.gif">
                    <img src="images/nav-right-bg.gif" width="16" height="29" />
                </td>
            </tr>
            <tr>
                <td valign="middle" background="images/mail_leftbg.gif">
                    &nbsp;
                </td>
                <td valign="top" bgcolor="#F7F8F9">
                    <div class="k10">
                    </div>
                    <!--主体内容区 开始-->
                    <!-- 显示新闻列表 开始 -->
                    <table class="tablecss1">
                        <tr>
                            <td class="tabletop" colspan="2" style="height: 30px">
                                管理员权限管理
                            </td>
                        </tr>
                        <tr id="toptr1">
                            <td align="center" width="450px">
                                <strong>菜单名称</strong>
                            </td>
                            <td align="center">
                                <strong>对应权限</strong>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left">
                                <img src="images/ftv2node.gif" onclick="Stretch(this, '123,124')" />系统设置
                            </td>
                            <td align="left">
                                <input id="Checkbox1" type="checkbox" />访问&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Checkbox2" type="checkbox" />添加&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Checkbox3" type="checkbox" />修改&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Checkbox4" type="checkbox" />删除
                            </td>
                        </tr>
                        <tr id="123">
                            <td align="left">
                                <img src="images/tree_Line.gif" /><img src="images/ftv2node.gif" onclick="Stretch(this, '124')" />系统设置
                            </td>
                            <td align="left">
                                <input id="Checkbox5" type="checkbox" />访问&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Checkbox6" type="checkbox" />添加&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Checkbox7" type="checkbox" />修改&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Checkbox8" type="checkbox" />删除
                            </td>
                        </tr>
                        <tr id="124">
                            <td align="left">
                                <img src="images/tree_Line.gif" /><img src="images/tree_Line.gif" /><img src="images/tree_End.gif" />系统设置
                            </td>
                            <td align="left">
                                <input id="Checkbox9" type="checkbox" />访问&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Checkbox10" type="checkbox" />添加&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Checkbox11" type="checkbox" />修改&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Checkbox12" type="checkbox" />删除
                            </td>
                        </tr>--%>
                        <%=binClass() %>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button runat="server" Text="确认修改" ID="delectmessage" CssClass="inp1" OnClientClick="return checkbox()"
                                    OnClick="delectmessage_Click" />
                            </td>
                        </tr>
                    </table>
                    <!-- 显示新闻列表 结束 -->
                    <!--主体内容区 结束-->
                </td>
                <td background="images/mail_rightbg.gif">
                    &nbsp;<asp:TextBox ID="txtList" Style="display: none;" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="bottom" background="images/mail_leftbg.gif">
                    <img src="images/buttom_left2.gif" width="17" height="17" />
                </td>
                <td background="images/buttom_bgs.gif">
                    <img src="images/buttom_bgs.gif" width="17" height="17">
                </td>
                <td valign="bottom" background="images/mail_rightbg.gif">
                    <img src="images/buttom_right2.gif" width="16" height="17" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        function Stretch(o, trIDList) {
            var trid = trIDList.split(',');
            for (var i = 0; i < trid.length; i++) {
                $("#" + trid[i]).toggle(); //.hide();
            }
            if (o.src == "http://localhost:3448/manage/images/ftv2pnode.gif")
                o.src = "images/ftv2node.gif";
            else
                o.src = "images/ftv2pnode.gif";
        }

        function SelectCheck(boxid) {
            document.getElementById("" + boxid + "").checked = true;
        }

        function AllCheck(o, setID, trIDList) {
            document.getElementById("" + setID + "Add").checked = o.checked;
            document.getElementById("" + setID + "Update").checked = o.checked;
            document.getElementById("" + setID + "Del").checked = o.checked;
            if (trIDList != "") {
                var trid = trIDList.split(',');
                for (var i = 0; i < trid.length; i++) {
                    if (trid[i] == "0")
                        continue;
                    document.getElementById("" + trid[i] + "Select").checked = o.checked;
                    document.getElementById("" + trid[i] + "Add").checked = o.checked;
                    document.getElementById("" + trid[i] + "Update").checked = o.checked;
                    document.getElementById("" + trid[i] + "Del").checked = o.checked;
                }
            }
        }

        function SelfCheck(o, setID) {
            document.getElementById("" + setID + "Add").checked = o.checked;
            document.getElementById("" + setID + "Update").checked = o.checked;
            document.getElementById("" + setID + "Del").checked = o.checked;
        }

        function checkbox() {
            var str = document.getElementsByName("Setcheckbox");
            var objarray = str.length;
            var chestr = "";
            for (i = 0; i < objarray; i++) {
                if (str[i].checked == true) {
                    chestr += str[i].value + ",";
                }
            }
            if (chestr == "") {
                alert("您没有选择任何菜单！");
                return false;
            }
            else {
                $("#txtList").val(chestr);
            }
        }
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Song.Web.manage.Member" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员管理</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
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
                                    会员管理</div>
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
                    <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#eae3e4">
                        <tr>
                            <td style="height: 30px" colspan="5" class="tabletop">
                                信息链接管理
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <!-- 信息链接管理 开始 -->
                                <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#f7f7f7">
                                    <asp:Repeater ID="linklist" runat="server">
                                        <HeaderTemplate>
                                            <tr bgcolor="#F7F7F7" style="font-weight: bolder">
                                                <td height="30px" align="center">
                                                    ID
                                                </td>
                                                <td>
                                                    登录名/邮箱
                                                </td>
                                                <td>
                                                    手机号码
                                                </td>
                                                <td>
                                                    QQ号码
                                                </td>
                                                <td>
                                                    注册时间
                                                </td>
                                                <td>
                                                    操作
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td height="25" width="100px" align="center">
                                                    <%# Eval("id") %>
                                                </td>
                                                <td>
                                                    <%# Eval("email")%>
                                                </td>
                                                <td>
                                                    <%# Eval("mobile")%>
                                                </td>
                                                <td>
                                                    <%# Eval("qq")%>
                                                </td>
                                                <td>
                                                    <%# Eval("timeinfo")%>
                                                </td>
                                                <td width="130px" align="center">
                                                    <%# Convert.ToString(Eval("userstate")) == "True" ? "<a href='?action=uncheck&id=" + Convert.ToString(Eval("id")) + "'>已审核</a>" : "<a href='?action=check&id=" + Convert.ToString(Eval("id")) + "'>未审核</a>"%>
                                                    <a href="SetUserPassword.aspx?pid=<%=pid %>&Uid=<%# Eval("id") %>">
                                                        重置密码</a> <a href="?action=delete&id=<%# Eval("id") %>">删除</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <!-- 信息链接管理 结束 -->
                            </td>
                        </tr>
                    </table>
                    <!--主体内容区 结束-->
                </td>
                <td background="images/mail_rightbg.gif">
                    &nbsp;
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
</body>
</html>

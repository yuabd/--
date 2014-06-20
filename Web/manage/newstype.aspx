<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newstype.aspx.cs" Inherits="Song.Web.manage.newstype" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=ClassName%></title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
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
                                    <%=ClassName%></div>
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
                    <% if (action == "edittype")
                       { %>
                    <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#f7f7f7">
                        <tr>
                            <td class="tabletop" colspan="2" style="height: 30px">
                                信息类别修改
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                类别名称：
                            </td>
                            <td>
                                <asp:TextBox ID="edit_title" runat="server" Width="200px"></asp:TextBox><input type="hidden"
                                    name="curid" id="curid" runat="server" />
                            </td>
                        </tr>
                        <tr style="<%=shownew %>">
                            <td class="tdMargin">
                                版主寄语：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" Width="400px" TextMode="MultiLine" Height="71px"></asp:TextBox><input
                                    type="hidden" name="curid" id="Hidden1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="edit_button" runat="server" Text="确认修改" OnClick="edit_button_Click"
                                                CssClass="inp1" />
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <a href="#" onclick="history.back()">返回上一页</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <%}
                       else
                       { %>
                    <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#eae3e4">
                        <tr>
                            <td style="height: 30px" colspan="5" class="tabletop">
                                新闻类别管理
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <!-- 信息类别管理 开始 -->
                                <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#f7f7f7">
                                    <asp:Repeater ID="newstypelist" runat="server" OnItemCommand="manageproductlist_ItemCommand"
                                        OnItemDataBound="manageproductlist_ItemDataBound">
                                        <HeaderTemplate>
                                            <tr bgcolor="#F7F7F7" style="font-weight: bolder">
                                                <td height="30px" align="center">
                                                    ID
                                                </td>
                                                <td>
                                                    类别名称
                                                </td>
                                                <td align="center">
                                                    修改
                                                </td>
                                                <td align="center">
                                                    删除
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td height="25" width="100px" align="center">
                                                    <%# Eval("id") %>
                                                </td>
                                                <td width="400px">
                                                    <%# Eval("title")%>
                                                </td>
                                                <td width="100px" align="center">
                                                    <asp:LinkButton ID="lbtn_Update" CommandName="Update" CommandArgument='<%#Eval("id") %>'
                                                        runat="server">修改</asp:LinkButton>
                                                </td>
                                                <td width="100px" align="center">
                                                    <asp:LinkButton ID="lbtn_Del" CommandName="Del" CommandArgument='<%#Eval("id") %>'
                                                        runat="server">删除</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <!-- 信息类别管理 结束 -->
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" height="20" bgcolor="#f7f7f7">
                            </td>
                        </tr>
                        <tr style="font-weight: bolder">
                            <td width="50" class="tdMargin">
                                类别名称
                            </td>
                            <td>
                                <asp:TextBox ID="title" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="<%=shownew %>">
                                <%--排序--%>
                                版主寄语
                            </td>
                            <td style="<%=shownew %>">
                                <asp:TextBox ID="idorder" runat="server" Width="300px" Height="51px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="添加类别" OnClick="Button1_Click" CssClass="inp1" />
                            </td>
                        </tr>
                    </table>
                    <%} %>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageList.aspx.cs" Inherits="Song.Web.manage.ManageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站信息管理</title>
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
                                    管理员管理</div>
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
                            <td class="tabletop" colspan="8" style="height: 30px">
                                管理员管理
                            </td>
                        </tr>
                        <asp:Repeater ID="manageproductlist" runat="server" OnItemCommand="manageproductlist_ItemCommand"
                            OnItemDataBound="manageproductlist_ItemDataBound">
                            <HeaderTemplate>
                                <tr id="toptr1">
                                    <td align="center">
                                        选择
                                    </td>
                                    <td align="center">
                                        登录名
                                    </td>
                                    <td align="center">
                                        姓名
                                    </td>
                                    <td align="center">
                                        最后登录IP地址
                                    </td>
                                    <td align="center">
                                        最后登录时间
                                    </td>
                                    <td align="center">
                                        登录次数
                                    </td>
                                    <td align="center">
                                        状态
                                    </td>
                                    <td align="center" width="15%">
                                        操作
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="trcss1" onmouseover="this.bgColor='#F7F7F7'" onmouseout="this.bgColor='#FFFFFF'"
                                    height="30px">
                                    <td align="center">
                                        <input name="selectmessage" value="<%# Eval("id") %>" type="checkbox" />
                                    </td>
                                    <td align="left">
                                        <%# Eval("adminname")%>
                                    </td>
                                    <td>
                                        <%# Eval("strName")%>
                                    </td>
                                    <td>
                                        <%# Eval("strLoginIP")%>
                                    </td>
                                    <td>
                                        <%# Eval("dtmLoginTime")%>
                                    </td>
                                    <td>
                                        <%# Eval("intLoginNum")%>
                                    </td>
                                    <td align="center">
                                        <%#(Eval("intStatus") + "") == "0" ? "启用" : "<span style=\"color:Red;\">锁定</span>"%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="lbtn_Update" CommandName="Update" CommandArgument='<%#Eval("id") %>'
                                            runat="server">修改</asp:LinkButton>&nbsp;|&nbsp;
                                        <asp:LinkButton ID="lbtn_Purview" CommandName="Purview" CommandArgument='<%#Eval("id") %>'
                                            runat="server">权限管理</asp:LinkButton>&nbsp;|&nbsp;
                                        <asp:LinkButton ID="lbtn_Locking" CommandName="Locking" CommandArgument='<%#Eval("id") %>'
                                            runat="server">锁定</asp:LinkButton>&nbsp;|&nbsp;
                                        <asp:LinkButton ID="lbtn_Del" CommandName="Del" CommandArgument='<%#Eval("id") %>'
                                            runat="server">删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="8">
                                <!-- 分页 开始 -->
                                <div align="center">
                                    [&nbsp;页次:<asp:Label ID="nowpage" runat="server" Text="0" ForeColor="Red"></asp:Label>/<asp:Label
                                        ID="allpage" runat="server" Text="0" ForeColor="Red"></asp:Label>&nbsp;]&nbsp;
                                    [&nbsp;共:<asp:Label ID="totalpage" runat="server" Text="0"></asp:Label>条&nbsp;<asp:Label
                                        ID="pagenum" runat="server" Text="0"></asp:Label>条/页&nbsp;]&nbsp; [&nbsp;<asp:HyperLink
                                            ID="homepage" runat="server">首页</asp:HyperLink>&nbsp;]&nbsp; [&nbsp;<asp:HyperLink
                                                ID="prepage" runat="server">上一页</asp:HyperLink>&nbsp;]&nbsp; [&nbsp;<asp:HyperLink
                                                    ID="nextpage" runat="server">下一页</asp:HyperLink>&nbsp;]&nbsp; [&nbsp;<asp:HyperLink
                                                        ID="endpage" runat="server">尾页</asp:HyperLink>&nbsp;]
                                </div>
                                <!-- 分页 结束 -->
                                <asp:Label ID="noproduct" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="center">
                                <asp:Button runat="server" Text="添加管理员" ID="delectmessage" OnClick="delectmessage_Click"
                                    CssClass="inp1" />
                            </td>
                        </tr>
                    </table>
                    <!-- 显示新闻列表 结束 -->
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

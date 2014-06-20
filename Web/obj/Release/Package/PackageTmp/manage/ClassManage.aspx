<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassManage.aspx.cs" Inherits="Song.Web.manage.ClassManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>功能设置</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="js/webcom.js"></script>
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
                                    栏目管理</div>
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
                    <table class="tablecss1">
                        <tr>
                            <td style="height: 30px" colspan="2" class="tabletop">
                                网站栏目设置
                            </td>
                        </tr>
                    </table>
                    <table class="tablecss1">
                        <tr>
                            <td>
                                栏目名：
                            </td>
                            <td>
                                <asp:TextBox ID="ClassName" runat="server" Widtd="300px"></asp:TextBox>
                                英文标题：<asp:TextBox ID="EnName" runat="server" Widtd="300px"></asp:TextBox>
                                &nbsp;
                                <asp:Button ID="Button1" runat="server" Text="添加" CssClass="inp1" OnClick="Button1_Click" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ClassName"
                                    ErrorMessage="类别名称不能为空！"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table class="tablecss1">
                        <tr>
                            <td colspan="8" align="left">
                                &nbsp;&nbsp; &nbsp;&nbsp;<img src="images/cc1.gif" />
                                &nbsp; <a href="ClassManage.aspx">栏目管理</a>
                                <%=TabClassName()%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                排序
                            </td>
                            <td>
                                栏目名称
                            </td>
                            <td>
                                子栏目
                            </td>
                            <td>
                                栏目功能
                            </td>
                            <td>
                                链接参数
                            </td>
                            <td>
                                字段管理
                            </td>
                            <td>
                                前台链接
                            </td>
                            <td>
                                排序
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                        <asp:Repeater ID="newstypelist" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Container.ItemIndex + 1%>
                                    </td>
                                    <td>
                                        <input name="c_<%# Eval("id") %>" id="c_<%# Eval("id") %>" value="<%#  Eval("ClassName").ToString().Trim() %>"
                                            class="cinput" style="width: 90px;" />
                                        <input name="e_<%# Eval("id") %>" id="e_<%# Eval("id") %>" value="<%#  Eval("EnName").ToString().Trim() %>"
                                            class="cinput" style="width: 120px;" />
                                    </td>
                                    <td>
                                        <img src="images/cc1.gif" />
                                        <a href="?Fid=<%# Eval("id") %>">子栏目<%--<%# TotalNum( Convert.ToString(Eval("id") )) %>--%></a>
                                    </td>
                                    <td>
                                        <%# ClassList(Convert.ToString(Eval("id")),Convert.ToString(Eval("PageId")))%>
                                    </td>
                                    <td>
                                        <input name="u_<%# Eval("id") %>" id="u_<%# Eval("id") %>" value="<%#  Eval("urlparm").ToString().Trim() %>"
                                            class="cinput" style="width: 80px;" />
                                        <input id="i_<%# Eval("id") %>" type="checkbox" <%# Convert.ToBoolean( Eval("isSelf") ) == true ? "checked" : "" %> />PID
                                    </td>
                                    <td>
                                        <%# ReturnDrop(Convert.ToString(Eval("id")),Convert.ToString(Eval("funid")))%>
                                    </td>
                                    <td>
                                        <input name="Url_<%# Eval("id") %>" id="Url_<%# Eval("id") %>" value="<%#  Eval("LinkUrl").ToString().Trim() %>"
                                            class="cinput" style="width: 90px;" />
                                    </td>
                                    <td>
                                        <a href="?action=up&Fid=<%=Fid %>&id=<%# Eval("id") %>&rid=<%# Eval("orderid") %>"
                                            title="上升一位">
                                            <img src="images/arrow_up.png" border="0" /></a><a href="?action=down&Fid=<%=Fid %>&id=<%# Eval("id") %>&rid=<%# Eval("orderid") %>"
                                                title="下降一位"><img src="images/arrow_down.png" border="0" /></a>
                                    </td>
                                    <td>
                                        <%--<a href="?action=edittype&editid=<%# Eval("id") %>&fid=<%=Fid %>">修改</a>--%>
                                        <input id="show_<%# Eval("id") %>" type="checkbox" <%# Convert.ToBoolean( Eval("isShow") ) == true ? "checked" : "" %> />显/隐
                                        <a href="javascript:UpdeteClass('<%# Eval("id") %>')" style="cursor: hand;">修改</a>
                                        <a href="javascript:if (confirm('删除类别将删除类别下的产品!您确定要删除吗？')) { location.href='?action=deletetype&Fid=<%# Eval("Fid") %>&id=<%# Eval("id") %>';} else { location.href='ClassManage.aspx';}">
                                            删除</a>
                                        <%--<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" CommandArgument="<%# Eval("id") %>" Visible=false>保存</asp:LinkButton>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="8" align="center">
                                <asp:Label ID="nodate" runat="server" Text=""></asp:Label>
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

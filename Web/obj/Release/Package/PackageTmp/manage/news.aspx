<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Song.Web.manage.news"
    ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站信息管理</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/js.js"></script>
    <script type="text/javascript" src="js/js.js"></script>
    <script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="js/popWin.js"></script>
    <script src="js/webcom.js" type="text/javascript"></script>
    <link href="css/popWin.css" rel="Stylesheet" type="text/css" />
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
                    <input id="hid_more" value="" runat="server" type="hidden" />
                    <% if (Request.QueryString["action"] == "addnew" || Request.QueryString["action"] == "edit")
                       { %>
                    <table border="1" bordercolor="#eae3e4" cellpadding="0" cellspacing="0" class="tablecss1">
                        <tr>
                            <td class="tabletop" colspan="2" style="height: 30px">
                                添加信息
                            </td>
                        </tr>
                        <tr <%=ShowField("title") %>>
                            <td class="tdMargin" style="width: 68px">
                                信息标题
                            </td>
                            <td>
                                <asp:TextBox ID="title" runat="server" Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr <%=ShowField("isShow") %>>
                            <td class="tdMargin" style="width: 68px">
                                信息设置：
                            </td>
                            <td>
                                <asp:CheckBox ID="isShow" runat="server" Text="显示/隐藏" Checked="true" />&nbsp;
                            </td>
                        </tr>
                        <tr <%=ShowField("newstype") %>>
                            <td class="tdMargin" style="width: 68px">
                                信息类别：
                            </td>
                            <td>
                                <asp:DropDownList ID="newstype" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr <%=ShowField("NewsPhoto") %>>
                            <td class="tdMargin" style="width: 68px">
                                信息图片：
                            </td>
                            <td>
                                &nbsp;<asp:FileUpload ID="newsphoto" runat="server" />图片大小：750px*300px
                                <asp:Literal ID="photoshow" runat="server"></asp:Literal>
                                <asp:HiddenField ID="hid_photo" runat="server" Value="nophoto" />
                            </td>
                        </tr>
                        <tr <%=ShowField("MorePic") %>>
                            <td class="tdMargin" style="width: 68px">
                                <asp:Literal ID="More_Txt" runat="server" Text="更多图片"></asp:Literal>：
                            </td>
                            <td>
                                <a id="addpic" style="cursor: hand" href="javascript:showMsg('更多图片','MorePic.aspx?action=<%=action %>&pid=<%=pid %>&mid=<%=mid %>&no=<%=MoreNo %>','700','600')">
                                    管理更多图片</a>
                            </td>
                        </tr>
                        <tr <%=ShowField("Links") %>>
                            <td class="tdMargin" style="width: 68px">
                                链接地址：
                            </td>
                            <td>
                                <asp:TextBox ID="Links" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr <%=ShowField("txtContent") %>>
                            <td class="tdMargin" style="width: 68px" valign="top">
                                <br />
                                信息内容：
                            </td>
                            <td>
                                <textarea name="txtContent" id="txtContent" style="display: none" runat="server"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=txtContent&amp;Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="700" width="100%"></iframe>
                                <%--<textarea id="txtContent" name="txtContent" style="display:none" runat="server"></textarea>
<iframe id="Iframe1" src="SongEdit/editor.htm?id=txtContent&ReadCookie=0" frameborder="0" scrolling="no" width="100%" height="700"></iframe>--%>
                            </td>
                        </tr>
                        <tr <%=ShowField("key1") %>>
                            <td class="tdMargin" style="width: 68px" valign="top">
                                <br />
                                关键字：
                            </td>
                            <td>
                                <textarea name="key1" id="key1" style="width: 500px; height: 100px" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr <%=ShowField("key2") %>>
                            <td class="tdMargin" valign="top">
                                <br />
                                描述：
                            </td>
                            <td>
                                <textarea name="key2" id="key2" style="width: 500px; height: 100px" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:HiddenField ID="hid_time" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 25px">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加信息" CssClass="inp1" /><input
                                    name="curstate" id="curstate" value="addnews" type="hidden" runat="server" /><input
                                        name="curid" id="curid" value="addnews" type="hidden" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <%}
                       else
                       { %>
                    <!-- 显示新闻列表 开始 -->
                    <table border="1" class="tablecss1">
                        <tr>
                            <td class="tabletop" colspan="8" style="height: 30px">
                                <center>
                                    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" LastPageText="尾页"
                                        NextPageText="下一页" PrevPageText="上一页" OnPageChanged="AspNetPager1_PageChanged"
                                        PageIndexBoxType="DropDownList" PageSize="12" CssClass="paginator" CurrentPageButtonClass="cpb"
                                        UrlPaging="True">
                                    </webdiyer:AspNetPager>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td width="200px" colspan="2">
                                <asp:Button runat="server" Text="添加新数据" ID="Button4" OnClick="Button2_Click" CssClass="inp3" /><asp:Button
                                    runat="server" Text="删除所选信息" CssClass="inp3" ID="Button5" OnClick="delectmessage_Click" />
                            </td>
                            <td colspan="6" style="height: 30px">
                                &nbsp; 关键字：<asp:TextBox ID="key" runat="server" Width="150"></asp:TextBox>
                                <asp:Button ID="Button3" runat="server" Text="搜索" OnClick="Button3_Click" CssClass="inp1" />
                            </td>
                        </tr>
                        <asp:Repeater ID="DList" runat="server" OnItemCommand="manageproductlist_ItemCommand"
                            OnItemDataBound="manageproductlist_ItemDataBound">
                            <HeaderTemplate>
                                <tr id="toptr1" style="font-weight: bolder">
                                    <td width="50px">
                                        选择
                                    </td>
                                    <td>
                                        信息标题
                                    </td>
                                    <td <%=ShowField("newstype") %>>
                                        信息类别
                                    </td>
                                    <td <%=ShowField("NewsPhoto") %> align="center">
                                        信息图片
                                    </td>
                                    <td width="80px" align="center">
                                        是否显示
                                    </td>
                                    <td width="120px" align="center">
                                        发布日期
                                    </td>
                                    <td width="80px" align="center">
                                        排序
                                    </td>
                                    <td width="120px" align="center">
                                        操作
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="trcss1" onmouseover="this.bgColor='#F7F7F7'" onmouseout="this.bgColor='#FFFFFF'">
                                    <td>
                                        <input name="selectmessage" value="<%# Eval("id")  %>" type="checkbox" />
                                    </td>
                                    <td align="left" style="text-align: left;">
                                        <%# Eval("title")%>
                                    </td>
                                    <td <%=ShowField("newstype") %>>
                                        <%# getClassName(Convert.ToString(Eval("newstype")))%>
                                    </td>
                                    <td <%=ShowField("NewsPhoto") %> align="center">
                                        <img alt="" height="60px" src="<%# CheckPic(Eval("photo").ToString())  %>" onload="AutoPhoto(100,60,this)" />
                                    </td>
                                    <td align="center">
                                        <%# Convert.ToBoolean( Eval("isShow") ) == true ? "显示" : "隐藏" %>
                                    </td>
                                    <td align="center">
                                        <%# Eval("timeinfo") %>
                                    </td>
                                    <td align="center">
                                        <a href="?<%=ComUrl %>&action=up&id=<%# Eval("id") %>&rid=<%# Eval("orderid") %>"
                                            title="上升一位">
                                            <img src="images/arrow_up.png" border="0" /></a><a href="?<%=ComUrl %>&action=down&id=<%# Eval("id") %>&rid=<%# Eval("orderid") %>"
                                                title="下降一位"><img src="images/arrow_down.png" border="0" /></a>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="lbtn_Update" CommandName="Update" CommandArgument='<%#Eval("id") %>'
                                            runat="server">修改</asp:LinkButton>&nbsp;|&nbsp;
                                        <asp:LinkButton ID="lbtn_Del" CommandName="Del" CommandArgument='<%#Eval("id") %>'
                                            runat="server">删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="8">
                                <!-- 分页 开始 -->
                                <center>
                                    <asp:Literal ID="nolist" runat="server"></asp:Literal>
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                        NextPageText="下一页" PrevPageText="上一页" OnPageChanged="AspNetPager1_PageChanged"
                                        PageIndexBoxType="DropDownList" PageSize="12" CssClass="paginator" CurrentPageButtonClass="cpb"
                                        UrlPaging="True">
                                    </webdiyer:AspNetPager>
                                </center>
                                <!-- 分页 结束 -->
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="center">
                                <asp:Button runat="server" Text="添加新数据" ID="Button2" OnClick="Button2_Click" CssClass="inp3" /><asp:Button
                                    runat="server" Text="删除所选信息" CssClass="inp3" ID="delectmessage" OnClick="delectmessage_Click" />
                            </td>
                        </tr>
                    </table>
                    <!-- 显示新闻列表 结束 -->
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

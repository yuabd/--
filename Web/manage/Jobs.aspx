<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jobs.aspx.cs" Inherits="Song.Web.manage.Jobs"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站招聘管理</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" src="inc/time2.js"></script>
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
                                    在线招聘</div>
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
                    <% if (action == "add" || action == "edit")
                       { %>
                    <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#eae3e4">
                        <tr>
                            <td class="tabletop" colspan="2" style="height: 30px">
                                添加招聘
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                标题：
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyName" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td class="tdMargin">
                                公司图片（小）：
                            </td>
                            <td>
                                <asp:FileUpload ID="productphotobig1" runat="server" />
                                <asp:Literal ID="Literal1" runat="server" Text="（建议尺寸 宽*高:140px*105px）"></asp:Literal>
                                <input name="productphotobigid" id="productphotobigid1" value="nophoto" type="hidden"
                                    runat="server" />
                                <asp:Literal ID="show_photo1" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td class="tdMargin">
                                公司名称（大）：
                            </td>
                            <td>
                                <asp:FileUpload ID="productphotobig2" runat="server" />
                                <asp:Literal ID="Literal2" runat="server" Text="（建议尺寸 宽*高:230px*120px）"></asp:Literal>
                                <input name="productphotobigid" id="productphotobigid2" value="nophoto" type="hidden"
                                    runat="server" />
                                <asp:Literal ID="show_photo2" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                工作地点：
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                招聘人数：
                            </td>
                            <td>
                                <asp:TextBox ID="txtNum" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="tdMargin">
                                性别要求：
                            </td>
                            <td>
                                <asp:TextBox ID="Sex" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="tdMargin">
                                工作经验：
                            </td>
                            <td>
                                <asp:TextBox ID="txtWorkExperience" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                薪资待遇：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMoney" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                发布日期：
                            </td>
                            <td>
                                <asp:TextBox ID="txtEducation" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                截止日期：
                            </td>
                            <td>
                                <asp:TextBox ID="txtJobDuration" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td class="tdMargin">
                                招聘部门：
                            </td>
                            <td>
                                <asp:TextBox ID="txtJobUnit" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td class="tdMargin">
                                联系人：
                            </td>
                            <td>
                                <asp:TextBox ID="txtContact" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td class="tdMargin">
                                联系地址：
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactTel" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                简历发到：
                            </td>
                            <td>
                                <asp:TextBox ID="txtWorkAdd" runat="server" Width="200px"></asp:TextBox>（邮箱格式）
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                职位描述：
                            </td>
                            <td>
                                <asp:TextBox ID="txtJobDescription" runat="server" TextMode="MultiLine" Width="400px"
                                    Height="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                招聘设置：
                            </td>
                            <td>
                                <asp:CheckBox ID="isShow" runat="server" Text="显示/隐藏" Checked="True" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox
                                    ID="isR" runat="server" Text="推荐" Checked="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin" style="width: 68px" valign="top">
                                需求描述：
                            </td>
                            <td>
                                <textarea name="Content" id="Content" runat="server" style="display: none"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=Content&amp;Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="500px" width="100%"></iframe>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td class="tdMargin" style="width: 68px" valign="top">
                                联系我们：
                            </td>
                            <td>
                                <textarea name="ContactUs" id="ContactUs" runat="server" style="display: none"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=ContactUs&amp;Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="300px" width="100%"></iframe>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td class="tdMargin" style="width: 68px" valign="top">
                                公司简介：
                            </td>
                            <td>
                                <textarea name="CompanyProfile" id="CompanyProfile" runat="server" style="display: none"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=CompanyProfile&amp;Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="300px" width="100%"></iframe>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 25px">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加招聘" CssClass="inp1" />
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <a href="#" onclick="history.back()">返回上一页</a>
                                        </td>
                                    </tr>
                                </table>
                                <input name="curstate" id="curstate" value="add" type="hidden" runat="server" /><input
                                    name="curid" id="curid" value="add" type="hidden" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <%}
                       else
                       { %>
                    <!-- 显示新闻列表 开始 -->
                    <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#eae3e4">
                        <tr>
                            <td class="tabletop" colspan="9" style="height: 30px">
                                招聘综合管理
                            </td>
                        </tr>
                        <asp:Repeater ID="manageproductlist" runat="server" OnItemCommand="manageproductlist_ItemCommand"
                            OnItemDataBound="manageproductlist_ItemDataBound">
                            <HeaderTemplate>
                                <tr id="toptr1">
                                    <td>
                                        选择
                                    </td>
                                    <td>
                                        序号
                                    </td>
                                    <td>
                                        标题
                                    </td>
                                    <td>
                                        薪资待遇
                                    </td>
                                    <td>
                                        招聘人数
                                    </td>
                                    <td>
                                        发布日期
                                    </td>
                                    <td align="center">
                                        操作
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="trcss1" onmouseover="this.bgColor='#F7F7F7'" onmouseout="this.bgColor='#FFFFFF'">
                                    <td>
                                        <input name="selectmessage" value="<%# Eval("id") %>" type="checkbox" />
                                    </td>
                                    <td>
                                        <%# Eval("id") %>
                                    </td>
                                    <td align="left">
                                        <a href="?<%=ComUrl %>&action=edit&id=<%# Eval("id") %>">
                                            <%# Eval("CompanyName")%></a>
                                    </td>
                                    <td>
                                        <%# Eval("Money")%>
                                    </td>
                                    <td>
                                        <%# Eval("Num") %>
                                    </td>
                                    <td>
                                        <%# Eval("TimeInfo") %>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="Lbtn_Show" CommandArgument='<%#Eval("id") %>' CommandName="Show"
                                            runat="server">显示</asp:LinkButton>&nbsp;|&nbsp;
                                        <asp:LinkButton ID="lbtn_Update" CommandName="Update" CommandArgument='<%#Eval("id") %>'
                                            runat="server">修改</asp:LinkButton>&nbsp;|&nbsp;
                                        <asp:LinkButton ID="lbtn_Del" CommandName="Del" CommandArgument='<%#Eval("id") %>'
                                            runat="server">删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="9">
                                <!-- 分页 开始 -->
                                <div align="center">
                                    [&nbsp;页次:<asp:Label ID="nowpage" runat="server" Text="Label" ForeColor="Red"></asp:Label>/<asp:Label
                                        ID="allpage" runat="server" Text="Label" ForeColor="Red"></asp:Label>&nbsp;]&nbsp;
                                    [&nbsp;共:<asp:Label ID="totalpage" runat="server" Text="Label"></asp:Label>条&nbsp;<asp:Label
                                        ID="pagenum" runat="server" Text="Label"></asp:Label>条/页&nbsp;]&nbsp; [&nbsp;<asp:HyperLink
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
                            <td colspan="9" align="center">
                                <asp:Button ID="Button2" runat="server" Text="添加招聘" OnClick="Button2_Click" CssClass="inp1" />
                                <asp:Button runat="server" Text="删除招聘" ID="delectmessage" OnClick="delectmessage_Click"
                                    CssClass="inp1" />
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
                <td>
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

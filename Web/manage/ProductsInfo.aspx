<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsInfo.aspx.cs" Inherits="Song.Web.manage.ProductsInfo" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站信息管理</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" src="inc/time2.js"></script>
    <script language="javascript">
        function Show() {
            if (document.getElementById("isRecommend").checked) {
                document.getElementById("pic").style.display = "block";
            }
            else {
                document.getElementById("pic").style.display = "none";
            }

        }
    </script>
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
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
                                    <%=ClassName %></div>
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
                    <% if (Request.QueryString["action"] == "addproduct" || Request.QueryString["action"] == "edit")
                       { %>
                    <table border="1" class="tablecss1">
                        <tr>
                            <td class="tabletop" colspan="2" style="height: 30px">
                                添加信息
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                <asp:Literal ID="Literal3" runat="server" Text="标题："></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="title" runat="server" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                <asp:Literal ID="Literal4" runat="server" Text="英文名："></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="entitle" runat="server" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                <asp:Literal ID="Literal5" runat="server" Text="讲师："></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="productno" runat="server" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                <asp:Literal ID="Literal6" runat="server" Text="职位："></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="Material" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                时间：
                            </td>
                            <td>
                                <input type="text" runat="server" name="saletime" id="saletime" style="width: 200px" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                <asp:Literal ID="Literal7" runat="server" Text="地点："></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="price" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                <asp:Literal ID="Literal8" runat="server" Text="时间："></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="saleprice" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                信息设置：
                            </td>
                            <td>
                                <asp:CheckBox ID="isShow" runat="server" Text="显示/隐藏" Checked="True" />
                                &nbsp; <span style="display: none">
                                    <asp:CheckBox ID="isRecommend" runat="server" Text="是/否推荐信息" onClick="Show()" />
                                </span>
                                <asp:CheckBox ID="isNew" runat="server" Text="是/否最新产品" Checked="True" />
                                <asp:CheckBox ID="isHot" runat="server" Text="是/否热销产品" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                信息类别：
                            </td>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="producttype" runat="server" OnSelectedIndexChanged="producttype_SelectedIndexChanged1"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="type2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="type2_SelectedIndexChanged"
                                            Visible="False">
                                            <asp:ListItem Value="0">选择分类</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="type3" runat="server" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="type3_SelectedIndexChanged">
                                            <asp:ListItem>0</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="type4" runat="server" Visible="False">
                                            <asp:ListItem Value="0">
                                            </asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr id="pic" style="display: none">
                            <td class="tdMargin">
                                推荐图片：
                            </td>
                            <td>
                                <asp:FileUpload ID="productphotobig" runat="server" />
                                <asp:Literal ID="Literal2" runat="server" Text="（建议尺寸 宽*高:370px*170px）"></asp:Literal>
                                <input name="productphotobigid" id="productphotobigid" value="nophoto" type="hidden"
                                    runat="server" />
                                <asp:Literal ID="show_photo2" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                信息图片：
                            </td>
                            <td>
                                <asp:FileUpload ID="productphoto" runat="server" />
                                <asp:Literal ID="Literal1" runat="server" Text="（建议尺寸 宽*高:114px*154px）"></asp:Literal>
                                <input name="productphotoid" id="productphotoid" value="nophoto" type="hidden" runat="server" />
                                <asp:Literal ID="show_photo" runat="server"></asp:Literal>
                                <script language="javascript">
                                    Show();
                                </script>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" valign="top">
                                职位简介：
                            </td>
                            <td>
                                <textarea name="features" id="features" style="display: none" runat="server"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=features&amp;Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="150px" width="100%"></iframe>
                                <%-- <textarea id="features" name="features" style="display:none" runat="server"></textarea>
<iframe id="Iframe1" src="SongEdit/editor.htm?id=features&ReadCookie=0" frameborder="0" scrolling="no" width="100%" height="400"></iframe>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin" valign="top">
                                <br />
                                内容：
                            </td>
                            <td>
                                <textarea name="productcontent" id="productcontent" style="display: none" runat="server"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=productcontent&amp;Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="400" width="100%"></iframe>
                                <%--<textarea id="productcontent" name="productcontent" style="display:none" runat="server"></textarea>
<iframe id="Iframe2" src="SongEdit/editor.htm?id=productcontent&ReadCookie=0" frameborder="0" scrolling="no" width="100%" height="400"></iframe>--%>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" valign="top">
                                <br />
                                介绍（英）：
                            </td>
                            <td>
                                <textarea name="encontent" id="encontent" style="display: none" runat="server"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=encontent&amp;Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="400" width="100%"></iframe>
                                <%--<textarea id="encontent" name="encontent" style="display:none" runat="server"></textarea>
<iframe id="Iframe3" src="SongEdit/editor.htm?id=encontent&ReadCookie=0" frameborder="0" scrolling="no" width="100%" height="400"></iframe>--%>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" valign="top">
                                <br />
                                关键字1：
                            </td>
                            <td>
                                <textarea name="key1" id="key1" runat="server" style="width: 500px; height: 100px;"></textarea>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" valign="top">
                                <br />
                                关键字2：
                            </td>
                            <td>
                                <textarea name="key2" id="key2" runat="server" style="width: 500px; height: 100px;"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="display: none">
                                <asp:HiddenField ID="hid_maxid" runat="server" Value="0" />
                                <asp:HiddenField ID="hid_moreno" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" class="style1">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加信息" CssClass="inp1" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <a href="#" onclick="history.back()">返回上一页</a>
                                        </td>
                                    </tr>
                                </table>
                                <input name="curstate" id="curstate" value="addproduct" type="hidden" runat="server" />
                                <input name="curid" id="curid" value="addproduct" type="hidden" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <%}
                       else
                       { %>
                    <table class="tablecss1">
                        <tr>
                            <td width="200px">
                                <asp:Button runat="server" Text="添加新信息" ID="Button4" OnClick="delectmessage_Click1"
                                    CssClass="inp2" />
                                <asp:Button runat="server" Text="删除所选信息" ID="Button5" OnClick="delectmessage_Click"
                                    CssClass="inp3" />
                            </td>
                            <td>
                                &nbsp;信息搜索&nbsp;
                                <asp:DropDownList ID="searchtype" Style="display: none" runat="server" AutoPostBack="false"
                                    OnSelectedIndexChanged="searchtype1_SelectedIndexChanged">
                                </asp:DropDownList>
                                &nbsp;
                                <asp:DropDownList ID="searchtype2" Style="display: none" runat="server" AutoPostBack="True"
                                    Visible="False">
                                    <asp:ListItem Value="0">选择分类</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="searchkey" runat="server" Width="100px"></asp:TextBox>
                                &nbsp;
                                <asp:Button ID="Button2" runat="server" Text="搜索" OnClick="Button2_Click" CssClass="inp1" />
                            </td>
                        </tr>
                    </table>
                    <!-- 显示新闻列表 开始 -->
                    <table class="tablecss1">
                        <tr>
                            <td class="tabletop" colspan="8" style="height: 30px">
                                <center>
                                    <%=ClassName %>
                                </center>
                            </td>
                        </tr>
                        <asp:Repeater ID="DList" runat="server" OnItemCommand="manageproductlist_ItemCommand"
                            OnItemDataBound="manageproductlist_ItemDataBound">
                            <HeaderTemplate>
                                <tr id="toptr1">
                                    <td width="30px">
                                        选择
                                    </td>
                                    <td>
                                        信息标题
                                    </td>
                                    <td width="80px" align="center" style="display: none">
                                        信息图片
                                    </td>
                                    <td width="100px" style="display: none">
                                        信息类别
                                    </td>
                                    <td width="100px" align="center">
                                        发布日期
                                    </td>
                                    <td width="50px" align="center">
                                        排序
                                    </td>
                                    <td width="50px" align="center" style="display: none">
                                        报名人数
                                    </td>
                                    <td width="50px" align="center" style="display: none">
                                        状态
                                    </td>
                                    <td width="100px" align="center">
                                        操作
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr id="trcss1" onmouseover="this.bgColor='#F7F7F7'" onmouseout="this.bgColor='#FFFFFF'">
                                    <td>
                                        <input name="selectmessage" value="<%# Eval("id") %>" type="checkbox" />
                                    </td>
                                    <td align="left" style="text-align: left;">
                                        <a href="?<%=ComUrl %>&action=edit&id=<%# Eval("id") %>">
                                            <%# Eval("title") %></a><%--<br />
                                        英：<a href="?action=edit&editid=<%# Eval("id") %>"><%# Eval("entitle")%></a>--%>
                                    </td>
                                    <td align="center" style="display: none">
                                        <img alt="" height="60px" src="<%# CheckPic(Convert.ToString(Eval("photo")))%>" />
                                    </td>
                                    <td style="display: none">
                                        <%# ProType(Convert.ToString(Eval("protype")))%><br />
                                        <%--<%# ProType(Convert.ToString(Eval("type2")))%>--%>
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
                                    <td align="center" style="display: none">
                                        <%#getCount(Eval("content")+"")%>人
                                    </td>
                                    <td align="center" style="display: none">
                                        <%# Convert.ToBoolean( Eval("isShow") ) == true ? "显示" : "隐藏" %>
                                    </td>
                                    <td align="center" width="100px">
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
                                <center>
                                    <asp:Literal ID="nolist" runat="server"></asp:Literal>
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                        NextPageText="下一页" PrevPageText="上一页" OnPageChanged="AspNetPager1_PageChanged"
                                        PageIndexBoxType="DropDownList" PageSize="12" CssClass="paginator" CurrentPageButtonClass="cpb"
                                        UrlPaging="True">
                                    </webdiyer:AspNetPager>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="center">
                                <asp:Button runat="server" Text="添加新信息" ID="delectmessage" OnClick="delectmessage_Click1"
                                    CssClass="inp2" />
                                <asp:Button runat="server" Text="删除所选信息" ID="Button3" OnClick="delectmessage_Click"
                                    CssClass="inp3" />
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

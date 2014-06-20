<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="product.aspx.cs" Inherits="Song.Web.product" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="Description" content="<%=Maticsoft.Common.webcommand.GetCompayInfo6()%>">
    <meta name="keywords" content="<%=Maticsoft.Common.webcommand.GetCompayInfo7()%>">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main2">
        <script src="js/prototype.js" type="text/javascript"></script>
        <script src="js/new_menu.js" type="text/javascript"></script>
        <script src="js/effects.js" type="text/javascript"></script>
        <div class="left">
            <div class="promenuborder">
                <img src="images/left_03.jpg" width="245" height="6"></div>
            <div class="promenu">
                <img src="Images/3.jpg" />
                <div class="ban">
                    &nbsp;+ 产品列表</div>
                <div class="productNavigation">
                    <asp:Repeater runat="server" ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <div class="navigationBlock">
                                <div class="navItem">
                                    <a id="lnkSubHdrNavEspot<%#Eval("id") %>" href="#" <%--onclick="toggleMenuItem($('lnkSubItemsNavEspot<%#Eval("id") %>'),$('navToggleNavEspot<%#Eval("id") %>'));return false;"--%>>
                                        <span id="navToggleNavEspot<%#Eval("id") %>" class="navToggle navToggleOpen">−</span>
                                        <span class="open">
                                            <%#Eval("title") %></span> </a>
                                </div>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("id") %>' />
                                <div style="overflow: visible;" id="lnkSubItemsNavEspot<%#Eval("id") %>">
                                    <div style="">
                                        <asp:Repeater runat="server" ID="repeat2">
                                            <ItemTemplate>
                                                <div class="subItem">
                                                    <a id="" href="product.aspx?id=<%#Eval("id") %>&id2=<%#Eval("fid") %>" onclick="checkCheckedLink(this);">
                                                        <span>
                                                            <%#Eval("title") %></span> </a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                            <%--<script type="text/javascript">                                hideMenu($('lnkSubItemsNavEspot<%#Eval("id") %>'), $('navToggleNavEspot<%#Eval("id") %>'));</script>--%>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="right">
            <h3>
                <%if (Request.QueryString["fid"] != null)
                  { %>
                &nbsp; 首页 &gt;&gt;
                <%=classname1 %>
                <%}
                  else if (Request.QueryString["id2"] != null)
                  { %>
                &nbsp; 首页 &gt;&gt;
                <%=classname1 %>&gt;&gt;
                <%=classname2 %>
                <%}
                  else if (Request.QueryString["key"] != null)
                  {%>
                &nbsp; 首页 &gt;&gt;产品搜索
                <%} %>
            </h3>
            <div class="pro">
                <ul>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <li style="height: auto;"><a href="detail.aspx?id=<%#Eval("id") %>" target="_blank">
                                <img src="/uploadfile/spic/<%# ProType(Convert.ToString(Eval("moreno")))%>" width="232"
                                    height="166" border="0"></a><br>
                                <a href="detail.aspx?id=<%#Eval("id") %>" target="_blank">
                                    <%#Eval("title") %><br>
                                    规格:<%#Eval("prono")%><br>
                                    原价:<%#Eval("price") %><br>
                                    优惠价:<span><%#Eval("text2") %></span></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <table width="100%">
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" height="10"
                        style="margin-bottom: 10px;">
                        <tbody>
                            <tr>
                                <td height="10" align="center" valign="middle" id="list" class="page">
                                    <asp:Literal ID="nolist" runat="server"></asp:Literal>
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                        NextPageText="下一页" PrevPageText="上一页" OnPageChanged="AspNetPager1_PageChanged"
                                        PageIndexBoxType="DropDownList" PageSize="15" CssClass="paginator" AlwaysShow="true"
                                        CurrentPageButtonClass="cpb" UrlPaging="True">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ul>
            </div>
        </div>
    </div>
    <div id="leftfoot">
        <img src="images/left_06.jpg" width="245" height="6"></div>
</asp:Content>

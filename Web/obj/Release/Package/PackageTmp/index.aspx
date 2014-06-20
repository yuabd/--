<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="Song.Web.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta name="Description" content="<%=Maticsoft.Common.webcommand.GetCompayInfo6()%>">
    <meta name="keywords" content="<%=Maticsoft.Common.webcommand.GetCompayInfo7()%>">
    <script src="js/97zzw.js" type="text/javascript"></script>
    <link href="css/97zzw.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main" style="margin-top: 10px;">
        <div class="left">
            <div class="promenuborder">
                <img src="images/index_34.jpg" width="247" height="8"></div>
            <div class="promenu">
                <img src="Images/3.jpg" />
                <div class="ban">
                    &nbsp; + 产品分类</div>
                <div class="productNavigation">
                    <asp:Repeater runat="server" ID="Repeater2" OnItemDataBound="Repeater2_ItemDataBound">
                        <ItemTemplate>
                            <div class="navigationBlock">
                                <div class="navItem">
                                    <a id="lnkSubHdrNavEspot15" href="#"><span id="navToggleNavEspot15" class="navToggle navToggleOpen">
                                        −</span> <span class="open">
                                            <%#Eval("title") %></span> </a>
                                </div>
                                <div style="overflow: visible;" id="lnkSubItemsNavEspot15">
                                    <div style="">
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("id") %>' />
                                        <asp:Repeater ID="Repeater3" runat="server">
                                            <ItemTemplate>
                                                <div class="subItem">
                                                    <a id="lnk1.leftnav-5-1" href="product.aspx?id=<%#Eval("id") %>&id2=<%#Eval("fid") %>">
                                                        <span>
                                                            <%#Eval("title") %></span> </a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="promenuborder">
                <img src="images/index_50.jpg" width="247" height="8"></div>
        </div>
        <div class="right">
            <div id="banner">
                <div id="slide">
                    <script type="text/javascript">
                        $("#slide").jdSlide({ width: 750, height: 300, pics: [
    <%=strboxList %>
    ]
                        })
                    </script>
                    <!--slide end-->
                </div>
            </div>
            <h3>
                <span>产品展示</span><a href="product.aspx?fid=1"><img src="images/index_22.jpg" width="48"
                    height="47" align="right" border="0"></a></h3>
            <div class="pro">
                <ul>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <li><a href="product.aspx?fid=<%#Eval("id") %>">
                                <img src="/uploadfile/pic/<%#Eval("photo") %>" width="373" height="204" border="0">
                            </a>
                                <br>
                                <span><a href="product.aspx?fid=<%#Eval("id") %>" class="titlecss">
                                    <%#Eval("title") %></a></span> </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

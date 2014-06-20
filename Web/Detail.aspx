<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Detail.aspx.cs" Inherits="Song.Web.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="subnav">
        <p class="subnav_p">
            <a href="/">北京生活服务网</a>&nbsp;&gt;&nbsp;<a href="/category.aspx?id=<%=nav.id %>"><%=nav.ClassName%></a>
            >
            <%=news.title%>
        </p>
    </div>
    <div class="div10">
    </div>
    <div class="contain clearfix">
        <!-- left context -->
        <div class="left">
            <!-- article title -->
            <div class="Article clearfix">
                <div class="article_title">
                    <h1 class="Article_h3">
                        <%=news.title%></h1>
                    <div class="copyform">
                        <span>
                            <%=news.timeinfo.ToString()%></span>&#12288;<span>作者：<span>生活服务网</span></span>&#12288;<span>来源：<span>生活服务网</span>&#12288;<span>点击次数：<span><%=news.hit%></span></span></div>
                </div>
                <!-- article source and share -->
                <div class="article_laiy">
                    <div class="far_comment">
                        <a href="#comments" id="comment" class="comment_add">评论 <span id="c_num"></span>
                        </a>
                    </div>
                    <div class="shared_list">
                    </div>
                </div>
                <div class="article_content clearfix">
                    <div id="text" class="text">
                        <%=news.content%>
                    </div>
                </div>
                <div class="div20">
                </div>
                <div class="article_bottom">
                    <div class="related_art">
                        <h3 class="reading">
                            相关阅读<span>reading</span></h3>
                        <ul id="relatedlist" class="readling_ul clearfix">
                            <li><a title="俞敏洪：移动互联网不是来颠覆传统教育的" href="http://www.cyzone.cn/a/20140612/259005.html"
                                class="sky_blue" target="_blank">俞敏洪：移动互联网不是来颠覆传统教育的</a><span>2014.06.12</span></li>
                            <li><a title="这个音乐硬件47天众筹了百万人民币，凭什么？" href="http://www.cyzone.cn/a/20140527/258256.html"
                                class="sky_blue" target="_blank">这个音乐硬件47天众筹了百万人民币，凭什么？</a><span>2014.05.27</span></li>
                            <li><a title="未来的众筹怎么玩？" href="http://www.cyzone.cn/a/20140418/256647.html" class="sky_blue"
                                target="_blank">未来的众筹怎么玩？</a><span>2014.04.18</span></li>
                            <li><a title="一个互联网金融创业者的自白：站在风口上，猪真的可以飞" href="http://www.cyzone.cn/a/20140317/255276.html"
                                class="sky_blue" target="_blank">一个互联网金融创业者的自白：站在风口上，猪真的可以飞</a><span>2014.03.17</span></li>
                            <li><a title="维络城8年抗战O2O 却被移动互联网杀死" href="http://www.cyzone.cn/a/20140306/254896.html"
                                class="sky_blue" target="_blank">维络城8年抗战O2O 却被移动互联网杀死</a><span>2014.03.06</span></li>
                            <li><a title="两会热议金融监管 央行称不取缔余额宝" href="http://www.cyzone.cn/a/20140304/254797.html"
                                class="sky_blue" target="_blank">两会热议金融监管 央行称不取缔余额宝</a><span>2014.03.04</span></li>
                        </ul>
                    </div>
                    <a name="comments" id="comments"></a>
                    <!-- 多说评论框 start -->
                    <div class="ds-thread" data-thread-key="<%=news.id%>" data-title="<%=news.title%>"
                        data-url="http://www.bjsh.org/detail.aspx?id=<%=news.id%>">
                    </div>
                    <!-- 多说评论框 end -->
                    <!-- 多说公共JS代码 start (一个网页只需插入一次) -->
                    <script type="text/javascript">
                        var duoshuoQuery = { short_name: "bjsh" };
                        (function () {
                            var ds = document.createElement('script');
                            ds.type = 'text/javascript'; ds.async = true;
                            ds.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') + '//static.duoshuo.com/embed.js';
                            ds.charset = 'UTF-8';
                            (document.getElementsByTagName('head')[0]
		 || document.getElementsByTagName('body')[0]).appendChild(ds);
                        })();
                    </script>
                    <!-- 多说公共JS代码 end -->
                </div>
            </div>
        </div>
        <div class="div20">
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="Song.Web.Index" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contain clearfix">
        <div class="left">
            <div class="scroll">
                <div class="scroll_pic">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <ul class="clearfix">
                                <li class="scroll_uleft"><a href="/Detail.aspx?id=<%#Eval("id") %>" target="_blank">
                                    <img src="/uploadfile/pic/<%#Eval("photo") %>" alt="" width="354" height="199"></a>
                                </li>
                                <li class="scroll_uright">
                                    <div class="splash_title">
                                        <a href="/Detail.aspx?id=<%#Eval("id") %>" target="_blank">
                                            <%#Eval("title") %></a></div>
                                    <div class="splash_deck">
                                        <%#Eval("content") %>
                                    </div>
                                </li>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="status">
                    <ul class="clearfix">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <%
                                    if (margin0 == 5)
                                    { str = "margin : 0;"; }
                                    else if (margin0 == 1)
                                    {
                                        str = "active";
                                    }
                                    else
                                    {
                                        str = "";
                                    }
                                %><li class="<%=str %>" style="<%=str %>"><a href="/Detail.aspx?id=<%#Eval("id") %>"
                                    target="_blank">
                                    <img src="/uploadfile/pic/<%#Eval("photo") %>" alt="<%#Eval("title") %>" width="112"
                                        height="63">
                                    <span>
                                        <%#Eval("title") %></span> </a></li>
                                <%margin0++;%>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!--热门关注-->
            <div class="all_hot">
                <div class="hot">
                    <div class="small_hot">
                        <h2 class="hot_h2">
                            热门关注</h2>
                        <a href="http://www.audiinnovation.cn/ " target="_blank" style="color: #990000">奥迪创新大赛全新来袭！</a>
                        <a href="http://demochina.cyzone.cn/2014aut/next_live.html" target="_blank">2014创新中国报名征集</a>
                        <a href="http://cxj.kuailiyu.com/teec.html" target="_blank">创新·创意大赛报名</a>
                        <!-- index_middle_hotfocus -->
                    </div>
                </div>
            </div>
            <!--intere开始-->
            <div class="intere mt20">
                <ul class="list clearfix">
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <li class="clearfix">
                                <div class="list_li1">
                                    <a href="/detail.aspx?id=<%#Eval("id") %>" target="_blank">
                                        <img src="/uploadfile/pic/<%#Eval("photo") %>" alt="<%#Eval("title") %>" width="150"
                                            height="96"></a>
                                    <!-- <em>商业模式</em> -->
                                </div>
                                <div class="list_li2">
                                    <a href="/detail.aspx?id=<%#Eval("id") %>" class="list_title" target="_blank">
                                        <%#Eval("title") %></a>
                                    <div class="list_div">
                                        <div class="jiaThis jiathis_style" onmouseover="setShare('互联网金融一周年：各路玩家们表现如何？', 'http://www.cyzone.cn/a/20140615/259073.html', '与其说互联网金融这一年来做的是创新，不如说做的是整合。以余额宝为代表，在创新的名义下，诸多金融细分市场被整合到“互联网金融”的概念下面', 'http://img7.cyzone.cn/uploadfile/2014/0613/20140613035751494.jpg');">
                                            <!-- JiaThis Button BEGIN -->
                                            <a class="jiathis_button_tsina" title="分享到新浪微博"><span class="jiathis_txt jtico jtico_tsina">
                                            </span></a><a class="jiathis_button_weixin" title="分享到微信"><span class="jiathis_txt jtico jtico_weixin">
                                            </span></a>
                                            <!-- JiaThis Button END -->
                                        </div>
                                        <span>北京生活</span><em><%#Eval("timeinfo") %></em>
                                    </div>
                                    <p>
                                        <%#Eval("content")%></p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <center>
                    <asp:Literal ID="nolist" runat="server"></asp:Literal>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                        NextPageText="下一页" PrevPageText="上一页" OnPageChanged="AspNetPager1_PageChanged"
                        PageIndexBoxType="DropDownList" PageSize="12" CssClass="paginator" CurrentPageButtonClass="cpb"
                        UrlPaging="True">
                    </webdiyer:AspNetPager>
                </center>
            </div>
            <script>
                $(function () {
                    $('.i-box li.tip').hover(function () {
                        $(this).find('.tips').stop().fadeIn();
                    }, function () {
                        $(this).find('.tips').stop().fadeOut();
                    })
                })
            </script>
        </div>
        <div class="right">
            <div id="media">
                <a href="http://weibo.com/cyzone" target="_blank"></a><a id="weixin_tiao" style="left: 25px;">
                    <img src="http://tpl7.cyzone.cn/templates/cyzonev1/css/images/weixin_tiao.jpg" width="100"></a><a
                        href="http://m.cyzone.cn/index.html" target="_blank" style="left: 45px;"></a><a href="http://www.cyzone.cn/rss/"
                            target="_blank" style="left: 70px"></a><a href="http://chuangyebangzazhi.taobao.com/"
                                target="_blank" style="left: 92px;"></a>
                <script type="text/javascript">
                    $('#weixin_tiao').hover(function () {
                        $(this).find('img').show();
                    }, function () {
                        $(this).find('img').hide();
                    })
                </script>
            </div>
            <div class="mt20">
                <style>
                    .remen em
                    {
                        float: left;
                    }
                    .remen .remen_span4
                    {
                        float: left;
                    }
                </style>
                <script type="text/javascript">
                    $(function () {
                        $('.paihang div').eq(0).find('a').click(function () {
                            _gaq.push(['_trackEvent', 'CYB', 'hotbang', '日排行', null, true]);
                        });
                        $('.paihang div').eq(1).find('a').click(function () {
                            _gaq.push(['_trackEvent', 'CYB', 'hotbang', '周排行', null, true]);
                        });
                        $('.paihang div').eq(2).find('a').click(function () {
                            _gaq.push(['_trackEvent', 'CYB', 'hotbang', '月排行', null, true]);
                        });
                    });
                </script>
                <div class="remen">
                    <span class="remen_span1">热门排行榜</span> <span></span><em class="remen_em" style="margin-left: 70px;">
                        当日</em> <span class="remen_span4"></span><em>当周</em> <span class="remen_span4">
                    </span><em>当月</em>
                </div>
                <div class="paihang">
                    <div style="display: block">
                        <ul class="clearfix">
                            <asp:Repeater ID="Repeater4" runat="server">
                                <ItemTemplate>
                                    <li><span>
                                        <%=d %></span> <a title="<%#Eval("title") %>" href="/detail.aspx?id=<%#Eval("id") %>"
                                            class="sky_blue" target="_blank">
                                            <%#Eval("title") %></a> </li>
                                    <%d++; %>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div>
                        <ul class="clearfix">
                            <asp:Repeater ID="Repeater5" runat="server">
                                <ItemTemplate>
                                    <li><span>
                                        <%=w %></span> <a title="<%#Eval("title") %>" href="/detail.aspx?id=<%#Eval("id") %>"
                                            class="sky_blue" target="_blank">
                                            <%#Eval("title") %></a> </li>
                                    <%w++; %>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div>
                        <ul class="clearfix">
                            <asp:Repeater ID="Repeater6" runat="server">
                                <ItemTemplate>
                                    <li><span>
                                        <%=m %></span> <a title="<%#Eval("title") %>" href="/detail.aspx?id=<%#Eval("id") %>"
                                            class="sky_blue" target="_blank">
                                            <%#Eval("title") %></a> </li>
                                    <%m++; %>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <!--热门排行榜Top10-->
            </div>
            <!--活动 开始-->
            <%--<div class="huodong mt20" style="position: relative;">
                <div class="hg_pic">
                </div>
                <span class="hg_span"><a href="http://conference.cyzone.cn/">活动日历</a></span>
                <div style="border: 1px solid #eaeaea; padding: 0 10px 10px;">
                    <div class="hdli">
                        <h4>
                            <a href="http://www.cyzone.cn/a/20140612/259014.html">2014中国南通智慧建筑（城市）国际创业大赛北京宣讲会</a></h4>
                        <p class="desc">
                            2014年6月19日 北京清华大学</p>
                    </div>
                    <div class="hdli">
                        <h4>
                            <a href="http://demochina.cyzone.cn/2014aut/changsha.html">2014创新中国·长沙站</a></h4>
                        <p class="desc">
                            2014年7月11日 湖南长沙</p>
                    </div>
                    <div class="hdli">
                        <h4>
                            <a href="http://jm.cyzone.cn/2014top50/">中国高成长连锁企业CEO峰会暨2014连锁50强评选</a></h4>
                        <p class="desc">
                            2014年8月5日 北京千禧酒店</p>
                    </div>
                    <div class="hdli">
                        <h4>
                            <a href="http://demochina.cyzone.cn/2014aut/live.html">2014创新中国·秋季终极展示</a></h4>
                        <p class="desc">
                            2014年9月3-4日 杭州</p>
                    </div>
                    <!-- index_right_eventcal -->
                    <a href="http://conference.cyzone.cn/" target="_blank" class="huodongmore">更多</a>
                </div>
            </div>--%>
            <!--活动 结束-->
            <!---快鲤鱼开始---->
            <%--<div class="kuailiyu mt20">
                <h3>
                    <a href="http://www.kuailiyu.com/" target="_blank">快鲤鱼</a></h3>
                <div class="column_li border">
                    <ul>
                        <li><a title="苹果新专利：智能保护套，可显示通知消息" href="http://kuailiyu.cyzone.cn/article/10283.html"
                            class="sky_blue" target="_blank">苹果新专利：智能保护套，可显示通...</a> </li>
                        <li><a title="这才是创业者真正的人生！（心理素质差者慎入）" href="http://kuailiyu.cyzone.cn/article/10258.html"
                            class="sky_blue" target="_blank">这才是创业者真正的人生！（心理素...</a> </li>
                        <li><a title="用平板电脑代替笔记本必备的几种外设" href="http://kuailiyu.cyzone.cn/article/10278.html"
                            class="sky_blue" target="_blank">用平板电脑代替笔记本必备的几种外...</a> </li>
                        <li><a title="做自媒体的还不如玩QQ群的：人家轻松月赚10万" href="http://kuailiyu.cyzone.cn/article/10274.html"
                            class="sky_blue" target="_blank">做自媒体的还不如玩QQ群的：人家轻...</a> </li>
                        <li><a title="中小网站如何使用谷歌Adsence国际化优势赚钱？" href="http://kuailiyu.cyzone.cn/article/10290.html"
                            class="sky_blue" target="_blank">中小网站如何使用谷歌Adsence国际...</a> </li>
                        <li><a title="看看iOS 8分屏功能(视频)" href="http://kuailiyu.cyzone.cn/article/10272.html"
                            class="sky_blue" target="_blank">看看iOS 8分屏功能(视频)</a> </li>
                        <li><a title="Tinder：阅后即焚约炮应用?" href="http://kuailiyu.cyzone.cn/article/10255.html"
                            class="sky_blue" target="_blank">Tinder：阅后即焚约炮应用?</a> </li>
                        <li><a title="360推出电视“隐形遥控器”" href="http://kuailiyu.cyzone.cn/article/10260.html"
                            class="sky_blue" target="_blank">360推出电视“隐形遥控器”</a> </li>
                        <li><a title="从91、搜狗、UC看BAT的投资眼光，谁更技高一筹？" href="http://kuailiyu.cyzone.cn/article/10259.html"
                            class="sky_blue" target="_blank">从91、搜狗、UC看BAT的投资眼光，...</a> </li>
                        <li style="border-bottom: none;"><a title="iOS迅速蹿红的小红书：境外购物领域的知乎" href="http://kuailiyu.cyzone.cn/article/10284.html"
                            class="sky_blue" target="_blank">iOS迅速蹿红的小红书：境外购物领...</a> </li>
                    </ul>
                </div>
            </div>--%>
            <!---快鲤鱼结束---->
            <%--<div class="tzkd">
                <h3>
                    <a href="http://jm.cyzone.cn/" target="_blank">投资开店</a></h3>
                <div class="border">
                    <div class="tzkd_content">
                        <dl class="tzkd_top clearfix">
                            <dt><a target="_blank" href="http://jm.cyzone.cn/specials/nailall/">
                                <img width="252" height="139" alt="" src="http://jm.cyzone.cn/uploadfile/2014/0318/20140318093432797.gif"></a>
                            </dt>
                            <dd>
                                <a target="_blank" href="http://jm.cyzone.cn/specials/nailall/">妮欧美甲招商加盟</a>
                            </dd>
                        </dl>
                        <ul class="tzkd_middl clearfix">
                            <li><a target="_blank" href="http://jm.cyzone.cn/zixun/29156.html" title="如何让你的连锁店独占鳌头？">
                                如何让你的连锁店独占鳌头？</a> </li>
                            <li><a target="_blank" href="http://jm.cyzone.cn/zixun/29005.html" title="在船上开展特许加盟">
                                在船上开展特许加盟</a> </li>
                            <li><a target="_blank" href="http://jm.cyzone.cn/zixun/29384.html" title="“一分钟诊所”是如何开展连锁加盟的？">
                                “一分钟诊所”是如何开展连锁加盟的</a> </li>
                            <li><a target="_blank" href="http://jm.cyzone.cn/zixun/29388.html" title="一个叫花子的经营模式">
                                一个叫花子的经营模式</a> </li>
                            <li><a target="_blank" href="http://jm.cyzone.cn/zixun/28698.html" title="投资开店如何为商铺定价？">
                                投资开店如何为商铺定价？</a> </li>
                        </ul>
                        <ul class="tzkd_bottom clearfix">
                            <li><a target="_blank" href="http://jm.cyzone.cn/specials/memedacake/">
                                <img width="135" height="76" alt="" src="http://jm.cyzone.cn/uploadfile/2014/0514/20140514015036416.gif"></a></li>
                            <li style="padding: 0"><a target="_blank" href="http://jm.cyzone.cn/pinpai/464.html">
                                <img width="135" height="76" alt="" src="http://jm.cyzone.cn/uploadfile/2014/0318/20140318093135520.png"></a></li>
                        </ul>
                    </div>
                </div>
            </div>--%>
            <!---投资开店结束-->
        </div>
    </div>
</asp:Content>

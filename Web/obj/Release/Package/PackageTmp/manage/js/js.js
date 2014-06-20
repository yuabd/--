// JScript 文件

  //获取搜索框的值
  function Search(page,keywordid,searchtypeid)
  {
	  var keyword;
	  var searchtype;
	  
      keyword = $("txtCond").value;
	  alert(keyword);
	  searchtype = document.getElementById(searchtypeid).selectedIndex;
	  alert("'"+ page + ".aspx?keyword=" + keyword + "&searchtype=" + searchtype + "'");
	  //window.location.href = "'"+ page + ".aspx?keyword=" + keyword + "&searchtype=" + searchtype + "'";
	  window.location.href = "http://www.baidu.com";
  }
  
  //发送邮件
  function SendEmail(name)
  {
    var idlist ="",maillist="";
    $("input[name='"+ name +"']").each(function(){
        if(this.checked)
        {
            idlist += this.id + ",";
            maillist += $("#e"+this.id).attr('value')+",";
        }
    })
    idlist += "0";
    maillist += "0";
    showMsg('邮件订阅-发送邮件','Sending.aspx?maillist='+maillist,800,400);
  }
  
  
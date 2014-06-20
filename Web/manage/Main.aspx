<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Song.Web.manage.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>管理中心</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<frameset rows="64,*,26" cols="*" framespacing="0" frameborder="no" border="0">
  <frame src="Top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset rows="*" cols="200,*">
    <frame src="Left.aspx" name="mainFrame" id="mainFrame" title="mainFrame"  target="main" />
    <frame src="webconfig.aspx?id=2" name="main"  />
  </frameset>
  
  <frame src="Btn.aspx" name="bottomFrame" scrolling="No" noresize="noresize" id="bottomFrame" title="bottomFrame" />
</frameset>
<noframes>
    <body>
    </body>
</noframes>
</html>

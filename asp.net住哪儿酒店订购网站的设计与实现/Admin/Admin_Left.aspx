<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;用户管理</div>
        <div class="MenuNote" style="display:none;" id="UserInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="UserInfoEdit.aspx" target="main">添加用户</a></li>
                <li><a href="UserInfoList.aspx" target="main">用户查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;酒店管理</div>
        <div class="MenuNote" style="display:none;" id="HotelDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="HotelEdit.aspx" target="main">添加酒店</a></li>
                <li><a href="HotelList.aspx" target="main">酒店查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;地区管理</div>
        <div class="MenuNote" style="display:none;" id="AreaDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="AreaEdit.aspx" target="main">添加地区</a></li>
                <li><a href="AreaList.aspx" target="main">地区查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;订单管理</div>
        <div class="MenuNote" style="display:none;" id="OrderInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="OrderInfoEdit.aspx" target="main">添加订单</a></li>
                <li><a href="OrderInfoList.aspx" target="main">订单查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;评论管理</div>
        <div class="MenuNote" style="display:none;" id="CommentDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="CommentEdit.aspx" target="main">添加评论</a></li>
                <li><a href="CommentList.aspx" target="main">评论查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;新闻公告管理</div>
        <div class="MenuNote" style="display:none;" id="NoticeDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="NoticeEdit.aspx" target="main">添加新闻公告</a></li>
                <li><a href="NoticeList.aspx" target="main">新闻公告查询</a></li> 
            </ul>
        </div>

  
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>

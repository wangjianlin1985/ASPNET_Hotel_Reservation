<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AreaEdit.aspx.cs" Inherits="chengxusheji.Admin.AreaEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var areanName = document.getElementById("areanName").value;
            if (areanName == "") {
                alert("请输入地区名称...");
                document.getElementById("areanName").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">地区管理 》》编辑地区</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   地区名称：</td>
                    <td width="650px;">
                         <input id="areanName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入地区名称！</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnAreaSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnAreaSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>


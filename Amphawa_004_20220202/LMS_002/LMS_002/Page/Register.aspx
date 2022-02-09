<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LMS_002.Page.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>
    <script>

</script>
    <h2>ลงทะเบียน</h2>
    <div class="wrapper fadeInDown">
        <div id="formContent">
            <div>
                <input type="text" runat="server" id="txt_login" class="fadeIn second" name="login" placeholder="ชื่อผู้ใช้"></div>
            <div>
                <input type="password" runat="server" id="txt_password" class="fadeIn third" name="login" placeholder="รหัสผ่าน"></div>
            <div>
                <input type="password" runat="server" id="txt_compare" class="fadeIn third" name="login" placeholder="ยืนยันรหัสผ่าน"></div>
            <div>
                <input type="text" runat="server" id="txt_Email" class="fadeIn third" name="login" placeholder="อีเมล์"></div>
            <div>
                <input type="text" runat="server" id="txt_name" class="fadeIn third" name="login" placeholder="ชื่อ - นามสกุล"></div>
            <div>
                <input type="text" runat="server" id="txt_address" class="fadeIn third" name="login" placeholder="ที่อยู่"></div>
            <asp:DropDownList ID="ddl_role" CssClass="fadeIn second ddl" runat="server">
                <asp:ListItem Value="3">บุคคลภายนอก</asp:ListItem>
            </asp:DropDownList>
            <div>
                <input type="submit" id="btn_save" runat="server" onserverclick="btn_save_ServerClick" class="fadeIn fourth" value="บันทึก">
                <div id="formFooter">
                    <div>
                        <input type="submit" id="btn_back" runat="server" onserverclick="btn_back_ServerClick" class="fadeIn fourth" value="กลับหน้าเข้าระบบ">
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

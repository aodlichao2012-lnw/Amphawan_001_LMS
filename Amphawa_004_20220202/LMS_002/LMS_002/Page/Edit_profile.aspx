<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit_profile.aspx.cs" Inherits="LMS_002.Page.Edit_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>แก้ไขโปรไฟล์</h2>
    <div id="formContent" runat="server">
        <div class="wrapper fadeInDown text-center">
            <div>
                <input type="text" runat="server" id="txt_login" class="fadeIn second" name="login" placeholder="ชื่อผู้ใช้"></div>
            <div class="form-group">

                <div>
                    <input type="text" runat="server" id="txt_name" class="fadeIn third" name="login" placeholder="ชื่อ - นามสุกล"></div>
                <div>
                    <input type="text" runat="server" id="txt_address" class="fadeIn third" name="login" placeholder="ที่อยู่"></div>
                <div>
                    <input type="password" runat="server" id="txt_password" class="fadeIn third" name="login" placeholder="รหัสผ่าน"></div>
                <div>
                    <input type="password" runat="server" id="txt_compare" class="fadeIn third" name="login" placeholder="ยืนยันรหัสผ่าน"></div>
                <div>
                    <input type="text" runat="server" id="txt_Email" class="fadeIn third" name="login" placeholder="อีเมล์"></div>
                <div>
                    <input type="submit" id="btn_save" runat="server" onserverclick="btn_save_ServerClick" class="fadeIn fourth" value="เปลี่ยนแปลง" /></div>
                <div>
                    <input type="submit" id="btn_back" runat="server" onserverclick="btn_back_ServerClick" class="fadeIn fourth" value="ย้อนกลับ" /></div>
            </div>
        </div>
    </div>
</asp:Content>

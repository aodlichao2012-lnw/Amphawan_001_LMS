<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Role_Admin.aspx.cs" Inherits="LMS_002.Admin.Role_Admin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>

</script>
      <meta http-equiv="refresh" content="6">
    <h2>กำหนดสิทธิ</h2>
    <div class="wrapper fadeInDown">


        <asp:GridView ID="gdv_Role_admin" runat="server" OnRowCommand="gdv_Role_admin_RowCommand"  OnRowEditing="gdv_Role_admin_RowEditing" AutoGenerateColumns="False" OnRowDeleting="gdv_Role_admin_RowDeleting" DataKeyNames="int_id">

            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="btn_edit" CommandName="edit" ImageAlign="Middle" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' ImageUrl="~/Image/icons/24pixel/edit_24.png" />
                        <asp:ImageButton runat="server" ID="btn_delete" CommandName="delete" ImageAlign="Middle" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' ImageUrl="~/Image/icons/24pixel/delete_24.png" />

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField ItemStyle-CssClass="w-25 h-50" DataField="int_id" HeaderText="ลำดับ" InsertVisible="False" ReadOnly="True" SortExpression="int_id" />
                <asp:BoundField ItemStyle-CssClass="w-25 h-50" DataField="st_user" HeaderText="ชื่อผู้ใช้งาน" SortExpression="st_user" />
                <asp:BoundField ItemStyle-CssClass="w-25 h-50" DataField="st_email" HeaderText="อีเมล์ผู้ใช้งาน" SortExpression="st_email" />
                <asp:BoundField ItemStyle-CssClass="w-25 h-50" DataField="st_type_cus" HeaderText="ประเภทผู้ใช้งาน" SortExpression="st_type_cus" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Amphawan_LMS_db_2ConnectionString %>" SelectCommand="SELECT [int_id], [st_user], [st_email], [st_type_cus] FROM [MD_Account]"></asp:SqlDataSource>

        <asp:Panel ID="pn_edit_role" runat="server" Visible="false">
            <div class="wrapper fadeInDown">
                <div>
                    <input type="text" runat="server" id="txt_login" class="fadeIn second" name="login" placeholder="ชื่อผู้ใช้"></div>
                <div class="form-group">
                    <label class="fadeIn second col-form-label">สิทธิ</label>
                    <asp:DropDownList ID="ddl_role" CssClass="fadeIn second ddl" runat="server">
                        <asp:ListItem Value="1">เจ้าหน้าที่</asp:ListItem>
                        <asp:ListItem Value="2">ผู้ดูแลระบบ</asp:ListItem>
                        <asp:ListItem Value="3">บุคคลภายนอก</asp:ListItem>
                    </asp:DropDownList>
                </div>
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
        </asp:Panel>
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="return_detail.aspx.cs" Inherits="LMS_002.Page.return_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="container" style="margin-top: 100px;">
        <div class="row">
            <h2>การคืน</h2>
     <asp:Panel runat="server" ID="return_main" Visible="true">
    <div class="row">
        <div class="card">
            <label>เลือกผู้ยืมจากสมาชิก</label>
           <asp:TextBox runat="server" CssClass="ddl" ID="txt_account" AutoPostBack="true" OnTextChanged="txt_account_TextChanged"></asp:TextBox>
        </div>
    </div>
    <div class="row">

            <div class=" card-header"> <label>ตารางหนังสือ</label></div>
            <div class="wrapper fadeInDown">
            <div class="text-center">
                <asp:GridView ID="GridView1" CssClass="s-table table"  runat="server" AutoGenerateColumns="False" DataKeyNames="int_id_catalog_book" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand">
                    <Columns>


                        <%--   <asp:CheckBoxField DataField="bool_current" HeaderText="เลือก"  />--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox  ID="chkrows" OnCheckedChanged="chkrows_CheckedChanged1"  runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:BoundField  DataField="int_id_catalog_book" HeaderText="ลำดับหนังสือ" InsertVisible="False" ReadOnly="True" SortExpression="int_id_catalog_book" />
                        <asp:BoundField DataField="st_name_book" HeaderText="ชื่อหนังสือ" SortExpression="st_name_book" />
                        <asp:ImageField DataAlternateTextField="img_path" ItemStyle-Width="20px" ItemStyle-Height="20px"  HeaderText="ภาพหนังสือ" DataImageUrlField="img_path">
                        </asp:ImageField>
                        <asp:BoundField DataField="st_ISBN_ISSN" HeaderText="ISBN_ISSN" SortExpression="st_ISBN_ISSN" />
                        <asp:BoundField DataField="st_detail_book" HeaderText="รายละเอียด หนังสือ" SortExpression="st_detail_book" />
                        <asp:BoundField DataField="dt_DATE_modify" HeaderText="วันที่มีหนังสือเล่มนี้" SortExpression="dt_DATE_modify" />
                        <asp:BoundField DataField="st_type_book_name" HeaderText="ประเภทหนังสือ" SortExpression="st_type_book_name" />
                        <asp:BoundField DataField="status_book" HeaderText="สถานะ" SortExpression="status_book" />
                        <%-- <asp:BoundField DataField="count_ISBN" HeaderText="จำนวนหนังสือที่เหลืออยู่" SortExpression="st_type_book_name" />--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        </div>

    <div class="row">
        <div class="card">
             <div class="text-center">
        <a class="btn btn-success btn-lg " runat="server" onserverclick="return_ServerClick" id="return" data-id="1" href="#"><i class="fa fa-filter "></i>คืน </a>
        <a class="btn btn-secondary btn-lg " runat="server" onserverclick="clear_list_ServerClick"  id="clear_list" href="#"><i class="fa fa-eraser "></i>ล้างที่เลือก</a>
    </div>
        </div>
    </div>
         </asp:Panel>
    <asp:Panel runat="server" ID="detail_return" Visible="false">
        <h2>สรุปรายชื่อหนังสือ ที่จะคืน</h2>
            <div  runat="server" id="lb_list">

            </div>
    </asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            </div>
           </div>
</asp:Content>

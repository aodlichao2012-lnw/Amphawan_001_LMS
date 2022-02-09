<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Circulation.aspx.cs" Inherits="LMS_002.Admin.Circulation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <meta http-equiv="refresh" content="6">
    <h2 style="margin-top: 100px;">ค้นหาหนังสือ</h2>
    <div class="card text-center">
        <div class="card-body">
            <div class="row">
                <div class="text-center">
                    <div class="form-group w-100">
                        <label>ค้นหาตาม</label>
                        <select name="JobID" runat="server" id="Types" class=" w-100 ddl">
                            <option value="st_name_book">ชื่อหนังสือ</option>
                            <option value="st_ISBN_ISSN">ISBN-ISSN</option>
                            <option value="st_type_book_name">ประเภทหนังสือ</option>
                            <option value="st_author">ชื่อผู้แต่ง</option>
                            <option value="barcode">บาร์โค้ด</option>
                            <option value="count_print">จำนวนที่พิมพ์</option>
                        </select>
                    </div>
                </div>
                <div class="form-group w-100 text-center">
                    <div class="form-group w-100">
                        <label>คำค้น</label>
                        <input runat="server" type="text" id="txt_ketword" name="Age" class="w-100" placeholder="รหัสหนังสือ">
                    </div>
                </div>
                <div class="text-center">
                    <a class="btn btn-success btn-lg " runat="server" onserverclick="searchCatalog_ServerClick" id="searchCatalog" data-id="1" href="#"><i class="fa fa-filter "></i>ค้นหา </a>
                    <a class="btn btn-secondary btn-lg " runat="server" onserverclick="clear_ServerClick" id="clear" href="#"><i class="fa fa-eraser "></i>ล้างค่า</a>
                </div>
            </div>
        </div>
    </div>
    <div>
        <div class="text-center">
            <a class="btn btn-success btn-lg " runat="server" onserverclick="delete_1_ServerClick1" id="delete_1" data-id="1" href="#"><i class="fa fa-filter "></i>ลบข้อมูล </a>
            <a class="btn btn-success btn-lg " runat="server" onserverclick="select_all_ServerClick1" id="select_all" data-id="1" href="#"><i class="fa fa-filter "></i>เลือกรายการทั้งหมด </a>
            <a class="btn btn-secondary btn-lg " runat="server" onserverclick="cancle_ServerClick1" id="cancle" href="#"><i class="fa fa-eraser "></i>ยกเลิกรายการ</a>
        </div>
        <div class="wrapper fadeInDown">
            <div class="text-center">
                <asp:GridView ID="GridView1" CssClass="s-table table" runat="server" AutoGenerateColumns="False" DataKeyNames="st_ISBN_ISSN" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkrows" AutoPostBack="true" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="st_name_book" HeaderText="ชื่อหนังสือ" SortExpression="st_name_book" />


                        <asp:ImageField HeaderText="ภาพหนังสือ" ItemStyle-Width="20px" ItemStyle-Height="20px" ControlStyle-Width="100" ControlStyle-Height="100" DataImageUrlField="img_path">
                        </asp:ImageField>
                        <asp:BoundField DataField="st_ISBN_ISSN" HeaderText="ISBN_ISSN" SortExpression="st_ISBN_ISSN" />
                        <asp:BoundField DataField="st_detail_book" HeaderText="รายละเอียด หนังสือ" SortExpression="st_detail_book" />
                        <asp:BoundField DataField="dt_DATE_modify" HeaderText="วันที่มีหนังสือเล่มนี้" SortExpression="dt_DATE_modify" />
                        <asp:BoundField DataField="st_type_book_name" HeaderText="ประเภทหนังสือ" SortExpression="st_type_book_name" />
                        <asp:BoundField DataField="st_cheeckin_out" HeaderText="สถานะ" SortExpression="status_book" />
                        <asp:BoundField DataField="count_" HeaderText="จำนวน" SortExpression="status_book" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div>
            ผู้ใช้ :
            <asp:Label ID="ld_profile" runat="server">ผู้ใช้ภายนอก</asp:Label>
            :  ได้เลือกหนังสือจำนวน
            <asp:Label ID="ld_count" runat="server">0</asp:Label>
            : เล่ม
        </div>
    </div>
    <div class="text-center">
        <a class="btn btn-success btn-lg " runat="server" onserverclick="delete_2_ServerClick" id="delete_2" data-id="1" href="#"><i class="fa fa-filter "></i>ลบข้อมูล </a>
        <a class="btn btn-success btn-lg " runat="server" onserverclick="select_all2_ServerClick" id="select_all2" data-id="1" href="#"><i class="fa fa-filter "></i>เลือกรายการทั้งหมด </a>
        <a class="btn btn-secondary btn-lg " runat="server" onserverclick="cancle2_ServerClick" id="cancle2" href="#"><i class="fa fa-eraser "></i>ยกเลิกรายการ</a>
    </div>
</asp:Content>

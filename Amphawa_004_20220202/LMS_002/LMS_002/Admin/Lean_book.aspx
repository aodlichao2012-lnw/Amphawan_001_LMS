<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Lean_book.aspx.cs" Inherits="LMS_002.Admin.Lean_book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    </style>
    <script>

</script>

    <div class="container" style="margin-top: 100px;">
        <div class="row">
            <h2>การยืม</h2>
            <div>
                <div class="card">
                    Barcode
                    <asp:TextBox runat="server" ID="txt_keyword" OnTextChanged="txt_keyword_TextChanged" AutoPostBack="true" CssClass="w-100"></asp:TextBox>
                </div>
                <div class="wrapper fadeInDown">
                    <div class="text-center">
                        <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound1" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="int_id_catalog_book">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkrows" AutoPostBack="true" Visible="true" OnCheckedChanged="chkrows_CheckedChanged" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="int_id_catalog_book" HeaderText="ลำดับหนังสือ" InsertVisible="False" ReadOnly="True" SortExpression="int_id_catalog_book" />
                                <asp:BoundField DataField="st_name_book" HeaderText="ชื่อหนังสือ" SortExpression="st_name_book" />
                                <asp:BoundField DataField="st_ISBN_ISSN" HeaderText="ISBN_ISSN" SortExpression="st_ISBN_ISSN" />
                                <asp:BoundField DataField="st_detail_book" HeaderText="รายละเอียด หนังสือ" SortExpression="st_detail_book" />
                                <asp:BoundField DataField="dt_DATE_modify" HeaderText="วันที่มีหนังสือเล่มนี้" SortExpression="dt_DATE_modify" />
                                <asp:BoundField DataField="st_type_book_name" HeaderText="ประเภทหนังสือ" SortExpression="st_type_book_name" />
                                <asp:BoundField DataField="status_book" HeaderText="สถานะ" SortExpression="status_book" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <div class="card">
                    <div class="card-body">
                        <div class="row">



                            <div class="col-md-2 pl-1">
                                <div class="form-group">
                                    <label>ยืม จากวันที่</label>
                                    <div>
                                        <input type="text" id="lend_date" runat="server"   data-date-format="dd/mm/yyyy" class="form-control date-range-filter datepicker w-100" autocomplete="off" placeholder="From:">
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2 pl-1">
                                <div class="form-group">
                                    <label>ยืม ถึงวันที่</label>
                                    <div>
                                        <input type="text" id="due_date" runat="server" data-date-format="dd/mm/yyyy"  class="form-control date-range-filter datepicker w-100" autocomplete="off" placeholder="To:">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 pl-1">
                                <div class="form-group">
                                    <label>เลือกผู้ยืมจากสมาชิก</label>
                                    <asp:TextBox runat="server" OnTextChanged="ddl_account_TextChanged" AutoPostBack="true" ID="ddl_account"></asp:TextBox>
                                    <asp:ListBox runat="server" Visible="false" CssClass="ddl" OnSelectedIndexChanged="list_acc_SelectedIndexChanged" AutoPostBack="true"  ID="list_acc"></asp:ListBox>
                                </div>
                            </div>

                            <div class="col-md-2 pl-1">
                                <div class="form-group">
                                    <label>จำนวน</label>
                                    <div>
                                        <input type="text" id="count_book" runat="server" class="form-control  w-100" readonly="readonly" autocomplete="off" placeholder="จำนวน:">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="card">
                        <div class=" card-header">จำนวนรายการที่จะยืม</div>
                        <div class=" card-body">
                            <asp:GridView ID="GridView2" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="int_id_catalog_book">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkrows" AutoPostBack="true" Visible="true" OnCheckedChanged="chkrows_CheckedChanged" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="int_id_catalog_book" HeaderText="ลำดับหนังสือ" InsertVisible="False" ReadOnly="True" SortExpression="int_id_catalog_book" />
                                    <asp:BoundField DataField="st_name_book" HeaderText="ชื่อหนังสือ" SortExpression="st_name_book" />
                                    <asp:BoundField DataField="st_ISBN_ISSN" HeaderText="ISBN_ISSN" SortExpression="st_ISBN_ISSN" />
                                    <asp:BoundField DataField="st_detail_book" HeaderText="รายละเอียด หนังสือ" SortExpression="st_detail_book" />
                                    <asp:BoundField DataField="dt_DATE_modify" HeaderText="วันที่มีหนังสือเล่มนี้" SortExpression="dt_DATE_modify" />
                                    <asp:BoundField DataField="Type_book" HeaderText="ประเภทหนังสือ" SortExpression="Type_book" />
                                    <asp:BoundField DataField="status_book" HeaderText="สถานะ" SortExpression="status_book" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class=" card-footer">
                            <div>
                               
                                ท่านได้เลือกหนังสือจำนวน
            <asp:Label ID="ld_count" runat="server">0</asp:Label>
                                : เล่ม
                            </div>
                        </div>
                    </div>
                    <div class="text-center">
                        <a class="btn btn-success btn-lg " runat="server" id="searchCatalog" onserverclick="searchCatalog_ServerClick" data-id="1" href="#"><i class="fa fa-filter "></i>ยืม </a>
                        <asp:Button CssClass="btn btn-secondary btn-lg " ID="btn_cancle" runat="server" Text="ยกเลิกการยืม" OnClick="btn_cancle_Click"  OnClientClick="return confrim('คุณต้องการจะยกเลิก การยืมทั้งหมดหรือไม่ ?');" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

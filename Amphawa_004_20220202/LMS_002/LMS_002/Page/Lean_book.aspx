<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lean_book.aspx.cs" Inherits="LMS_002.Page.Lean_book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>
    <script>

</script>

    <div class="container">
        <div class="row">
            <h2>การยืม</h2>
            <div>
                <div class="wrapper fadeInDown">
                    <div class="text-center">
                        <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="int_id_catalog_book">
                            <Columns>


                                <%--   <asp:CheckBoxField DataField="bool_current" HeaderText="เลือก"  />--%>
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
                                <asp:BoundField DataField="dt_checkout_date" HeaderText="วันที่ถูยืม" SortExpression="dt_checkout_date" />
                                <asp:BoundField DataField="dt_checkin_date" HeaderText="วันที่ถูกคืน" SortExpression="dt_checkin_date" />
                                <asp:BoundField DataField="status_book" HeaderText="สถานะ" SortExpression="status_book" />
                                <%-- <asp:BoundField DataField="count_ISBN" HeaderText="จำนวนหนังสือที่เหลืออยู่" SortExpression="st_type_book_name" />--%>
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
                                        <input type="text" id="min_date" runat="server" class="form-control date-range-filter datepicker w-100" autocomplete="off" placeholder="From:">
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2 pl-1">
                                <div class="form-group">
                                    <label>ยืม ถึงวันที่</label>
                                    <div>
                                        <input type="text" id="max_date" runat="server" class="form-control date-range-filter datepicker w-100" autocomplete="off" placeholder="To:">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 pl-1">
                                <div class="form-group">
                                    <label>เลือกผู้ยืมจากสมาชิก</label>
                                    <asp:DropDownList runat="server" ID="ddl_account" CssClass="ddl"></asp:DropDownList>
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
                    <div class="text-center">
                        <a class="btn btn-success btn-lg " runat="server" id="searchCatalog" onserverclick="searchCatalog_ServerClick" data-id="1" href="#"><i class="fa fa-filter "></i>ยืม </a>
                        <a class="btn btn-secondary btn-lg " runat="server" id="clear" href="#"><i class="fa fa-eraser "></i>ยกเลิกการยืม</a>
                    </div>
                </div>
                <%--        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Amphawan_LMS_db_2ConnectionString2 %>" SelectCommand="SELECT top 5 st_ISBN_ISSN , [int_id_catalog_book],[st_name_book], dbo.MD_statusbook.status_book as statusbook ,[st_detail_book], format( [dt_DATE_modify]   , 'dd MMM yyyy' , 'th-TH') as dt_DATE_modify  ,[MD_Account_int_id],[st_type_book],[st_type_book_name] , bool_current FROM [dbo].[MD_catralog_book] Left join dbo.MD_statusbook on [dbo].[MD_catralog_book].int_cheeckin_out = dbo.MD_statusbook.self_id order by dt_DATE_modify DESC"></asp:SqlDataSource>--%>
            </div>
        </div>
    </div>
</asp:Content>

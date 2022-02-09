<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_book.aspx.cs" Inherits="LMS_002.Page.List_book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>
    <script>

</script>
      <meta http-equiv="refresh" content="6">
    <h2>ค้นหาหนังสือ</h2>
    <div class="card text-center">
        <div class="card-body">
            <div class="row">
                <div class="text-center">
                    <div class="form-group w-100" style="display: inline-block;">
                        <%--<label>ค้นหาตาม</label>
                        <select name="JobID" runat="server" id="Types" class=" w-100 ddl">
                            <option value="st_name_book">ชื่อหนังสือ</option>
                            <option value="st_ISBN_ISSN">ISBN-ISSN</option>
                            <option value="st_type_book_name">ประเภทหนังสือ</option>
                            <option value="st_author">ชื่อผู้แต่ง</option>
                            <option value="barcode">บาร์โค้ด</option>
                            <option value="count_print">จำนวนที่พิมพ์</option>
                        </select>--%>
                    </div>
                </div>
                 <div class="form-group w-100 text-center">
                                    <div class="form-group w-100">
                                        <label>หมวดหมู่
                                        </label>
                                        <asp:DropDownList runat="server" CssClass="ddl" ID="ddl_dictionnary" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                <div class="form-group w-100 text-center">
                    <div class="form-group w-100">
                        <label>คำค้น</label>
                        <asp:TextBox runat="server" ID="txt_ketword2" CssClass="w-100" OnTextChanged="txt_ketword2_TextChanged"></asp:TextBox>
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
        <div class="wrapper fadeInDown">
            <div class="text-center">
                <asp:GridView ID="GridView1" CssClass=" table" runat="server" AutoGenerateColumns="False" DataKeyNames="st_ISBN_ISSN" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkrows" AutoPostBack="true" runat="server" />
                                <asp:Button runat="server" CommandName="open" ID="btn_open" OnClick="btn_open_Click" Text="เปิดดู" />
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
        <%--        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Amphawan_LMS_db_2ConnectionString2 %>" SelectCommand="SELECT top 5 st_ISBN_ISSN , [int_id_catalog_book],[st_name_book], dbo.MD_statusbook.status_book as statusbook ,[st_detail_book], format( [dt_DATE_modify]   , 'dd MMM yyyy' , 'th-TH') as dt_DATE_modify  ,[MD_Account_int_id],[st_type_book],[st_type_book_name] , bool_current FROM [dbo].[MD_catralog_book] Left join dbo.MD_statusbook on [dbo].[MD_catralog_book].int_cheeckin_out = dbo.MD_statusbook.self_id order by dt_DATE_modify DESC"></asp:SqlDataSource>--%>
    </div>
    <div class="text-center">
        <a class="btn btn-success btn-lg " runat="server" onserverclick="sendto_lend_ServerClick" id="sendto_lend" data-id="1" href="#"><i class="fa fa-filter "></i>ส่งไปหน้ายืม </a>
        <a class="btn btn-secondary btn-lg " runat="server" onserverclick="clear_list_ServerClick" id="clear_list" href="#"><i class="fa fa-eraser "></i>ล้างที่เลือก</a>
    </div>
</asp:Content>


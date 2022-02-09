<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="History_lean_book.aspx.cs" Inherits="LMS_002.Page.History_lean_book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $(function () {
                $(".datepicker").datepicker();
                format = "yy/dd/mm"
            });

            // Bootstrap datepicker
            $('.input-daterange input').each(function () {
                $(this).datepicker('clearDates');
            });

            // Extend dataTables search
            $.fn.dataTable.ext.search.push(
                function (settings, data, dataIndex) {
                    var min = $('#min-date').val();
                    var max = $('#max-date').val();
                    var createdAt = data[7] || 7  // Our date column in the table

                    if (
                        (min == "" || max == "") ||
                        (
                            moment(createdAt).isSameOrAfter(min)
                            && moment(createdAt).isSameOrBefore(max)

                        )
                    ) {
                        return true;
                    }
                    return false;
                }
            );


            $('#ex_filter').hide();
        });
    </script>
      <meta http-equiv="refresh" content="6">
    <h2>ประวัติการยืม - คืนหนังสือ</h2>
    <div class="wrapper fadeInDown">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-2 pl-1">
                        <div class="form-group">
                            <label>ประเภท</label>
                            <select name="JobID" runat="server" id="Type" class="form-control">
                                <option value="0">หนังสือ</option>
                                <option value="1">E-book</option>
                                <option value="2">หนังสือเสียง</option>
                                <option value="3">วิดีโอ</option>

                            </select>
                        </div>
                    </div>
                    <div class="col-md-2 pl-1">
                        <div class="form-group">
                            <label>รหัสหนังสือ</label>
                            <div>
                                <input runat="server" type="text" id="txt_iss_num" name="Age" class="form-control w-100" placeholder="รหัสหนังสือ"></div>
                        </div>
                    </div>
                    <div class="col-md-2 pl-1">
                        <div class="form-group">
                            <label>ชื่อหนังสือ</label>
                            <div>
                                <input runat="server" type="text" id="txt_name_book" name="Age" class="form-control w-100" placeholder="ชื่อหนังสือ"></div>
                        </div>
                    </div>
                    <div class="col-md-2 pl-1">
                        <div class="form-group">
                            <label>ยืม จากวันที่</label>
                            <div>
                                <input type="text" id="min_date" runat="server" class="form-control date-range-filter datepicker w-100" placeholder="From:"></div>
                        </div>
                    </div>
                    <div class="col-md-2 pl-1">
                        <div class="form-group">
                            <label>ยืม ถึงวันที่</label>
                            <div>
                                <input type="text" id="max_date" runat="server" class="form-control date-range-filter datepicker w-100" placeholder="To:"></div>
                        </div>
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
                <asp:GridView ID="GridView1" CssClass=" table" runat="server" AutoGenerateColumns="False" DataKeyNames="int_id_catalog_book">
                    <Columns>


                        <%--   <asp:CheckBoxField DataField="bool_current" HeaderText="เลือก"  />--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkrows" AutoPostBack="true" runat="server" />
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
        <div>
        </div>
        <%--        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Amphawan_LMS_db_2ConnectionString2 %>" SelectCommand="SELECT top 5 st_ISBN_ISSN , [int_id_catalog_book],[st_name_book], dbo.MD_statusbook.status_book as statusbook ,[st_detail_book], format( [dt_DATE_modify]   , 'dd MMM yyyy' , 'th-TH') as dt_DATE_modify  ,[MD_Account_int_id],[st_type_book],[st_type_book_name] , bool_current FROM [dbo].[MD_catralog_book] Left join dbo.MD_statusbook on [dbo].[MD_catralog_book].int_cheeckin_out = dbo.MD_statusbook.self_id order by dt_DATE_modify DESC"></asp:SqlDataSource>--%>
    </div>
    <div class="text-center">
    </div>
</asp:Content>

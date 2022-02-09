<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="catalog_detail.aspx.cs" Inherits="LMS_002.Admin.catalog_detail" %>

<!DOCTYPE html>
  <meta http-equiv="refresh" content="6">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
    <title></title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>

<body>

    <form id="form1" runat="server">
        <div>
            
            <asp:GridView ID="GridView1" CssClass="s-table table" runat="server" AutoGenerateColumns="False" DataKeyNames="st_ISBN_ISSN" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand1">
                <Columns>
                    <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="checkbox" AutoPostBack="true" OnCheckedChanged="checkbox_CheckedChanged" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                     <asp:TemplateField>
                        <ItemTemplate>
                           <asp:CheckBox ID="checkbox" runat="server" OnCheckedChanged="btn_check__CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="st_name_book" HeaderText="ชื่อหนังสือ" SortExpression="st_name_book" />
                    <asp:BoundField DataField="st_callnumber" HeaderText="เลขเรียกหนังสือ" SortExpression="st_callnumber" />


                    <asp:ImageField HeaderText="ภาพหนังสือ" ItemStyle-Width="20px" ItemStyle-Height="20px" ControlStyle-Width="100" ControlStyle-Height="100" DataImageUrlField="img_path">
                    </asp:ImageField>
                    <asp:BoundField DataField="st_ISBN_ISSN" HeaderText="ISBN_ISSN" SortExpression="st_ISBN_ISSN" />
                    <asp:BoundField DataField="st_detail_book" HeaderText="รายละเอียด หนังสือ" SortExpression="st_detail_book" />
                    <asp:BoundField DataField="dt_DATE_modify" HeaderText="วันที่มีหนังสือเล่มนี้" SortExpression="dt_DATE_modify" />
                    <asp:BoundField DataField="st_type_book_name" HeaderText="ประเภทหนังสือ" SortExpression="st_type_book_name" />
                    <asp:BoundField DataField="st_cheeckin_out" HeaderText="สถานะ" SortExpression="status_book" />
                </Columns>
            </asp:GridView>

            <asp:Button runat="server" OnClientClick="return confirm('คุณต้องการลบ หนังสือที่เลือกหรือไม่ ?');" Text="ลบ" ID="btn_delete" OnClick="btn_delete_Click" />
        </div>
    </form>
</body>
</html>

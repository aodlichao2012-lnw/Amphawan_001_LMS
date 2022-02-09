<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Catalog_module.aspx.cs" Inherits="LMS_002.Admin.Catalog_module" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta http-equiv="refresh" content="6" />
    <div id="mainContent" style="margin-top: 100px;">
        <div class="menuBox">
            <div class="menuBoxInner biblioIcon">
                <div class="per_title">
                    <h2>บรรณานุกรม</h2>
                </div>
                <div class="sub_section">
                    <div class="btn-group">

                        <div class="row">
                            <div class="form-group w-100 text-center">
                                <div class="form-group w-100">
                                    <label>
                                        หมวดหมู่
                                    </label>
                                    <asp:DropDownList runat="server" CssClass="ddl" ID="ddl_dictionnary">
                                    </asp:DropDownList>
                                </div>
                            </div>
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
                                    <input runat="server" type="text" id="keywords" name="Age" class="w-100" placeholder="รหัสหนังสือ">
                                </div>
                            </div>
                               <div class="form-group w-100 text-center">
                                <div class="form-group w-100">
                            <input type="submit" id="doSearch" value="สืบค้น" runat="server" onserverclick="doSearch_ServerClick" class="btn form-group w-50 text-center">
                                    </div>
                                   </div>
                        </div>

                    </div>
                    <div class="card container text-center">
                        
                        <a class="btn btn-secondary form-group w-100 text-center" runat="server" id="list" onserverclick="list_ServerClick">รายการบรรณานุกรม</a>
                        <a runat="server" id="add_book" onserverclick="add_book_ServerClick" class="btn form-group btn-secondary w-100 text-center">เพิ่มรายการบรรณานุกรม</a>
                    </div>

                </div>
            </div>
            <input type="hidden" name="csrf_token" value="95b84d303fe86c6484c983e4cb39ca94dd1a840c6c1d2d74c281f0c38f85e2d6"><input type="hidden" name="form_name" value="datagrid"><table cellspacing="0" cellpadding="5" class="datagrid-action-bar" style="width: 100%;">
                <tbody>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="Button1" CssClass="btn btn-danger" Text="ลบ" AlternateText="Delete" OnClick="delete_Click" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
                            <input type="button" value="เลือกรายการทั้งหมด" id="seleclall" runat="server" onserverclick="seleclall_ServerClick" class="check-all button btn btn-default">
                            <input type="button" id="unselect1" runat="server" onserverclick="unselect1_ServerClick" value="ยกเลิกรายการทั้งหมด" class="uncheck-all button btn btn-default">
                        </td>
                    </tr>
                </tbody>
            </table>

            <asp:GridView ID="GridView1" CssClass="s-table table" runat="server" AutoGenerateColumns="False" DataKeyNames="st_ISBN_ISSN" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="checkbox" AutoPostBack="true" OnCheckedChanged="checkbox_CheckedChanged" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                           <asp:Button ID="btn_list_" runat="server" OnClick="btn_list__Click" Text="เปิดดู" />
                           <asp:Button ID="btn_list_edit" runat="server" OnClick="btn_list_edit_Click" Text="แก้ไข" />
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
            <table cellspacing="0" cellpadding="5" class="datagrid-action-bar" style="width: 100%;">
                <tbody>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="delete" CssClass="btn btn-danger" Text="ลบ" AlternateText="Delete" OnClick="delete_Click" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
                            <input type="button" id="seleclall2" runat="server" onserverclick="seleclall_ServerClick" value="เลือกรายการทั้งหมด" class="check-all button btn btn-default">
                            <input type="button" value="ยกเลิกรายการทั้งหมด" id="unselect2" runat="server" onserverclick="unselect1_ServerClick" class="uncheck-all button btn btn-default">
                        </td>
                    </tr>
                </tbody>
            </table>
            <input type="hidden" name="itemAction" value="true"><input type="hidden" name="lastQueryStr" value="">

            <iframe name="submitExec" style="display: none; visibility: hidden; width: 100%; height: 0;"></iframe>
        </div>
        </div>
    
        <script>
           
            setTimeout('location.reload(true); ', 60000);
            
</script>
   
</asp:Content>

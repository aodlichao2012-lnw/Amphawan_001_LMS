<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Add_book_Admin.aspx.cs" Inherits="LMS_002.Admin.Add_book_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    </style>
    <script>

</script>

    <div id="mainContent" style="margin-top: 80px;">
        <div class="menuBox">
            <div class="menuBoxInner biblioIcon">
                <div class="per_title">
                    <h2>เพิ่มหนังสือ</h2>
                    <div class=" card-body mt-2 col-1 w-100">
                        <div class=" col-1 w-25 d-inline-block">
                            <div class="text-center">
                                <div class="form-group w-100" style="display: inline-block;">
                                    <label>ประเภท</label>
                                    <select name="JobID" runat="server" id="Types" class=" w-100 ddl">
                                        <option value="0 หนังสือ">หนังสือ</option>
                                        <option value="1 E-book">E-book</option>
                                        <option value="2 หนังสือเสียง">หนังสือเสียง</option>
                                        <option value="3 วิดีโอ">วิดีโอ</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class=" card-body mt-2 col-1 w-100">
                            <div class=" col-1 w-25 d-inline-block">
                                รูปหน้าปก
                    <asp:FileUpload ID="f_book" CssClass="ddl" runat="server" />
                            </div>

                            <div class=" col-1 w-25 d-inline-block">
                                วิดีโอ
                  <asp:FileUpload ID="f_video" CssClass="ddl" runat="server" />
                            </div> 
                            <div class=" col-1 w-25 d-inline-block">
                                เสียง
                  <asp:FileUpload ID="f_sound" CssClass="ddl" runat="server" />
                            </div>
                            <div class=" col-1 w-25 d-inline-block">
                                E-book
                    <asp:FileUpload ID="f_ebook" CssClass="ddl" runat="server" />
                            </div>
                        </div>
                        <div class=" col-1 w-25 d-inline-block">
                                เอกสารหลายๆหน้า รวมเป็น E-bbok
                    <asp:FileUpload ID="f_gen_ebook" CssClass="ddl" AllowMultiple="true"  runat="server" />
                             <asp:Button runat="server" ID="btn_upload" Text="อัพโหลด" OnClientClick="return confirm('ต้องการจะอัพโหลดเอกสารทั้งหมดหรือไม่ ? ');" OnClick="btn_upload_Click" />
                            </div>

                            
                        </div>

                        <div class="  card-body mt-2 col-1 w-100">
                            <div class=" card-header"></div>
                            <div class=" card-body">
                                <div class="form-group w-100 text-center">
                                    <div class="form-group w-100">
                                        <label>บาร์โค้ด</label>
                                        <input runat="server" type="text" id="txt_bar_code" name="Age" class="w-100 ddl" placeholder="รหัสหนังสือ">
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
                                        <label>ISBN/ISSN</label>
                                        <input runat="server" type="text" id="txt_iss_num" name="Age" class="w-100 ddl" placeholder="รหัสหนังสือ">
                                    </div>
                                </div>
                                <div class="form-group w-100 text-center d-inline-block">
                                    <div class="form-group w-100">
                                        <label>ชื่อหนังสือ</label>
                                        <input runat="server" type="text" id="txt_book_name" name="Age" class="w-100 ddl" placeholder="รหัสหนังสือ">
                                    </div>
                                </div>
                                <div class="form-group w-100 text-center d-inline-block">
                                    <div class="form-group w-100">
                                        <label>ชื่อผู้แต่ง</label>
                                        <input runat="server" type="text" id="txt_author" name="Age" class="w-100 ddl" placeholder="รหัสหนังสือ">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=" card-body mt-2 col-1 w-100">
                        <div class=" card-header"></div>
                        <div class=" card-body">
                            <div class="form-group w-100 text-center">
                                <div class="form-group w-100">
                                    <label>จำนวนที่พิมพ์</label>
                                    <input runat="server" type="text" id="count_print" name="Age" class="w-100 ddl" placeholder="รหัสหนังสือ">
                                </div>
                            </div>

                            <div class="form-group w-100 text-center">
                                <div class="form-group w-100">
                                    <label>สถานที่พิมพ์</label>
                                    <input runat="server" type="text" id="plate_print" name="Age" class="w-100 ddl" placeholder="รหัสหนังสือ">
                                </div>
                            </div>
                            <div class="form-group w-100 text-center d-inline-block">
                                <div class="form-group w-100">
                                    <label>บริษัทที่พิมพ์</label>
                                    <input runat="server" type="text" id="company_print" name="Age" class="w-100 ddl" placeholder="รหัสหนังสือ">
                                </div>
                            </div>
                            <div class="form-group w-100 text-center d-inline-block">
                                <div class="form-group w-100">
                                    <label>ปีที่พิมพ์</label>
                                    <input runat="server" type="text" id="year_print" name="Age" class="w-100 ddl" placeholder="รหัสหนังสือ">
                                </div>
                            </div>
                            <div class="form-group w-100 text-center d-inline-block">
                                <div class="form-group w-100">
                                    <label>เลขเรียกหนังสือ</label>
                                    <input runat="server" type="text" id="call_number" name="Age" class="w-100 ddl" placeholder="รหัสหนังสือ">
                                </div>
                            </div>
                            <div class="form-group w-100 text-center d-inline-block">
                                <div class="form-group w-100">
                                    <label>รายละเอียดอื่นๆ </label>
                                    <textarea runat="server" id="detail_book" name="Text1" class="ddl" cols="40" rows="5"></textarea>
                                </div>
                            </div>
                            <div class="form-group w-100 text-center d-inline-block">
                                <div class="form-group w-100">
                                    <label>จำนวนหนังสือ </label>
                                    <input runat="server" type="number" id="count_book" name="Age" class="w-100 ddl" placeholder="จำนวนหนังสือ">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="text-center">
                        <a class="btn btn-success btn-lg " runat="server" id="searchCatalog" onserverclick="searchCatalog_ServerClick" data-id="1" href="#"><i class="fa fa-filter "></i>บันทึก </a>
                        <a class="btn btn-secondary btn-lg " runat="server" id="clear" href="#"><i class="fa fa-eraser "></i>ยกเลิก</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" Culture="en-US" UICulture="en-US" ResponseEncoding="utf-8" CodeBehind="System_management.aspx.cs" Inherits="LMS_002.Admin.System_management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <div oncontextmenu="return false;">
    <div style="margin-top:100px;" id="mainContent" ><div class="menuBox" >
  <div class="menuBoxInner systemIcon">
    <div class="per_title">
      <h2>ตั้งค่าระบบ</h2>
    </div>
    <div class="infoBox">
      แก้ไขข้อมูลได้ตามต้องการ    </div>
  </div>
</div>
<form name="mainForm" id="mainForm" class="simbio_form_maker" method="post" action="/senayan/admin/modules/system/index.php" target="submitExec" enctype="multipart/form-data"><input type="hidden" name="csrf_token" value="5b1e8f27681a743d107486f48a16e4eeb0184178cf8f0a8f806ac627db24cdb8"><input type="hidden" name="form_name" value="mainForm">
<table cellspacing="0" cellpadding="3" style="width: 100%;"><tbody><tr><td><input type="submit" class="s-btn btn btn-primary" name="updateData" onserverclick="updateconfig2_ServerClick" onclick="return comfrim('ต้องการที่จะเปลี่ยนแปลงการตั้งค่าหรือไม่ ?');" runat="server" id="updateconfig2" value="บันทึกการตั้งค่า">&nbsp;</td><td class="edit-link-area">&nbsp;&nbsp;</td></tr></tbody></table>
<table id="dataList" class="s-table table">
<tbody><tr row="0" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">SLiMS Version</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><strong>SLiMS 9 (Bulian)</strong></td></tr>
<tr id="simbioFormRowlibrary_name" row="1" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">ชื่อย่อห้องสมุด</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><input type="text" name="library_name" runat="server" id="library_name" value="PEN1 Library" class="form-control" maxlength="256">
</td></tr>
<tr id="simbioFormRowlibrary_subname" row="2" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">ชื่อเต็มห้องสมุด</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><input type="text" name="library_subname" id="library_subname" runat="server" value="Open Source Library Management System" class="form-control" maxlength="256">
</td></tr>
<tr row="3" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Logo Image</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><div style="padding:10px;"><img src="../lib/minigalnano/createthumb.php?filename=images/default/logo.png&amp;width=130" runat="server" id="img_cover" class="img-fluid rounded" alt="Image cover"><a href="/senayan/admin/modules/system/index.php" postdata="removeImage=true&amp;limg=logo.png" class="btn btn-sm btn-danger">Remove Image</a></div><div class="custom-file col-3"><input type="file" name="image" id="image" value="" class="custom-file-input">
<label class="custom-file-label" for="customFile">Choose file</label></div> <div class="mt-2 ml-2">Maximum 500 KB</div><script>
                                                                                                                           $('.custom-file input').on('change', function () {
                                                                                                                               //get the file name
                                                                                                                               const fileName = $(this).val();
                                                                                                                               //replace the "Choose a file" label
                                                                                                                               $(this).next('.custom-file-label').html(fileName);
                                                                                                                           });
</script></td></tr>
<tr id="simbioFormRowdefault_lang" row="4" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">เลือกภาษา</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="default_lang" id="default_lang" runat="server" class="form-control col-3">
<option value="en-EN">English</option>
<option value="th-TH">ไทย</option>
</select>
</td></tr>
<tr id="simbioFormRowopac_result_num" row="5" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">ตั้งค่าจำนวนรายการที่แสดงในหน้า OPAC</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="opac_result_num" runat="server" id="opac_result_num" class="form-control col-1">
<option value="10" selected="">10</option>
<option value="20">20</option>
<option value="30">30</option>
<option value="40">40</option>
<option value="50">50</option>
</select>
</td></tr>
<tr id="simbioFormRowenable_promote_titles" row="6" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">แสดงรายการชื่อเรื่องใหม่ในหน้าโฮมเพจ</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><div title="class=" form-control="" col-3=""><input type="checkbox" runat="server" id="check_book" name="enable_promote_titles[]" value="1" style="border: 0;" checked=""> ใช่</div>
<div class="formElementInfo">class="form-control col-3"</div></td></tr>
<tr id="simbioFormRowquick_return" row="7" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">คืน</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="quick_return" runat="server" id="quick_return" class="form-control col-3">
<option value="0">ไม่สามารถใช้งานได้</option>
<option value="1" selected="">สามารถใช้งานได้</option>
</select>
</td></tr>
<tr id="simbioFormRowcirculation_receipt" row="8" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Print Circulation Receipt</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select runat="server" name="circulation_receipt" id="circulation_receipt" class="form-control col-3">
<option value="0" selected="">Don't Print</option>
<option value="1">Print</option>
</select>
</td></tr>
<tr id="simbioFormRowallow_loan_date_change" row="9" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">ยืม และ วันที่คืน</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="allow_loan_date_change" runat="server" id="allow_loan_date_change" class="form-control col-3">
<option value="0">ไม่สามารถใช้งานได้</option>
<option value="1" selected="">สามารถใช้งานได้</option>
</select>
</td></tr>
<tr id="simbioFormRowloan_limit_override" row="10" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">จำกัดการยืม</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="loan_limit_override" id="loan_limit_override" runat="server" class="form-control col-3">
<option value="0">ไม่สามารถใช้งานได้</option>
<option value="1" selected="">สามารถใช้งานได้</option>
</select>
</td></tr>
<%--<tr id="simbioFormRowignore_holidays_fine_calc" row="11" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Ignore Holidays Fine Calculation</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="ignore_holidays_fine_calc" id="ignore_holidays_fine_calc" class="form-control col-3">
<option value="0" selected="">ไม่สามารถใช้งานได้</option>
<option value="1">สามารถใช้งานได้</option>
</select>
</td></tr>--%>
<%--<tr id="simbioFormRowenable_xml_detail" row="12" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">แสดงรายละเอียด XML</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="enable_xml_detail" id="enable_xml_detail" class="form-control col-3">
<option value="0">ไม่สามารถใช้งานได้</option>
<option value="1" selected="">สามารถใช้งานได้</option>
</select>
</td></tr>
<tr id="simbioFormRowenable_xml_result" row="13" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">แสดงผล XML</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="enable_xml_result" id="enable_xml_result" class="form-control col-3">
<option value="0">ไม่สามารถใช้งานได้</option>
<option value="1" selected="">สามารถใช้งานได้</option>
</select>
</td></tr>--%>
<%--<tr id="simbioFormRowspellchecker_enabled" row="14" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Enable Search Spellchecker</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="spellchecker_enabled" id="spellchecker_enabled" class="form-control col-3">
<option value="0">ไม่สามารถใช้งานได้</option>
<option value="1" selected="">สามารถใช้งานได้</option>
</select>
</td></tr>--%>
<tr id="simbioFormRowallow_file_download" row="15" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">อนุญาตให้ดาวน์โหลดเอกสารดิจิทัล</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="allow_file_download" runat="server" id="allow_file_download" class="form-control col-3">
<option value="0">ไม่อนุญาต</option>
<option value="1" selected="">อนุญาต</option>
</select>
</td></tr>
<tr id="simbioFormRowsession_timeout" row="16" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">เวลาอยู่ในระบบ(นาที)</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><input type="text" name="session_timeout" runat="server" id="session_timeout" value="7200" style="width: 10%;" class="form-control" maxlength="256">
</td></tr>
<%--<tr id="simbioFormRowbarcode_encoding" row="17" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Barcode Encoding</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="barcode_encoding" id="barcode_encoding" class="form-control col-3">
<option value="code39">Code 39</option>
<option value="code128" selected="">Code 128</option>
</select>
</td></tr>--%>
<tr id="simbioFormRowenable_counter_by_ip" row="18" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Visitor Counter by IP</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="enable_counter_by_ip" runat="server" id="enable_counter_by_ip" class="form-control col-3">
<option value="0">ไม่สามารถใช้งานได้</option>
<option value="1" selected="">สามารถใช้งานได้</option>
</select>
</td></tr>
<tr id="simbioFormRowallowed_counter_ip" row="19" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Allowed Counter IP</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><textarea name="allowed_counter_ip" runat="server" id="allowed_counter_ip" style="width: 100%;" class="form-control" maxlength="30720">127.0.0.1</textarea>
</td></tr>
<tr id="simbioFormRowenable_visitor_limitation" row="20" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Visitor Limitation by Time</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="enable_visitor_limitation" runat="server" id="enable_visitor_limitation" class="form-control col-3">
<option value="0" selected="">ไม่สามารถใช้งานได้</option>
<option value="1">สามารถใช้งานได้</option>
</select>
</td></tr>
<tr id="simbioFormRowtime_visitor_limitation" row="21" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Time visitor limitation (in minute)</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><input type="text" name="time_visitor_limitation" id="time_visitor_limitation" value="60" runat="server" style="width: 10%;" class="form-control" maxlength="256">
</td></tr>
<%--<tr id="simbioFormRowreserve_direct_database" row="22" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Reserve methode</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="reserve_direct_database" id="reserve_direct_database" class="form-control col-3">
<option value="0">Email</option>
<option value="1" selected="">Database</option>
</select>
</td></tr>
<tr id="simbioFormRowreserve_on_loan_only" row="23" style="cursor: pointer;"><td width="20%" valign="top" class="alterCell font-weight-bold">Reserve for item on loan only</td><td width="1%" valign="top" class="alterCell font-weight-bold">:</td><td width="79%" class="alterCell2"><select name="reserve_on_loan_only" id="reserve_on_loan_only" class="form-control col-3">
<option value="0" selected="">ไม่สามารถใช้งานได้</option>
<option value="1">สามารถใช้งานได้</option>
</select>
</td></tr>--%>
</tbody></table>
<table cellspacing="0" cellpadding="3" style="width: 100%;"><tbody><tr><td><input type="submit" runat="server" onserverclick="updateconfig_ServerClick" id="updateconfig" onclick="return comfrim('ต้องการที่จะเปลี่ยนแปลงการตั้งค่าหรือไม่ ?');" class="s-btn btn btn-primary" name="updateData" value="บันทึกการตั้งค่า">&nbsp;</td><td class="edit-link-area">&nbsp;&nbsp;</td></tr></tbody></table>
</form>
<iframe name="submitExec" class="noBlock" style="display: none; visibility: hidden; width: 100%; height: 0;"></iframe></div>
        </div>
</asp:Content>

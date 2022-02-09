<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="LMS_002.Admin.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <meta http-equiv="refresh" content="6">
    <div style="margin-top: 100px;" id="mainContent">
        <div class="menuBox">
            <div class="menuBoxInner statisticIcon">
                <div class="per_title">
                    <h2>สรุปสถิติทรัพยากรสารสนเทศ</h2>
                </div>
                <div class="infoBox">
                    <input type="hidden" name="print" value="true">
                    <input type="submit" runat="server" id="submit" onserverclick="submit_ServerClick" value="รายงานการดาวน์โหลดเอกสารดิจิทัล" class="s-btn btn btn-default">
                </div>
                <iframe name="submitPrint" style="display: none; visibility: hidden; width: 0; height: 0;"></iframe>
            </div>
        </div>
        <table class="s-table table table-bordered mb-0">
            <tbody>
                <tr class="dataListHeader">
                    <td colspan="2">สรุปรายการสถิติการใช้ทรัพยากรสารสนเทศ</td>
                </tr>
                <tr>
                    <td class="alterCell" valign="top" style="width: 300px;">ชื่อเรื่องทั้งหมด</td>
                    <td class="alterCell" valign="top" style="width: auto;"><div id="total_namebook" runat="server"></div></td>
                </tr>

                <tr>
                    <td class="alterCell" valign="top" style="width: 300px;">รายการตัวเล่มทั้งหมด</td>
                    <td class="alterCell" valign="top" style="width: auto;"><div id="total_book" runat="server"></div></td>
                </tr>
                <tr>
                    <td class="alterCell" valign="top" style="width: 300px;">รายการยืมตัวเล่มทั้งหมด</td>
                    <td class="alterCell" valign="top" style="width: auto;"><div id="total_lend" runat="server"></div></td>
                </tr>
                <tr>

                    <td class="alterCell" valign="top" style="width: 300px;">รายการชื่อเรื่องแบ่งตามประเภทวัสดุ/มีเดีย</td>
                    <td class="alterCell" valign="top" style="width: auto;">
                        <div id="total_type" runat="server"></div>
                        </td>
                </tr>
                <tr>

                    <td class="alterCell" valign="top" style="width: 300px;">รายการตัวเล่มทั้งหมดแบ่งตามประเภททรัพยากรสารสนเทศ</td>
                    <td class="alterCell" valign="top" style="width: auto;"><div id="total_type2" runat="server"></div>
                       </td>
                </tr>
                <tr>
                    <td class="alterCell" valign="top" style="width: 300px;">ชื่อเรื่อง 10 ลำดับแรกที่ถูกยืมมากที่สุด</td>
                    <td class="alterCell" valign="top" style="width: auto;">
                        <ol>
                            <li><div id="lb_top_lend" runat="server"></div></li>

                        </ol>
                    </td>
                </tr>
                <tr>
                    <td><input id="File1" type="file" runat = "server" /></td>
                </tr>
            </tbody>
        </table>
    </div>

    <script>
        var cs = document.getElementById("div_").innerHTML;
        
    </script>

</asp:Content>

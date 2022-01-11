

$(document).ready(function () {

    editor = new $.fn.dataTable.Editor( {
        ajax: "../php/staff.php",
        table: "#example",
        fields: [ {
                label: "First name:",
                name: "first_name"
            }, {
                label: "Last name:",
                name: "last_name"
            }, {
                label: "Position:",
                name: "position"
            }, {
                label: "Office:",
                name: "office"
            }, {
                label: "Extension:",
                name: "extn"
            }, {
                label: "Start date:",
                name: "start_date",
                type: "datetime"
            }, {
                label: "Salary:",
                name: "salary"
            }
        ]
    } );
    //ข้อมูล
    var data = [
    [
        "Tiger Nixon",
        "System Architect",
        "Edinburgh",
        "5421",
        "2011/04/25",
        "$3,120"
    ],
    [
        "Garrett Winters",
        "Director",
        "Edinburgh",
        "8422",
        "2011/07/25",
        "$5,300"
    ]
]
    var selectrow;
    var url;
    var method;


    $("#send_datafromsummit").click(sendtodb);
    $("#searchCatalog").click(sendtodb_fromsearch);
    $("#clear").click(clears);

    //เคลียร์ ค่า 
    function clears() {

    }

    //กำหนด table

   var table_catalog =   $('#myTable_catalog').DataTable({

        data: data,
       select: true,
      buttons: [
            { extend: "create", editor: editor },
            { extend: "edit",   editor: editor },
            { extend: "remove", editor: editor }
        ]
    });

    $('#myTable_catalog tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });




    $('#myTable_History').DataTable({

        data: data,
        select: true
    });

    $('#myTable_History tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });



    $('#myTable_Market').DataTable({

        data: data,
        select: true
    });

    $('#myTable_Market tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });


    //ส่งจากปุ่ม submit
    function sendtodb() {
        var command = $("#send_datafromsummit").attr('data-id');
        alert("ok")
        alert(command);
        if (command == 1) {
            selectrow = table_catalog.rows('.selected').data()
            url = 'Catalog_/Lend'
            method = 'GET'
            ajaxs(url, selectrow, method);
            alert("ok2")
        }
        else {
            var selectrow2 = document.querySelectorAll("#myTable_Account tbody").values();
            var selectrow3 = document.querySelectorAll("#myTable_catalog").values();
            var selectrow4 = document.querySelectorAll("#myTable_Market").values();
        }
    }

    //ส่งจากปุมค้นหา
     function sendtodb_fromsearch() {
        var command = $("#searchCatalog").attr('data-id');
        alert("ok")
         alert(command);
         var type = $('select[name=JobID] option').filter(':selected').val()
         var issnum = $("#Age").val()
         var from = $("#min-date").val()
         var to = $("#max-date").val()
         if (command == 1) {

            selectrow = table_catalog.rows('.selected').data()
            url = 'Catalog_/search'
            method = 'GET'
            ajaxs(url, selectrow, method);
            alert("ok2")
        }
        else {
            var selectrow2 = document.querySelectorAll("#myTable_Account tbody").values();
            var selectrow3 = document.querySelectorAll("#myTable_catalog").values();
            var selectrow4 = document.querySelectorAll("#myTable_Market").values();
        }
    }



    function ajaxs(url, selectrow, methods) {
        $.ajax({
            url: url,
            type: 'JSON',
            method: methods,
            data: selectrow,
            contentType: 'application/json',
            timeout: 60,
            success: function (res) {
                respone(res);
            }
        })
    }





 


 //Advance search 




     $( function() {
        $( ".datepicker" ).datepicker();
         format = "yy/dd/mm"
    } );

// Bootstrap datepicker
        $('.input-daterange input').each(function() {
        $(this).datepicker('clearDates');
        });

        // Set up your table
          table =   $('#myTable_Account').DataTable({

        data: data,
        select: true
    });

    $('#myTable_Account tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });


        // Extend dataTables search
        $.fn.dataTable.ext.search.push(
        function(settings, data, dataIndex) {
            var min = $('#min-date').val();
            var max = $('#max-date').val();
            var createdAt = data[7] || 7  // Our date column in the table

            if (
            (min == "" || max == "" ) ||
                (
                    moment(createdAt).isSameOrAfter(min) 
                &&  moment(createdAt).isSameOrBefore(max)
                 
                )  
            ) 
            {
            return true;
            }
            return false;
        }
        );
        $('#ex_filter').hide();
        // Re-draw the table when the a date range filter changes
        $('.date-range-filter').change(function() {
        table.draw();
        });


});

function respone(res) {
    data = JSON.parse(res);
}
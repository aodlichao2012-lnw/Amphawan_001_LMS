

//var data = [
//    [
//        "Tiger Nixon",
//        "System Architect",
//        "Edinburgh",
//        "5421",
//        "2011/04/25",
//        "$3,120"
//    ],
//    [
//        "Garrett Winters",
//        "Director",
//        "Edinburgh",
//        "8422",
//        "2011/07/25",
//        "$5,300"
//    ]
//]


function respone(res) {
    data = JSON.parse(res);
}
$(document).ready(function () {
    var data = [];
    var selectrow;
    var url;
    $("#send_datafromsummit").click(function (e ) {
        alert("ok")
        alert(e.values);
        if (e == 1) {
            selectrow = document.querySelectorAll("#myTable_Account").values();
            url = 'Account_/Index'
            ajaxs(url, selectrow);
            alert("ok2")
        }
        else {
            var selectrow2 = document.querySelectorAll("#myTable_Account tbody").values();
            var selectrow3 = document.querySelectorAll("#myTable_catalog").values();
            var selectrow4 = document.querySelectorAll("#myTable_Market").values();
        }
    })

    function ajaxs(url,selectrow) {
        $.ajax({
            url: url,
            type: 'JSON',
            method: 'POST',
            data: selectrow,
            contentType: 'application/json',
            timeout: 60,
            success: function (res) {
                respone(res);
            }
        })
    }
  
    $('#myTable_Account').DataTable({

        data: data,
        select: true
    });

    $('#myTable_Account tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });


    $('#myTable_catalog').DataTable({

        data: data,
        select: true
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
    }   );

    $('#myTable_Market tbody').on('click', 'tr', function () {
        $(this).toggleClass('selected');
    });

});

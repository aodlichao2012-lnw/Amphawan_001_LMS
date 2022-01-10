
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
$(document).ready(function () {


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


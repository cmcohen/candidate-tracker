$(function()
{
//    $(window).on('load', function () {
        if($("#status").text() !== "Pending")
        {
            $("#confirm-btn").remove();
            $("#refuse-btn").remove();
        }
    //})

    $("#confirm-btn").on('click', function () {
       
        $.post("/home/updatestatus", { id: $(this).data('id'), confirmed: true }, function () {
            $.get("/home/updatecount", function (result) {
                $("#pending").text(result.pending);
                $("#confirmed").text(result.confirmed);
                $("#refused").text(result.refused);
            })
            $("#confirm-btn").remove();
            $("#refuse-btn").remove();
        });
    })

    $("#refuse-btn").on('click', function () {

        $.post("/home/updatestatus", { id: $(this).data('id'), confirmed: false }, function () {
            $.get("/home/updatecount", function (result) {
                $("#pending").text(result.pending);
                $("#confirmed").text(result.confirmed);
                $("#refused").text(result.refused);
            })
            $("#confirm-btn").remove();
            $("#refuse-btn").remove();
        });
    })
})
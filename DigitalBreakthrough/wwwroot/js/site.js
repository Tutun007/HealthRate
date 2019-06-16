// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
  $('body').on('click','.book_all_doc', function(e) {
    e.preventDefault();
    $('.booking_day').datepicker('update', new Date());
    var date = $('#booking_popup input[name="date"]').val();
    $.ajax({
      type: "GET",
      url: "Api/Appointment/Get",
      data: {'date':date},
      beforeSend: function () {
 
      },
      success: function(t){ 
        $('#overlay').toggleClass('active');
        $('#booking_popup').toggleClass('active'); 
      }
    });
  });
  
  //popup
  
  $('body').on('click','.thickbox_cont .close', function(e) {
    e.preventDefault();
    $(this).parent('.thickbox_cont').removeClass('active');
    $('#overlay').removeClass('active');
  });
  
  $('body').on('click','.thickbox_cont .close2', function(e) {
    e.preventDefault();
    $(this).parents('.thickbox_cont').removeClass('active');
    $('#overlay').removeClass('active');
  });
  
  $(".input-append.date").datepicker({
    todayBtn: "linked",
    language: "ru",
    todayHighlight: true,
    orientation: "bottom auto",
    startDate: 0
  });

});
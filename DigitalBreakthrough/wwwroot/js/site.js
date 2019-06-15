// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
  $('body').on('click','.book_all_doc', function(e) {
    e.preventDefault();
    var date = $('#booking_popup input[name="date"]').val();
    $.ajax({
      type: "GET",
      url: "Api/Appointment",
      data: {'action':'add_ship_data','date':date},
      beforeSend: function () {
 
      },
      success: function(t){ 
        if(t=='OK'){
          
        }
        $('#overlay').toggleClass('active');
        $('#booking_popup').toggleClass('active'); 
      }
    });
    $('#overlay').toggleClass('active');
    $('#booking_popup').toggleClass('active');  
  });
  
  //popup
  
  $('body').on('click','.thickbox_cont .close', function(e) {
    e.preventDefault();
    $(this).parent('.thickbox_cont').removeClass('active');
    $('#overlay').removeClass('active');
  });
});
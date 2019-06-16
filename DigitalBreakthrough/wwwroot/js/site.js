// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
  $('body').on('click','.book_all_doc', function(e) {
    e.preventDefault();
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = dd + '.' + mm + '.' + yyyy;
    $('.auto_width_input').val(today);
    var date = $('#booking_popup input[name="date"]').val();
    $.ajax({
      type: "GET",
      url: "Api/Appointment/Get",
      data: {'date':date},
      beforeSend: function () {
        $('.booking_list').empty();
        $('#overlay').toggleClass('active');
        $('#booking_popup').toggleClass('active'); 
      },
      success: function(t){ 
        if(t!='') {
          //var obj = jQuery.parseJSON(t);
          $.each( t, function( key, value ) {
            var date_format = value.time;
            $('.booking_list').append('<li><a href="#" class="task" data-id="'+value.id+'" data-doc="'+value.doctorId+'" data-time="'+value.time+'">'+
              '<span class="docName">'+value.doctorName+'</span>'+
              '<span class="docTime">'+value.time+'</span>'
            +'</a></li>');
          });
        }        
      }
    });
  });
  
  $('body').on('change','.booking_day', function(e) {
    var date = $(this).val();
    $.ajax({
      type: "GET",
      url: "Api/Appointment/Get",
      data: {'date':date},
      beforeSend: function () {
        $('.booking_list').empty();
      },
      success: function(t){ 
        if(t!='') {
          //var obj = jQuery.parseJSON(t);
          $.each( t, function( key, value ) {
            $('.booking_list').append('<li><a href="#" class="task" data-id="'+value.id+'" data-doc="'+value.doctorId+'" data-time="'+value.time+'">'+
              '<span class="docName">'+value.doctorName+'</span>'+
              '<span class="docTime">'+value.time+'</span>'
            +'</a></li>');
          });
        }else {
          $('.booking_list').append('<p>Нет доступных врачей для данного периода!</p>');
        }
      }
    });
  });
  
  $('body').on('click','.booking_list a.task', function(e) {
    e.preventDefault();
    $('.booking_list a.active').removeClass('active');
    $(this).addClass('active');
  });
  
  $('body').on('click','.book_task', function(e) {
    e.preventDefault();
    if ($('.booking_list a.active').length){
      var book_id = $('.booking_list a.active').data('id');
      var user_id = $('#booking_popup input[name="user_id"]').val();
      $.ajax({
        type: "GET",
        url: "Api/Appointment/SignInto",
        data: {'userId':user_id,'appointmentId':book_id},
        beforeSend: function () {
          $('.booking_list').empty();
        },
        success: function(t){ 
          if(t!='') {
            //var obj = jQuery.parseJSON(t);
            $.each( t, function( key, value ) {
              $('.booking_list').append('<li><a href="#" class="task" data-id="'+value.id+'" data-doc="'+value.doctorId+'" data-time="'+value.time+'">'+
                '<span class="docName">'+value.doctorName+'</span>'+
                '<span class="docTime">'+value.time+'</span>'
              +'</a></li>');
            });
          }
        }
      });
    }else {
      alert('Выберите нужный прием врача');
    }
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
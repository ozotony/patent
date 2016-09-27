///<reference path="jquery-1.4.1-vsdoc.js"/>
//var serviceURL = "http://localhost:55482/Handlers/";
var serviceURL = "http://pt.cldng.com/Handlers/";

function doPrev(page) {
    window.location.href = page;
}

function doView(page) {
    window.open(page);
}
function postwith(to, p) {
    var myForm = document.createElement("form");
    myForm.method = "post";
    myForm.action = to;
    for (var k in p) {
        var myInput = document.createElement("input");
        myInput.setAttribute("name", k);
        myInput.setAttribute("value", p[k]);
        myForm.appendChild(myInput);
    }
    document.body.appendChild(myForm);
    myForm.submit();
    document.body.removeChild(myForm);
}

function doRenewalConfirm() {
    $("#main").hide();
    $("#p_title").empty().append($("#title").val());
    $("#p_item_code").empty().append($("#item_code").val());
    $("#p_type").empty().append($("#type").val());
    $("#p_app_no").empty().append($("#app_no").val());
    $("#p_app_date").empty().append($("#app_date").val());
    $("#p_xname").empty().append($("#xname").val());
    $("#p_xaddy").empty().append($("#xaddy").val());
    $("#p_xmobile").empty().append($("#xmobile").val());
    $("#p_xemail").empty().append($("#xemail").val());
    $("#p_agt_name").empty().append($("#agt_name").val());
    $("#p_agt_code").empty().append($("#agt_code").val());
    $("#p_agt_addy").empty().append($("#agt_addy").val());
    $("#p_agt_mobile").empty().append($("#agt_mobile").val());
    $("#p_agt_email").empty().append($("#agt_email").val());
    $("#p_last_rwl_date").empty().append($("#last_rwl_date").val());
    $("#confirm").show();
}

function doRenewalEdit() {
    $("#main").show();
    
    $("#confirm").hide();
}

function addRenewal() {
    var to = 'addRenewal.ashx';
    var hwalletID = $("#hwalletID").val();
    var title = $("#title").val();
    var type = $("#type").val();
    var app_no = $("#app_no").val();
    var app_date = $("#app_date").val();
    var xname = $("#xname").val();
    var xaddy = $("#xaddy").val();
    var xmobile = $("#xmobile").val();
    var xemail = $("#xemail").val();
    var agt_code = $("#agt_code").val();
    var agt_name = $("#agt_name").val();
    var agt_addy = $("#agt_addy").val();
    var agt_mobile = $("#agt_mobile").val();
    var agt_email = $("#agt_email").val();
    var last_rwl_date = $("#last_rwl_date").val();
    var transID = $("#transID").val();
    var payment_date = $("#payment_date").val();
    var serverpath = $("#serverpath").val();
    var amt = $("#amt").val();
    var log_staffID = $("#log_staffID").val();
    var item_code = $("#item_code").val();
//    if ((xemail == "") || (validate_email(xemail) == false)) {
//        $("#xemail").css('border-color', 'red');
////        $('#acc_error_img').fadeIn(1000).show();
////        $('#acc_success_msg').empty().fadeIn(1000).show().append("The email field cannot be empty and must be in the correct format E.g: 'agent@x.com'");
//    }
//    if ((xmobile == "") || (validate_mobile(xmobile) == false)) {
//        $("#xmobile").css('border-color', 'red');
////        $('#acc_error_img').fadeIn(1000).show();
////        $('#acc_success_msg').empty().fadeIn(1000).show().append("The mobile field cannot be empty and must be a mobile GSM number E.g: '08080000000'");
//    }
//    if ((agt_email == "") || (validate_email(agt_email) == false)) {
//        $("#agt_email").css('border-color', 'red');
//        //        $('#acc_error_img').fadeIn(1000).show();
//        //        $('#acc_success_msg').empty().fadeIn(1000).show().append("The email field cannot be empty and must be in the correct format E.g: 'agent@x.com'");
//    }
   
//    if ((agt_mobile == "") || (validate_mobile(agt_mobile) == false)) {
//        $("#agt_mobile").css('border-color', 'red');
//        //        $('#acc_error_img').fadeIn(1000).show();
//        //        $('#acc_success_msg').empty().fadeIn(1000).show().append("The mobile field cannot be empty and must be a mobile GSM number E.g: '08080000000'");
//    }   
    /////////
    if (title == "") {
        $("#title").css('border-color', 'red');
    }
    if (app_no == "") {
        $("#app_no").css('border-color', 'red');
    }
    if (app_date == "") {
        $("#app_date").css('border-color', 'red');
    }

    if ((xname == "")) {
        $("#xname").css('border-color', 'red');
    }

    if (xaddy == "") {
        $("#xaddy").css('border-color', 'red');
    }
    if (agt_name == "") {
        $("#agt_name").css('border-color', 'red');
    }
    if (agt_addy == "") {
        $("#agt_addy").css('border-color', 'red');
    }
    
    if ((last_rwl_date == "")) {
        $("#last_rwl_date").css('border-color', 'red');
    }

    if ((agt_code == "")) {
        $("#agt_code").css('border-color', 'red');
    }
    if ((title != "")
    && (type != "")
    && (app_no != "")
    && (app_date != "")
    && (xname != "")
    && (xaddy != "")
    && (agt_name != "")
    && (agt_code != "")
    && (agt_addy != "")
    && (last_rwl_date != "")
    && (transID != "")
    && (serverpath != "")
    && (amt != "")
    && (log_staffID != "")
    && (item_code != "")
    //&& (validate_mobile(agt_mobile) == true) //&& (validate_email(agt_email) == true)
    //&& (validate_mobile(xmobile) == true) //&& (validate_email(xemail) == true)
    ) {     
        ajaxindicatorstart('Loading .. please wait..');
      //  $.blockUI({ message: '<h3><img src="./images/loading.gif" /><br/>Please wait2...</h3>', css: { backgroundColor: '#1C5E55', color: '#fff', width: '50%', top: '30%', left: '25%' } });

        $.post(serviceURL + to,
        { 'title': title, 'app_no': app_no, 'type': type, 'app_date': app_date, 'xname': xname, 'xaddy': xaddy, 'xmobile': xmobile,
            'xemail': xemail, 'agt_code': agt_code, 'agt_name': agt_name, 'agt_addy': agt_addy, 'agt_mobile': agt_mobile, 'agt_email': agt_email, 'last_rwl_date': last_rwl_date,
            'hwalletID': hwalletID, 'transID': transID, 'serverpath': serverpath, 'amt': amt, 'item_code': item_code, 'log_staffID': log_staffID
        },
        function (data) {
            var member = data.msg;
            alert(data)
            if ((member != null) && (member > 0)) {
                //                $('#acc_error_img').fadeOut(1000).hide(); $('#acc_error_msg').empty().fadeOut(1000).hide();
                //                $('#acc_success_img').fadeIn(1000).show();
                //                $("#acc_success_msg").empty().append('Details for Agent <b>' + txt_firstname + ' ' + txt_surname + '</b> were updated successfully!!').show();
                //                $("#btnUpdateApplication").hide();
              //  $.unblockUI();
                ajaxindicatorstop();
                alert('Renewal Application for Applicant \"' + xname + '\" was added successfully!!');

                postwith('ren_ack.aspx', { 'title': title, 'app_no': app_no, 'type': type, 'app_date': app_date, 'xname': xname, 'xaddy': xaddy, 'xmobile': xmobile,
                    'xemail': xemail, 'agt_code': agt_code, 'agt_name': agt_name, 'agt_addy': agt_addy, 'agt_mobile': agt_mobile, 'agt_email': agt_email, 'last_rwl_date': last_rwl_date,
                    'xid': member, 'transID': transID, 'payment_date': payment_date
                });
            }
            else {
                //  $.unblockUI();
                ajaxindicatorstop();
                alert('Renewal Application for Applicant \"' + xname + '\" was not successful,Please try again!!');
                //                $('#acc_error_img').fadeIn(1000).show();
                //                $("#acc_success_msg").empty().append('Details for Agent <b>' + txt_firstname + ' ' + txt_surname + '</b> could not be updated. Please try again later!!').show();
            }
        },
        "json"
    );
    }
    else {
        //  $.unblockUI();
        ajaxindicatorstop();
    }
}
//////////////////////////////////////////////////////////////////////


////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////VALIDATION SECTION////////////////////////////////////
function validate_email(inputstr) {
    var pattern =
/^[a-zA-Z0-9_\-.]+@([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,3}$/;
    if (inputstr.search(pattern) > -1) {
        return true;
    } else {
        return false;
    }
}

function validate_mobile(inp) {
    var pattern = /^\d{11}$/;
    if (inp.search(pattern) > -1) {
        return true;
    } else {
        return false;
    }
}

function validate_ban(inp) {
    var pattern = /^\d{1,10}$/;
    if (inp.search(pattern) > -1) {
        return true;
    }
    else {
        return false;
    }
}


function ajaxindicatorstart(text) {

    if (jQuery('body').find('#resultLoading').attr('id') != 'resultLoading') {

        jQuery('body').append('<div id="resultLoading" style="display:none"><div><img src="ajax-loader.jpg"><div>' + text + '</div></div><div class="bg"></div></div>');

    }



    jQuery('#resultLoading').css({

        'width': '100%',

        'height': '100%',

        'position': 'fixed',

        'z-index': '10000000',

        'top': '0',

        'left': '0',

        'right': '0',

        'bottom': '0',

        'margin': 'auto'

    });



    jQuery('#resultLoading .bg').css({

        'background': '#000000',

        'opacity': '0.7',

        'width': '100%',

        'height': '100%',

        'position': 'absolute',

        'top': '0'

    });



    jQuery('#resultLoading>div:first').css({

        'width': '250px',

        'height': '75px',

        'text-align': 'center',

        'position': 'fixed',

        'top': '0',

        'left': '0',

        'right': '0',

        'bottom': '0',

        'margin': 'auto',

        'font-size': '16px',

        'z-index': '10',

        'color': '#ffffff'



    });



    jQuery('#resultLoading .bg').height('100%');

    jQuery('#resultLoading').fadeIn(300);

    jQuery('body').css('cursor', 'wait');

}

function ajaxindicatorstop() {

    jQuery('#resultLoading .bg').height('100%');

    jQuery('#resultLoading').fadeOut(300);

    jQuery('body').css('cursor', 'default');

}


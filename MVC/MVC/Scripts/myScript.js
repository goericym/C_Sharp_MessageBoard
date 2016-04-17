function Check_Main(){
	var MsgValue = document.getElementById("NewMessage").value;
	if(MsgValue.length==0)	  
	{
		document.getElementById("tip01").style.color = "red";
		document.getElementById("tip01").style.display = 'block';
		document.getElementById("NewMessage").focus();
		return false;
	}else
	{
		document.getElementById("tip01").style.display = 'none';
	}
	//post
	$.ajax({
		type: 'POST',
		url: 'index.php',
		data: { NewMsg : document.getElementById("NewMessage").value,
				action : document.getElementById("action").value
                },
		dataType: 'text',
		success: function(response) {
			$('.NewMsg').append(response);
			document.getElementById("NewMessage").value="";
		}
	});
	//document.forms[0].submit();
}

function DoReMsg(id) {
    //var html="<b>留言</b>";
    var Mainid="main"+id;
    var Addid="add"+id;
    $('.'+Addid).hide();
    $('.'+Addid).remove();
    var html='<div class="add'+id+'"><b>回覆留言</b> <font class="FontColorClass01">  </font> <br><br>  <input type="text" name="NewMsg" id="ReMessage"> <p id="tip01" style="display:none">請輸入留言!</p>    <p align="right"> <input class="button" type="button" value="發佈" onclick="Check_ReMsg('+id+')"> <input type="button" value="取消" onclick="Remove_ReMsg('+id+')"></p></div>';
    $('.'+Mainid).append(html);
    $('.'+Addid).hide();
    $('.'+Addid).fadeIn('slow');
    //$('.'+mainid).hide().append(html).fadeIn('slow');
}
function Remove_ReMsg(id){
    //var html="<b>留言</b>";

    var Addid="add"+id;
    $('.'+Addid).hide();
    $('.'+Addid).remove();
    //$('.'+mainid).hide().append(html).fadeIn('slow');
}
function Check_ReMsg(id){
    var MsgValue = document.getElementById("ReMessage").value;
    if(MsgValue.length==0)
    {
        document.getElementById("tip01").style.color = "red";
        document.getElementById("tip01").style.display = 'block';
        document.getElementById("ReMessage").focus();
        return false;
    }else
    {
        document.getElementById("tip01").style.display = 'none';
    }
    //console.log(id);
    //post
    $.ajax({
        type: 'POST',
        url: 'index.php',
        data: { ReMsg : document.getElementById("ReMessage").value,
            action : 'ReMsg',
            Re_Id:id
        },
        dataType: 'text',
        success: function(response) {
            var mainid="main"+id
            var addid="add"+id
            $('.'+addid).remove();
            $('.'+mainid).append(response);
            //document.getElementById("ReMessage").value="";
        }
    });
    //document.forms[0].submit();
}
function Check_Login(){

	var accountValue = document.getElementById("account").value;
	var PasswdValue = document.getElementById("passwd").value;
	reEng=/^[a-zA-Z0-9]+$/;

	if(accountValue.length<6)	  
	{
		//alert("帳號最少6位字元!");
		document.getElementById("tip01").style.color = "red";
		document.getElementById("account").focus();
		return false;
	}else
	{
		document.getElementById("tip01").style.color = "gray";
	}
	
	if(!reEng.test(PasswdValue))
	{
		document.getElementById("tip03").style.color = "red";
		document.getElementById("passwd").focus();
		return false;
	}else
	{
		document.getElementById("tip03").style.color = "gray";
	}

	document.forms[0].submit();
}
function Check_Regedit(){

	var accountValue = document.getElementById("account").value;
	var UserNameValue = document.getElementById("username").value;
	var PasswdValue = document.getElementById("passwd").value;
	var CheckPasswdValue = document.getElementById("check_passwd").value;
	reBig5=/^[\u4E00-\u9FA5]+$/;	
	reEng=/^[a-zA-Z0-9]+$/;
	
	if(accountValue.length<6)	  
	{
		//alert("帳號最少6位字元!");
		document.getElementById("tip01").style.color = "red";
		document.getElementById("account").focus();
		return false;
	}else
	{
		document.getElementById("tip01").style.color = "gray";
	}

	if(!reBig5.test(UserNameValue))
	{
		document.getElementById("tip02").style.color = "red";
		document.getElementById("username").focus();
		return false;
	}else
	{
		document.getElementById("tip02").style.color = "gray";
	}

	if(!reEng.test(PasswdValue))
	{
		document.getElementById("tip03").style.color = "red";
		document.getElementById("passwd").focus();
		return false;
	}else
	{
		document.getElementById("tip03").style.color = "gray";
	}

	if(PasswdValue!=CheckPasswdValue)
	{
		document.getElementById("tip04").style.color = "red";
		document.getElementById("check_passwd").focus();			
		return false;
	}else
	{
		document.getElementById("tip04").style.color = "gray";
	}

	document.forms[0].submit();

 }
 function detectCapsLock(e){

 	valueCapsLock = e.keyCode ? e.keyCode:e.which;
	valueShift = e.shiftKey ? e.shiftKey:((valueCapsLock == 16) ? true : false);
	var SelectedID = document.activeElement.id;
	//console.log(valueCapsLock + " : " + valueShift + " : "+SelectedID);

   if (((valueCapsLock >= 65 && valueCapsLock <= 90) && !valueShift) || ((valueCapsLock >= 97 && valueCapsLock <= 122) && valueShift)) 
   {
       //請注意 ！Caps Lock 鍵目前為開啟狀態。
	   if(SelectedID=="passwd")
		document.getElementById("tip03").innerHTML="大小寫區別，請注意！Caps Lock 鍵目前為開啟狀態。";
		else
		document.getElementById("tip04").innerHTML="密碼與確認密碼相符，請注意！Caps Lock 鍵目前為開啟狀態。";
   }
   else 
   {
		document.getElementById("tip03").innerHTML="大小寫區別";
		if (typeof tip04 != 'undefined') {
			document.getElementById("tip04").innerHTML="密碼與確認密碼相符";
		}
		
	   
   }
 }

 function CreateMsg()
 {
     var token = $('input[name="__RequestVerificationToken"]').val();
     $.ajax({
         type: 'POST',
         url: '/messages/Create',
         data: {
             Message1: document.getElementById("Message1").value,
             Account: document.getElementById("Account").value,
             __RequestVerificationToken: token
         },
         dataType: 'text',
         success: function (response) {
             alert("successfully");
             // alert(response);
         }
     });
 }
 function DoModify(id) {
     
    var Msgid="Msg"+id;

    $.ajax({
        type: 'POST',
        url: 'index.php',
        data: { Msg : document.getElementById(Msgid).value,
            action : 'Modify',
            hid:id,
            MsgId:Msgid
        },
        dataType: 'text',
        success: function(response) {
           alert("successfully");
           // alert(response);
        }
    });
}

function DoDelete(id) {

    var Mainid="main"+id;
    $.ajax({
        type: 'POST',
        url: 'index.php',
        data: { action : 'Delete',
            hid:id
        },
        dataType: 'text',
        success: function(response) {
            alert("successfully");
            $('.'+Mainid).hide();
        }
    });
}
var AutoLoad=function(){
	var URLs="index.php";
	$.ajax({
		url: URLs,
		data: { action : 'GetAllMsg'},
		type:"POST",
		dataType:'text',
		success: function(html){
			$('.main').append(html);
		},
		beforeSend:function(){
			$('#loadingIMG').show();
		},
		complete:function(){
			$('#loadingIMG').hide();
		},
		error:function(xhr, ajaxOptions, thrownError){
			alert(xhr.status);
			alert(thrownError);
		}
	});
}

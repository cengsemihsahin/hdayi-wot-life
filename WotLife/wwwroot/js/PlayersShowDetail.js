$(PlayersDetailpageReady);

function PlayersDetailpageReady() {
    if (/iPhone|iPad|iPod/i.test(navigator.userAgent)) {

    }
    else {
        $("#PlayersDetailtopdiv #PlayersDetailCombo1Div").css("overflow", "hidden");
        $("#PlayersDetailtopdiv #PlayersDetailCombo2Div").css("overflow", "hidden");
    }
    GetPlayersDetail();
    $.ajaxSetup({ cache: false });
}

var formPlayersDetailData;

function GetPlayersDetail() {
    $("#PlayersDetailSpinPopup").css("display", "block");
    var deviceHeight = (typeof window.outerHeight != 'undefined') ? Math.max(window.outerHeight, $(window).height()) : $(window).height();
    if (isBreakpointGet('xs')) {
        dialogHeight = Number(deviceHeight) / 1.65;
    }
    else {
        dialogHeight = Number(deviceHeight) / 1.75;
    }
    if (document.getElementById("PlayersShowShowtabs")) {
        document.getElementById("PlayersDetailFormData").style.height = "150px";
    }
    else {
        document.getElementById("PlayersDetailtopdiv").style.height = dialogHeight + "px";
    }
    var PKIDget = $("#PlayersForm [name=Player_ID]").val();
    formPlayersDetailData = "Player_ID=" + PKIDget;
    if (PKIDget != -1) {
        var itemsoptype = "<option value='-1'>dummy</option>";
        $("#PlayersDetailValForm [name=PlayersnormcomboADDCombo]").html(itemsoptype);
        setTimeout(PlayersDetailGoToServer, 30);
    }
    else {
        $("#PlayersDetailSpinPopup").css("display", "none");
        PlayersDetailEditForm('ADD');
    }
}

function PlayersDetailGoToServerAdd() {
    $.post(PlayersDetailGetAddURL, formPlayersDetailData, function (data, textStatus) {
        PlayersDetailDisplayRecordAdd(data);
    }, "json")
}

function PlayersDetailDisplayRecordAdd(jsonScript) {
    if (jsonScript.ReturnStatus == true) {
        PlayersDetailDisplayWorkerTypesADD(jsonScript.PlayersnormcomboList);
    }
    var returnMessage = "";
    var i = 0;
    for (i = 0; i < jsonScript.ReturnMessage.length; i++) {
        returnMessage = returnMessage + jsonScript.ReturnMessage[i] + "\n";
    }
    if (jsonScript.ReturnStatus == true) { }
    else {
        alert("" + returnMessage);
    }
}

function PlayersDetailGoToServer() {
    $.ajax(
        PlayersDetailGetURL, {
        type: 'GET',
        data: formPlayersDetailData,
        success: function (data, status, xhr) {
            PlayersDetailDisplayRecord(data);
        },
        error: function (jqXhr, textStatus, errorMessage) {
            alert(" errorMessage is:- " + errorMessage + "\n Xhr.status is :- " + jqXhr.status + "\n Xhr.responseText is :- " + jqXhr.responseText + "\n textStatus is :- " + textStatus);
        }
    });
}

function PlayersShowit() {
    $("#PlayersShowit").val("showit");
}

function PlayersDetailDisplayRecord(jsonScript) {
    $("#PlayersDetailSpinPopup").css("display", "none");
    try {
        if (document.getElementById("PlayersShowShowtabs")) {

        }
        else {

        }
    }
    catch (err) {

    }

    if (jsonScript.ReturnStatus == true) {
        $("#PlayersDetailForm [name=Player_ID]").val(jsonScript.Player_ID);
        $("#PlayersDetailValForm [name=Nickname_in]").val(jsonScript.Nickname);
        $("#PlayersDetailValForm [name=Nickname_inCopy]").val(jsonScript.Nickname);
        $('#PlayersDetailValForm [name=Nickname_in]').attr('readonly', true);
        $("#PlayersDetailValForm [name=Nickname_in]").css("background-color", "#ebeff2");
        $("#PlayersDetailValForm [name=Battles_in]").val(jsonScript.Battles);
        $("#PlayersDetailValForm [name=Battles_inCopy]").val(jsonScript.Battles);
        $('#PlayersDetailValForm [name=Battles_in]').attr('readonly', true);
        $("#PlayersDetailValForm [name=Battles_in]").css("background-color", "#ebeff2");
        $("#PlayersDetailValForm [name=Wn_State_in]").val(jsonScript.Wn_State);
        $("#PlayersDetailValForm [name=Wn_State_inCopy]").val(jsonScript.Wn_State);
        $('#PlayersDetailValForm [name=Wn_State_in]').attr('readonly', true);
        $("#PlayersDetailValForm [name=Wn_State_in]").css("background-color", "#ebeff2");
        $("#PlayersDetailValForm [name=Damage_in]").val(jsonScript.Damage);
        $("#PlayersDetailValForm [name=Damage_inCopy]").val(jsonScript.Damage);
        $('#PlayersDetailValForm [name=Damage_in]').attr('readonly', true);
        $("#PlayersDetailValForm [name=Damage_in]").css("background-color", "#ebeff2");
        $("#PlayersDetailValForm #Playersradio3").attr("checked", false);
        $("#PlayersDetailValForm #Playersradio1").attr("checked", false);
        $("#PlayersDetailValForm #Playersradio2").attr("checked", false);
        if (jsonScript.Sex == "M") {
            $("#PlayersDetailValForm #Playersradio1").attr("checked", true);
            $('#PlayersDetailValForm #PlayersRadio1_inCopy').attr('checked', true);
        }
        if (jsonScript.Sex == "F") {
            $("#PlayersDetailValForm #Playersradio2").attr("checked", true);
            $('#PlayersDetailValForm #PlayersRadio2_inCopy').attr('checked', true);
        }
        if (jsonScript.Sex == "O") {
            $("#PlayersDetailValForm #Playersradio3").attr("checked", true);
            $('#PlayersDetailValForm #PlayersRadio3_inCopy').attr('checked', true);
        }
        PlayersDetailFormatFields();
        $("#btnPlayersDetailCancel").css("visibility", "visible");
        $("#btnPlayersDetailCancel").css("display", "");
        $("#btnPlayersDetailEdit").css("visibility", "visible");
        $("#btnPlayersDetailEdit").css("display", "");
        $('#PlayersDetailtopdiv [name=comboCheckit]').val("False");
    }

    var returnMessage = "";
    var i = 0;
    for (i = 0; i < jsonScript.ReturnMessage.length; i++) {
        returnMessage = returnMessage + jsonScript.ReturnMessage[i] + "\n";
    }
    if (jsonScript.ReturnStatus == true) {

    }
    else {
        alert("" + returnMessage);
    }
}

function PlayersDetailDisplayWorkerTypesADD(SList) {
    var defaulte = "";
    var defaulteID = "";
    var items = "<option value='" + defaulteID + "'>" + defaulte + "</option>";
    $.each(SList, function (i, item) {
        items += "<option value='" + item.normcombopkid + "'>" + item.normcombocol1 + "</option>";
    });
    $("#PlayersDetailValForm [name=PlayersnormcomboADDCombo]").html(items);
}

function PlayersDetailDisplayWorkerTypes(SList) {
    var defaulte; var defaulteID;
    defaulte = $("#PlayersDetailValForm [name=WorkerType_in]").val();
    defaulteID = $("#PlayersDetailForm [name=normcombopkid]").val();
    var items = "<option value='" + defaulteID + "'>" + defaulte + "</option>";
    $.each(SList, function (i, item) {
        if (item.Worker_Type_ID != defaulteID) {
            items += "<option value='" + item.normcombopkid + "'>" + item.normcombocol1 + "</option>";
        }
    });
    $("#PlayersDetailValForm [name=PlayersnormcomboEDITCombo]").html(items);
}

function PlayersDetailDisplayWorkerTypesTEXT(SList) {
    var defaulte; defaulte = $("#PlayersDetailValForm [name=WorkerType_in]").val();
    var items = "<option value='" + defaulte + "'>" + defaulte + "</option>";
    $.each(SList, function (i, item) {
        if (item.Worker_Type != defaulte) {
            items += "<option value='" + item.normcombocol1 + "'>" + item.normcombocol1 + "</option>";
        }
    });
    $("#PlayersDetailValForm [name=PlayersnormcomboEDITCombo]").html(items);
}

function PlayersDetailFormatFields() {
    $("#PlayersDetailValForm [name=Nickname_in]").css("width", "100%");
    $("#PlayersDetailValForm [name=Nickname_in]").css("text-align", "left");
    $("#PlayersDetailValForm [name=Battles_in]").css("width", "80px");
    $("#PlayersDetailValForm [name=Battles_in]").css("text-align", "right");
    $("#PlayersDetailValForm [name=Wn_State_in]").css("width", "80px");
    $("#PlayersDetailValForm [name=Wn_State_in]").css("text-align", "right");
    $("#PlayersDetailValForm [name=Damage_in]").css("width", "80px");
    $("#PlayersDetailValForm [name=Damage_in]").css("text-align", "right");
    $("#PlayersDetailValForm [name=WorkerType_in]").css("width", "150px");
    $("#PlayersDetailValForm [name=WorkerType_in]").css("text-align", "left");
}
function PlayersDetailEditForm(opt) {
    $('#PlayersDetailtopdiv [name=comboCheckit]').val("True");
    $("#btnPlayersDetailSave").css("visibility", "visible");
    $("#btnPlayersDetailSave").css("display", "");
    $("#btnPlayersDetailEdit").css("visibility", "hidden");
    $("#btnPlayersDetailEdit").css("display", "none");
    $("#btnPlayersDetailCancel").css("visibility", "hidden");
    $("#btnPlayersDetailCancel").css("display", "none");
    if (opt != "ADD") {
        $("#btnPlayersDetailCancelEDIT").css("visibility", "visible");
        $("#btnPlayersDetailCancelEDIT").css("display", "");
    }
    else {
        $("#PlayersDetailFormData").css("display", "");
        $("#btnPlayersDetailCancelADD").css("visibility", "visible");
        $("#btnPlayersDetailCancelADD").css("display", "");
    }
    $('#PlayersDetailValForm [name=Nickname_in]').removeAttr('readonly');
    $('#PlayersDetailValForm [name=Nickname_in]').removeAttr('disabled');
    $("#PlayersDetailValForm [name=Nickname_in]").css("background-color", "#ffffff");
    $("#PlayersDetailValForm [name=Nickname_in]").val($("#PlayersDetailValForm [name=Nickname_inCopy]").val());
    $('#PlayersDetailValForm [name=Battles_in]').removeAttr('readonly');
    $('#PlayersDetailValForm [name=Battles_in]').removeAttr('disabled');
    $("#PlayersDetailValForm [name=Battles_in]").css("background-color", "#ffffff");
    $("#PlayersDetailValForm [name=Battles_in]").val($("#PlayersDetailValForm [name=Battles_inCopy]").val());
    $('#PlayersDetailValForm [name=Wn_State_in]').removeAttr('readonly');
    $('#PlayersDetailValForm [name=Wn_State_in]').removeAttr('disabled');
    $("#PlayersDetailValForm [name=Wn_State_in]").css("background-color", "#ffffff");
    $("#PlayersDetailValForm [name=Wn_State_in]").val($("#PlayersDetailValForm [name=Wn_State_inCopy]").val());
    $('#PlayersDetailValForm [name=Damage_in]').removeAttr('readonly');
    $('#PlayersDetailValForm [name=Damage_in]').removeAttr('disabled');
    $("#PlayersDetailValForm [name=Damage_in]").css("background-color", "#ffffff");
    $("#PlayersDetailValForm [name=Damage_in]").val($("#PlayersDetailValForm [name=Damage_inCopy]").val());
    PlayersDetailFormatFields();
    $("#PlayersDetailValForm #Playersradio1").removeAttr("disabled");
    $("#PlayersDetailValForm #Playersradio2").removeAttr("disabled");
    $("#PlayersDetailValForm #Playersradio3").removeAttr("disabled");
}

function PlayersDetailCancelForm() {
    $("#DivErrPlayersDetailBattles_in").css("display", "none");
    $("#DivErrPlayersDetailNickname_in").css("display", "none");
    $("#DivErrPlayersDetailDamage_in").css("display", "none");
    //$("#DivErrPlayersDetailWn_State_in").css("display", "none"); // BURASI
    $('#PlayersDetailtopdiv [name=comboCheckit]').val("False");
    $("#DivErrorPlayersDetail").css("display", "none");
    var datecopy = "";
    var datecopy2 = "";
    $("#btnPlayersDetailSave").css("visibility", "hidden");
    $("#btnPlayersDetailSave").css("display", "none");
    $("#btnPlayersDetailCancelEDIT").css("visibility", "hidden");
    $("#btnPlayersDetailCancelEDIT").css("display", "none");
    $("#btnPlayersDetailEdit").css("visibility", "visible");
    $("#btnPlayersDetailEdit").css("display", "");
    $("#btnPlayersDetailCancel").css("visibility", "visible");
    $("#btnPlayersDetailCancel").css("display", "");
    $('#PlayersDetailValForm [name=Nickname_in]').attr('readonly', true);
    $("#PlayersDetailValForm [name=Nickname_in]").css("background-color", "#ebeff2");
    $("#PlayersDetailValForm [name=Nickname_in]").val($("#PlayersDetailValForm [name=Nickname_inCopy]").val());
    $('#PlayersDetailValForm [name=Battles_in]').attr('readonly', true);
    $("#PlayersDetailValForm [name=Battles_in]").css("background-color", "#ebeff2");
    $("#PlayersDetailValForm [name=Battles_in]").val($("#PlayersDetailValForm [name=Battles_inCopy]").val());
    $('#PlayersDetailValForm [name=Wn_State_in]').attr('readonly', true);
    $("#PlayersDetailValForm [name=Wn_State_in]").css("background-color", "#ebeff2");
    $("#PlayersDetailValForm [name=Wn_State_in]").val($("#PlayersDetailValForm [name=Wn_State_inCopy]").val());
    $('#PlayersDetailValForm [name=Damage_in]').attr('readonly', true);
    $("#PlayersDetailValForm [name=Damage_in]").css("background-color", "#ebeff2");
    $("#PlayersDetailValForm [name=Damage_in]").val($("#PlayersDetailValForm [name=Damage_inCopy]").val());
    if ($('#PlayersDetailValForm #PlayersRadio1_inCopy').is(":checked")) {
        $('#PlayersDetailValForm #Playersradio1').attr('checked', true);
    }
    if ($('#PlayersDetailValForm #PlayersRadio2_inCopy').is(":checked")) {
        $('#PlayersDetailValForm #Playersradio2').attr('checked', true);
    }
    if ($('#PlayersDetailValForm #PlayersRadio3_inCopy').is(":checked")) {
        $('#PlayersDetailValForm #Playersradio3').attr('checked', true);
    }
    $("#PlayersDetailValForm #Playersradio3").attr("disabled", "disabled");
    $("#PlayersDetailValForm #Playersradio1").attr("disabled", "disabled");
    $("#PlayersDetailValForm #Playersradio2").attr("disabled", "disabled");
}
var PlayersDetailValidChk = "";
function PlayersDetailFieldValidate() {
    $("#DivErrPlayersDetailBattles_in").html("&nbsp;");
    $("#DivErrPlayersDetailNickname_in").html("&nbsp;");
    //$("#DivErrPlayersDetailWn_State_in").html("&nbsp;"); // BURASI
    $("#DivErrPlayersDetailDamage_in").html("&nbsp;");
    $("#PlayersDetailBattlesOK").css("display", "inline-block");
    $("#PlayersDetailNicknameOK").css("display", "inline-block");
    $("#PlayersDetailWn_StateOK").css("display", "inline-block");
    $("#PlayersDetailDamageOK").css("display", "inline-block");
    PlayersDetailValidChk = "true"; var returnErrMessage = "";
    var Nickname_inVal = $("#PlayersDetailValForm [name=Nickname_in]").val();
    Nickname_inVal = Nickname_inVal.trim();
    if (Nickname_inVal.length < 3) {
        returnErrMessage = "Takma ad (nickname) en az 2 karakter olmali";
        $("#DivErrPlayersDetailNickname_in").html(returnErrMessage);
        $("#PlayersDetailNicknameOK").css("display", "none"); PlayersDetailValidChk = "false";
    }
    if (Nickname_inVal == "") {
        returnErrMessage = "Lutfen nickname (oyun ici takma ad) giriniz.";
        $("#DivErrPlayersDetailNickname_in").html(returnErrMessage);
        $("#PlayersDetailNicknameOK").css("display", "none");
        PlayersDetailValidChk = "false";
    }
    var Battles_inVal = $("#PlayersDetailValForm [name=Battles_in]").val();
    Battles_inVal = Battles_inVal.trim();
    if (isNaN(Battles_inVal)) {
        returnErrMessage = "Savas sayisi tam sayi olmalidir.";
        $("#DivErrPlayersDetailBattles_in").html(returnErrMessage);
        $("#PlayersDetailBattlesOK").css("display", "none");
        PlayersDetailValidChk = "false";
    }
    var Wn_State_inVal = $("#PlayersDetailValForm [name=Wn_State_in]").val();
    Wn_State_inVal = Wn_State_inVal.trim();
    if (isNaN(Wn_State_inVal)) {
        returnErrMessage = "WN tam sayi girilmelidir.";
        //$("#DivErrPlayersDetailWn_State_in").html(returnErrMessage); // BURASI
        $("#PlayersDetailWn_StateOK").css("display", "none");
        //PlayersDetailValidChk = "false";
    }
    var Damage_inVal = $("#PlayersDetailValForm [name=Damage_in]").val();
    Damage_inVal = Damage_inVal.trim();
    if (isNaN(Damage_inVal)) {
        returnErrMessage = "Damage (hasar) tam sayi girilmelidir.";
        $("#DivErrPlayersDetailDamage_in").html(returnErrMessage);
        $("#PlayersDetailDamageOK").css("display", "none");
        PlayersDetailValidChk = "false";
    }
}

var PlayersDetailDateValidChk = "";

function PlayersDetailvaliddateaud(inputText) {
    PlayersDetailDateValidChk = "true";
    try {
        var res = inputText.split("-");
        var mon = res[1];
        var dayy = res[0];
        var yyy = res[2];
        if (mon == "Jan") {
            mon = "01";
        }
        if (mon == "Feb") {
            mon = "02";
        }
        if (mon == "Mar") {
            mon = "03";
        }
        if (mon == "Apr") {
            mon = "04";
        }
        if (mon == "May") {
            mon = "05";
        }
        if (mon == "Jun") {
            mon = "06";
        }
        if (mon == "Jul") {
            mon = "07";
        }
        if (mon == "Aug") {
            mon = "08";
        }
        if (mon == "Sep") {
            mon = "09";
        }
        if (mon == "Oct") {
            mon = "10";
        }
        if (mon == "Nov") {
            mon = "11";
        }
        if (mon == "Dec") {
            mon = "12";
        }
        var is_chrome = navigator.userAgent.indexOf('Chrome') > -1;
        var is_explorer = navigator.userAgent.indexOf('MSIE') > -1;
        var is_firefox = navigator.userAgent.indexOf('Firefox') > -1;
        var is_safari = navigator.userAgent.indexOf("Safari") > -1;
        var is_opera = navigator.userAgent.toLowerCase().indexOf("op") > -1;
        if ((is_chrome) && (is_safari)) {
            is_safari = false;
        }
        if ((is_chrome) && (is_opera)) {
            is_chrome = false;
        }
        if (is_safari) {

        }

        if (is_safari) {
            var inputDates = new Date(mon + "/" + dayy + "/" + yyy);
            var timestamps = Date.parse(inputDates.toUTCString());
            if (isNaN(timestamps) == true) {
                PlayersDetailDateValidChk = "false";
            }
        }
        else {
            var inputDate = new Date(yyy + "-" + mon + "-" + dayy);
            var timestamp = Date.parse(inputDate);
            if (isNaN(timestamp) == true) {
                PlayersDetailDateValidChk = "false";
            }
        }
    }
    catch (err) {
        PlayersDetailDateValidChk = "false";
    }
}

var PlayersDetailformData;

function PlayersDetailSaveScript() {
    PlayersDetailFieldValidate();
    if (PlayersDetailValidChk == "false") {
        return false;
    }
    LayoutShowProgressBar();
    $("#PlayersDetailForm [name=Nickname]").val($("#PlayersDetailValForm [name=Nickname_in]").val());
    $("#PlayersDetailForm [name=Battles]").val($("#PlayersDetailValForm [name=Battles_in]").val());
    $("#PlayersDetailForm [name=Wn_State]").val($("#PlayersDetailValForm [name=Wn_State_in]").val());
    $("#PlayersDetailForm [name=Damage]").val($("#PlayersDetailValForm [name=Damage_in]").val());
    var CheckADDget = $("#PlayersForm [name=Player_ID]").val();
    if (CheckADDget == "-1") {

    } else {

    }
    var RadioButton_inchk1 = $("#Playersradio1").is(":checked");
    if (RadioButton_inchk1 == true) {
        $("#PlayersDetailForm [name=Sex]").val("M");
    }
    var RadioButton_inchk2 = $("#Playersradio2").is(":checked");
    if (RadioButton_inchk2 == true) {
        $("#PlayersDetailForm [name=Sex]").val("F");
    }
    var RadioButton_inchk3 = $("#Playersradio3").is(":checked");
    if (RadioButton_inchk3 == true) {
        $("#PlayersDetailForm [name=Sex]").val("O");
    } PlayersDetailformData = $("#PlayersDetailForm").serialize();
    setTimeout(PlayersDetailSaveToServer, 40);
}

var PlayersDetailAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $("[name='__RequestVerificationToken']").val();
    return data;
};

function PlayersDetailSaveToServer() {
    var PKIDget = $("#PlayersForm [name=Player_ID]").val();
    if (PKIDget == "-1") {
        var headersadd = {};
        headersadd['MY-XSRF-TOKEN'] = $("[name='__RequestVerificationToken']").val();
        $.ajax(PlayersDetailAddURL, {
            type: 'POST',
            data: PlayersDetailformData,
            datatype: 'json',
            headers: headersadd,
            success: function (data, status, xhr) {
                PlayersDetailSaveComplete(data);
            },
            error: function (jqXhr, textStatus, errorMessage) {
                alert(" errorMessage is:- " + errorMessage + "\n Xhr.status is :- " + jqXhr.status + "\n Xhr.responseText is :- " + jqXhr.responseText + "\n textStatus is :- " + textStatus);
            }
        });
        $("#PlayersFormtopdiv [name=CurrentPageNumber]").val("1");
    } else {
        var headersupd = {};
        headersupd['MY-XSRF-TOKEN'] = $("[name='__RequestVerificationToken']").val();
        $.ajax(PlayersDetailUpdateURL, {
            type: 'POST',
            data: PlayersDetailformData,
            datatype: 'json',
            headers: headersupd,
            success: function (data, status, xhr) {
                PlayersDetailSaveComplete(data);
            },
            error: function (jqXhr, textStatus, errorMessage) {
                alert(" errorMessage is:- " + errorMessage + "\n Xhr.status is :- " + jqXhr.status + "\n Xhr.responseText is :- " + jqXhr.responseText + "\n textStatus is :- " + textStatus);
            }
        });
    }
}

function PlayersDetailSaveComplete(jsonScript) {
    LayoutHideProgressBar();
    $("#PlayersForm [name=Player_ID]").val(jsonScript.Player_ID);
    var returnMessage = "";
    var i = 0;
    for (i = 0; i < jsonScript.ReturnMessage.length; i++) {
        returnMessage = returnMessage + jsonScript.ReturnMessage[i] + "\n";
    }
    if (jsonScript.ReturnStatus == true) {
        PlayersPostSearchForm(); PlayersDetailClosePopup();
    }
    else {
        var returnMessage2 = "";
        var i = 0; for (i = 0; i < jsonScript.ReturnMessage.length; i++) {
            returnMessage2 = returnMessage2 + jsonScript.ReturnMessage[i] + "\n";
        }
        var PlayersFieldIndex = 0;
        var PlayersField = "";
        var PlayersFielderrMsg = "";
        var ik = 0;
        try {
            for (ik = 0; ik < jsonScript.ReturnMessage.length; ik++) {
                if (jsonScript.ReturnMessage[ik].length) {
                    PlayersFieldLen = jsonScript.ReturnMessage[ik].length;
                    if (PlayersFieldLen > 0) {
                        PlayersFieldIndex = jsonScript.ReturnMessage[ik].indexOf("~");
                        if (PlayersFieldIndex > 0) {
                            PlayersFielderrMsg = jsonScript.ReturnMessage[ik].substring(0, PlayersFieldIndex);
                            PlayersField = jsonScript.ReturnMessage[ik].substr(PlayersFieldIndex + 1, PlayersFieldLen - (PlayersFieldIndex + 1));
                        }
                    }
                    $("#DivErrPlayersDetail" + PlayersField + "_in").html(PlayersFielderrMsg);
                    $("#DivErrPlayersDetail" + PlayersField + "_in").css("display", "");
                    $("#PlayersDetail" + PlayersField + "OK").css("display", "none");
                }
            }
        }
        catch (err) {
            alert("Client Error (Istemci hatasi) " + err.message);
            alert("Server Error (Sunucu hatasi) " + returnMessage);
        } if (PlayersFielderrMsg == "") {
            alert("Server Error (sunucu hata) " + "\n\n" + returnMessage);
        }
    }
}

function PlayersDetailCombo1(txtbox, docombo) {
    if (docombo != "true") {
        return false;
    }
    $("#PlayersDetailtopdiv [name=overlayprogressNEW]").css("visibility", "visible");
    $("#PlayersDetailtopdiv [name=overlayprogressNEW]").css("display", "block");
    var pagesrc = ""; pagesrc = PlayersDetailCombo1URL + '?txtbox=replace';
    pagesrc = pagesrc.replace("replace", txtbox);
    var iframeid = "PlayersDetailCombo1Div";
    var iframdiv = document.getElementById(iframeid);
    var dialogWidth = 0;
    dialogWidth = $("#PlayersDetailValForm [name=Nickname_in]").outerWidth();
    document.getElementById(iframeid).style.width = dialogWidth + "px";
    document.getElementById(iframeid).style.height = "130px";
    if ($("#PlayersDetailCombo1Div").length == 0) {
        alert("div yok");
    }
    else {
        $('#PlayersDetailCombo1Div').load(pagesrc, '', function (response, status, xhr) {
            if (status == 'success') {
                $("#PlayersDetailCombo1Div").css("display", "block");
                var p = $("#PlayersDetailValForm [name=Nickname_in]");
                var position = p.position();
                $("#PlayersDetailCombo1Div").position({
                    my: "left top",
                    at: "left top",
                    of: $('#PlayersDetailValForm [name=Nickname_in]'),
                    collision: "flip"
                });
            }
            else {
                alert("Combo load problem is: " + xhr.statusText);
                alert("Combo load problem text is: " + xhr.responseText);
            }
        });
    }
}

function PlayersDetailPopulateCombo1(strinsert) {
    $('#PlayersDetailValForm [name=Nickname_in]').val(strinsert);
}

function PlayersDetailCloseCombo1() {
    $('#PlayersDetailtopdiv [name=comboCheckit]').val("Close");
    $("#PlayersDetailCombo1Div").css("display", "none");
    $("#PlayersDetailCombo1Div").css("bottom", "10px");
    $("#PlayersDetailCombo1Div").empty();
    $("#PlayersDetailtopdiv [name=overlayprogressNEW]").css("visibility", "hidden");
    $("#PlayersDetailtopdiv [name=overlayprogressNEW]").css("display", "none");
}

function PlayersDetailClosePopup() {
    if (document.getElementById("PlayersShowShowtabs")) {
        $("#OverlayPlayersDetail").empty();
        var Expandid = "OverlayPlayersDetail";
        document.getElementById(Expandid).style.display = "none";
    }
    else {
        PlayersCloseK();
    }
}    
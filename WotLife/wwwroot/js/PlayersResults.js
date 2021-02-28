/*
    TABLO ICERIGI
 */

function PlayersPopDialog(PKID, row_ID) {
    LayoutShowProgressBar();
    window.location.hash = "ini";
    PlayersHideChildALL();
    $("#PlayersFormtopdiv [name=Player_ID]").val(PKID);
    $("#ParentGeneralDiv [name=PK_ID]").val(PKID);
    var putTitle = "";
    if (PKID == -1) {
        putTitle = "Oyuncu Ekleme";
    }
    else {
        putTitle = "Oyuncu Duzenleme";
        Playersresetablebg();
        Playersrowhighlight(row_ID);
    }
    var strAction = "PlayersDetail";
    var strController = "Players";
    var pagesrc = PlayersDetailURL;
    var dialogWidth = 0;
    var dialogHeight = 0;
    var deviceHeight = (typeof window.outerHeight != 'undefined') ? Math.max(window.outerHeight, $(window).height()) : $(window).height();
    var HeightChk = "true";
    if (HeightChk == "true") {
        $("#PlayersModalk").css("display", "block");
        $("#PlayersmodalkTitle").text(putTitle);
        var Expandid = "ModalPlayersOverlayK";
        var Expandheightpx = dialogHeight + "px";
        document.getElementById(Expandid).style.height = Expandheightpx;
        $("#OverlayPlayersDetail").empty();
        $("#ModalPlayersOverlayK").empty();
        if ($("#ModalPlayersOverlayK").length == 0) {
            LayoutHideProgressBar();
            alert("Yukleme(Isleme) div i bulunamadi. Load (yukleme) kontrol et ");
        }
        else {
            $('#ModalPlayersOverlayK').load(pagesrc, '', function (response, status, xhr) {
                if (status == 'success') {
                    LayoutHideProgressBar();
                }
                else {
                    LayoutHideProgressBar();
                    alert("Duzenle yukleme (load): " + xhr.statusText);
                    alert("Load metni: " + xhr.responseText);
                }
            });
        }
    }
}

function PlayersCloseK() {
    $("#ModalPlayersOverlayK").empty();
    $("#PlayersModalk").css("display", "none");
    $(".modal-contentk").css("width", "85%");
}

var PlayersOpenCheckLoad;

function PlayersOpenDetails(PKID, row_ID, arrayname) {
    window.location.hash = "ini";
    Playersresetablebg();
    PlayersHideChildALL();
    Playersrowhighlight(row_ID);
    $("#PlayersFormtopdiv [name=Player_ID]").val(PKID);
    $("#ParentGeneralDiv [name=PK_ID]").val(PKID);
    var pos = $("#PlayersFormtopdiv").position();
    var topsetchr = Number(pos.top - 1) + "px";
    var leftsetchr = Number(pos.left) + "px";
    var newwidth = $("#PlayersFormtopdiv").outerWidth();
    var newheight = $("#PlayersFormtopdiv").outerHeight();
    var heightsetchr = Number(newheight + 0) + "px";
    var widthsetchr = Number(newwidth - 0) + "px";
    var Expandid = "OverlayPlayersDetail";
    document.getElementById(Expandid).style.position = "fixed";
    document.getElementById(Expandid).style.top = topsetchr;
    document.getElementById(Expandid).style.left = leftsetchr;
    document.getElementById(Expandid).style.width = widthsetchr;
    document.getElementById(Expandid).style.height = heightsetchr;
    var deviceHeight = (typeof window.outerHeight != 'undefined') ? Math.max(window.outerHeight, $(window).height()) : $(window).height();
    
    if (HeightChk == "true") {
        var pagesrc = PlayersDetailShowURL;
        $("#ModalPlayersOverlayK").empty();
        $("#OverlayPlayersDetail").empty();
        if ($("#OverlayPlayersDetail").length == 0) {
            LayoutHideProgressBar(); alert("div yok");
        }
        else {
            $('#OverlayPlayersDetail').load(pagesrc, '', function (response, status, xhr) {
                if (status == 'success') {
                    setTimeout(ShowPlayersLoad, 50);
                }
                else {
                    LayoutHideProgressBar();
                    alert("detaylar yukleme (load): " + xhr.statusText);
                    alert("yukleme metni: " + xhr.responseText);
                }
            });
        }
    }
}

function ShowPlayersLoad() {
    try {
        var Expandid = "OverlayPlayersDetail";
        document.getElementById(Expandid).style.display = "block";
    } catch (err) { }
}

function CheckPlayersLoad(pagesrc) {
    LayoutShowProgressBar();
    try {
        var chkit = $("#PlayersDetailtopdiv").find('#PlayersShowit').val();
        if (chkit == "showit") {
            var Expandid = "OverlayPlayersDetail";
            document.getElementById(Expandid).style.display = "block";
            LayoutHideProgressBar();
            clearInterval(PlayersOpenCheckLoad);
        }
    } catch (err) { }
}

function PlayersShowChild(PKID, row_ID, arrayname) {
    window.location.hash = "ini";
    Playersresetablebg();
    PlayersHideChildALL();
    Playersrowhighlight(row_ID);
    $("#ParentGeneralDiv [name=PK_ID]").val(PKID);
    var deviceHeight = (typeof window.outerHeight != 'undefined') ? Math.max(window.outerHeight, $(window).height()) : $(window).height();
    
    if (HeightChk == "true") {
        var Expandid = "expandRowdivPlayers" + row_ID;
        $("#PlayersFormtopdiv [name=Player_ID]").val(PKID);
        var pagesrc = PlayersDetailTabURL;
        var Expandheight = 295;
        var tablediv = document.getElementById('idDivPlayersTBody');
        tablediv.style.overflow = "hidden";
        var newwidth = $("#PlayersFormtopdiv").outerWidth();
        var widthsetchr = Number(newwidth - 43) + "px";
        $("#expandRowdivPlayers" + row_ID).css("width", widthsetchr);
        var ichildrowid = "Playerschild" + row_ID;
        document.getElementById(ichildrowid).style.display = "";
        $("#ModalPlayersOverlayK").empty();
        $("#OverlayPlayersDetail").empty();
        $("#expandRowdivPlayers" + row_ID).empty();
        if ($("#expandRowdivPlayers" + row_ID).length == 0) {
            LayoutHideProgressBar();
            alert("div yok");
        }
        else {
            $('#expandRowdivPlayers' + row_ID).load(pagesrc, '', function (response, status, xhr) {
                if (status == 'success') {
                    var minusignid = "Playersminusign" + row_ID;
                    var plusignid = "Playersplusign" + row_ID;
                    document.getElementById(minusignid).style.display = "block";
                    document.getElementById(plusignid).style.display = "none";
                    ScrollToTop();
                }
                else {
                    LayoutHideProgressBar();
                    alert("Genisleme yukleme hatasi " + xhr.statusText);
                    alert("hata metni: " + xhr.responseText);
                }
            });
        }
    }
}

function PlayersDelDetails(PKID, row_ID, arrayname) {
    Playersresetablebg();
    Playersrowhighlight(row_ID);
    var putTitle = "";
    putTitle = "Sil";
    $("#PlayersModalk").css("display", "block");
    $(".modal-contentk").css("width", "220px");
    $("#PlayersmodalkTitle").text(putTitle);
    var Expandid = "ModalPlayersOverlayK";
    var dialogHeight = "80";
    var Expandheightpx = dialogHeight + "px";
    document.getElementById(Expandid).style.height = Expandheightpx;
    $("#ModalPlayersOverlayK").empty();
    var strTextDel = "<div style='font-size:12px;color:black;padding-bottom: 9px;padding-top:6px;'>Kaydi silecek misiniz?</div>";
    var strSubmit = '<input style="font-size:11px;color:black;display:inline-block;font-weight:bold;margin-right:9px;" class="btn btn-sm" type="button" value="Evet" onclick="PlayersDelRecord(' + PKID + ');PlayersCloseK();" />';
    var strCancel = '<input style="font-size:10px;color:red;display:inline-block;" class="btn btn-xs" type="button" value="Iptal" onclick="PlayersCloseK();" />';
    $("#ModalPlayersOverlayK").html(strTextDel + strSubmit + strCancel);
}

function PlayersDeleteALL() {
    var pagsiz = $("#PlayersFormtopdiv [name=PageSizeNEW]").val();
    var contin = "No";
    for (var r = 0; r < pagsiz + 1; r++) {
        if (document.getElementById('PlayersChk' + r) != null) {
            if (document.getElementById('PlayersChk' + r).checked == true) {
                contin = "Yes";
                document.getElementById('PlayersCheckB' + r).value = "on";
            }
            else {
                document.getElementById('PlayersCheckB' + r).value = "off";
            }
        }
    }
    var putTitle = "";
    putTitle = "Sil";
    $("#PlayersModalk").css("display", "block");
    $(".modal-contentk").css("width", "220px");
    $("#PlayersmodalkTitle").text(putTitle);
    var Expandid = "ModalPlayersOverlayK";
    var dialogHeight = "80";
    var Expandheightpx = dialogHeight + "px";
    document.getElementById(Expandid).style.height = Expandheightpx;
    $("#ModalPlayersOverlayK").empty();
    var strTextDel = "<div style='font-size:12px;color:black;padding-bottom: 9px;padding-top:6px;'>Kaydi silecek misiniz?</div>";
    var strSubmit = '<input style="font-size:11px;color:black;display:inline-block;font-weight:bold;margin-right:9px;" class="btn btn-sm" type="button" value="Evet" onclick="PlayersDeleteSelected();PlayersCloseK();" />';
    var strCancel = '<input style="font-size:10px;color:red;display:inline-block;" class="btn btn-xs" type="button" value="Iptal" onclick="PlayersCloseK();" />';
    $("#ModalPlayersOverlayK").html(strTextDel + strSubmit + strCancel);
}




function PlayersfinishDownload() {
    LayoutHideProgressBar();
}

function PlayersSubmitRepPDF() {
    var token = new Date().getTime();
    $("#PlayersRepPDF [name=download_token_value]").val(token);
    var FormtoDO = $('#PlayersRepPDF');
    $.ajax({
        type: 'POST',
        url: FormtoDO.attr('action'),
        data: FormtoDO.serialize(),
        success: function (response) {
            PlayersfinishDownload();
            window.location.href = "PlayersDownloadPDF?file=" + response.filename;
            setTimeout(PlayersSubmitDelPDF, 500, response.filename);
        },
        error: function (jqXhr, textStatus, errorMessage) {
            alert(" errorMessage is:- " + errorMessage + "\n Xhr.status is :- " + jqXhr.status + "\n Xhr.responseText is :- " + jqXhr.responseText + "\n textStatus is :- " + textStatus);
        }
    });
}

function PlayersSubmitDelPDF(filenamee) {
    var GetDelURLL = '/Players/PlayersDownloadPDFDel';
    $.ajax({
        type: 'POST',
        url: GetDelURLL,
        data: { file: filenamee },
        success: function (response) { },
        error: function (jqXhr, textStatus, errorMessage) {
            alert(" errorMessage is:- " + errorMessage + "\n Xhr.status is :- " + jqXhr.status + "\n Xhr.responseText is :- " + jqXhr.responseText + "\n textStatus is :- " + textStatus);
        }
    });
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i]; while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function checkCookie() {
    var user = getCookie("username");
    if (user != "") {
        alert("Welcome again " + user);
    }
    else {
        user = prompt("Lutfen adinizi giriniz:", "");
        if (user != "" && user != null) { setCookie("username", user, 365); }
    }
}

function PlayersmyTimer() {
    var scrola = $("#idDivPlayersTBody").scrollLeft();
    $("#idDivPlayersTBody2").scrollLeft(scrola);
    $("#idDivPlayersTFooter").scrollLeft(scrola);
}

AdjustDivWidthPlayers();

function AdjustDivWidthPlayers() {
    if (document.getElementById("idDivPlayersTBody")) {
        var idDivPlayersTBodyNew = document.getElementById("idDivPlayersTBody").clientWidth;
        var idDivPlayersTBodyNewoff = document.getElementById("idDivPlayersTBody").offsetWidth;
        var idscrolWidth = idDivPlayersTBodyNewoff - idDivPlayersTBodyNew;
        $("#PlayersFormtopdiv [name=ScrollWidthh]").val(idscrolWidth);
        $("#PlayersFormtopdiv [name=OrigScreenWidthh]").val(idDivPlayersTBodyNewoff);
        var resetWidth = 0;
        var newwidthUse = $("#PlayersFormtopdiv").outerWidth();
        newwidthUse = Number(newwidthUse) - (Number(idscrolWidth) + 2);
        resetWidth = newwidthUse;
        document.getElementById("idDivPlayersTBody").style.height = "400px";
    }
    if (document.getElementById("idPlayersHeader")) {
        document.getElementById("idPlayersHeader").style.width = resetWidth + "px";
    }
    if (document.getElementById("idPlayersHeader2")) {
        document.getElementById("idPlayersHeader2").style.width = resetWidth + "px";
        document.getElementById("idDivPlayersTBody2").style.width = resetWidth + "px";
    }
    if (document.getElementById("idPlayersFooter")) {

    }
}

function Playersresetablebg() {
    var table = document.getElementById('PlayersTable');
    var rowsss = table.getElementsByTagName('tr');
    var rowidstr;
    var tr;
    var backgr = "#D3DCE5";
    if (table) {
        tr = $('#PlayersTable').find('tr');
        $.each(tr, function (index, item) {
            rowidstr = rowsss[index].id;
            if (rowidstr.indexOf("Playersmaster") != -1) {
                document.getElementById(rowidstr).style.backgroundColor = backgr;
                if (backgr == "#fffbe6") {
                    backgr = "#ede4e4";
                }
                else {
                    backgr = "#fffbe6";
                }
            }
        });
    }
}

function Playersrowhighlight(row_ID) {
    Playersresetablebg();
    var table = document.getElementById('PlayersTable');
    if (table) {
        $("#PlayersFormtopdiv [name=CurrentRowNumber]").val(row_ID);
    }
    row_ID = row_ID - 1;
    var imasterrowid = "Playersmaster" + row_ID;
    document.getElementById(imasterrowid).style.backgroundColor = "silver";
}

function PlayersHighlightCol(colname) {
    if (document.getElementById('PlayersTable') != null) {
        var table = document.getElementById('PlayersTable');
        var rowss = table.getElementsByTagName('tr');
        var colss = table.getElementsByTagName('td');
        var colhh = table.getElementsByTagName('th');
        if (table) {
            for (var r = 0; r < colss.length; r++) {
                if (colss[r].id == colname) {
                    colss[r].style.backgroundColor = "#D3DCE5";
                }
            }
        }
    }
}

function PlayersCheckALLs() {
    if (document.getElementById('PlayersCheckALL').checked == false) {
        $("input[name^=PlayersChk]").prop("checked", false);
    }
    if (document.getElementById('PlayersCheckALL').checked == true) {
        $("input[name^=PlayersChk]").prop("checked", true);
    }
}

function PlayersShowColumn(row_ID, colnam) {
    PlayersHideColumnALL(colnam);
    var ik = Number(row_ID - 2);
    var tippp = colnam + "tipp" + ik;
    $("#PlayersFormtopdiv [name=" + tippp + "]").css("display", "none");
    var minusignid = "minusign" + colnam + row_ID;
    var plusignid = "plusign" + colnam + row_ID;
    $("#PlayersFormtopdiv [name=" + minusignid + "]").css("display", "inline-block");
    $("#PlayersFormtopdiv [name=" + plusignid + "]").css("display", "none");
}

function PlayersHideColumn(row_ID, colnam) {
    var ik = Number(row_ID - 2);
    var tippp = colnam + "tipp" + ik;
    $("#PlayersFormtopdiv [name=" + tippp + "]").css("display", "");
    var minusignid = "minusign" + colnam + row_ID;
    var plusignid = "plusign" + colnam + row_ID;
    $("#PlayersFormtopdiv [name=" + minusignid + "]").css("display", "none");
    $("#PlayersFormtopdiv [name=" + plusignid + "]").css("display", "inline-block");
}

function PlayersHideColumnALL(colnam) {
    var tippp = colnam + "tipp";
    $("#PlayersFormtopdiv [name=" + tippp + "]").css("display", "");
    var minusignid = "minusign" + colnam; var plusignid = "plusign" + colnam;
    $("#PlayersFormtopdiv [name=" + minusignid + "]").css("display", "none");
    $("#PlayersFormtopdiv [name=" + plusignid + "]").css("display", "inline-block");
}

function Playersnewrowhighlight() {
    Playersresetablebg();
    var table = document.getElementById('PlayersTable');
    var rowsss = table.getElementsByTagName('tr');
    var dValue;
    var addval;
    var IDId;
    var indx;
    var rowidstr;
    var tr;
    indx = 1;
    var rowCount = $('#PlayersTable tr').length;
    if (table) {
        for (var r = 0; r < rowCount; r++) {
            try {
                rowidstr = rowsss[r].id;
            }
            catch (e) {
                break;
            }
            if (rowidstr.indexOf("Playersmaster") != -1) {
                dValue = document.getElementById('PlayersPK_IDD' + indx).value;
                if ($("#PlayersFormtopdiv [name=Player_ID]").val() == dValue) {
                    document.getElementById(rowidstr).style.backgroundColor = "silver";
                    break;
                }
                indx = indx + 1;
            }
        }
    }
    var row_ID2 = indx + 1;
    var imasterrowid2 = "Playersmaster" + row_ID2;
    var selectedPosy = 0;
    if (document.getElementById(imasterrowid2)) {
        selectedPosy = document.getElementById(imasterrowid2).offsetTop;
        if (Number(selectedPosy > 400)) {
            $("#idDivPlayersTBody").scrollTop(selectedPosy);
        }
    }
}

function ScrollToTop() {
    var row_ID = $("#PlayersFormtopdiv [name=CurrentRowNumber]").val();
    var row_ID2 = row_ID - 1;
    var imasterrowid = "Playersmaster" + row_ID2;
    var selectedPosy = 0;
    selectedPosy = document.getElementById(imasterrowid).offsetTop;
    var tablediv = document.getElementById('idDivPlayersTBody');
    $("#idDivPlayersTBody").scrollTop(selectedPosy);
}

function PlayersHideChild(PKID, row_ID, arrayname) {
    Playersresetablebg();
    Playersrowhighlight(row_ID);
    $("#expandRowdivPlayers" + row_ID).empty();
    var tablediv = document.getElementById('idDivPlayersTBody');
    tablediv.style.overflow = "scroll";
    $("#idDivPlayersTBody").scrollTop(2);
    var ichildrowid = "Playerschild" + row_ID;
    if (document.getElementById(ichildrowid) != null) {
        document.getElementById(ichildrowid).style.display = "none";
    }
    var minusignid = "Playersminusign" + row_ID;
    var plusignid = "Playersplusign" + row_ID;
    if (document.getElementById(minusignid) != null) {
        document.getElementById(minusignid).style.display = "none";
    }
    if (document.getElementById(plusignid) != null) {
        document.getElementById(plusignid).style.display = "block";
    }
}

function PlayersHideChildALL() {
    try {
        Playersresetablebg();
        var tablediv = document.getElementById('idDivPlayersTBody');
        tablediv.style.overflow = "scroll";
        var table = document.getElementById('PlayersTable');
        var rowsss = table.getElementsByTagName('tr');
        var tr;
        var indx;
        var rowidstr;
        indx = 3;
        if (table) {
            tr = $('#PlayersTable').find('tr');
            $.each(tr, function (index, item) {
                try {
                    rowidstr = rowsss[index].id;
                }
                catch (err) {

                }
                if (rowidstr.indexOf("Playersmaster") != -1) {
                    $("#expandRowdivPlayers" + indx).empty();
                    var ichildrowid = "Playerschild" + indx;
                    if (document.getElementById(ichildrowid) != null) {
                        document.getElementById(ichildrowid).style.display = "none";
                    }
                    var minusignid = "Playersminusign" + indx;
                    var plusignid = "Playersplusign" + indx;
                    if (document.getElementById(minusignid) != null) {
                        document.getElementById(minusignid).style.display = "none";
                    }
                    if (document.getElementById(plusignid) != null) {
                        document.getElementById(plusignid).style.display = "block";
                    }
                    indx = indx + 1;
                }
            });
        }
    } catch (err) { }
}  
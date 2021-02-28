/*
    TABLO ICERIGI DISINDA TUM KISIM
 */

function PlayersStartSearch() {
    try {
        PlayersHideChildALL();
    }
    catch (err) {

    }

    var dtime = new Date();
    var ndiff = dtime.getTimezoneOffset();
    $("#PlayersFormtopdiv [name=TimeDiff]").val(ndiff);
    $("#PlayersFormtopdiv [name=CurrentPageNumber]").val("1");
    $("#PlayersFormtopdiv [name=CurrentRowNumber]").val("0");
    $("#PlayersFormtopdiv [name=Player_ID]").val("0");
    if ($("#PlayersFormtopdiv [name=PageSizeNEW]").length != 0) {
        var intPagesize = $("#PlayersFormtopdiv [name=PageSizeNEW]").val();
        $("#PlayersFormtopdiv [name=PageSize]").val(intPagesize);
    }
    else {
        // SAYFADA GORUNTULENECEK SAYI
        $("#PlayersFormtopdiv [name=PageSize]").val("20");
    }
    $("#PlayersFormtopdiv [name=SortAscendingDescending]").val("ASC");
    $("#PlayersFormtopdiv [name=SortBy]").val("PlayersFourthCol");
    PlayersPostSearchForm();
}

function PlayersResetPage() {
    try {
        PlayersHideChildALL();
    }
    catch (err) {

    }
    $("#PlayersFormtopdiv [name=GlobalSearchString]").val("");
    $("#PlayersFormtopdiv [name=Nickname]").val("");
    $("#PlayersFormtopdiv [name=Battles]").val("");
    $("#PlayersFormtopdiv [name=Wn_State_Str]").val("");
    $("#PlayersFormtopdiv [name=Damage_Str]").val(""); PlayersStartSearch();
}

function PlayersEnableGridSorting() {
    $("#PlayersFormtopdiv [name=SortByFirstCol]").css("visibility", "visible");
    $("#PlayersFormtopdiv [name=SortByFirstCol]").css("display", "block");
    $("#PlayersFormtopdiv [name=SortBySecondCol]").css("visibility", "visible");
    $("#PlayersFormtopdiv [name=SortBySecondCol]").css("display", "block");
    $("#PlayersFormtopdiv [name=SortByThirdCol]").css("visibility", "visible");
    $("#PlayersFormtopdiv [name=SortByThirdCol]").css("display", "block");
    $("#PlayersFormtopdiv [name=SortByFourthCol]").css("visibility", "visible");
    $("#PlayersFormtopdiv [name=SortByFourthCol]").css("display", "block");
    $("#PlayersFormtopdiv [name=SortByFifthCol]").css("visibility", "visible");
    $("#PlayersFormtopdiv [name=SortByFifthCol]").css("display", "block");
    $("#PlayersFormtopdiv [name=SortBySixthCol]").css("visibility", "visible");
    $("#PlayersFormtopdiv [name=SortBySixthCol]").css("display", "block");
}

function PlayersSetPagingLinks(currentPageNumber, totalPages) {
    $("#PlayersFormtopdiv [name=PagingLinks]").css("visibility", "visible");
    $("#PlayersFormtopdiv [name=PagingLinks]").css("display", "block");
    var currPageNumber = parseFloat(currentPageNumber);
    totalPages = parseFloat(totalPages);
    $("#Playersfirstpagee").hide();
    $("#Playersprevpagee").hide();
    $("#Playersnextpagee").hide();
    $("#Playerslastpagee").hide();
    if (currPageNumber == 1) {
        $("#Playersfirstpagee").hide();
        $("#Playersprevpagee").hide();
        $("#Playersnextpagee").hide();
        $("#Playerslastpagee").hide();
    }

    if (currPageNumber > 1) {
        $("#Playersfirstpagee").show();
        $("#Playersprevpagee").show();
    }

    if (currPageNumber < totalPages && totalPages > 0) {
        $("#Playersnextpagee").show();
        $("#Playerslastpagee").show();
    }

    if (currPageNumber == totalPages && totalPages > 0) {
        $("#Playersnextpagee").hide();
        $("#Playerslastpagee").hide();
    }
    PlayersEnableGridSorting();
}

function PlayersNavigateToPage(action) {
    PlayersHideChildALL();
    var currentPage = $("#PlayersFormtopdiv [name=CurrentPageNumber]").val();
    currentPage = parseFloat(currentPage);
    if (action == "next")
        currentPage = currentPage + 1;
    else if (action == "prev")
        currentPage = currentPage - 1;
    else if (action == "last")
        currentPage = $("#PlayersFormtopdiv [name=TotalPages]").val();
    else if (action == "first")
        currentPage = 1;
    $("#PlayersFormtopdiv [name=CurrentPageNumber]").val(currentPage);
    $("#PlayersFormtopdiv [name=CurrentRowNumber]").val("0");
    $("#PlayersFormtopdiv [name=Player_ID]").val("0");
    PlayersPostSearchForm();
}

function PlayersNextPage() {
    PlayersNavigateToPage("next");
}

function PlayersPrevPage() {
    PlayersNavigateToPage("prev");
}

function PlayersLastPage() {
    PlayersNavigateToPage("last");
}

function PlayersFirstPage() {
    PlayersNavigateToPage("first");
}

function PlayersSortGrid(sortBy) {
    PlayersHideChildALL();
    var currentSortBy = $("#PlayersFormtopdiv [name=SortBy]").val();
    var currentSortAsc = $("#PlayersFormtopdiv [name=SortAscendingDescending]").val();
    if (currentSortBy == sortBy) {
        if (currentSortAsc == "ASC")
            currentSortAsc = "DESC";
        else currentSortAsc = "ASC";
    }
    else {
        currentSortAsc = "ASC";
    }
    $("#PlayersFormtopdiv [name=SortAscendingDescending]").val(currentSortAsc);
    $("#PlayersFormtopdiv [name=SortBy]").val(sortBy);
    $("#PlayersFormtopdiv [name=CurrentRowNumber]").val("0");
    $("#PlayersFormtopdiv [name=Player_ID]").val("0");
    PlayersPostSearchForm();
}

var PlayersListformData;

function PlayersPostSearchForm() {
    LayoutShowProgressBar();
    PlayersListformData = $("#PlayersFormtopdiv :input").serialize();
    try {
        setTimeout(PlayersPostSearchToServer, 50);
    } catch (err) {
        alert("err message " + err.message);
    }
}

function PlayersDisableForm() {
    $('#PlayersForm').css("cursor", "wait");
}

function PlayersEnableForm() {
    $('#PlayersForm').css("cursor", "default");
}

function PlayersAdvancedSearch() {
    PlayersHideChildALL();
    var el = $("#PlayersFormtopdiv [name=PlayersAdvancedSearch]")[0];
    el.style.display = (el.style.display == "block") ? "none" : "block";
}

function PlayersSearchOption() {
    PlayersHideChildALL();
    var el = $("#PlayersFormtopdiv [name=PlayersSearchOption]")[0];
    if (el.style.display == "block") {
        PlayersResetPage();
    }
    el.style.display = (el.style.display == "block") ? "none" : "block";
}

function isBreakpointGet(alias) {
    return $('.device-' + alias).is(':visible');
}  
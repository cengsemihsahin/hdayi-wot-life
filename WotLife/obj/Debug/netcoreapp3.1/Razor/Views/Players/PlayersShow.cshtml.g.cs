#pragma checksum "C:\Users\ASUS\Desktop\AYHAN ÇETİN\WotLife\Views\Players\PlayersShow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e71355c4c30eb6285d1bc97b6769e0253f3ac8a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Players_PlayersShow), @"mvc.1.0.view", @"/Views/Players/PlayersShow.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ASUS\Desktop\AYHAN ÇETİN\WotLife\Views\_ViewImports.cshtml"
using appAPP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\AYHAN ÇETİN\WotLife\Views\_ViewImports.cshtml"
using appAPP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e71355c4c30eb6285d1bc97b6769e0253f3ac8a2", @"/Views/Players/PlayersShow.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a95b5e653e5e10f51daf0ba9815980ac48ec87e", @"/Views/_ViewImports.cshtml")]
    public class Views_Players_PlayersShow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<appAPP.Models.PlayersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "PlayersDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\AYHAN ÇETİN\WotLife\Views\Players\PlayersShow.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    div.PlayersShowtab {
        overflow: hidden;
        border-top: 1px solid #ccc;
        border-bottom: 0px solid #ccc;
        border-left: 1px solid #ccc;
        border-right: 1px solid #ccc;
        background-color: white;
        border-top-left-radius:5px;
        border-top-right-radius:5px;
    }
        div.PlayersShowtab button {
            background-color: inherit;
            float: left;
            border-top: 1px solid #ccc;
            border-bottom: 1px solid #ccc;
            border-left: 1px solid #ccc;
            border-right: 1px solid #ccc;
            border-top-left-radius:4px;
            border-top-right-radius:4px;
            outline: none;
            cursor: pointer;
            padding: 5px 8px;
            transition: 0.3s;
            font-size: 12px;
            margin-left: 1px;
            margin-top: 3px;
            color: navy;
            font-family:Arial;
        }

            div.PlayersShowtab button:hover {
     ");
            WriteLiteral(@"           background-color: #ddd;
            }

            div.PlayersShowtab button.active {
                background-color: #ccc;
                color: black;
                font-weight:bold;
                font-family:Arial;
                font-size: 13px;
            }


    div.PlayersShowtabxs {
        overflow: auto;
        background-color: white;
        border-top-left-radius:5px;
        border-top-right-radius:5px;
        white-space: nowrap;
        border-top: 0px solid #ccc;
        border-bottom: 0px solid #ccc;
        border-left: 1px solid #ccc;
        border-right: 1px solid #ccc;
    }

        div.PlayersShowtabxs button {
            background-color: inherit;
            border-top: 1px solid #ccc;
            border-bottom: 1px solid #ccc;
            border-left: 1px solid #ccc;
            border-right: 1px solid #ccc;
            border-top-left-radius:4px;
            border-top-right-radius:4px;
            outline: none;
            ");
            WriteLiteral(@"cursor: pointer;
            padding: 5px 8px;
            transition: 0.3s;
            font-size: 11px;
            margin-left: 1px;
            margin-top: 1px;
            color: navy;
            font-weight:normal;
            font-family:Arial;
        }

            div.PlayersShowtabxs button:hover {
                background-color: #ddd;
            }

            div.PlayersShowtabxs button.active {
                background-color: #ccc;
                color: black;
                font-weight:bold;
                font-family:Arial;
                font-size: 12px;
            }


    .PlayersShowtabcontent {
        display: none;
        padding: 6px 12px;
        border: 1px solid #ccc;
        border-top: none;
        border-bottom-left-radius: 5px;
        border-bottom-right-radius: 5px;
    }


    .PlayersShowclosebtn {
        font-size: 17px;
        text-decoration: none;
        color: black;
        font-weight: bold;
        padding-right: ");
            WriteLiteral("7px;\r\n        padding-top: 3px;\r\n    }\r\n</style>\r\n\r\n\r\n<div id=\"PlayersShowShowtabs\" style=\"padding-top: 0px;background-color:white;\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e71355c4c30eb6285d1bc97b6769e0253f3ac8a26893", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 118 "C:\Users\ASUS\Desktop\AYHAN ÇETİN\WotLife\Views\Players\PlayersShow.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <div class=""PlayersShowtab hidden-xs"">

        <button class=""PlayersShowtablinks"" onclick=""PlayersShowAddChild('PlayersShowStart', 'Child1')"" id=""PlayersShowStartChild1"">Add Child</button>

    </div>
    <div class=""PlayersShowtabxs visible-xs"">

        <button class=""PlayersShowtablinks"" onclick=""PlayersShowAddChild('PlayersShowStart', 'Child1')"" id=""PlayersShowStartChild1xs"">Add Child</button>

    </div>

    <div id=""PlayersShow~childprog1~"" class=""PlayersShowtabcontent"">
        <div id=""PlayersShow~childprog1~Div"">

        </div>
    </div>
    <div id=""PlayersShow~childprog2~"" class=""PlayersShowtabcontent"">
         <div id=""PlayersShow~childprog2~Div"">

        </div>
    </div>
    <div id=""PlayersShow~childprog3~"" class=""PlayersShowtabcontent"">
        <div id=""PlayersShow~childprog3~Div"">

        </div>
    </div>
    <div id=""PlayersShow~childprog4~"" class=""PlayersShowtabcontent"">
         <div id=""PlayersShow~childprog4~Div"">

        </div>
    </div>");
            WriteLiteral(@"
    <div id=""PlayersShow~childprog5~"" class=""PlayersShowtabcontent"">
         <div id=""PlayersShow~childprog5~Div"">

        </div>
    </div>
   <div id=""PlayersShow~childprog6~"" class=""PlayersShowtabcontent"">
        <div id=""PlayersShow~childprog6~Div"">

        </div>
    </div>
    <div id=""PlayersShow~childprog7~"" class=""PlayersShowtabcontent"">
         <div id=""PlayersShow~childprog7~Div"">

        </div>
    </div>
    <div id=""PlayersShow~childprog8~"" class=""PlayersShowtabcontent"">
         <div id=""PlayersShow~childprog8~Div"">

        </div>
    </div>

</div>

<div id=""PlayersShowshowSpinPopup"" data-bind=""visible: isSpinning"" style=""display:none; position: absolute; top: 40px; left: 220px;"">
    <i class=""fa fa-spinner fa-spin""></i>
    <span class=""updateProgressMessage"">Processing ...</span>
</div>


<script language=""javascript"" type=""text/javascript"">

   var PlayersurlChildDel = '/Home/ReloadDel';  
   function PlayersShowDelChild(Prog, ChildNumber, ChildTable");
            WriteLiteral(@") {
     var txt;
     var r = confirm(""Continue to Delete Left Tab?"");
     if (r == true) {
         PlayersShowDelChildStart(Prog, ChildNumber, ChildTable);
     } else {

      } 

   }
    function PlayersShowDelChildStart(Prog, ChildNumber, ChildTable) {
        $(""#PlayersFormtopdiv [name=CurrentProgName]"").val(Prog);
        $(""#PlayersFormtopdiv [name=CurrentChildNo]"").val(ChildNumber);
        var ParentProgName = ""Players"";
        $(""#PlayersFormtopdiv [name=ParenterProgName]"").val(ParentProgName);
        $(""#PlayersFormtopdiv [name=ChildtableName]"").val(ChildTable);

        PlayersChildDel = $(""#PlayersForm"").serialize();  

        setTimeout(PlayersChildServerDEL, 30);
    }


    function PlayersChildServerDEL() {

        var putTitle = """";
        putTitle = ""Deleting Child"";

        $(""#PlayersModalk"").css(""display"", ""block"");
        $("".modal-contentk"").css(""width"", ""280px"");
        $(""#PlayersmodalkTitle"").text(putTitle);

        var Expandid = ""Modal");
            WriteLiteral(@"PlayersOverlayK"";

        var ChildNumber = ""1"";
        var Existin = ""Exist"";
        var Newin = ""New"";

        var dialogHeight = ""100"";
        var Expandheightpx = dialogHeight + ""px"";
        document.getElementById(Expandid).style.height = Expandheightpx;

        $(""#ModalPlayersOverlayK"").empty();
        var strTextDel = ""<div style='font-size:12px;color:black;padding-bottom: 9px;padding-top:9px;'>Choose to Delete Code and/or Table?</div>"";
        var strSubmit = '<input style=""font-size:10px;display:inline-block;font-weight:bold;margin-right:9px;"" class=""btn-primary btn-sm"" type=""button"" value=""Delete Code ONLY"" onclick=""PlayersChildServerDELStart(' + '\'' + ChildNumber + '\'' + ',' + '\'' + Newin + '\'' + ');PlayersCloseK();"" />';
        var strCancel = '<input style=""font-size:10px;display:inline-block;font-weight:bold;"" class=""btn-success btn-sm"" type=""button"" value=""Delete Code & Table"" onclick=""PlayersChildServerDELStart(' + '\'' + ChildNumber + '\'' + ',' + '\'' + Existin + ");
            WriteLiteral("\'\\\'\' + \');PlayersCloseK();\" />\';\r\n\r\n        $(\"#ModalPlayersOverlayK\").html(strTextDel + strSubmit + strCancel);\r\n\r\n    }\r\n\r\n   function PlayersChildServerDELStart(ChildNumber, typein) {\r\n\r\n        var PlayersChildDelURL77 = \'");
#nullable restore
#line 236 "C:\Users\ASUS\Desktop\AYHAN ÇETİN\WotLife\Views\Players\PlayersShow.cshtml"
                               Write(Url.Action("GenerateCodeDELChildPOnly", "ENTITYTABLE"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n\r\n\r\n        if (typein == \"Exist\") {\r\n          PlayersChildDelURL77 = \'");
#nullable restore
#line 240 "C:\Users\ASUS\Desktop\AYHAN ÇETİN\WotLife\Views\Players\PlayersShow.cshtml"
                             Write(Url.Action("GenerateCodeDELChild", "ENTITYTABLE"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        }

        
        $.post(PlayersChildDelURL77, PlayersChildDel, function (data, textStatus) {
            PlayersChildGenCodeRecordDEL(data);
        }, ""json"");

    }
    function PlayersChildGenCodeRecordDEL(jsonScript) {
        var returnMessage = """";

        for (i = 0; i < jsonScript.ReturnMessage.length; i++) {
            returnMessage = returnMessage + jsonScript.ReturnMessage[i] + ""\n"";
        }

        if (jsonScript.ReturnStatus == true) {
            alert(""Generated Code successfully Deleted."");
            PlayersChildDoneitDEL();
        }
        else {
            alert("""" + returnMessage);
        }
    }
    function PlayersChildDoneitDEL() {
        window.location.href = PlayersurlChildDel; 
    }



  
  function PlayersShowAddChild(PKID, ChildNumber) {
   
      var putTitle = """";
      putTitle = ""Adding New Child"";

      $(""#PlayersModalk"").css(""display"", ""block"");
      $("".modal-contentk"").css(""width"", ""270px"");
      $(""#Play");
            WriteLiteral(@"ersmodalkTitle"").text(putTitle);

      var Expandid = ""ModalPlayersOverlayK"";

      var Existin = ""Exist"";
      var Newin = ""New"";

      var dialogHeight = ""100"";
      var Expandheightpx = dialogHeight + ""px"";
      document.getElementById(Expandid).style.height = Expandheightpx;

      $(""#ModalPlayersOverlayK"").empty();
      var strTextDel = ""<div style='font-size:12px;color:black;padding-bottom: 9px;padding-top:9px;'>Choose to Create or use Existing Table?</div>"";
      var strSubmit = '<input style=""font-size:11px;display:inline-block;font-weight:bold;margin-right:9px;"" class=""btn-primary btn-sm"" type=""button"" value=""Use Existing Table"" onclick=""PlayersShowAddChildStart(' + '\'' + ChildNumber + '\'' + ',' + '\'' + Existin + '\'' + ');"" />';
      var strCancel = '<input style=""font-size:11px;display:inline-block;font-weight:bold;"" class=""btn-success btn-sm"" type=""button"" value=""Create New Table"" onclick=""PlayersShowAddChildStart(' + '\'' + ChildNumber + '\'' + ',' + '\'' + Newin + '\''");
            WriteLiteral(@" + ');"" />';

      $(""#ModalPlayersOverlayK"").html(strTextDel + strSubmit + strCancel);

  }
  
  function PlayersShowAddChildStart(ChildNumber, typein) {

        var PrimPKID = $(""#PlayersFormtopdiv [name=Name_ID]"").val();


        $(""#ChildCounterDiv [name=CHILDNUMBER]"").val(ChildNumber);

        var ParentProgName = ""Players"";
        $(""#ParentProgNameDiv [name=PARENTPROG]"").val(ParentProgName);

        var ParentProgPKID = ""Player_ID"";
        $(""#ParentProgPKIDDiv [name=PARENTPKID]"").val(ParentProgPKID);

        var putTitle = """";
        putTitle = ""Add Child"";

       
        var strAction = ""DisplayChildAdd"";
        var strController = ""ChildAdd"";
    
        if (typein == ""Exist"") {
            strAction = ""DisplayChildAddk"";
            strController = ""ChildAddk"";
        }

       
        var pagesrc = '/Names17/Names1Detail7'; 
        pagesrc = pagesrc.replace(""Names1Detail7"", strAction);
        pagesrc = pagesrc.replace(""Names17"", strController);
");
            WriteLiteral(@"
   
        var dialogWidth = 0;
        var dialogHeight = 0;
        dialogWidth = document.getElementById(""PlayersForm"").offsetWidth;
        dialogHeight = document.getElementById(""PlayersForm"").offsetHeight;
        //var dialogHeight = 0;

        var deviceHeight = (typeof window.outerHeight != 'undefined') ? Math.max(window.outerHeight, $(window).height()) : $(window).height();
        //-------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------
        var HeightChk = ""true"";
        if (isBreakpointGet('xs')) {   //  Width < 768px
            if (Number(deviceHeight) < 400) {
                alert(""Please increase Window Height, or use Portrait Mode, to proceed."");
                LayoutHideProgressBar();  //found in _Layout.cshtml
                HeightChk = ""false"";
           ");
            WriteLiteral(@" }
        }
        else  // ekran > 768px genislik
        {
            if (Number(deviceHeight) < 640) {
                alert(""Please increase Window Height, or use Portrait Mode, to proceed."");
                LayoutHideProgressBar();
                HeightChk = ""false"";
            }
        }----------------------------------------------------------------------------------------------------------------------------

        if (isBreakpointGet('xs')) { 
            dialogHeight = Number(deviceHeight) - 328;
        }
        else {
            dialogHeight = Number(deviceHeight) - 350; 
        }

        var deviceWidth = (typeof window.outerWidth != 'undefined') ? Math.max(window.outerWidth, $(window).width()) : $(window).width();

        if (isBreakpointGet('xs')) { 
            dialogWidth = Number(deviceWidth) - 40;  
        }
        else {
            dialogWidth = Number(deviceWidth) - 240;  
        }


        if (HeightChk == ""true"")
        {

            $(");
            WriteLiteral(@"""#PlayersModalk"").css(""display"", ""block"");
            $(""#PlayersmodalkTitle"").text(putTitle);
            $("".modal-contentk"").css(""width"", ""85%"");      

            var Expandid = ""ModalPlayersOverlayK"";         

            var Expandheightpx = dialogHeight + ""px"";
            document.getElementById(Expandid).style.height = Expandheightpx;

            $(""#ModalPlayersOverlayK"").empty();

            if ($(""#ModalPlayersOverlayK"").length == 0) { 
                alert(""Div yk ""); // div bulunamadi
            }
            else {

                $('#ModalPlayersOverlayK').load(pagesrc, '', function (response, status, xhr) {
                    if (status == 'success') {
                        //alert(""status text is: "" + xhr.statusText);
                        //alert(""response text is: "" + xhr.responseText);
                        //LayoutHideProgressBar();  
                    }
                    else  
                    {
                        alert(""Eduzenle: "" + ");
            WriteLiteral(@"xhr.statusText);
                        alert(""detay "" + xhr.responseText);
                    }

                });

            }

        }

    }
  


    function PlayersShowOpenTab(evt, tabName, ProgName) {
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName(""PlayersShowtabcontent"");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = ""none"";
        }
        tablinks = document.getElementsByClassName(""PlayersShowtablinks"");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace("" active"", """");
        }
        document.getElementById(tabName).style.display = ""block"";
        evt.currentTarget.className += "" active"";

        var strAction = ""Display"" + ProgName;
        var strController = ProgName;


        //Controller/Action
        var PlayersShowpagesrc = '/PlayersShowk/PlayersShowActionk';  // yeni kod degisme orngegi
     ");
            WriteLiteral(@"   PlayersShowpagesrc = PlayersShowpagesrc.replace(""PlayersShowActionk"", strAction);
        PlayersShowpagesrc = PlayersShowpagesrc.replace(""PlayersShowk"", strController);

        $(""#PlayersShow"" + ProgName + ""Div"").empty();

        $(""#PlayersShow"" + ProgName + ""Div"").load(PlayersShowpagesrc, '', function (response, status, xhr) {
            if (status == 'success') {
                //alert(""status text is: "" + xhr.statusText);
                //alert(""response text is: "" + xhr.responseText);
            }
            else 
            {
                alert(""Show load problem is: "" + xhr.statusText);
            }

        });

    }

    try {
           if (isBreakpointGet('xs')) {   
               //mobilde
              var parentElement = document.getElementsByClassName(""PlayersShowtabxs"")[0];
              var c = parentElement.children;
               c[0].click(); 

           }
           else
           {
               var parentElement = document.getElementsB");
            WriteLiteral(@"yClassName(""PlayersShowtab"")[0];
               var c = parentElement.children;
               c[0].click();

            }
    }
    catch (err) {

    }

    setTimeout(LayoutHideProgressBar, 1000);   // 1 sn bekle (her ihtimale karsi)
  

</script>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<appAPP.Models.PlayersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

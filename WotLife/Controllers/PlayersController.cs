using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;
using System.Net.Mail;
//using System.Media;
using System.ComponentModel;
using System.Threading.Tasks;
using appBLL;
using appMODEL;
using System.Security.AccessControl;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc.Filters;


using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Font;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO;
using iText.Kernel.Utils;


namespace appAPP.Controllers
{

    public class PlayersController : Controller
    {

        private IMemoryCache _Cache;
        private IWebHostEnvironment _Env;
        private IHttpContextAccessor _Htp;
        IConfiguration _iconfiguration;

        public PlayersController(IWebHostEnvironment envrtmnt, IHttpContextAccessor htp, IConfiguration iconfiguration, IMemoryCache imemoryCache)
        {
            _Env = envrtmnt;
            _Htp = htp;
            _iconfiguration = iconfiguration;
            _Cache = imemoryCache;

        }


        public IActionResult DisplayPlayers()
        {
            Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();

            ThisViewModel.TotalPages = 0;
            ThisViewModel.TotalRows = 0;
            ThisViewModel.CurrentPageNumber = 0;

            ViewData.Model = ThisViewModel;

            return View("PlayersGrid");
        }

        public IActionResult PlayersAttributes()
        {
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> PlayersSearch()
        {
            long totalRows;
            long totalPages;
            long pageRows;
            bool returnStatus;
            string returnErrorMessage;

            PlayersBLL ThisBLL = new PlayersBLL();
            Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();

            await this.TryUpdateModelAsync(ThisViewModel);

            ThisViewModel.DBConnectString = _iconfiguration.GetSection("Data").GetSection("ConnectString").Value;

            List<Players> scripts = ThisBLL.PlayersSearch(
                ThisViewModel,
                ThisViewModel.CurrentPageNumber,
                ThisViewModel.PageSize,
                ThisViewModel.SortBy,
                ThisViewModel.SortAscendingDescending,
                out totalRows,
                out totalPages,
                out pageRows,
                out returnStatus,
                out returnErrorMessage);

            ViewData["scripts"] = scripts;

            ThisViewModel.TotalPages = totalPages;
            ThisViewModel.TotalRows = totalRows;

            ViewData.Model = ThisViewModel;


            return PartialView("PlayersResults");

        }

        public IActionResult PlayersDetail()
        {

            PlayersBLL ThisBLL = new PlayersBLL();
            Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();

            ViewData.Model = ThisViewModel;


            return View();
        }



        public JsonResult GetPlayersDetailAdd()
        {
            bool returnStatus;
            string returnErrorMessage;

            PlayersBLL ThisBLL = new PlayersBLL();
            Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();
            //---------------------------------------------------------------------------------------------------
            Players script = new Players();
            List<Playersnormcombo> PlayersnormcomboList = new List<Playersnormcombo>();
            PlayersnormcomboList = ThisBLL.GetPlayersnormcombo(out returnStatus, out returnErrorMessage);
            script.PlayersnormcomboList = PlayersnormcomboList;
            //---------------------------------------------------------------------------------------------------

            ThisViewModel.UpdateViewModel(script, typeof(Players).GetProperties());

            List<string> outputMessages = new List<string>();
            outputMessages.Add(returnErrorMessage);
            ThisViewModel.ReturnMessage = outputMessages;
            ThisViewModel.ReturnStatus = returnStatus;

            return new JsonResult(ThisViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> GetPlayersDetail()
        {
            bool returnStatus;
            string returnErrorMessage;
            List<string> returnMessage;

            PlayersBLL ThisBLL = new PlayersBLL();
            Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();

            await this.TryUpdateModelAsync(ThisViewModel);

            ThisViewModel.DBConnectString = _iconfiguration.GetSection("Data").GetSection("ConnectString").Value;

            Players script = ThisBLL.GetPlayersDetail(
                ThisViewModel.Player_ID,
                ThisViewModel.DBConnectString,
                out returnStatus,
                out returnErrorMessage,
                out returnMessage);

            ThisViewModel.UpdateViewModel(script, typeof(Players).GetProperties());

            ThisViewModel.ReturnMessage = returnMessage;
            ThisViewModel.ReturnStatus = returnStatus;

            return new JsonResult(ThisViewModel);

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddPlayers()
        {
            long returnPageNumber;
            long returnRowNumber;
            bool returnStatus;
            string returnErrorMessage;

            List<string> returnMessage;

            try
            {
                PlayersBLL ThisBLL = new PlayersBLL();
                Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();

                await this.TryUpdateModelAsync(ThisViewModel);

                ThisViewModel.DBConnectString = _iconfiguration.GetSection("Data").GetSection("ConnectString").Value;

                Players script = ThisBLL.AddPlayers(
                   ThisViewModel,
                   out returnPageNumber,
                   out returnRowNumber,
                   out returnMessage,
                   out returnStatus,
                   out returnErrorMessage);

                ThisViewModel.UpdateViewModel(script, typeof(Players).GetProperties());

                ThisViewModel.ReturnMessage = returnMessage;
                ThisViewModel.ReturnStatus = returnStatus;
                ThisViewModel.CurrentPageNumber = returnPageNumber;
                ThisViewModel.CurrentRowNumber = returnRowNumber;

                return new JsonResult(ThisViewModel);
            }
            catch (Exception ex)
            {
                Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();
                List<string> outputMessage = new List<string>();
                outputMessage.Add(ex.Message);
                ThisViewModel.ReturnMessage = outputMessage;

                ThisViewModel.ReturnStatus = false;

                return new JsonResult(ThisViewModel);
            }

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> UpdatePlayers()
        {
            long returnPageNumber;
            long returnRowNumber;

            bool returnStatus;

            List<string> returnMessage;

            try
            {
                PlayersBLL ThisBLL = new PlayersBLL();
                Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();

                await this.TryUpdateModelAsync(ThisViewModel);

                ThisViewModel.DBConnectString = _iconfiguration.GetSection("Data").GetSection("ConnectString").Value;

                Players script = ThisBLL.UpdatePlayers(
                   ThisViewModel,
                   out returnPageNumber,
                   out returnRowNumber,
                   out returnStatus,
                   out returnMessage);

                ThisViewModel.UpdateViewModel(script, typeof(Players).GetProperties());

                ThisViewModel.ReturnMessage = returnMessage;
                ThisViewModel.ReturnStatus = returnStatus;
                ThisViewModel.CurrentPageNumber = returnPageNumber;
                ThisViewModel.CurrentRowNumber = returnRowNumber;


                return new JsonResult(ThisViewModel);
            }
            catch (Exception ex)
            {
                Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();
                List<string> outputMessage = new List<string>();
                outputMessage.Add(ex.Message);
                ThisViewModel.ReturnMessage = outputMessage;

                ThisViewModel.ReturnStatus = false;

                return new JsonResult(ThisViewModel);
            }

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> DelPlayers()
        {
            long returnPageNumber;
            long returnRowNumber;

            bool returnStatus;

            List<string> returnMessage;

            PlayersBLL ThisBLL = new PlayersBLL();
            Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();

            await this.TryUpdateModelAsync(ThisViewModel);

            ThisViewModel.DBConnectString = _iconfiguration.GetSection("Data").GetSection("ConnectString").Value;

            Players script = ThisBLL.DelPlayers(
                ThisViewModel,
                out returnPageNumber,
                out returnRowNumber,
                out returnStatus,
                out returnMessage);

            ThisViewModel.UpdateViewModel(script, typeof(Players).GetProperties());

            ThisViewModel.ReturnMessage = returnMessage;
            ThisViewModel.ReturnStatus = returnStatus;
            ThisViewModel.CurrentPageNumber = returnPageNumber;
            ThisViewModel.CurrentRowNumber = returnRowNumber;

            return new JsonResult(ThisViewModel);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> DelPlayersALL()
        {
            long returnPageNumber;
            long returnRowNumber;

            bool returnStatus;

            List<string> returnMessage;

            PlayersBLL ThisBLL = new PlayersBLL();
            Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();

            await this.TryUpdateModelAsync(ThisViewModel);

            ThisViewModel.DBConnectString = _iconfiguration.GetSection("Data").GetSection("ConnectString").Value;

            Players script = ThisBLL.DelPlayersALL(
                ThisViewModel,
                out returnPageNumber,
                out returnRowNumber,
                out returnStatus,
                out returnMessage);

            ThisViewModel.UpdateViewModel(script, typeof(Players).GetProperties());

            ThisViewModel.ReturnMessage = returnMessage;
            ThisViewModel.ReturnStatus = returnStatus;
            ThisViewModel.CurrentPageNumber = returnPageNumber;
            ThisViewModel.CurrentRowNumber = returnRowNumber;

            return new JsonResult(ThisViewModel);
        }


        public IActionResult PlayersShow()
        {
            Models.PlayersViewModel ThisViewModel = new Models.PlayersViewModel();
            ViewData.Model = ThisViewModel;

            return View();
        }

        public class DeleteFileAttribute : ActionFilterAttribute
        {

            public override void OnActionExecuted(ActionExecutedContext context)
            {
                var filePathResultitvs = context.Result as FileStreamResult;

                string jsdelit = "wwwroot/" + filePathResultitvs.FileDownloadName;

                string jsdelit2 = filePathResultitvs.FileDownloadName;

            }

        }

        public string GetPathK()
        {

            string pathget = _Env.WebRootPath;
            return pathget;
        }

        }
    }

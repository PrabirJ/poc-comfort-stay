namespace ComfortStay.Controllers
{
    using Comfortstay.BusinessServices;
    using ComfortStay.Models;
    using ComfortStay.Utility;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SearchController : Controller
    {

        private IHotelService searchHotel;
        private ILoggerService logToFile;
        private AppSettings appSettings;


    /// <summary>
    /// Constructor for dependency injection
    /// </summary>
    /// <param name="searchHotelAPI">Search hotel interface</param>
    /// <param name="logFile">Logger interface</param>
    /// <param name="config">Configuration interface</param>
        public SearchController(IHotelService searchHotelAPI, ILoggerService logFile, IConfiguration config)
        {
            this.searchHotel = searchHotelAPI;
            this.logToFile = logFile;
            appSettings = new AppSettings
            {
                ExtApiAuthCode = config.GetSection("AppSettings")["ExteralAPI_AuthCode"],
                ExtApiMethodName = config.GetSection("AppSettings")["ExternalAPI_MethodName"],
                ExtApiUrl = config.GetSection("AppSettings")["ExternalAPI_URL"]
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This controller method will call the service layer to get hotel details
        /// </summary>
        /// <param name="searchModel">Model data from View</param>
        /// <returns return="ActionResult"></returns>
        [HttpPost]
        public async Task<ActionResult> Index(SearchRequestModel searchModel)
        {
            ViewResult returnView;
            try
            {
                if (searchModel == null)
                {
                    returnView = View(searchModel);
                }
                var authCode = appSettings.ExtApiAuthCode;
                var apiMethodName = appSettings.ExtApiMethodName;
                var apiUrl = appSettings.ExtApiUrl;

                var hotelList = await searchHotel.GetSearchDetail(apiUrl, apiMethodName, searchModel.DestinationId, searchModel.Nights, authCode);
                var recordList = new List<SearchResponseModel>();
                if (hotelList != null)
                {
                    foreach (var hotel in hotelList)
                    {
                        foreach (var rate in hotel.Rates)
                        {
                            recordList.Add(new SearchResponseModel()
                            {
                                HotelName = hotel.Name,
                                BoardType = rate.BoardType,
                                RateType = rate.RateType,
                                BasePrice = rate.UnitPrice,
                                ActualPrice = rate.ActualPrice
                            });
                        }
                    }
                }
                ViewData["ResultSet"] = recordList;
                returnView = View("Index");
            }
            catch (Exception ex)
            {
                logToFile.LogToFile("C:\\Logging", "ExceptionLog", ex.Message);
                returnView = View("../Views/Shared/Error.cshtml", new ErrorModel { RequestId = "123", ExceptionMessage = ex.Message });
            }
            return returnView;
        }
    }
}
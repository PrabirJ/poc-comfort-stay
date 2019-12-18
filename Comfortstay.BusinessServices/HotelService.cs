namespace Comfortstay.BusinessServices
{
    using ComfortStay.Repository;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// This class basically is the srvice layer, will take data from repository and will send back to controller.
    /// </summary>
    public class HotelService : IHotelService
    {
        private IHotelRepository objHotelRepository;
        public HotelService(IHotelRepository repo)
        {
            objHotelRepository = repo;
        }
        /// <summary>
        /// This method call hotel repository and send back the hotel detail to controller
        /// </summary>
        /// <param name="apiUrl" >url of api</param>
        /// <param name="apiMethodName">api method name</param>
        /// <param name="destinationId">destination id</param>
        /// <param name="nights">no of night </param>
        /// <param name="authCode">auth code</param>
        /// <returns></returns>
        public async Task<List<Hotel>> GetSearchDetail(string apiUrl, string apiMethodName, int destinationId, int nights, string authCode)
        {
            var hotelList = await objHotelRepository.FindBargain(apiUrl, apiMethodName, destinationId, nights, authCode);
            if (hotelList != null && hotelList.Count > 0)
            {
                foreach (var hotel in hotelList)
                {
                    foreach (var rate in hotel.Rates)
                    {
                        rate.ActualPrice = rate.RateType == "PerNight" ? rate.UnitPrice * nights : rate.UnitPrice;
                    }
                }
            }
            return hotelList;
        }
    }
}

namespace Comfortstay.BusinessServices
{
    using ComfortStay.Repository;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHotelService
    {
        Task<List<Hotel>> GetSearchDetail(string apiUrl, string apiMethodName, int destinationId, int nights, string authCode);
    }
}

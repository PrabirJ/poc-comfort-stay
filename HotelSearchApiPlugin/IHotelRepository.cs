namespace ComfortStay.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHotelRepository
    {
        Task<List<Hotel>> FindBargain(string apiUrl, string apiMethodName, int destinationId, int nights, string authCode);
    }
}

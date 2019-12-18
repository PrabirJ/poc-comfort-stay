namespace ComfortStay.Repository
{
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class HotelRepository : IHotelRepository
    {
        private ConfigurationBuilder configurationBuilder;
        public HotelRepository()
        {
            configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
        }
        /// <summary>
        /// This method call the api and fetch the bargain details against the following 
        /// </summary>
        /// <param name="apiUrl" >url of api</param>
        /// <param name="apiMethodName">api method name</param>
        /// <param name="destinationId">destination id</param>
        /// <param name="nights">no of night </param>
        /// <param name="authCode">auth code</param>
        /// <returns></returns>
        public async Task<List<Hotel>> FindBargain(string apiUrl, string apiMethodName, int destinationId, int nights, string authCode)
        {
            List<Hotel> hotelList = new List<Hotel>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                var requestUri = $"{apiMethodName}?destinationId={destinationId}&nights={nights}&code={authCode}";
                using (var response = await client.GetAsync(requestUri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();

                        var rawAPIResult = JsonConvert.DeserializeObject<List<SearchAPIDataContract>>(jsonString);
                        hotelList = rawAPIResult.Select(data => new Hotel
                        {
                            GeoId = data.Hotel.GeoId,
                            Name = data.Hotel.Name,
                            PropertyId = data.Hotel.PropertyId,
                            Rating = data.Hotel.Rating,
                            Rates = data.Rates
                        }).ToList();
                        return hotelList;
                    }
                    else
                    {
                        throw new Exception("API Exception Occurred. Try with different query or contact support.");
                    }
                }
            }
        }
    }
}

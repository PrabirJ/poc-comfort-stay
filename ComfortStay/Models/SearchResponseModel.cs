using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfortStay.Models
{
    public class SearchResponseModel
    {
        /// <summary>
        /// Broad type the final price associated 
        /// </summary>
        public string BoardType { get; set; }

        /// <summary>
        /// Name of the hotel
        /// </summary>
        public string HotelName { get; set; }

        /// <summary>
        /// Rate catagory
        /// </summary>
        public string RateType { get; set; }

        /// <summary>
        /// Base price
        /// </summary>
        public double BasePrice { get; set; }

        /// <summary>
        /// Actual price the proper price associated with hotel
        /// </summary>
        public double ActualPrice { get; set; }
    }
}

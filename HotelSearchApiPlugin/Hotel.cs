using System.Collections.Generic;

namespace ComfortStay.Repository
{
    /// <summary>
    /// Hotel consist of Name , Geographycal id & Rating
    /// </summary>
    public class Hotel
    {
        /// <summary>
        /// property id is the unique id against the hotel
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Name of the hotel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Geographical id
        /// </summary>
        public int GeoId { get; set; }

        /// <summary>
        /// Evaluation on the basis of performation
        /// </summary>
        public int Rating { get; set; }


        public List<Rate> Rates { get; set; }
    }

}

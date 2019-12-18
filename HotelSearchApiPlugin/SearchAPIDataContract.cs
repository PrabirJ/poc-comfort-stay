namespace ComfortStay.Repository
{
    using System.Collections.Generic;

    /// <summary>
    /// Json object was created
    /// </summary>
    public class SearchAPIDataContract
    {
        /// <summary>
        /// Hotel parameter of type Hotel object 
        /// </summary>
        public Hotel Hotel { get; set; }

        /// <summary>
        /// List if Rate object
        /// </summary>
        public List<Rate> Rates { get; set; }
    }


}

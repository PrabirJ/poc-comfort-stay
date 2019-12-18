namespace ComfortStay.Repository
{
    /// <summary>
    /// Listed the rate on the basis of ratetype,boardtype,value
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// rate type are of two type per night or stay
        /// </summary>
        public string RateType { get; set; }

        /// <summary>
        /// board type was the final price allocated
        /// </summary>
        public string BoardType { get; set; }


        /// <summary>
        /// Unit price for the property
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        /// Actual price for the property against the stay
        /// </summary>
        public double ActualPrice { get; set; }
    }
}

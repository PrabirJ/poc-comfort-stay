namespace ComfortStay.Models
{
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// search Model Basically do the search the hotels w.r.t DestinationId and No. Of Night Stay
    /// </summary>
    public class SearchRequestModel
    {
        /// <summary>
        /// DestinationId is the unique ID associated with the Destination
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Choose Destination")]
        public int DestinationId { get; set; }


        /// <summary>
        /// Nights represents the no of days the customer stays
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only Positive Value Required")]
        public int Nights { get; set; }
    }
}

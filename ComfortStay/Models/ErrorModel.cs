namespace ComfortStay.Models
{
    /// <summary>
    /// Error Model Basically dot the exception if its occure in the application
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// request id is the unique id represent the calling api request
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Exception message is the exception outcome that was register at this parameter
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Show Request Id is the boolean field against the 
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

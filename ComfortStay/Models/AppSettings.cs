namespace ComfortStay.Models
{
    /// <summary>
    /// Model use to collect the setting configuration from Appsetting
    /// </summary>
    public class AppSettings
    {
        public string ExtApiUrl { get; set; }
        public string ExtApiAuthCode { get; set; }
        public string ExtApiMethodName { get; set; }
    }
}
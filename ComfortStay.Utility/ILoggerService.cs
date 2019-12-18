namespace ComfortStay.Utility
{
    public interface ILoggerService
    {
        void LogToFile(string logPath, string filename, string logData);
    }
}
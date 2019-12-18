namespace ComfortStay.Utility
{
    using System;
    using System.IO;
    public class TextFileLoggerService : ILoggerService
    {
        /// <summary>
        /// Log File Basically write the exception logging at textfile
        /// </summary>
        /// <param name="logPath"></param>
        /// <param name="filename"></param>
        /// <param name="logData"></param>
        public void LogToFile(string logPath, string filename, string logData)
        {
            try
            {
                Directory.CreateDirectory(logPath);
                File.WriteAllText(Path.Combine(logPath, AddTimeStampToFilename(filename)), logData);
            }
            catch (Exception Ex)
            {
                throw Ex.InnerException;
            }
        }


        /// <summary>
        /// Add the Time Stamped to a text file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static string AddTimeStampToFilename(string filename)
        {
            return string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), filename);
        }
    }
}

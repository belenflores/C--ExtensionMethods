using System.IO;
using System.Text;

namespace System
{
    /// <summary>
    /// Contains extension methods for loging exceptions to txt or csv files. Extends Exception Class.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Log to a Txt file. The file´s name has the format: yyyyMMdd.txt and is saved in \log directory
        /// </summary>
        public static void LogToTXT(this Exception ex)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(getPath(FileExtension.txt), true))
                {
                    outputFile.WriteLine($"DATE: {DateTime.Now.ToString("yyyyMMdd hh:mm:ss")} | MESSAGE: {ex.Message} | SOURCE: {ex.Source} | STACKTRACE: {ex.StackTrace}");
                }
            }
            catch(Exception)
            {
                //Do nothing
            }
        }

        /// <summary>
        /// Log to a Cvs file. The file´s name has the format: yyyyMMdd.csv and is saved in \log directory
        /// </summary>
        public static void LogToCVS(this Exception ex)
        {
            try
            {
                string path = getPath(FileExtension.csv);
                StringBuilder sb = new StringBuilder();

                if (new FileInfo(path).Length == 0)
                    sb.AppendLine("DATE,MESSAGE,SOURCE,STACKTRACE");

                sb.AppendLine($"{DateTime.Now.ToString("yyyyMMdd hh:mm:ss")},\"{ex.Message}\",\"{ex.Source}\",\"{ex.StackTrace}\"");
                File.WriteAllText(getPath(FileExtension.csv), sb.ToString());
            }
            catch (Exception)
            {
                //Do nothing
            }
        }

        /// <summary>
        /// Gets the path for the log file. Creates the path if does not exist
        /// </summary>
        /// <param name="ext">Extension of file type (csv,txt)</param>
        /// <returns>Path of log file</returns>
        private static string getPath(FileExtension ext)
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"logs");
            if (!System.IO.Directory.Exists(logPath)) //create directory 
                System.IO.Directory.CreateDirectory(logPath);

            string filePath = Path.Combine(logPath, $"{DateTime.Today.ToString("yyyyMMdd")}.{ext}"); 
            if (!File.Exists(filePath))//create file
                File.Create(filePath).Dispose();

            return filePath;
        }
    }

    enum FileExtension
    {
        csv,
        txt
    }
}


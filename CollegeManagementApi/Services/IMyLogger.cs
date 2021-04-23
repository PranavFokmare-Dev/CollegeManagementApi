using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface IMyLogger
    {
        void log(string message);
    }

    public class MyLogger : IMyLogger
    {
        private string logFileName;
        private string logFilePath;
        private string logFinalPath;
        private readonly IWebHostEnvironment _env;

        public MyLogger(IWebHostEnvironment env)
        {

            this._env = env;
            this.logFileName = GetLogFileName();
            this.logFilePath = GetLogFilePath();
            this.logFinalPath = logFilePath + logFileName;

        }
        private string GetLogFileName()
        {
            string currentDate = DateTime.Now.ToString("dd_MM_yyyy");
            return $"log {currentDate}.txt";
        }
        private string GetLogFilePath()
        {
            string rootPath = _env.ContentRootPath;
            string normalLogsPath = "//logs//Normal//";
            return rootPath + normalLogsPath;
        }

        public async void log(string message)
        {
            using (FileStream fs = new FileStream(logFinalPath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    await sw.WriteLineAsync(message);
                }
            }
        }
    }
}

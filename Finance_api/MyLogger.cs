using Finance_api.Interfaces;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_api
{
    internal class MyLogger
    {
        //public Logger WriteLogInFile()
        //{
        //    return WriteLogInFiles();
        //}
        public static Logger WriteLogInFile()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\logFile.txt";
            return new LoggerConfiguration()
                .WriteTo
                .File(baseDirectory, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}

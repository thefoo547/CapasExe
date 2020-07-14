﻿using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Loggers
{
    class FileLogger : ILog
    {
        public void Log(string mensaje)
        {
            using (StreamWriter writetext = new StreamWriter(@"C:\log.txt", append: true))
            {
                writetext.WriteLine(mensaje);
            }
        }

        public void LogException(Exception ex)
        {
            string error = $"{ex.Message}: {ex.StackTrace}";
            Log(error);
        }
    }
}

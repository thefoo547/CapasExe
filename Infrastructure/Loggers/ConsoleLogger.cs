using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain.Interfaces;


namespace Infrastructure.Loggers
{
    public class ConsoleLogger : ILog
    {
        public void Log(string mensaje)
        {
            Console.WriteLine($"{DateTime.Now}: {mensaje}");
        }

        public void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void LogException(Exception ex)
        {
            SetColor(ConsoleColor.Red);
            string error = $"{ex.Message}: {ex.StackTrace}";
            Log(error);
            SetColor(ConsoleColor.White);

        }
    }
}

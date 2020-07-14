using Domain.Interfaces;
using Infrastructure.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Factories
{
    public class LoggerFact
    {
        public enum LoggerType
        {
            CONSOLE = 1,
            FILE = 2
        }
        public ILog ObtenerLogger(LoggerType type)
        {
            switch (type)
            {
                case LoggerType.CONSOLE:
                    return new ConsoleLogger();
                case LoggerType.FILE:
                    return new FileLogger();
                default:
                    throw new NotImplementedException("logger not found");
            }
        }
    }
}

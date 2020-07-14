using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ILog
    {
        void Log(string msg);
        void LogException(Exception ex);
    }
}

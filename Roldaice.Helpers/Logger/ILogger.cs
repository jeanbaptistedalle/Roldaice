using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Helpers.Logger
{
    public interface ILogger
    {
        void LogInfoIf(bool condition, string message);
        void Info(string message);
        void Warn(string message);
        void Warn(Exception x);
        void Debug(string message);
        void Error(string message);
        void Error(string message, Exception x);
        void Error(Exception x);
        void Fatal(string message);
        void Fatal(Exception x);
        string RollingLogFileAppenderDirectory { get; }
    }
}

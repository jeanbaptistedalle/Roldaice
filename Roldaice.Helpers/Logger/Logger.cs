using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Helpers.Logger
{
    public class Logger : ILogger
    {
        public ILog _logger;

        public string RollingLogFileAppenderDirectory { get; private set; }

        public Logger()
        {
            LogManager.ResetConfiguration();
            log4net.Config.XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(this.GetType());
            RollingLogFileAppenderDirectory = GetRollingLogFileAppenderDirectory();
        }

        public void LogInfoIf(bool condition, string message)
        {
            if (condition)
            {
                _logger.Info(message);
            }
        }
        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Warn(Exception x)
        {
            Warn(BuildExceptionMessage(x));
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception x)
        {
            Error(BuildExceptionMessage(x));
        }

        public void Error(string message, Exception x)
        {
            _logger.Error(message, x);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(Exception x)
        {
            Fatal(BuildExceptionMessage(x));
        }

        private string GetRollingLogFileAppenderDirectory()
        {
            var hierarchy = LogManager.GetRepository() as Hierarchy;
            var appender = hierarchy?.Root?.Appenders?.OfType<RollingFileAppender>()?.FirstOrDefault();
            appender?.Flush(0);
            return appender != null ? System.IO.Path.GetDirectoryName(appender.File) : string.Empty;
        }

        private string BuildExceptionMessage(Exception x)
        {
            Exception logException = x;

            StringBuilder strErrorMsg = new StringBuilder(Environment.NewLine);

            strErrorMsg.AppendLine($"Message : {logException.Message}");

            // Source of the message
            strErrorMsg.AppendLine($"Source : {logException.Source}");
            strErrorMsg.AppendLine($"Exception : {logException.GetType().Name}");


            // Stack Trace of the error
            strErrorMsg.AppendLine(string.Format("Stack Trace : {0}", logException.StackTrace));

            var innerException = logException.InnerException;

            //Show all inner exceptions
            var cpt = 1;
            while (innerException != null)
            {
                //Inner exception
                strErrorMsg.AppendLine($"Inner Exception {cpt}");
                strErrorMsg.AppendLine($"   Message : {innerException.Message}");
                strErrorMsg.AppendLine($"   Exception : {innerException.GetType().Name}");
                strErrorMsg.AppendLine($"   Stack Trace: {innerException.StackTrace}");

                cpt++;
                innerException = innerException.InnerException;
            }
            // Method where the error occurred
            strErrorMsg.AppendLine($"TargetSite : {logException.TargetSite}");

            strErrorMsg.AppendLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            return strErrorMsg.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace QaCore
{
    public class LoggerUtil
    {
        private static readonly Logger Logger = LogManager.GetLogger(typeof(RestUtility).Name);

        public static void Log(Exception error, LogLevel level)
        {
            switch(level)
            {
                case LogLevel.Trace:
                    break;
                case LogLevel.Debug:
                    break;
                case LogLevel.Error:
                    if(Logger.IsErrorEnabled)
                    {
                        Logger.Error(string.Format("Message: {0} {1}Stack Trace: {2}{1}", error.Message.Trim(), Environment.NewLine, error.StackTrace?.Trim()?? ""));
                    }
                    break;
                case LogLevel.Fatal:
                    break;
                default:
                    break;
            }
        }
    }

    public enum LogLevel
    {
        Trace,
        Debug,
        Error,
        Fatal
    }

}

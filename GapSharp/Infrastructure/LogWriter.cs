using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.Infrastructure
{
    public delegate void WriteLog(string message, LogErrorLevel level = LogErrorLevel.Info, Exception ex = null);
    public abstract class LogWriter : ILogWriter
    {
        protected LogWriter()
        {
            LogLevel = LogErrorLevel.Error;
        }
        public LogErrorLevel LogLevel { get; set; }
        protected WriteLog OnWriteLog { get; set; }

        public void Log(string message, LogErrorLevel level = LogErrorLevel.Info, Exception ex = null)
        {
            if (OnWriteLog != null && level >= LogLevel)
                Task.Run(() => { OnWriteLog(message, level, ex); });
        }
    }
}

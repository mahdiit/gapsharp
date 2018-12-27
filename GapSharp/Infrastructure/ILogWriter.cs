using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapSharp.Infrastructure
{
    public interface ILogWriter
    {
        LogErrorLevel LogLevel { get; set; }
        void Log(string message, LogErrorLevel level = LogErrorLevel.Info, Exception ex = null);
    }
}

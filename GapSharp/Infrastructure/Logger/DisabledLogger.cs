namespace GapSharp.Infrastructure.Logger
{
    public class DisabledLogger: LogWriter
    {
        public DisabledLogger()
        {
            LogLevel = LogErrorLevel.None;
        }
    }
}

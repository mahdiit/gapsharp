using System;

namespace GapSharp.Infrastructure.Logger
{
    public class ConsoleLogger : LogWriter
    {
        public ConsoleLogger()
        {
            OnWriteLog = (message, level, exception) =>
            {
                Console.WriteLine("------------\r\n{0}\t{1}\t{2}\t{3}\r\n", DateTime.Now.ToShortTimeString(), level, message);
                if (exception != null)
                {
                    Console.WriteLine("Error:\r\n" + exception.Message);
                }
            };
        }
    }
}

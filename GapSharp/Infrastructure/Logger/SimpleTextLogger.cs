using System;
using System.IO;
using System.Threading;

namespace GapSharp.Infrastructure.Logger
{
    public class SimpleTextLogger : LogWriter
    {
        public string LogFolder { get; }
        private string _logFileName;
        private readonly ReaderWriterLockSlim _fileLocker;
        private string CurrentLogFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_logFileName))
                    _logFileName = string.Format("{0}\\{1}.txt", LogFolder, DateTime.Now.ToString("yyyy-MM-dd-HH"));

                var fileInfo = new FileInfo(_logFileName);
                if (fileInfo.Exists)
                {
                    if (Convert.ToSingle(fileInfo.Length / 1024.0f) >= 1024)
                    {
                        _logFileName = string.Format("{0}\\{1}.txt", LogFolder, DateTime.Now.ToString("yyyy-MM-dd-HH"));
                        int i = 1;
                        while (File.Exists(_logFileName))
                        {
                            _logFileName = string.Format("{0}\\{1}-{2}.txt", LogFolder, DateTime.Now.ToString("yyyy-MM-dd-HH"), i);
                            i++;
                        }
                    }
                }

                return _logFileName;
            }
        }

        public SimpleTextLogger(string logFolder, LogErrorLevel logErrorLevel = LogErrorLevel.Info)
        {
            _fileLocker = new ReaderWriterLockSlim();
            LogLevel = logErrorLevel;

            if (!logFolder.EndsWith("\\"))
                logFolder += "\\";

            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            LogFolder = logFolder;

            OnWriteLog = (message, level, exception) =>
            {
                var logMsg = $"{DateTime.Now:G}\t{level}\r\n---------------\r\n{message}\r\n";
                if (exception != null)
                {
                    logMsg += "Error:\r\n";
                    logMsg += "------------------\r\n" + exception.Message + "\r\n";
                    logMsg += exception.StackTrace + "\r\n";

                    Exception innerExeption = exception.InnerException;
                    while (innerExeption != null)
                    {
                        logMsg += innerExeption.Message + "\r\n";
                        logMsg += innerExeption.StackTrace + "\r\n";
                        innerExeption = innerExeption.InnerException;
                    }
                    logMsg += "------------------\r\n";
                }

                logMsg += "\r\n";

                _fileLocker.EnterWriteLock();

                File.AppendAllText(CurrentLogFileName, logMsg);

                _fileLocker.ExitWriteLock();
            };
        }
    }
}

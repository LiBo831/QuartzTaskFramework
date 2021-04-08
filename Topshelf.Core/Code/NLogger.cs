using NLog;
using System;

namespace Topshelf.Core
{
    public class NLogger : INLogger
    {

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message, object argument)
        {
            logger.Debug(message, argument);
        }
        public void Info(string message)
        {
            logger.Info(message);
        }
        public void Warn(string message)
        {
            Warn(message);
        }
        public void Error(string message)
        {
            logger.Error(message);
        }
        public void Fatal(string message)
        {
            logger.Fatal(message);
        }
    }

    public interface INLogger
    {
        void Debug(string message, object argument);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);
    }

}

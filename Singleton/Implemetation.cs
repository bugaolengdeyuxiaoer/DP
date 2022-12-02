
namespace Singleton
{
    using System;
    public class Logger
    {
        private static readonly Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());

        public static Logger Instance
        {
            get
            {
                return _lazyLogger.Value;
            }
        }
        protected Logger()
        {

        }
        public void Log(string message)
        {
            Console.WriteLine($"Message to log {message}");
        }
    }
}

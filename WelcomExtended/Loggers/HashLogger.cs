using System;
using System.Collections.Concurrent;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WelcomExtended.Loggers
{
    public class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public void Log(string message)
        {
            int hash = message.GetHashCode();
            _logMessages.TryAdd(hash, message);
        }

        public string GetName()
        {
            return _name;
        }

        public ConcurrentDictionary<int, string> GetLogMessages()
        {
            return _logMessages;
        }

        IDisposable ILogger.BeginScope<TState>(TState state)
        {
            return null!;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var messages = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine("- LOGGER -");
            var messageToBeLogger = new StringBuilder();
            messageToBeLogger.Append($"[{logLevel}]");
            messageToBeLogger.AppendFormat("[{0}]", _name);
            Console.WriteLine(messageToBeLogger);
            Console.WriteLine($"{formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = messages;
        }
    }
}

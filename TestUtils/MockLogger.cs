using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace StoneAge.TestUtils
{
    public class MockLogger<T> : ILogger<T>
    {
        public IDictionary<LogLevel, List<string>> LogEntries { get; }

        public MockLogger()
        {
            LogEntries = new Dictionary<LogLevel, List<string>>();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!LogEntries.ContainsKey(logLevel))
            {
                LogEntries[logLevel] = new List<string>();
            }

            LogEntries[logLevel].Add(state.ToString());
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
    }
}

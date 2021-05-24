using BarbequeWeather.Utilities.Logger;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarbequeWeather.Test
{
    class TestLogger : ILogger
    {
        private List<LogLine> _logs = new List<LogLine>();

        public void Log(string message, Severity severity)
        {
            _logs.Add(new LogLine(message, severity));
        }

        public void AssertLogged(string message, Severity level)
        {
            var logline = _logs.FirstOrDefault(t => t.Message == message && t.Severity == level);
            Assert.IsNotNull(logline, $"Log line was not found: {message}, {level}");
        }
    }

    public class LogLine
    {
        public string Message { get; }
        public Severity Severity { get; }

        public LogLine(string message, Severity severity)
        {
            Message = message;
            Severity = severity;
        }
    }
}

using System;
using Microsoft.Extensions.Logging;
namespace WelcomExtended.Loggers
{
	public class LoggerProvider : ILoggerProvider
	{
		public ILogger CreateLogger(string categoryName)
		{
			return new HashLogger(categoryName);
		}
		public void Dispose()
		{

		}
	}
}


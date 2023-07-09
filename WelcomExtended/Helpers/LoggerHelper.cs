using System;
using Microsoft.Extensions.Logging;
using WelcomExtended.Loggers;

namespace WelcomExtended.Helpers
{
	public static class LoggerHelper 
	{
		public static ILogger GetLogger(string categoryName)
		{

			ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
			{
				builder.AddProvider(new LoggerProvider());
			});

			return loggerFactory.CreateLogger(categoryName);
		}
	}
}


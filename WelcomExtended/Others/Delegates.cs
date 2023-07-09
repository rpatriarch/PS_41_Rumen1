using System;
using Microsoft.Extensions.Logging;
using WelcomExtended.Helpers;

namespace WelcomExtended.Others
{
	public static class Delegates
	{
		public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");

		public static void Log(string error)
		{
			logger.LogError(error);
		}

		public static void Log2(string error)
		{
			Console.WriteLine("- DELEGATES -");
			Console.WriteLine($"{error}");
			Console.WriteLine("- DELEGATES -");
		}

		public delegate void ActionOnError(string errorMessage);
	}
}


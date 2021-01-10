using System;
using System.IO;
using System.Collections;
using Console = System.Console;

namespace MoebooruSnatcher.Util
{
    internal static class ConsoleUtils
	{
		internal static void LogLogoText()
        {
			//Apotheosis
			string[] logo = new string[]{
				"------------------------------------------------------------------------------",
				"|~######~~######~~~~####~~~~######~~##~~##~~~~####~~~~######~~######~~######~|",
				"|~##~~##~~##~~##~~##~~~~##~~~~##~~~~##~~##~~##~~~~##~~##~~~~~~~~##~~~~##~~~~~|",
				"|~######~~######~~##~~~~##~~~~##~~~~######~~##~~~~##~~######~~~~##~~~~######~|",
				"|~##~~##~~##~~~~~~##~~~~##~~~~##~~~~##~~##~~##~~~~##~~~~~~##~~~~##~~~~~~~~##~|",
				"|~##~~##~~##~~~~~~~~####~~~~~~##~~~~##~~##~~~~####~~~~######~~######~~######~|",
				"------------------------------------------------------------------------------"
				};
			foreach(string s in logo)
            {
				
				Log("");
				char[] cs = s.ToCharArray();
				foreach (char c in cs)
				{
					switch (c)
					{
						case '-':
						case '|':
							LogAdd(c.ToString(), ConsoleColor.DarkRed);
							break;
						case '#':
							LogAdd(c.ToString(), ConsoleColor.Red);
							break;
						case '~':
							LogAdd(c.ToString(), ConsoleColor.Black);
							break;
					}
				}
				
            }
			Log("");
		}
		internal static void Timestamp()
        {
			LogAdd("[", ConsoleColor.DarkRed);
			LogAdd(DateTime.Now.ToString("dd"), ConsoleColor.Red);
			LogAdd(":");
			LogAdd(DateTime.Now.ToString("hh"), ConsoleColor.Red);
			LogAdd(":");
			LogAdd(DateTime.Now.ToString("mm"), ConsoleColor.Red);
			LogAdd(":");
			LogAdd(DateTime.Now.ToString("ss.ffff"), ConsoleColor.Red);
			LogAdd("] ", ConsoleColor.DarkRed);
		}
		internal static string Readline(string Var)
        {
			Log(Var+": ", ConsoleColor.DarkMagenta);
			return Console.ReadLine();
        }

		internal static void Error(string text, string Debug = null)
		{
			Timestamp();
			if (Debug != null)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("[Apotheosis] [Error] " + text + " || [Debug] " + Debug);
				Console.ForegroundColor = ConsoleColor.White;
				return;
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[Apotheosis] [Error] " + text);
			Console.ForegroundColor = ConsoleColor.White;
			ConsoleUtils.Log("");
		}
		internal static void Error(Exception e)
		{
			Error(e.Message, e.StackTrace);
		}

		internal static void Success(string text)
		{
			Timestamp();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("[Apotheosis] [Success] " + text);
			ConsoleUtils.Log("");
			Console.ForegroundColor = ConsoleColor.White;

		}
		internal static void Info(string text)
		{
			Timestamp();
			Console.Write("[Apotheosis] [Info] " + text);
			ConsoleUtils.Log("");
		}
		internal static void Log(string text, ConsoleColor color = ConsoleColor.White)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(text);
			Console.ForegroundColor = ConsoleColor.White;
		}
		internal static void Debug(string text, ConsoleColor color = ConsoleColor.White)
		{
#if DEBUG
			Console.ForegroundColor = color;
			Console.WriteLine(text);
			Console.ForegroundColor = ConsoleColor.White;
#endif
		}
		internal static void LogAdd(string text, ConsoleColor color = ConsoleColor.White)
		{
			Console.ForegroundColor = color;
			Console.Write(text);
			Console.ForegroundColor = ConsoleColor.White;
		}
		internal static void LogArray(string[] text, ConsoleColor color = ConsoleColor.White)
		{
			foreach (string s in text)
			{
				Log(s, color);
			}
		}

		internal static void Warning(string text)
		{
			Timestamp();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("[Apotheosis] [Warning] " + text);
			ConsoleUtils.Log("");
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
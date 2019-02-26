using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayEight
	{
		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(8);

			Console.WriteLine(lines.Select(x => CalculateLineValue(x)).Sum());
		}

		public static int CalculateLineValue(string input)
		{
			int total = 0;
			for (int i = 0; i < input.Count(); i++)
			{
				total++;
				if (input[i] == '\\')
				{
					i++;
					ParseEscapeCharacter(input, ref i);
				}
			}

			return input.Count() - (total - 2);
		}

		private static void ParseEscapeCharacter(string input, ref int index)
		{
			switch (input[index])
			{
				case '\\':
				case '"':
					return;
				case 'x':
					index += 2;
					return;
			}
		}

		public static void PartTwo()
		{
			var lines = Utils.GetLinesForDay(8);

			Console.WriteLine(lines.Select(x => EncodeNewString(x).Count() - x.Count()).Sum());
		}

		private static string EncodeNewString(string input)
		{
			string output = "\"";

			for (int i = 0; i < input.Count(); i++)
			{
				switch(input[i])
				{
					case '"':
						output += "\\\"";
						break;
					case '\\':
						output += "\\\\";
						break;
					default:
						output += input[i];
						break;
					
				}
			}
			output += "\"";

			return output;
		}
	}
}
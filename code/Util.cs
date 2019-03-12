using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class Utils
	{
		public static IEnumerable<string> GetLinesFromFile(string filename)
		{
			string line;
			using (var reader = File.OpenText(filename))
			{
				while ((line = reader.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}

		public static IEnumerable<string> GetLinesForDay(int number)
		{
			return GetLinesFromFile("input/Day" + number +"Input.txt");
		}

		public static string RemoveLastChar(string input)
		{
			return input.Substring(0, input.Count() - 1);
		}
	}
}
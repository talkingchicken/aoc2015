using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayOne
	{
		public static void PartOne()
		{
			IEnumerable<string> lines = Utils.GetLinesFromFile("input/Day1Input.txt");

			string line = lines.ElementAt(0);

			int result = line.Where(x => x == '(').Count() - line.Where(x => x == ')').Count();

			Console.WriteLine(result);
		}

		public static void PartTwo()
		{
			IEnumerable<string> lines = Utils.GetLinesFromFile("input/Day1Input.txt");
			string line = lines.ElementAt(0);

			int currentFloor = 0;

			for (int i = 0; i < line.Count(); i++)
			{
				if (line[i] == '(')
					currentFloor++;
				else
					currentFloor--;

				if (currentFloor < 0)
				{
					Console.WriteLine("current position is {0}", i + 1);
					break;
				}
			}
		}
	}
}
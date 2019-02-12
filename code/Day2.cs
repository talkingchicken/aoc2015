using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayTwo
	{
		public static void PartOne()
		{
			IEnumerable<string> lines = Utils.GetLinesFromFile("input/Day2Input.txt");

			int total = lines.Select(x =>
			{
				string[] numbers = x.Split("x");
				int length = Convert.ToInt32(numbers[0]);
				int width = Convert.ToInt32(numbers[1]);
				int height = Convert.ToInt32(numbers[2]);

				List<int> sides = new List<int>{length * width, width * height, height * length};

				return sides.Min() + 2 * sides.Sum();
			}).Sum();

			Console.WriteLine(total);
		}

		public static void PartTwo()
		{
			IEnumerable<string> lines = Utils.GetLinesForDay(2);

			int total = lines.Select(x =>
			{
				string[] numbers = x.Split("x");
				int length = Convert.ToInt32(numbers[0]);
				int width = Convert.ToInt32(numbers[1]);
				int height = Convert.ToInt32(numbers[2]);

				List<int> perimeters = new List<int>{2 * (length + width), 2 * (length + height), 2 * (width + height)};

				return perimeters.Min() + length * width * height;
			}).Sum();

			Console.WriteLine(total);
		}
	}
}
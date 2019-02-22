using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayFive
	{
		private static bool IsNice(string input)
		{
			int vowelCount = 0;
			bool containsRepeat = false;

			for (int i = 0; i < input.Count(); i++)
			{
				if (i > 0)
				{
					switch(input[i])
					{
						case 'b':
						case 'd':
						case 'q':
						case 'y':
							if (input[i - 1] == input[i] - 1)
								return false;
							break;
					}

					if (input[i] == input[i - 1])
						containsRepeat = true;
				}

				switch(input[i])
				{
					case 'a':
					case 'e':
					case 'i':
					case 'o':
					case 'u':
						vowelCount++;
						break;
				}
			}

			return vowelCount >= 3 && containsRepeat;
		}

		public static bool IsReallyNice(string input)
		{
			Dictionary<string, int> pairs = new Dictionary<string, int>();

			bool containsRepeatPair = false;
			bool containsSpecialRepeat = false;

			for (int i = 0; i < input.Count() && (!containsRepeatPair || !containsSpecialRepeat); i++)
			{
				if (i > 0 && !containsRepeatPair)
				{
					string substring = input.Substring(i - 1, 2);
					if (!pairs.TryAdd(substring, i - 1))
					{
						if (pairs[substring] != i - 2)
						{
							containsRepeatPair = true;
						}
					}
				}

				if (i > 1 && !containsSpecialRepeat)
				{
					if (input[i] == input[i - 2])
					{
						containsSpecialRepeat = true;
					}
				}
			}

			return containsRepeatPair && containsSpecialRepeat;
		}

		public static void PartOne()
		{
			IEnumerable<string> lines = Utils.GetLinesForDay(5);

			int total = lines.Where(x => IsNice(x)).Count();

			Console.WriteLine(total);
		}

		public static void PartTwo()
		{
			IEnumerable<string> lines = Utils.GetLinesForDay(5);

			int total = lines.Where(x => IsReallyNice(x)).Count();

			Console.WriteLine(total);
		}
	}
}
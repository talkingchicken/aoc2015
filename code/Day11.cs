using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayEleven
	{
		private static bool IsValidPassword(List<char> input)
		{
			int repeatingPairs = 0;
			int lastPairIndex = -1;
			bool containsSequence = false;

			for (int i = 0; i < input.Count; i++)
			{
				switch(input[i])
				{
					case 'i':
					case 'o':
					case 'l':
						return false;
				}

				if (i > 0 && repeatingPairs < 2)
				{
					if (input[i] == input[i - 1] && (i >= lastPairIndex + 2))
					{
						repeatingPairs++;
						lastPairIndex = i;
					}
				}

				if (i > 1 && !containsSequence)
				{
					if (input[i] - input[i - 1] == 1 && input[i] - input[i - 2] == 2)
					{
						containsSequence = true;
					}
				}
			}

			return repeatingPairs >= 2 && containsSequence;
		}

		public static void PartOne()
		{
			string stringInput = "hxbxwxba";
			List<char> input = new List<char>(stringInput);

			while(!IsValidPassword(input))
			{
				for (int i = input.Count - 1; i >= 0; i--)
				{
					if (input[i] != 'z')
					{
						input[i]++;
						break;
					}
					else
					{
						input[i] = 'a';
					}
				}
			}

			foreach(char c in input)
			{
				Console.Write(c);
			}

			Console.WriteLine();
		}

		public static void PartTwo()
		{
			string stringInput = "hxbxxyzz";
			List<char> input = new List<char>(stringInput);

			do
			{
				for (int i = input.Count - 1; i >= 0; i--)
				{
					if (input[i] != 'z')
					{
						input[i]++;
						break;
					}
					else
					{
						input[i] = 'a';
					}
				}
			} while(!IsValidPassword(input));

			foreach(char c in input)
			{
				Console.Write(c);
			}

			Console.WriteLine();
		}
	}
}
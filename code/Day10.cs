using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayTen
	{
		public static void PartOne()
		{
			string input = "1113122113";
			List<int> listInput = new List<int>(input.Select(x => (x - '0')));

			for (int i = 0; i < 40; i++)
			{
				List<int> newInput = new List<int>();
				int lastIndex = 0;

				for (int j = 1; j < listInput.Count; j++)
				{
					if (listInput[j] != listInput[j - 1])
					{
						newInput.Add(j - lastIndex);
						newInput.Add(listInput[j - 1]);
						lastIndex = j;
					}
				}
				
				newInput.Add(listInput.Count - lastIndex);
				newInput.Add(listInput[listInput.Count - 1]);
				listInput = newInput;
			}

			Console.WriteLine(listInput.Count);
		}

		public static void PartTwo()
		{
			string input = "1113122113";
			List<int> listInput = new List<int>(input.Select(x => (x - '0')));

			for (int i = 0; i < 50; i++)
			{
				List<int> newInput = new List<int>();
				int lastIndex = 0;

				for (int j = 1; j < listInput.Count; j++)
				{
					if (listInput[j] != listInput[j - 1])
					{
						newInput.Add(j - lastIndex);
						newInput.Add(listInput[j - 1]);
						lastIndex = j;
					}
				}
				
				newInput.Add(listInput.Count - lastIndex);
				newInput.Add(listInput[listInput.Count - 1]);
				listInput = newInput;
			}

			Console.WriteLine(listInput.Count);
		}
	}
}
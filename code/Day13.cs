using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayThirteen
	{
		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(13);

			Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
			foreach (string line in lines)
			{
				string[] splitLine = line.Split(" ");
				string firstPerson = splitLine[0];
				int value = Convert.ToInt32(splitLine[3]);
				if (splitLine[2] == "lose")
					value *= -1;
				
				string secondPerson = splitLine[10].Substring(0, splitLine[10].Length - 1);

				if (!dict.ContainsKey(firstPerson))
					dict[firstPerson] = new Dictionary<string, int>();

				dict[firstPerson][secondPerson] = value;
			}
			
			List<string> currentTable = new List<string>();
			
			Console.WriteLine(OptimizeTable(dict, currentTable));
		}

		private static int OptimizeTable(Dictionary<string, Dictionary<string, int>> dict, List<string> currentTable)
		{
			if (currentTable.Count == dict.Keys.Count)
			{
				int total = 0;
				for (int i = 0; i < currentTable.Count; i++)
				{
					total += dict[currentTable[i]][currentTable[(i + 1) % currentTable.Count]];
					total += dict[currentTable[i]][currentTable[(i + currentTable.Count - 1) % currentTable.Count]];
				}

				return total;
			}

			int maxValue = int.MinValue;

			foreach(string person in dict.Keys)
			{
				if (!currentTable.Contains(person))
				{
					currentTable.Add(person);
					maxValue = Math.Max(maxValue, OptimizeTable(dict, currentTable));
					currentTable.Remove(person);
				}
			}

			return maxValue;
		}

		public static void PartTwo()
		{
			var lines = Utils.GetLinesForDay(13);

			Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
			foreach (string line in lines)
			{
				string[] splitLine = line.Split(" ");
				string firstPerson = splitLine[0];
				int value = Convert.ToInt32(splitLine[3]);
				if (splitLine[2] == "lose")
					value *= -1;
				
				string secondPerson = splitLine[10].Substring(0, splitLine[10].Length - 1);

				if (!dict.ContainsKey(firstPerson))
					dict[firstPerson] = new Dictionary<string, int>();

				dict[firstPerson][secondPerson] = value;
			}

			string you = "you";

			dict[you] = new Dictionary<string, int>();

			foreach(string person in dict.Keys)
			{
				dict[you][person] = 0;
				dict[person][you] = 0;
			}
			
			List<string> currentTable = new List<string>();
			
			Console.WriteLine(OptimizeTable(dict, currentTable));
		}
	}
}
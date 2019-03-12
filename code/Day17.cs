using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DaySeventeen
	{
		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(17);

			List<int> jugs = new List<int>(lines.Select(x => int.Parse(x)));

			int combinations = 1 << jugs.Count();

			int exact = 0;

			for (int i = 0; i < combinations; i++)
			{
				int total = 0;
				for (int j = 0; j < jugs.Count; j++)
				{
					if (((1 << j) & i) != 0)
					{
						total += jugs[j];
					}
				}

				if (total == 150)
				{
					exact++;
				}
			}

			Console.WriteLine(exact);
		}

		public static void PartTwo()
		{
			var lines = Utils.GetLinesForDay(17);

			List<int> jugs = new List<int>(lines.Select(x => int.Parse(x)));

			int combinations = 1 << jugs.Count();

			int exact = 0;

			int maxContainers = int.MaxValue;

			for (int i = 0; i < combinations; i++)
			{
				int containers = 0;
				int total = 0;
				for (int j = 0; j < jugs.Count; j++)
				{
					if (((1 << j) & i) != 0)
					{
						total += jugs[j];
						containers++;
					}
				}

				if (total == 150)
				{
					if (containers == maxContainers)
						exact++;
					else if (containers < maxContainers)
					{
						exact = 1;
						maxContainers = containers;
					}
				}
			}

			Console.WriteLine(exact);
		}
	}
}
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayThree
	{
		public static void PartOne()
		{
			IEnumerable<string> lines = Utils.GetLinesForDay(3);
			Dictionary<Tuple<int, int>, int> map = new Dictionary<Tuple<int, int>, int>();

			int row = 0;
			int column = 0;
			map[new Tuple<int, int>(0, 0)] = 1;

			foreach (char letter in lines.ElementAt(0))
			{
				switch(letter)
				{
					case '^':
						row--;
						break;
					case 'v':
						row++;
						break;
					case '<':
						column--;
						break;
					case '>':
						column++;
						break;
				}
				
				var coord = new Tuple<int, int>(row, column);
				if (!map.TryAdd(coord, 1))
				{
					map[coord]++;
				}
			}

			Console.WriteLine(map.Count());
		}

		public static void PartTwo()
		{
			IEnumerable<string> lines = Utils.GetLinesForDay(3);
			Dictionary<Tuple<int, int>, int> map = new Dictionary<Tuple<int, int>, int>();

			int row = 0;
			int column = 0;

			int roboRow = 0;
			int roboColumn = 0;
			map[new Tuple<int, int>(0, 0)] = 1;

			bool isRoboSanta = false;
			foreach (char letter in lines.ElementAt(0))
			{
				switch(letter)
				{
					case '^':
						if (isRoboSanta)
							roboRow--;
						else
							row--;
						break;
					case 'v':
						if (isRoboSanta)
							roboRow++;
						else
							row++;
						break;
					case '<':
						if (isRoboSanta)
							roboColumn--;
						else
							column--;
						break;
					case '>':
						if (isRoboSanta)
							roboColumn++;
						else
							column++;
						break;
				}
				
				var coord = !isRoboSanta ? new Tuple<int, int>(row, column) : new Tuple<int, int>(roboRow, roboColumn);
				if (!map.TryAdd(coord, 1))
				{
					map[coord]++;
				}

				isRoboSanta = !isRoboSanta;
			}

			Console.WriteLine(map.Count());
		}
	}
}
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayEighteen
	{
		private static List<bool> ConvertLineToList(string input)
		{
			return new List<bool>(input.Select(x => x == '#'));
		}

		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(18);
			List<List<bool>> grid = new List<List<bool>>(lines.Select(x => ConvertLineToList(x)));

			for (int i = 0; i < 100; i++)
			{
				List<List<bool>> newGrid = new List<List<bool>>();

				for (int row = 0; row < grid.Count(); row++)
				{
					List<bool> newRow = new List<bool>();

					for (int column = 0; column < grid[row].Count(); column++)
					{
						int litNeighbors = 0;

						for (int y = Math.Max(row - 1, 0); y <= Math.Min(row + 1, grid.Count() - 1); y++)
						{
							for (int x = Math.Max(column - 1, 0); x <= Math.Min(column + 1, grid[y].Count() - 1); x++)
							{
								if (!(x == column && y == row) && grid[y][x])
								{
									litNeighbors++;
								}
							}
						}

						if (grid[row][column])
						{
							newRow.Add(litNeighbors == 2 || litNeighbors == 3);
						}
						else
						{
							newRow.Add(litNeighbors == 3);
						}
					}

					newGrid.Add(newRow);
				}

				grid = newGrid;
			}

			Console.WriteLine(grid.Select(x => x.Where(y => y == true).Count()).Sum());
		}

		public static void PartTwo()
		{
			var lines = Utils.GetLinesForDay(18);
			List<List<bool>> grid = new List<List<bool>>(lines.Select(x => ConvertLineToList(x)));

			grid[0][0] = true;
			grid[0][grid[0].Count() - 1] = true;
			grid[grid.Count() - 1][0] = true;
			grid[grid.Count() - 1][grid[0].Count() - 1] = true;
			
			for (int i = 0; i < 100; i++)
			{
				List<List<bool>> newGrid = new List<List<bool>>();

				for (int row = 0; row < grid.Count(); row++)
				{
					List<bool> newRow = new List<bool>();

					for (int column = 0; column < grid[row].Count(); column++)
					{
						if ((row == 0 || row == grid.Count() - 1) && (column == 0 || column == grid[row].Count() - 1))
						{
							newRow.Add(true);
							continue;
						}

						int litNeighbors = 0;

						for (int y = Math.Max(row - 1, 0); y <= Math.Min(row + 1, grid.Count() - 1); y++)
						{
							for (int x = Math.Max(column - 1, 0); x <= Math.Min(column + 1, grid[y].Count() - 1); x++)
							{
								if (!(x == column && y == row) && grid[y][x])
								{
									litNeighbors++;
								}
							}
						}

						if (grid[row][column])
						{
							newRow.Add(litNeighbors == 2 || litNeighbors == 3);
						}
						else
						{
							newRow.Add(litNeighbors == 3);
						}
					}

					newGrid.Add(newRow);
				}

				grid = newGrid;
			}

			Console.WriteLine(grid.Select(x => x.Where(y => y == true).Count()).Sum());
		}
	}
}
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	enum CommandType
	{
		TurnOn,
		TurnOff,
		Toggle
	}

	struct Command
	{
		public CommandType command {get;set;}
		public int startRow {get;}
		public int startColumn {get;}
		public int endRow {get;}
		public int endColumn {get;}

		public Command(CommandType commandParam, int startRowParam, int startColumnParam, int endRowParam, int endColumnParam)
		{
			command = commandParam;
			startRow = startRowParam;
			startColumn = startColumnParam;
			endRow = endRowParam;
			endColumn = endColumnParam;
		}
	}

	class DaySix
	{
		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(6);

			IEnumerable<Command> commands = lines.Select(x =>
			{
				CommandType commandType;
				int startRow;
				int endRow;
				int startColumn;
				int endColumn;
				string[] words = x.Split(" ");

				if (words[0] == "turn")
				{
					if (words[1] == "off")
					{
						commandType = CommandType.TurnOff;
					}
					else
					{
						commandType = CommandType.TurnOn;
					}

					string[] start = words[2].Split(",");
					startRow = Convert.ToInt32(start[0]);
					startColumn = Convert.ToInt32(start[1]);

					string[] end = words[4].Split(",");
					endRow = Convert.ToInt32(end[0]);
					endColumn = Convert.ToInt32(end[1]);
				}
				else
				{
					commandType = CommandType.Toggle;
					string[] start = words[1].Split(",");
					startRow = Convert.ToInt32(start[0]);
					startColumn = Convert.ToInt32(start[1]);

					string[] end = words[3].Split(",");
					endRow = Convert.ToInt32(end[0]);
					endColumn = Convert.ToInt32(end[1]);
				}

				return new Command(commandType, startRow, startColumn, endRow, endColumn);
			});

			List<List<bool>> grid = new List<List<bool>>();
			for (int i = 0; i < 1000; i++)
			{
				grid.Add(new List<bool>(new bool[1000]));
			}

			foreach (Command command in commands)
			{
				for(int i = command.startRow; i <= command.endRow; i++)
				{
					for (int j = command.startColumn; j <= command.endColumn; j++)
					{
						switch (command.command)
						{
							case CommandType.TurnOn:
								grid[i][j] = true;
								break;
							case CommandType.TurnOff:
								grid[i][j] = false;
								break;
							case CommandType.Toggle:
								grid[i][j] = !grid[i][j];
								break;
						}
					}
				}
			}

			Console.WriteLine(grid.Select(x => x.Where(y => y == true).Count()).Sum());
		}

		public static void PartTwo()
		{
			var lines = Utils.GetLinesForDay(6);

			IEnumerable<Command> commands = lines.Select(x =>
			{
				CommandType commandType;
				int startRow;
				int endRow;
				int startColumn;
				int endColumn;
				string[] words = x.Split(" ");

				if (words[0] == "turn")
				{
					if (words[1] == "off")
					{
						commandType = CommandType.TurnOff;
					}
					else
					{
						commandType = CommandType.TurnOn;
					}

					string[] start = words[2].Split(",");
					startRow = Convert.ToInt32(start[0]);
					startColumn = Convert.ToInt32(start[1]);

					string[] end = words[4].Split(",");
					endRow = Convert.ToInt32(end[0]);
					endColumn = Convert.ToInt32(end[1]);
				}
				else
				{
					commandType = CommandType.Toggle;
					string[] start = words[1].Split(",");
					startRow = Convert.ToInt32(start[0]);
					startColumn = Convert.ToInt32(start[1]);

					string[] end = words[3].Split(",");
					endRow = Convert.ToInt32(end[0]);
					endColumn = Convert.ToInt32(end[1]);
				}

				return new Command(commandType, startRow, startColumn, endRow, endColumn);
			});

			List<List<int>> grid = new List<List<int>>();
			for (int i = 0; i < 1000; i++)
			{
				grid.Add(new List<int>(new int[1000]));
			}

			foreach (Command command in commands)
			{
				for(int i = command.startRow; i <= command.endRow; i++)
				{
					for (int j = command.startColumn; j <= command.endColumn; j++)
					{
						switch (command.command)
						{
							case CommandType.TurnOn:
								grid[i][j] += 1;
								break;
							case CommandType.TurnOff:
								if (grid[i][j] > 0)
									grid[i][j] -= 1;
								break;
							case CommandType.Toggle:
								grid[i][j] += 2;
								break;
						}
					}
				}
			}

			Console.WriteLine(grid.Select(x => x.Sum()).Sum());
		}
	}
}
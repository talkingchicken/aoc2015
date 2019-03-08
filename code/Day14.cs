using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayFourteen
	{
		class Reindeer
		{
			public int speed {get;}
			public int time {get;}
			public int rest {get;}
			private bool resting {get; set;}
			public int distance {get; private set;}
			public int points { get; set; }
			private int countdown {get; set;}
			public void Advance()
			{
				if (!resting)
				{
					distance += speed;
				}
				countdown--;
				if (countdown == 0)
				{
					resting = !resting;

					if (resting)
					{
						countdown = rest;
					}
					else
					{
						countdown = time;
					}
				}
			}

			public Reindeer(int speedParam, int timeParam, int restParam)
			{
				speed = speedParam;
				time = timeParam;
				rest = restParam;
				resting = false;
				countdown = time;
				distance = 0;
				points = 0;
			}
		}
		public static void PartOne()
		{
			int duration = 2503;
			var lines = Utils.GetLinesForDay(14);

			IEnumerable<Reindeer> reindeerList = lines.Select(x =>
			{
				string[] splitLine = x.Split(" ");

				int speed = Convert.ToInt32(splitLine[3]);
				int time = Convert.ToInt32(splitLine[6]);
				int rest = Convert.ToInt32(splitLine[13]);

				return new Reindeer(speed, time, rest);
			});

			IEnumerable<int> distances = reindeerList.Select(x => CalculateDistance(x, duration));

			Console.WriteLine(distances.Max());
		}

		private static int CalculateDistance(Reindeer reindeer, int duration)
		{
			int totalTime = 0;
			int totalDistance = 0;
			while (totalTime < duration)
			{
				if ((duration - totalTime) < reindeer.time)
				{
					totalDistance += reindeer.speed * (duration - totalTime);
					return totalDistance;
				}
				else
				{
					totalDistance += reindeer.speed * reindeer.time;
					totalTime += reindeer.time;
				}

				totalTime += reindeer.rest;
			}

			return totalDistance;
		}

		public static void PartTwo()
		{
			int duration = 2503;
			var lines = Utils.GetLinesForDay(14);

			List<Reindeer> reindeerList = new List<Reindeer>(lines.Select(x =>
			{
				string[] splitLine = x.Split(" ");

				int speed = Convert.ToInt32(splitLine[3]);
				int time = Convert.ToInt32(splitLine[6]);
				int rest = Convert.ToInt32(splitLine[13]);

				return new Reindeer(speed, time, rest);
			}));

			for (int timer = 0; timer < duration; timer++)
			{
				int maxValue = -1;
				foreach (Reindeer reindeer in reindeerList)
				{
					reindeer.Advance();
					maxValue = Math.Max(reindeer.distance, maxValue);
				}

				foreach (Reindeer reindeer in reindeerList)
				{
					if (reindeer.distance == maxValue)
						reindeer.points += 1;
				}
			}

			Console.WriteLine(reindeerList.Select(x => x.points).Max());
		}
	}
}
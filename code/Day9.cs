using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayNine
	{
		private static void AddPath(Dictionary<string, Dictionary<string, int>> graph, string source, string dest, int distance)
		{
			if (!graph.ContainsKey(source))
				graph[source] = new Dictionary<string, int>();
			
			if (!graph.ContainsKey(dest))
				graph[dest] = new Dictionary<string, int>();

			graph[source][dest] = distance;
			graph[dest][source] = distance;
		}

		private static int FindShortestPath(Dictionary<string, Dictionary<string, int>> graph, List<string> currentPath)
		{
			if (currentPath.Count == graph.Count)
			{
				int total = 0;
				for (int i = 0; i < currentPath.Count - 1; i++)
				{
					total += graph[currentPath[i]][currentPath[i+1]];
				}
				return total;
			}

			int minTotal = int.MaxValue;

			foreach(string location in graph.Keys)
			{
				if (currentPath.Contains(location))
				{
					continue;
				}

				currentPath.Add(location);
				minTotal = Math.Min(minTotal, FindShortestPath(graph, currentPath));
				currentPath.RemoveAt(currentPath.Count - 1);
			}

			return minTotal;
		}

		private static int FindLongestPath(Dictionary<string, Dictionary<string, int>> graph, List<string> currentPath)
		{
			if (currentPath.Count == graph.Count)
			{
				int total = 0;
				for (int i = 0; i < currentPath.Count - 1; i++)
				{
					total += graph[currentPath[i]][currentPath[i+1]];
				}
				return total;
			}

			int maxTotal = 0;

			foreach(string location in graph.Keys)
			{
				if (currentPath.Contains(location))
				{
					continue;
				}

				currentPath.Add(location);
				maxTotal = Math.Max(maxTotal, FindLongestPath(graph, currentPath));
				currentPath.RemoveAt(currentPath.Count - 1);
			}

			return maxTotal;
		}

		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(9);

			Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>();

			foreach (string line in lines)
			{
				string[] lineSplit = line.Split(" ");
				AddPath(graph, lineSplit[0], lineSplit[2], int.Parse(lineSplit[4]));
			}

			Console.WriteLine(FindShortestPath(graph, new List<string>()));
		}

		public static void PartTwo()
		{
			var lines = Utils.GetLinesForDay(9);

			Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>();

			foreach (string line in lines)
			{
				string[] lineSplit = line.Split(" ");
				AddPath(graph, lineSplit[0], lineSplit[2], int.Parse(lineSplit[4]));
			}

			Console.WriteLine(FindLongestPath(graph, new List<string>()));
		}
	}
}
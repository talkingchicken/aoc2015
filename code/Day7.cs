using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DaySeven
	{
		enum Operator
		{
			None,
			Store,
			And,
			Or,
			Not,
			Lshift,
			Rshift
		}
		class Connection
		{
			public string target {get;}
			public Operator operation {get;}
			public string value1 {get;}
			public string value2 {get;}

			public Connection(string targetParam, Operator operationParam, string value1Param, string value2Param)
			{
				target = targetParam;
				operation = operationParam;
				value1 = value1Param;
				value2 = value2Param;
			}

		}
		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(7);

			Dictionary<string, List<Connection>> connectionMap = new Dictionary<string, List<Connection>>();
			Dictionary<string, int> wireValues = new Dictionary<string, int>();

			foreach (string line in lines)
			{
				string[] firstSplit = line.Split(" -> ");
				string target = firstSplit[1];

				string[] inputSplit = firstSplit[0].Split(" ");

				Operator operation = Operator.None;
				string firstParam = "";
				string secondParam = "";

				if (inputSplit.Count() == 3)
				{
					switch (inputSplit[1])
					{
						case "AND":
							operation = Operator.And;
							break;
						case "OR":
							operation = Operator.Or;
							break;
						case "LSHIFT":
							operation = Operator.Lshift;
							break;
						case "RSHIFT":
							operation = Operator.Rshift;
							break;
					}

					firstParam = inputSplit[0];
					secondParam = inputSplit[2];
				}
				else if (inputSplit.Count() == 2)
				{
					operation = Operator.Not;
					firstParam = inputSplit[1];
				}
				else
				{
					operation = Operator.Store;
					firstParam = inputSplit[0];
				}

				Connection connection = new Connection(target, operation, firstParam, secondParam);

				if (operation == Operator.Store)
				{
					if (!String.IsNullOrEmpty(firstParam))
					{
						if (!int.TryParse(firstParam, out int x))
						{
							TryCreateList(connectionMap, firstParam);
							connectionMap[firstParam].Add(connection);
						}
						else
						{
							TryCreateList(connectionMap, "setter");
							connectionMap["setter"].Add(connection);
						}
					}
				}
				else
				{
					if (!String.IsNullOrEmpty(firstParam) && !int.TryParse(firstParam, out int x))
					{
						TryCreateList(connectionMap, firstParam);
						connectionMap[firstParam].Add(connection);
					}

					if (!String.IsNullOrEmpty(secondParam) && !int.TryParse(secondParam, out int y))
					{
						TryCreateList(connectionMap, secondParam);
						connectionMap[secondParam].Add(connection);
					}
				}
			}

			RunCircuit(connectionMap, wireValues);

			Console.WriteLine(wireValues["a"]);
		}
		public static void PartTwo()
		{
			var lines = Utils.GetLinesForDay(7);

			Dictionary<string, List<Connection>> connectionMap = new Dictionary<string, List<Connection>>();
			Dictionary<string, int> wireValues = new Dictionary<string, int>();

			foreach (string line in lines)
			{
				string[] firstSplit = line.Split(" -> ");
				string target = firstSplit[1];

				string[] inputSplit = firstSplit[0].Split(" ");

				Operator operation = Operator.None;
				string firstParam = "";
				string secondParam = "";

				if (inputSplit.Count() == 3)
				{
					switch (inputSplit[1])
					{
						case "AND":
							operation = Operator.And;
							break;
						case "OR":
							operation = Operator.Or;
							break;
						case "LSHIFT":
							operation = Operator.Lshift;
							break;
						case "RSHIFT":
							operation = Operator.Rshift;
							break;
					}

					firstParam = inputSplit[0];
					secondParam = inputSplit[2];
				}
				else if (inputSplit.Count() == 2)
				{
					operation = Operator.Not;
					firstParam = inputSplit[1];
				}
				else
				{
					operation = Operator.Store;
					firstParam = inputSplit[0];
				}

				Connection connection = new Connection(target, operation, firstParam, secondParam);

				if (operation == Operator.Store)
				{
					if (!String.IsNullOrEmpty(firstParam))
					{
						if (!int.TryParse(firstParam, out int x))
						{
							TryCreateList(connectionMap, firstParam);
							connectionMap[firstParam].Add(connection);
						}
						else
						{
							TryCreateList(connectionMap, "setter");
							connectionMap["setter"].Add(connection);
						}
					}
				}
				else
				{
					if (!String.IsNullOrEmpty(firstParam) && !int.TryParse(firstParam, out int x))
					{
						TryCreateList(connectionMap, firstParam);
						connectionMap[firstParam].Add(connection);
					}

					if (!String.IsNullOrEmpty(secondParam) && !int.TryParse(secondParam, out int y))
					{
						TryCreateList(connectionMap, secondParam);
						connectionMap[secondParam].Add(connection);
					}
				}
			}

			wireValues["b"] = 956;
			RunCircuit(connectionMap, wireValues);

			Console.WriteLine(wireValues["a"]);
		}

		private static void TryCreateList(Dictionary<string, List<Connection>> connectionMap, string key)
		{
			if (!connectionMap.ContainsKey(key))
			{
				connectionMap[key] = new List<Connection>();
			}
		}

		private static void RunCircuit(Dictionary<string, List<Connection>> connectionMap, Dictionary<string, int> wireValues)
		{
			Queue<Connection> connections = new Queue<Connection>();
			foreach (Connection connection in connectionMap["setter"])
			{
				connections.Enqueue(connection);
			}

			while (connections.Count > 0)
			{
				Connection currentConnection = connections.Dequeue();

				RunGate(currentConnection, wireValues);

				if (connectionMap.ContainsKey(currentConnection.target))
				{
					foreach (Connection connection in connectionMap[currentConnection.target])
					{
						if (!wireValues.ContainsKey(connection.target))
							connections.Enqueue(connection);
					}
				}
			}
		}

		private static void RunGate(Connection connection, Dictionary<string, int> wireValues)
		{
			if (wireValues.ContainsKey(connection.target))
				return;

			switch (connection.operation)
			{
				case Operator.Store:
				{
					int firstValue;

					if (!int.TryParse(connection.value1, out firstValue) && !wireValues.TryGetValue(connection.value1, out firstValue))
					{
						return;
					}

					wireValues[connection.target] = firstValue;
					break;
				}
				case Operator.Not:
				{
					int firstValue;

					if (!int.TryParse(connection.value1, out firstValue) && !wireValues.TryGetValue(connection.value1, out firstValue))
					{
						return;
					}

					wireValues[connection.target] = ~firstValue;
					break;
				}
				case Operator.And:
				{
					int firstValue;
					int secondValue;

					if (!int.TryParse(connection.value1, out firstValue) && !wireValues.TryGetValue(connection.value1, out firstValue))
					{
						return;
					}

					if (!int.TryParse(connection.value2, out secondValue) && !wireValues.TryGetValue(connection.value2, out secondValue))
					{
						return;
					}

					wireValues[connection.target] = firstValue & secondValue;
					break;
				}
				case Operator.Or:
				{
					int firstValue;
					int secondValue;

					if (!int.TryParse(connection.value1, out firstValue) && !wireValues.TryGetValue(connection.value1, out firstValue))
					{
						return;
					}

					if (!int.TryParse(connection.value2, out secondValue) && !wireValues.TryGetValue(connection.value2, out secondValue))
					{
						return;
					}

					wireValues[connection.target] = firstValue | secondValue;
					break;
				}

				case Operator.Lshift:
				{
					int firstValue;
					int secondValue;

					if (!int.TryParse(connection.value1, out firstValue) && !wireValues.TryGetValue(connection.value1, out firstValue))
					{
						return;
					}

					if (!int.TryParse(connection.value2, out secondValue) && !wireValues.TryGetValue(connection.value2, out secondValue))
					{
						return;
					}

					wireValues[connection.target] = firstValue << secondValue;
					break;
				}

				case Operator.Rshift:
				{
					int firstValue;
					int secondValue;

					if (!int.TryParse(connection.value1, out firstValue) && !wireValues.TryGetValue(connection.value1, out firstValue))
					{
						return;
					}

					if (!int.TryParse(connection.value2, out secondValue) && !wireValues.TryGetValue(connection.value2, out secondValue))
					{
						return;
					}

					wireValues[connection.target] = firstValue >> secondValue;
					break;
				}
			}
		}

	}
}
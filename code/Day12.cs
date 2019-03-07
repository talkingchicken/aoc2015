using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;

namespace AdventOfCode
{
	class DayTwelve
	{
		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(12);
			string line = lines.ElementAt(0);

			StringBuilder parsedLine = new StringBuilder();
			for (int i = 0; i < line.Count(); i++)
			{
				if (line[i] == '-' || (line[i] >= '0' && line[i] <='9'))
				{
					parsedLine.Append(line[i]);
				}
				else
				{
					parsedLine.Append(' ');
				}
			}

			string[] numbers = parsedLine.ToString().Split(" ");

			int total = 0;
			foreach (string number in numbers)
			{
				if (!string.IsNullOrEmpty(number))
					total += Convert.ToInt32(number);
			}

			Console.WriteLine(total);
		}

		public static void PartTwo()
		{
			string line = Utils.GetLinesForDay(12).ElementAt(0);

			var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(line), new System.Xml.XmlDictionaryReaderQuotas());

			var root = XElement.Load(jsonReader);

			int total  = ParseJsonTreeForTotal(root, "red");

			Console.WriteLine(total);
		}

		private static int ParseJsonTreeForTotal(XElement element, string ignoreWord)
		{
			if (element.FirstAttribute.Value == "number")
			{
				return (Convert.ToInt32(element.Value));
			}

			int total = 0;

			foreach(XElement child in element.Elements())
			{
				if (element.FirstAttribute.Value == "object" && child.FirstAttribute.Value == "string" && child.Value == ignoreWord)
				{
					return 0;
				}

				total += ParseJsonTreeForTotal(child, ignoreWord);
			}
			return total;
		}
	}
}
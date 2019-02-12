using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class Utils
	{
		public static IEnumerable<string> GetLinesFromFile(string filename)
		{
			string line;
			using (var reader = File.OpenText(filename))
			{
				while ((line = reader.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}
	}
}
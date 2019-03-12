using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DayFifteen
	{
		class Ingredient
		{
			public string name {get;}
			public int capacity {get;}
			public int durability {get;}
			public int flavor {get;}
			public int texture {get;}
			public int calories {get;}
			public Ingredient(string nameParam, int capacityParam, int durabilityParam, int flavorParam, int textureParam, int calorieParam)
			{
				name = nameParam;
				capacity = capacityParam;
				durability = durabilityParam;
				flavor = flavorParam;
				texture = textureParam;
				calories = calorieParam;
			}
		}
		private static Ingredient ParseIngredientLine(string line)
		{
			string[] splitLine = line.Split(" ");
			string name = Utils.RemoveLastChar(splitLine[0]);
			int capacity = int.Parse(Utils.RemoveLastChar(splitLine[2]));
			int durability = int.Parse(Utils.RemoveLastChar(splitLine[4]));
			int flavor = int.Parse(Utils.RemoveLastChar(splitLine[6]));
			int texture = int.Parse(Utils.RemoveLastChar(splitLine[8]));
			int calories = int.Parse(splitLine[10]);

			return new Ingredient(name, capacity, durability, flavor, texture, calories);
		}

		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(15);
			var ingredientList = new List<Ingredient>(lines.Select(x => ParseIngredientLine(x)));

			List<int> ingredientTotals = new List<int>(new int[ingredientList.Count()]);

			Console.WriteLine(FindMaxScore(ingredientList, ingredientTotals, 0, -1));
		}

		private static int FindMaxScore(IEnumerable<Ingredient> ingredientList, List<int> ingredientTotals, int index, int calorieCount)
		{
			int total = ingredientTotals.Take(index).Sum();
			int maxScore = 0;
			if (index == ingredientTotals.Count() - 1)
			{
				int totalCapacity = 0;
				int totalDurability = 0;
				int totalFlavor = 0;
				int totalTexture = 0;
				int totalCalories = 0;
				ingredientTotals[ingredientTotals.Count() - 1] = 100 - total;

				for (int i = 0; i < ingredientList.Count(); i++)
				{
					totalCapacity += ingredientList.ElementAt(i).capacity * ingredientTotals[i];
					totalDurability += ingredientList.ElementAt(i).durability * ingredientTotals[i];
					totalFlavor += ingredientList.ElementAt(i).flavor * ingredientTotals[i];
					totalTexture += ingredientList.ElementAt(i).texture * ingredientTotals[i];
					totalCalories += ingredientList.ElementAt(i).calories * ingredientTotals[i];
				}

				if (calorieCount >= 0 && totalCalories != calorieCount)
				{
					return 0;
				}

				if (totalCapacity <= 0 || totalDurability <= 0 || totalFlavor <= 0 || totalTexture <= 0)
				{
					return 0;
				}

				return totalCapacity * totalDurability * totalFlavor * totalTexture;
			}

			for (int i = 0; i <= 100 - total; i++)
			{
				ingredientTotals[index] = i;
				maxScore = Math.Max(maxScore, FindMaxScore(ingredientList, ingredientTotals, index + 1, calorieCount));
			}

			return maxScore;
		}

		public static void PartTwo()
		{
			var lines = Utils.GetLinesForDay(15);
			var ingredientList = new List<Ingredient>(lines.Select(x => ParseIngredientLine(x)));

			List<int> ingredientTotals = new List<int>(new int[ingredientList.Count()]);

			Console.WriteLine(FindMaxScore(ingredientList, ingredientTotals, 0, 500));
		}
	}
}
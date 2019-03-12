using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	class DaySixteen
	{
		class AuntSue
		{
			public int id {get;}
			public int? children {get;}
			public int? cats {get;}
			public int? samoyeds {get;}
			public int? pomeranians {get;}
			public int? akitas {get;}
			public int? vizslas {get;}
			public int? goldfish {get;}
			public int? trees {get;}
			public int? cars {get;}
			public int? perfumes {get;}

			public AuntSue(
				int idParam,
				int? childrenParam,
				int? catsParam,
				int? samoyedsParam,
				int? pomeraniansParam,
				int? akitasParam,
				int? vizslasParam,
				int? goldfishParam,
				int? treesParam,
				int? carsParam,
				int? perfumesParam)
			{
				id = idParam;
				children = childrenParam;
				cats = catsParam;
				samoyeds = samoyedsParam;
				pomeranians = pomeraniansParam;
				akitas = akitasParam;
				vizslas = vizslasParam;
				goldfish = goldfishParam;
				trees = treesParam;
				cars = carsParam;
				perfumes = perfumesParam;
			}
		}
		private static AuntSue ParseAuntSue(string line)
		{
			string[] splitLine = line.Split(" ");

			int id = int.Parse(Utils.RemoveLastChar(splitLine[1]));
			int? children = null;
			int? cats = null;
			int? samoyeds = null;
			int? pomeranians = null;
			int? akitas = null;
			int? vizslas = null;
			int? goldfish = null;
			int? trees = null;
			int? cars = null;
			int? perfumes = null;

			for (int i = 2; i < splitLine.Count(); i += 2)
			{
				int number = int.Parse((i != splitLine.Count() - 2) ? Utils.RemoveLastChar(splitLine[i + 1]) : splitLine[i + 1]);
				switch (splitLine[i])
				{
					case "children:":
						children = number;
						break;
					case "cats:":
						cats = number;
						break;
					case "samoyeds:":
						samoyeds = number;
						break;
					case "pomeranians:":
						pomeranians = number;
						break;
					case "akitas:":
						akitas = number;
						break;
					case "vizslas:":
						vizslas = number;
						break;
					case "goldfish:":
						goldfish = number;
						break;
					case "trees:":
						trees = number;
						break;
					case "cars:":
						cars = number;
						break;
					case "perfumes:":
						perfumes = number;
						break;
					default:
						throw new Exception("Bad parameter");

				}
			}

			return new AuntSue(id, children, cats, samoyeds, pomeranians, akitas, vizslas, goldfish, trees, cars, perfumes);

		}

		public static void PartOne()
		{
			var lines = Utils.GetLinesForDay(16);

			int targetChildren = 3;
			int targetCats = 7;
			int targetSamoyeds = 2;
			int targetPomeranians = 3;
			int targetAkitas = 0;
			int targetVizslas = 0;
			int targetGoldfish = 5;
			int targetTrees = 3;
			int targetCars = 2;
			int targetPerfumes = 1;

			List<AuntSue> auntSues = new List<AuntSue>(lines.Select(x => ParseAuntSue(x)));

			foreach (AuntSue auntSue in auntSues)
			{
				if (auntSue.children.HasValue && auntSue.children != targetChildren)
					continue;

				if (auntSue.cats.HasValue && auntSue.cats != targetCats)
					continue;
				
				if (auntSue.samoyeds.HasValue && auntSue.samoyeds != targetSamoyeds)
					continue;
				
				if (auntSue.pomeranians.HasValue && auntSue.pomeranians != targetPomeranians)
					continue;
				
				if (auntSue.akitas.HasValue && auntSue.akitas != targetAkitas)
					continue;
				
				if (auntSue.vizslas.HasValue && auntSue.vizslas != targetVizslas)
					continue;
				
				if (auntSue.goldfish.HasValue && auntSue.goldfish != targetGoldfish)
					continue;
				
				if (auntSue.trees.HasValue && auntSue.trees != targetTrees)
					continue;
				
				if (auntSue.cars.HasValue && auntSue.cars != targetCars)
					continue;
				
				if (auntSue.perfumes.HasValue && auntSue.perfumes != targetPerfumes)
					continue;

				Console.WriteLine(auntSue.id);
			}
		}

		public static void PartTwo()
		{
			var lines = Utils.GetLinesForDay(16);

			int targetChildren = 3;
			int targetCats = 7;
			int targetSamoyeds = 2;
			int targetPomeranians = 3;
			int targetAkitas = 0;
			int targetVizslas = 0;
			int targetGoldfish = 5;
			int targetTrees = 3;
			int targetCars = 2;
			int targetPerfumes = 1;

			List<AuntSue> auntSues = new List<AuntSue>(lines.Select(x => ParseAuntSue(x)));

			foreach (AuntSue auntSue in auntSues)
			{
				if (auntSue.children.HasValue && auntSue.children != targetChildren)
					continue;

				if (auntSue.cats.HasValue && auntSue.cats <= targetCats)
					continue;
				
				if (auntSue.samoyeds.HasValue && auntSue.samoyeds != targetSamoyeds)
					continue;
				
				if (auntSue.pomeranians.HasValue && auntSue.pomeranians >= targetPomeranians)
					continue;
				
				if (auntSue.akitas.HasValue && auntSue.akitas != targetAkitas)
					continue;
				
				if (auntSue.vizslas.HasValue && auntSue.vizslas != targetVizslas)
					continue;
				
				if (auntSue.goldfish.HasValue && auntSue.goldfish >= targetGoldfish)
					continue;
				
				if (auntSue.trees.HasValue && auntSue.trees <= targetTrees)
					continue;
				
				if (auntSue.cars.HasValue && auntSue.cars != targetCars)
					continue;
				
				if (auntSue.perfumes.HasValue && auntSue.perfumes != targetPerfumes)
					continue;

				Console.WriteLine(auntSue.id);
			}
		}
	}
}
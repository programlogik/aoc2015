﻿using System;
using System.Linq;
using System.IO;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var sumWrapper = 0;
            var sumRibbon = 0;
            foreach (var line in File.ReadLines(@"../../../input.txt")) 
            {
                var parsed = ParseInputLine(line);
				sumWrapper += SqFeetWrapper(parsed);
                sumRibbon += RibbonLength(parsed);
			}

            Console.WriteLine("Pt1:" + sumWrapper);
            Console.WriteLine("Pt2:" + sumRibbon);
            Console.ReadLine();
        }

        static (int, int, int) ParseInputLine(string line)
        {
            var parts = line.Split(new[] { 'x' })
                            .Select(s => int.Parse(s))
                            .OrderBy(x => x)
                            .ToArray();
            if (parts.Length == 3)
                return (parts[0], parts[1], parts[2]);

            throw new ArgumentException("Invalid arg:" + line);
        }

        static int SqFeetWrapper((int, int, int) xs) 
        {
            return
                (2 * xs.Item1 * xs.Item2) +
                (2 * xs.Item1 * xs.Item3) +
                (2 * xs.Item2 * xs.Item3) +
                (xs.Item1 * xs.Item2);
        }

        static int RibbonLength((int, int, int) xs)
        {
            return 2 * xs.Item1 +
                         2 * xs.Item2 +
                         xs.Item1 * xs.Item2 * xs.Item3;
        }
    }
}

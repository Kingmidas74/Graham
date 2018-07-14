using System;
using System.Linq;
using GrahamAlg;

namespace GrahamConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToData = "./Data/input.txt";
            if (args.Length == 1)
            {
                pathToData = args[0];
            }
            var points = PointCreator.ReadPointsFromFile(pathToData).ToList();

            for (var i = 0; i < points.Count; i++)
            {
                Console.WriteLine($"{i}-{points[i].X};{points[i].Y}");
            }

            var GS = new GrahamScan(points);
            var res = GS.GetSortPoints().ToList();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Result:");
            for (var i = 0; i < res.Count; i++)
            {
                Console.WriteLine($"{i}-{res[i].X};{res[i].Y}");
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}

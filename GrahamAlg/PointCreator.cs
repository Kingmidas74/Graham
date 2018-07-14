using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrahamAlg
{
    public class PointCreator
    {
        public static IEnumerable<Point> ReadPointsFromFile(String filePath)
        {
            return File.ReadAllLines(filePath).Select(e => e.Split(';').Select(int.Parse)).Select(e => new Point { X = e.First(), Y = e.Last() }).ToList();
        }
    }
}

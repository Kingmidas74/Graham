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
            return File.ReadAllLines(filePath).Select(line => (Point)line).ToList();
        }
    }
}

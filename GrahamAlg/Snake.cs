using System.Collections.Generic;
using System.Linq;

namespace GrahamAlg
{
    public class Snake
    {
        public static IEnumerable<Point> Sort(IEnumerable<Point> points)
        {
            return points.OrderBy(p => p.X).ThenBy(p => p.Y);
        }
    }
}

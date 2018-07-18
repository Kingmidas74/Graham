using System.Collections.Generic;
using System.Linq;

namespace GrahamAlg
{
    public class Snake:ISortAlgorithms
    {
        private readonly IEnumerable<Point> _points;

        public Snake(IEnumerable<Point> points)
        {
            _points = points;
        }
        public IEnumerable<Point> GetSortPoints()
        {
            return _points.OrderBy(p => p.X).ThenBy(p => p.Y);
        }
    }
}

using System.Collections.Generic;

namespace GrahamAlg
{
    public class SortFactory
    {
        public ISortAlgorithms CreateEndruHandler(IEnumerable<Point> points)
        {
            return new Endru(points);
        }

        public ISortAlgorithms CreateGrahamHandler(IEnumerable<Point> points)
        {
            return new Graham(points);
        }

        public ISortAlgorithms CreateSnakeHandler(IEnumerable<Point> points)
        {
            return new Snake(points);
        }
    }
}

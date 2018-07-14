using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrahamAlg
{
    public class GrahamWithSpiral
    {
        private static bool AreClockWise(Point a, Point b, Point c)
        {
            return a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y) < 0;
        }

        private static bool AreCounterClockWise(Point a, Point b, Point c)
        {
            return a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y) > 0; ;
        }

        private static SpiralLevel Split(List<Point> source)
        {
            var copy = source.ToList();
            if (source.Count <= 1) return new SpiralLevel { Value = copy };
            copy.Sort();

            var p1 = copy.First();
            var p2 = copy.Last();
            var up = new List<Point>();
            var down = new List<Point>();
            up.Add(p1);
            down.Add(p1);
            for (var i = 1; i < copy.Count; ++i)
            {
                if (i + 1 == copy.Count || AreClockWise(p1, copy[i], p2))
                {
                    while (up.Count >= 2 && !AreClockWise(up[up.Count - 2], up[up.Count - 1], copy[i]))
                    {
                        up.RemoveAt(up.Count - 1);
                    }

                    up.Add(copy[i]);
                }

                if (i+1 == copy.Count || AreCounterClockWise(p1, copy[i], p2))
                {
                    while (down.Count >= 2 && !AreCounterClockWise(down[down.Count - 2], down[down.Count - 1], copy[i]))
                    {
                        down.RemoveAt(down.Count - 1);
                    }

                    down.Add(copy[i]);
                }
            }

            var reorder = new SpiralLevel { Value = new List<Point>() };
            reorder.Value.AddRange(up);
            for (var i = down.Count - 2; i > 0; --i)
            {
                reorder.Value.Add(down[i]);
            }

            HashSet<Point> used = new HashSet<Point>();
            reorder.Value.ForEach(d => used.Add(d));
            reorder.Next = Split(source.Where(d => !used.Contains(d)).ToList());

            return reorder;
        }

        public static List<Point> ReorderNoCrossing(List<Point> source)
        {

            var reordering = Split(source);
            return reordering.Merge();
        }
    }
}

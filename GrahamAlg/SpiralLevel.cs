using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrahamAlg
{
    class SpiralLevel
    {
        public List<Point> Value { get; set; }
        public SpiralLevel Next { get; set; }

        public List<Point> Merge()
        {
            var result = new List<Point>(Value);
            var current = Next;

            while (current != null && current.Value.Count > 0)
            {
                var last = result.Last();
                var dists = current.Value.Select(s => Math.Pow(s.X - last.X, 2) + Math.Pow(s.Y - last.Y, 2)).ToList();
                var minValue = dists.Min();
                var idx = dists.IndexOf(minValue);
                result.AddRange(current.Value.Skip(idx));
                result.AddRange(current.Value.Take(idx));
                current = current.Next;
            }

            return result;
        }
    }
}

using System;

namespace GrahamAlg
{
    public class Point : IComparable<Point>, IEquatable<Point>
    {
        public Int32 X { get; set; } = 0;
        public Int32 Y { get; set; } = 0;

        public static implicit operator Point(string value)
        {
            var values = value.Split(';');
            return new Point { X = Int32.Parse(values[0]), Y = Int32.Parse(values[1]) };
        }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(Point other)
        {
            var xComparison = X.CompareTo(other.X);
            return xComparison != 0 ? xComparison : Y.CompareTo(other.Y);
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Point d && Equals(d);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
       // public override bool Equals(object obj) => (obj is Point) && (obj as Point).X == X && (obj as Point).Y == Y;
    }
}

using System;

namespace GrahamAlg
{
    public class Point
    {
        public Int32 X { get; set; } = 0;
        public Int32 Y { get; set; } = 0;

        public static implicit operator Point(string value)
        {
            var values = value.Split(';');
            return new Point { X = Int32.Parse(values[0]), Y = Int32.Parse(values[1]) };
        }

        public override bool Equals(object obj) => (obj is Point) && (obj as Point).X == X && (obj as Point).Y == Y;
    }
}

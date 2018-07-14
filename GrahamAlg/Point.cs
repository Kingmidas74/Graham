using System;

namespace GrahamAlg
{
    public class Point
    {
        public Int32 X { get; set; } = 0;
        public Int32 Y { get; set; } = 0;

        public override bool Equals(object obj) => (obj is Point) && (obj as Point).X == X && (obj as Point).Y == Y;
    }
}

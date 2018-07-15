using System;
using System.Collections.Generic;
using System.Linq;
using GrahamAlg;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrahamAlgTest
{
    [TestClass]
    public class GrahamScanTest
    {
        private bool IsNext(Line A, Line B)
        {
            return A.End.Equals(B.Start) && !A.Start.Equals(B.End);
        }

        private bool IsNotCross(Line A, Line B)
        {
            var p1 = A.Start;
            var p2 = A.End;
            var p3 = B.Start;
            var p4 = B.End;
            if (p2.X < p1.X)
            {

                Point tmp = p1;
                p1 = p2;
                p2 = tmp;
            }

            if (p4.X < p3.X)
            {

                Point tmp = p3;
                p3 = p4;
                p4 = tmp;
            }
            if (p2.X < p1.X)
            {

                Point tmp = p1;
                p1 = p2;
                p2 = tmp;
            }

            if (p4.X < p3.X)
            {

                Point tmp = p3;
                p3 = p4;
                p4 = tmp;
            }
            if (p2.X < p3.X)
            {
                return false;
            }
            //если оба отрезка вертикальные
            if ((p1.X - p2.X == 0) && (p3.X - p4.X == 0))
            {

                //если они лежат на одном X
                if (p1.X == p3.X)
                {

                    //проверим пересекаются ли они, т.е. есть ли у них общий Y
                    //для этого возьмём отрицание от случая, когда они НЕ пересекаются
                    if (!((Math.Max(p1.Y, p2.Y) < Math.Min(p3.Y, p4.Y)) ||
                          (Math.Min(p1.Y, p2.Y) > Math.Max(p3.Y, p4.Y))))
                    {
                        return true;
                    }
                }

                return false;
            } else
            //если первый отрезок вертикальный
            if (p1.X - p2.X == 0)
            {

                //найдём Xa, Ya - точки пересечения двух прямых
                double Xa = p1.X;
                double A2 = (p3.X - p4.X) / (p3.X - p4.X);
                double b2 = p3.X - A2 * p3.X;
                double Ya = A2 * Xa + b2;

                if (p3.X <= Xa && p4.X >= Xa && Math.Min(p1.Y, p2.Y) <= Ya &&
                    Math.Max(p1.Y, p2.Y) >= Ya)
                {

                    return true;
                }

                return false;
            } else
            //если второй отрезок вертикальный
            if (p3.X - p4.X == 0)
            {

                //найдём Xa, Ya - точки пересечения двух прямых
                double Xa = p3.X;
                double A1 = (p1.Y - p2.Y) / (p1.Y - p2.Y);
                double b1 = p1.Y - A1 * p1.X;
                double Ya = A1 * Xa + b1;

                if (p1.X <= Xa && p2.X >= Xa && Math.Min(p3.Y, p4.Y) <= Ya &&
                    Math.Max(p3.Y, p4.Y) >= Ya)
                {

                    return true;
                }

                return false;
            }
            else
            {
                //оба отрезка невертикальные
                double A1 = (p1.Y - p2.Y) / (p1.X - p2.X);
                double A2 = (p3.Y - p4.Y) / (p3.X - p4.X);
                double b1 = p1.Y - A1 * p1.X;
                double b2 = p3.Y - A2 * p3.X;

                if (A1 == A2)
                {
                    return false; //отрезки параллельны
                }

                //Xa - абсцисса точки пересечения двух прямых
                double Xa = (b2 - b1) / (A1 - A2);

                if ((Xa < Math.Max(p1.X, p3.X)) || (Xa > Math.Min(p2.X, p4.X)))
                {
                    return false; //точка Xa находится вне пересечения проекций отрезков на ось X 
                }
                else
                {
                    return true;
                }
            }
        }

        [TestMethod]
        public void GetSortPointTest()
        {
            var points = new List<Point>()
            {
                new Point(100, 100),
                new Point(400, 100),
                new Point(100, 400),
                new Point(400, 400),
                new Point(200, 200)
            };
            var res = new GrahamScan(points).GetSortPoints().ToList();
            var lines = new List<Line>();
            for (int i = 0; i < res.Count-1; i++)
            {
                lines.Add(new Line
                {
                    Start = res[i],
                    End = res[i+1]
                });
            }

            for (int i = 0; i < lines.Count-1; i++)
            {
                var firstLine = lines[i];
                var isNext = IsNext(firstLine, lines[i + 1]);
                Assert.IsTrue(isNext);
                for (var j = i+2; j < lines.Count; j++)
                {
                    var notCrossing = IsNotCross(firstLine, lines[j]);
                    //Assert.IsTrue(notCrossing);
                }
            }

        }
    }
}

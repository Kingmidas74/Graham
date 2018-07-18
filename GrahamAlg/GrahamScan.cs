using System;
using System.Collections.Generic;
using System.Linq;

namespace GrahamAlg
{
    public class Graham:ISortAlgorithms
    {
        private readonly List<Point> _initialPoints;
        private readonly List<Int32> _pointsIndexes;

        public Graham(IEnumerable<Point> initialPoints)
        {
            _initialPoints = initialPoints.ToList();
            _pointsIndexes = Enumerable.Range(0, _initialPoints.Count).ToList();
        }

        private Boolean rotateAngle(Point A, Point B, Point C)
        {
            return (B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X) <= 0;
        }

        private void DefineStartPoint()
        {
            for (var i = 0; i < _pointsIndexes.Count; i++)
            {
                if (_initialPoints[_pointsIndexes[i]].X < _initialPoints[_pointsIndexes[0]].X)
                {
                    var temp = _pointsIndexes[0];
                    _pointsIndexes[0] = _pointsIndexes[i];
                    _pointsIndexes[i] = temp;
                }
            }
        }

        private void Sort()
        {
            for (var i = 2; i < _pointsIndexes.Count; i++)
            {
                var j = i;
                while (j > 1 && rotateAngle(_initialPoints[_pointsIndexes[0]], _initialPoints[_pointsIndexes[j - 1]],
                           _initialPoints[_pointsIndexes[j]]))
                {
                    var temp = _pointsIndexes[j - 1];
                    _pointsIndexes[j - 1] = _pointsIndexes[j];
                    _pointsIndexes[j] = temp;
                    j = -1;
                }
            }
        }


        /*
         * Из алгоритма был убран шаг построения выпуклого многогранника, т.к. необходимо задействовать все точки
         */
        public IEnumerable<Point> GetSortPoints()
        {
            if (_initialPoints.Count <= 2) return _initialPoints;

            DefineStartPoint();

            Sort();

            var resultPoints = new Stack<Point>();
            resultPoints.Push(_initialPoints[_pointsIndexes[0]]);
            resultPoints.Push(_initialPoints[_pointsIndexes[1]]);
            for (var i = 2; i < _pointsIndexes.Count; i++)
            {
                resultPoints.Push(_initialPoints[_pointsIndexes[i]]);
            }
            return resultPoints;
        }
    }
}

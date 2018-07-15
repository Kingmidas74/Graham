using System;
using GrahamAlg;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrahamAlgTest
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void CompareToTest()
        {
            var point1 = new Point(0, 2);
            var point2 = new Point(2,0);
            var result = point1.CompareTo(point2);
            Assert.AreNotEqual(0,result);
            Assert.IsFalse(result>0);
        }

        [TestMethod]
        public void EqualsTest()
        {
            var point1 = new Point(0, 2);
            var point2 = new Point(2, 0);
            var point3 = point1;
            var point4 = new Point(0,2);
            var result = point1.Equals(point2);
            Assert.IsFalse(result);
            Assert.IsTrue(point1.Equals(point3));
            Assert.IsTrue(point1.Equals(point4));
        }

        [TestMethod]
        public void InstanceTest()
        {
            var point1 = new Point(0, 2);
            Assert.IsInstanceOfType(point1,typeof(Point));
        }
    }
}

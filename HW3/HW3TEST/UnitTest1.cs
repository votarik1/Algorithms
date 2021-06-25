using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW3;

namespace HW3TEST
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestCalculateDistStructFloat()
        {

            BechmarkClass unit = new BechmarkClass();
            PointStructFloat PointA = new PointStructFloat(2.456f, 1.347f);
            PointStructFloat PointB = new PointStructFloat(4.729f, 9.997f);

            float expected = 8.943658f;
            float actual = unit.CalculateDistStructFloat(PointA, PointB);
            Assert.AreEqual(expected, actual, 0.000001, "В методе CalculateDistStructFloat ошибка");


        }
        [TestMethod]
        public void TestCalculateDistClassFloat()
        {
            BechmarkClass unit = new BechmarkClass();
            PointClassFloat PointA = new PointClassFloat(2.456f, 1.347f);
            PointClassFloat PointB = new PointClassFloat(4.729f, 9.997f);


            float expected = 8.943658f;
            float actual = unit.CalculateDistClassFloat(PointA, PointB);
            Assert.AreEqual(expected, actual, 0.000001, "В методе CalculateDistStructFloat ошибка");


        }
        [TestMethod]
        public void TestCalculateDistStructDoublet()
        {

            BechmarkClass unit = new BechmarkClass();
            PointStructDouble PointA = new PointStructDouble(2.456, 1.347);
            PointStructDouble PointB = new PointStructDouble(4.729, 9.997);
            

            double expected = 8.943658;
            double actual = unit.CalculateDistStructDouble(PointA, PointB);
            Assert.AreEqual(expected, actual, 0.000001, "В методе CalculateDistStructFloat ошибка");


        }
        [TestMethod]
        public void TestCalculateDistWithoutSqrt()
        {

            BechmarkClass unit = new BechmarkClass();
            PointStructFloat PointA = new PointStructFloat(2.456f, 1.347f);
            PointStructFloat PointB = new PointStructFloat(4.729f, 9.997f);
           

            float expected = 79.989029f;
            float actual = unit.CalculateDistWithoutSqrt(PointA, PointB);
            Assert.AreEqual(expected, actual, 0.00001, "В методе CalculateDistStructFloat ошибка");


        }
    }
}

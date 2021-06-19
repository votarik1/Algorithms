using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace HW3
{
    public class PointClassFloat
    {
        public float X { get; set; }
        public float Y { get; set; }

        public PointClassFloat(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    public struct PointStructFloat
    {
        public float X { get; set; }
        public float Y { get; set; }

        public PointStructFloat(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
       
    }

    public struct PointStructDouble
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointStructDouble(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();
        }
    }

    public class BechmarkClass
    {
        public float CalculateDistStructFloat(PointStructFloat A, PointStructFloat B)
        {
            float deltaX = A.X - B.X;
            float deltaY = A.Y - B.Y;
            return MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public float CalculateDistClassFloat(PointClassFloat A, PointClassFloat B)
        {
            float deltaX = A.X - B.X;
            float deltaY = A.Y - B.Y;
            return MathF.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
        public double CalculateDistStructDouble(PointStructDouble A, PointStructDouble B)
        {
            double deltaX = A.X - B.X;
            double deltaY = A.Y - B.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public float CalculateDistWithoutSqrt(PointStructFloat A, PointStructFloat B)
        {
            float deltaX = A.X - B.X;
            float deltaY = A.Y - B.Y;
            return deltaX * deltaX + deltaY * deltaY;
        }


        [Benchmark]
        public void TestCalculateDistStructFloat()
        {
            PointStructFloat PointA = new PointStructFloat(2.456f, 1.347f);
            PointStructFloat PointB = new PointStructFloat(4.729f, 9.997f);
            CalculateDistStructFloat(PointA, PointB);
        }

        [Benchmark]
        public void TestCalculateDistClassFloat()
        {
            PointClassFloat PointA = new PointClassFloat(2.456f, 1.347f);
            PointClassFloat PointB = new PointClassFloat(4.729f, 9.997f);
            CalculateDistClassFloat(PointA, PointB);
        }

        [Benchmark]
        public void TestCalculateDistStructDouble()
        {
            PointStructDouble PointA = new PointStructDouble(2.456, 1.347);
            PointStructDouble PointB = new PointStructDouble(4.729, 9.997);
            CalculateDistStructDouble(PointA, PointB);
        }


        [Benchmark]
        public void TestCalculateDistWithoutSqrt()
        {
            PointStructFloat PointA = new PointStructFloat(2.456f, 1.347f);
            PointStructFloat PointB = new PointStructFloat(4.729f, 9.997f);
            CalculateDistWithoutSqrt(PointA, PointB);
        }

    }
}
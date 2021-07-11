using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HW8;
namespace TestHW8
{
    [TestClass]
    public class UnitTest1
    {

        public int[] arr { get; set; }
        public UnitTest1()
        {
            arr = new int[100];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 100);
            }
        }
        [TestMethod]
        public void TestBucketSort1()
        {
            int[] sorted = MySorts.BucketSort(arr, 7);
            bool expected = true;
            bool received = sorted[45] <= sorted[46];
            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestBucketSort2()
        {
            int[] sorted = MySorts.BucketSort(arr, 7);
            int expected = 100;
            int received = sorted.Length;
            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestExternalSort1()
        {
            int[] sorted = MySorts.ExternalSort(arr, 7);
            bool expected = true;
            bool received = sorted[45] <= sorted[46];
            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void TestExternalSort2()
        {
            int[] sorted = MySorts.ExternalSort(arr, 7);
            int expected = 100;
            int received = sorted.Length;
            Assert.AreEqual(expected, received);
        }
        [TestMethod]
        public void CommonTest()
        {
            int[] sorted1 = MySorts.ExternalSort(arr, 3);
            int[] sorted = MySorts.BucketSort(arr, 24);
            bool expected = true;
            bool received = sorted[79] == sorted1[79];
            Assert.AreEqual(expected, received);
        }


    }
}

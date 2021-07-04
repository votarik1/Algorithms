using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HW4
{
    public class BenchmarkClass
    {
        private readonly HashSet<string> myHashSet = new HashSet<string>();
        private readonly string[] myArray = new string[10000];
        private readonly Random random = new Random();
        private string searchString;
        public BenchmarkClass()
    {
        searchString = random.Next().ToString();
        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = random.Next().ToString();
        }
        myHashSet = new HashSet<string>(myArray);

    }

    private bool ArraySearch()
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            if (searchString == myArray[i])
            {
                return true;
            }
        }
        return false;
    }

    private bool HashSetSearch()
    {
        if (myHashSet.Contains(searchString))
        {
            return true;
        }
        return false;
    }

    [Benchmark]
    public bool TestArraySearch()
    {
        return ArraySearch();
    }
    [Benchmark]
    public bool TestHashSetSearch()
    {
        return HashSetSearch();
    }

}




}

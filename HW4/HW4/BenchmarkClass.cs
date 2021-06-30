using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HW4
{
    public class BenchmarkClass
    {
        HashSet<string> myHashSet = new HashSet<string>();
        string[] myArray = new string[10000];
        Random random = new Random();
        string searchString;
        public BenchmarkClass()
    {
        searchString = random.Next().ToString();
        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = random.Next().ToString();
        }
        foreach (var item in myArray)
        {
            myHashSet.Add(item);
        }

    }

    int ArraySearch()
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            if (searchString == myArray[i])
            {
                return i;
            }
        }
        return -1;
    }

    string HashSetSearch()
    {
        if (myHashSet.Contains(searchString))
        {
            return searchString.GetHashCode().ToString();
        }
        return null;
    }

    [Benchmark]
    public void TestArraySearch()
    {
        ArraySearch();
    }
    [Benchmark]
    public void TestHashSetSearch()
    {
        HashSetSearch();
    }

}




}

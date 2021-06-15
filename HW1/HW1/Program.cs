using System;
using System.Collections.Generic;

namespace HW1
{
    class Program
    {
        public class TestCase
        {
            public int n { get; set; }
            public string Exepted { get; set; }
            public int ExeptedInt { get; set; }

            public static string Simple(int n)
            {
                int d = 0;
                int i = 2;
                while (i < n)
                {
                    if (n % i == 0)
                    {
                        d++;
                    }
                    i++;
                }

                if (d == 0)
                {
                    return ("Простое");
                }
                else
                {
                    return ("Не простое");
                }
            }

            public static int FibonacciFor(int n)
            {
                if (n < 1)
                {
                    throw new ArgumentOutOfRangeException("число должно быть натуральным", n);
                }
                if (n == 1)
                { return 0; }
                else
                {
                    int last = 0;
                    int output = 1;
                    for (int i = 2; i < n; i++)
                    {
                        int memory = output;
                        output = output + last;
                        last = memory;
                    }
                    return output;
                }
                //слжоность O(n)
            }

            public static int FibonacciRec(int n)
            {
                if (n < 1)
                {
                    throw new ArgumentOutOfRangeException("число должно быть неотрицательным", n);
                }
                if (n == 1)
                { return 0; }
                else if (n == 2)
                { return 1; }
                else
                {
                    return FibonacciRec(n - 2) + FibonacciRec(n - 1);
                }

                //Сложность O(2^n)

            }



        }
        static void TestSimple(TestCase testCase)
        {
            var actual = TestCase.Simple(testCase.n);
            if (actual == testCase.Exepted)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }

        }

        static void TestFibonacciFor(TestCase testCase)
        {
            var actual = TestCase.FibonacciFor(testCase.n);
            if (actual == testCase.ExeptedInt)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }

        static void TestFibonacciRec(TestCase testCase)
        {

            var actual = TestCase.FibonacciRec(testCase.n);
            if (actual == testCase.ExeptedInt)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }


        }

        static void Main(string[] args)
        {
            List<TestCase> Task1 = new List<TestCase>();
            Task1.Add(new TestCase()
            {
                n = 10,
                Exepted = "Не простое"
            });
            Task1.Add(new TestCase()
            {
                n = 17,
                Exepted = "Простое"
            });
            Task1.Add(new TestCase()
            {
                n = 1500,
                Exepted = "Не простое"
            });
            Task1.Add(new TestCase()
            {
                n = 3741,
                Exepted = "Простое"
            });
            Task1.Add(new TestCase()
            {
                n = 2803,
                Exepted = "Не простое"
            });
            foreach (var item in Task1)
            {
                TestSimple(item);
            }

            List<TestCase> Task2For = new List<TestCase>();
            Task2For.Add(new TestCase()
            {
                n = 5,
                ExeptedInt = 3
            });
            Task2For.Add(new TestCase()
            {
                n = 6,
                ExeptedInt = 5
            });
            Task2For.Add(new TestCase()
            {
                n = 7,
                ExeptedInt = 8
            });
            Task2For.Add(new TestCase()
            {
                n = 10,
                ExeptedInt = 13
            });
            Task2For.Add(new TestCase()
            {
                n = 20,
                ExeptedInt = 511
            });

            foreach (var item in Task2For)
            {
                TestFibonacciFor(item);
            }

            List<TestCase> Task2Rec = new List<TestCase>();
            Task2Rec.Add(new TestCase()
            {
                n = 5,
                ExeptedInt = 3
            });
            Task2Rec.Add(new TestCase()
            {
                n = 6,
                ExeptedInt = 5
            });
            Task2Rec.Add(new TestCase()
            {
                n = 7,
                ExeptedInt = 8
            });
            Task2Rec.Add(new TestCase()
            {
                n = 42,
                ExeptedInt = 13
            });
            Task2Rec.Add(new TestCase()
            {
                n = 43,
                ExeptedInt = 511
            });

            foreach (var item in Task2Rec)
            {
                TestFibonacciRec(item);
            }
        }



     


        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) //O(1+(n+1)+2n+(6n^2+5n+2)n) = O(8n^3+5n^2+5n+2)
            {
                for (int j = 0; j < inputArray.Length; j++)//O(1+(n+1)+2n+(2+8n)n) = O(8n^2+5n+2)
                {
                    for (int k = 0; k < inputArray.Length; k++)//O(1+(n+1)+2n+5n) = O(2+8n)
                    {
                        int y = 0; //1n

                        if (j != 0) //1n
                        {
                            y = k / j; // ??? не знаю как считать асимптотическую сложность от условного оператора... предполагаю 2n (деление + присвоение)
                        }

                        sum += inputArray[i] + i + k + j + y; //1n
                    }
                }
            }

            return sum;// O(1)
        }
        //Ответ: (8n^3+5n^2+5n+4)=O(n^3)





    }
}

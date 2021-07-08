using System;

namespace HW7
{
    class Program
    {
        static void Main(string[] args)
        {

            int m = 8; // ширина поля 
            int n = 8; // высота поля
            int[,] arr = new int[m, n];

            for (int i = 0; i < m; i++) // заполняем матрицу количества маршрутов
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0) // начальное поле
                    {
                        arr[i, j] = 1;
                        continue;
                    }
                    if (i != 0 && j != 0) // все остальные
                    {
                        arr[i, j] = arr[i, j - 1] + arr[i - 1, j];
                        continue;
                    }
                    else if (i == 0) // поля в 1 ряду
                    {
                        arr[i, j] = arr[i, j - 1];
                        continue;
                    }
                    else if (j == 0) // поля в 1 колонке
                    {
                        arr[i, j] = arr[i-1, j];
                        continue;
                    }
                }

            }            

            Console.WriteLine(arr[m-1,n-1]); // Ответ
            // Код очень простой. Не вижу смысла писать к нему  unit тесты. 
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HW8
{
    public class MySorts
    {


        static void AddAndSort(List<int> list, int value)
        {
            list.Add(value);
            int pos = 0;
            int lenth = list.Count;
            while (value >= list[pos] && pos < lenth - 1)
            {
                pos++;
            }
            if (pos == lenth - 1)
            {
                return;
            }
            for (int i = pos; i < lenth - 1; i++)
            {
                int memory = list[i];
                list[i] = list[lenth - 1];
                list[lenth - 1] = memory;
            }
        }

        static List<int>[] GetBuckets(int[] arr, int cof)
        {
            int min = arr[0];
            int max = arr[0];
            foreach (var item in arr)
            {
                if (item < min)
                {
                    min = item;
                }
                if (item > max)
                {
                    max = item;
                }

            }
            int NumberOfBukets = (max - min) / cof + 1;
            List<int>[] bukets = new List<int>[NumberOfBukets];
            for (int i = 0; i < bukets.Length; i++)
            {
                bukets[i] = new List<int>();
            }

            foreach (var item in arr)
            {
                int i = (item - min) / cof;
                AddAndSort(bukets[i], item);
            }
            return bukets;

        }

        static List<int> MergeTwoSortedLists(List<int> a, List<int> b)
        {
            int CurrentIndexList1 = 0;
            int CurrentIndexList2 = 0;
            List<int> list3 = new List<int>();
            while (list3.Count < a.Count + b.Count)
            {
                if (a[CurrentIndexList1] <= b[CurrentIndexList2])
                {
                    list3.Add(a[CurrentIndexList1]);
                    CurrentIndexList1++;
                    if (CurrentIndexList1 == a.Count)
                    {
                        for (int j = CurrentIndexList2; j < b.Count; j++)
                        {
                            list3.Add(b[j]);
                        }
                        return list3;
                    }
                }
                if (a[CurrentIndexList1] >= b[CurrentIndexList2])
                {
                    list3.Add(b[CurrentIndexList2]);
                    CurrentIndexList2++;
                    if (CurrentIndexList2 == b.Count)
                    {
                        for (int j = CurrentIndexList1; j < a.Count; j++)
                        {
                            list3.Add(a[j]);
                        }
                        return list3;
                    }
                }
            }
            return list3;
        }

        static void Serialize(string FileName, List<int> list)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                var formater = new BinaryFormatter();
                formater.Serialize(fs, list);
            }
        }
        static void Serialize(string FileName, int[] arr)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                var formater = new BinaryFormatter();
                formater.Serialize(fs, arr);
            }
        }
        static object Deserialize(string FileName)
        {
            using (FileStream fs = new FileStream(FileName, FileMode.Open))
            {
                var formater = new BinaryFormatter();
                return formater.Deserialize(fs);
            }
        }

        public static int[] BucketSort(int[] arr, int cof) // cof коэффициент дробления
        {
            if (arr == null || arr.Length < 2)
            {
                return arr;
            }
            List<int>[] bukets = GetBuckets(arr, cof);
            int[] ForReturn = new int[arr.Length];
            int counter = 0;
            foreach (var item in bukets)
            {
                foreach (var value in item)
                {
                    ForReturn[counter] = value;
                    counter++;
                }
            }
            return ForReturn;
        }


        
        public static int[] ExternalSort(int[] arr, int NumberOfParts) //Метод можно прервать в любой момент времени. При повторном вызове он начнёт с того места на котором его прервали.
        {
            if (arr == null || arr.Length < 2)
            {
                return arr;
            }
            int NumberOfElements = arr.Length / NumberOfParts;
            var status = new int[2]; // мини-массив контролирующий прогресс выполнения функции
            string FileStat = "status.bin";
            if (File.Exists(FileStat))
            {
                status = (int[])Deserialize(FileStat); // если функция была прервана по этому файлу востанавливается прогресс
            }
            else
            {
                status[0] = 0;
                status[1] = 0;
            }


            if (status[0] == 0) // дробим массив на произвольные части. Сортируем каждую часть и сохраняем в отдельный файл
            {
                for (int i = status[1]; i < NumberOfParts; i++)
                {
                    List<int> CurrentBlock = new List<int>();
                    int LeftBorder = status[1] * NumberOfElements;
                    int RighBorder;
                    if (i == NumberOfParts - 1)
                    {
                        RighBorder = arr.Length;
                    }
                    else                   
                    {
                        RighBorder = (status[1] + 1) * NumberOfElements;
                    }

                    for (int j = LeftBorder; j < RighBorder; j++)
                    {
                        AddAndSort(CurrentBlock, arr[j]);
                    }
                    Serialize($"{status[0]}_{status[1]}.bin", CurrentBlock);
                    status[1]++;
                    if (i == NumberOfParts - 1)
                    {
                        status[0]++;
                        status[1] = 0;
                    }
                    Serialize(FileStat, status);
                }

            }  // если функция была прервана по этому файлу востанавливается прогресс

            for (int i = 1; i < status[0]; i++) //для восстановления прогресса выполнения функции
            {
                NumberOfElements = NumberOfElements / 2;
            }

            while (NumberOfParts > 1) //суммируем по два-три файла пока не получим 1 итоговый файл с отсортированными элементами
            {
                for (int i = status[1] * 2; i < NumberOfParts - 1; i = i + 2)
                {
                    bool LonelyLastFile = false;
                    string file1 = $"{status[0] - 1}_{i}.bin";
                    string file2 = $"{status[0] - 1}_{i + 1}.bin";
                    List<int> list1 = new List<int>();
                    List<int> list2 = new List<int>();
                    list1 = (List<int>)Deserialize(file1);
                    list2 = (List<int>)Deserialize(file2);
                    var list3 = MergeTwoSortedLists(list1, list2);
                    if (i + 2 == NumberOfParts - 1)
                    {
                        LonelyLastFile = true;
                        string file4 = $"{status[0] - 1}_{i + 2}.bin";
                        List<int> list4 = new List<int>();
                        list4 = (List<int>)Deserialize(file4);
                        list3 = MergeTwoSortedLists(list3, list4);
                    }
                    Serialize($"{status[0]}_{status[1]}.bin", list3);
                    status[1]++;
                    Serialize(FileStat, status);
                    File.Delete(file1);
                    File.Delete(file2);
                    if (LonelyLastFile)
                    {
                        File.Delete($"{status[0] - 1}_{i + 2}.bin");
                    }
                }
                status[0]++;
                status[1] = 0;
                Serialize(FileStat, status);
                NumberOfParts = NumberOfParts / 2;
            }
            List<int> finishlist = new List<int>();
            string FileName = $"{status[0] - 1}_0.bin"; //итоговый файл
            finishlist = (List<int>)Deserialize(FileName);
            int[] ReturnArray = new int[finishlist.Count];
            for (int i = 0; i < finishlist.Count; i++)
            {
                ReturnArray[i] = finishlist[i];
            }
            File.Delete(FileStat); //удаляем оставшиеся файлы
            File.Delete(FileName); 
            return ReturnArray; 

        } 

    }
}

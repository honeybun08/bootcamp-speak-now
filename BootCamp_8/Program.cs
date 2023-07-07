// Quick sort (sergey)
//﻿using static Sorting;

//int size = 100;
//var arr = size.CreateArray()
//.Show()
//.SortQuick(0, size - 1)
//.Show()
//;


//public static class Sorting
//{
//public static int[] SortQuick(this int[] collection, int left, int right)
//{
// int i = left;
//int j = right;

//int pivot = collection[Random.Shared.Next(left, right)];
//while (i <= j)
//{
//while (collection[i] < pivot) i++;
//while (collection[j] > pivot) j--;

//if (i <= j)
//{
//int t = collection[i];
//collection[i] = collection[j];
//collection[j] = t;
//i++;
//j--;
//}
//}
//if (i < right) SortQuick(collection, i, right);
//if (left < j) SortQuick(collection, left, j);
//return collection;
//}
//}


// Seminar's explanation 
// Quick sorting on Python
//
// def quick_sort(arr);                                               - функция
//      if len(arr)<= 1;                                              "защита от дурака" 
//        return arr                                                  эти 3 строки явл.условием выхода из рекурсии(строки 50,51)
//      else;
//         pivot = arr[0]                                             - опорный элемент(первый)
//
//         left = [x for x in arr[1:] if x < pivot]                   - пробегись по коллекции array и каждую итерацию х будет равен след.элементу коллекции(1- т.к. первый элемен мы из левого массива уже просмотрели условно)
//         right = [x for x in arr[1:] if x >= pivot]                 - рекурсивный шаг
//
//         return quick_sort(left) + [pivot] + quick_sort(right)
//
//
// arr = [3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 ]
//
// sorted_arr = quick_sort(arr)
//
// print(sorted_arr)

// On C#

int[] QuickSort(int[] arr)
{
    if (arr.Length <= 1)
    {
        return arr;
    }

    else
    {
        int pivot = arr[0];
        int count_left = 0;
        int count_right = 0;
        for (int i = 1; i < arr.Length; i++)                                                                        // ображение к индексам элементов
        {
            if (arr[i] < pivot)
            {
                count_left++;                                                                                                        // подсчет кол-ва эл.для массивов left и right
            }
            else
            {
                count_right++;
            }
        }

        int[] left = new int[count_left];                                   // создаем массив левой и правой частей на нужное конкретное кол-во эл.
        int[] right = new int[count_right];
        
        int index_left = 0;
        int index_right = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < pivot)
            {
                left[index_left] = arr[i];
                index_left++;
            }
            else
            {
                right[index_right] = arr[i];
                index_right++;
            }
        }
        //int[] left = arr.Skip(1).Where(x => x < pivot).ToArray();                                                 // пропуск первого элемента в массиве
        //int[] right = arr.Skip(1).Where(x => x >= pivot).ToArray();                                          // второй знак-меньше или равно
        //int result_size = left.Length + 1 + right.Length;                                                                 // +1 - pivot
        //int [] result_arr = new int [result_size];

        //for (int i = 0; i < result_size; i++)
        //{
        //  result_arr[i] = 
        //}
        return QuickSort(left).Concat(new int[] { pivot }).Concat(QuickSort(right)).ToArray();                  // Concat значит "+", ToArray собирает все в один массив

    }
}

int[] arr = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
int[] arr_result = QuickSort(arr);

foreach (var item in arr_result)            // как в строках 50 и 51
{
    Console.Write($" {item} ");
}
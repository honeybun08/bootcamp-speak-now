// First Code, его сложность ПОЧЕМУ-ТО логарифмическая

//   // if n = 1(row of 1s), then it's done 1 TIME


//double s = 0;

//for (int n = 0; n < 15; n++)
//{
//int count = 0;
//int i = n;
//while (i > 0)
//{
//count++;
//s += i;
//i = i / 2;
//}
//System.Console.WriteLine($"n:{n}  count:{count}");  // для скольких n сколько раз выполняется код
//}

//2 вариант

//int n = Random.Shared.Next(1000000);

//double s = 0;

//int i = n;
//for (int j = 2; j < n / 2; j++)   // n/2 - 2
//{
//while (i > 0)
//{
////s += i;
//i = i / 2;   // log(n) + 1
//}
//}
// (n/2 - 2) * (log(n) + 1) = 
// 
// n/2*log(n) +  n/2  -2*log(n)  -2 =
// 1/2*log(n) + 1/2*n  -2*log(n) -2 =
// 

//Code 3 SelectionSort

///public static class Sorting
 ///{

    /// <summary>
    /// Сортировка методом выбора
    /// </summary>
    /// <param name="collection">Исходный массив</param>
    /// <returns>Отсортированный массив массив</returns>
    int[] SortSelection(int[] collection)
    {
        int size = collection.Length;
        for (int i = 0; i < size - 1; i++)        // доходим до предпоследнего, ведь он и так будет отсортирован(смысл в него упираться тогда!?)
        {
            int pos = i;
            for (int j = i + 1; j < size; j++)      // пробегаемся от след. до конца
            {
                if (collection[j] < collection[pos]) pos = j;    // нахождение мин.элемента в промежутке
            }
            int temp = collection[i];
            collection[i] = collection[pos];
            collection[pos] = temp;
        }
        return collection;
    }
///}

var arr = new int[] { 9, 6, 0, 5, 7, 3, 2, 1 };
System.Console.WriteLine(string.Join(' ', arr));
SortSelection(arr);
System.Console.WriteLine(string.Join(' ', arr));

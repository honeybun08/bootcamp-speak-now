//сортировка подсчетом

//int[] array = {0, 2, 3, 2, 1, 5, 9, 1, 1};
//CountingSort(array);
// Console.WriteLine(String.Join("," , array));

int[] array = { -10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1 };
int[] sortedArray = CountingSortExtended(array);
Console.WriteLine(string.Join(", ", sortedArray));



//void CountingSort(int[] inputArray)
// {
//      int[] counters = new int[10]; //массив повторений(вспомогательный)

//      for (int i = 0; i < inputArray.Length; i++) // идем по всему array
//      {
//          counters[inputArray[i]]++;
//          // int ourNumber = inputArray[i];  элемет,который просматриваем
//          // counters[ourNumber]++; в массиве counters по этому индексу увеличить значение на единицу
//      }

//     int index = 0;
//      // обход нашего массива
//      for (int i = 0; i < counters.Length; i++) // нужно ставить нужное число нужное кол-во раз в итоговый массив, обойдя весь массив
//      {
//        for (int j = 0; j < counters[i]; j++) // чтобы как раз ставить по числу повторений(повторяется столько раз, сколько повторов)
//          {
//              inputArray[index] = i;
//              index++;
//          }
//      }
//  }

int[] CountingSortExtended(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] sortedArray = new int[inputArray.Length];
    int[] counters = new int[max + offset + 1]; // получается новый нужный length

    Console.WriteLine($"Смещение равно  {max + offset + 1}");

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++; // чтобы сравнивать на пример не 0, а -10(чтобы не вылететь за предел массива)
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            sortedArray[index] = i - offset;  // от исходного индекса отнимаем offset и в итоговый массив пишем нужное число
            index++;
        }
    }

    return sortedArray;
}



// Сортировка подсчетом камянецкого

// public static class Sorting
// {
//   public static int[] SortCounting(this int[] collection)
//   {
//     int size = collection.Length;

//     int max = collection[0];
//     for (int i = 1; i < size; i++)
//       if (collection[i] > max) max = collection[i];

//     int[] counter = new int[max + 1];

//     for (int i = 0; i < size; i++)
//       counter[collection[i]]++;
//     Console.WriteLine($"counter = [{String.Join(' ', counter)}]");
//     int index = 0;
//     for (int i = 0; i < max + 1; i++)
//       for (int j = 0; j < counter[i]; j++)
//         collection[index++] = i;

//     return collection;
//   }
// }


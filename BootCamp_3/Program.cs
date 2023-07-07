// First Example of bubble sort and speed of it

//int n = 5;
//int [] array = new int[n];
// Пользовательское заполнение массива числами
//for (int i = 0; i < n; i++)
//array[i] = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("[" + string.Join(",", array) + "]");
//Console.WriteLine(array[3]);
//Сложность алгоритма О(1)(1 действие - строка выше)   (before the existence of n)

// [4, 5, 3, 1, 2]  сгенерированный массив размером n = 5
// Сколько операций, чтобы узнать СУММУ массива?
// O(n) - кол-во операций

// [1, 2, 3, 4, 5] - O(n * log2(n)) = быстрая сортировка
// ((5 + 1) / 2) * 5 =  O(1)
// n < n * log(n) + 1  = при использовании сложных алгоритмов может быть больше время выполнения
// В итоге алгоритм работает со скоростью 14 и 15 строчек односременно ВМЕСТЕ вместо О(n)

//int summa = 0;        // скорость О(n)
//for (int i = 0; i < n; i++)
//summa += array[i];
//Console.WriteLine(summa);

// Second Example  Таблица умножения
int n = Convert.ToInt32(Console.ReadLine());   // time of work - О(square n)
int[,] matrix = new int[n, n];
for (int i = 0; i < n; i++)
{
    for (int j = i; j < n; j++)
    {
        matrix[i, j] = (i + 1) * (j + 1);
        matrix[j, i] = (i + 1) * (j + 1);   // теперь алгоритм работает быстрее
    }
    Console.WriteLine();
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(matrix[i, j]);
        Console.Write(" ");
    }
    Console.WriteLine();
}

// Сокращение времени работы программы(убрать повторы, но сложность не меняется!)
﻿/*
1. Константные O(1)                         ввод значений, какие-то условия
2. Логарифмические O(log2(n))               бинарный поиск, обход деревьев, сортировка слияние
3. Линейные O(n)                            циклы while, for, работа с одномерным массивом 
4. Линейно-логарифмические O(log2(n) * n)   
5. Квадратичные O(n ^ 2)
6. Кубические O(n ^ 3)
7. Задача о комивояжере(N!)

Лекции по С#(Последовательность Фиббоначчи) O(2^n)
*/

// Напишите программу, которая принимает на вход одно число и возвращает сумму чисел от 1 до n.
// Console.Clear();                                            // очистка консоли, вывод только нужного
// Console.Write("Введите число: ");
// int n = int.Parse(Console.ReadLine()!), result = 0;
// for (int i = 1; i <= n; i++)
//     result += i;
// Console.WriteLine($"Сумма число от 1 до {n} = {result}");
// Console.WriteLine(((1 + n) / 2.0) * n);
// Sn = ((a0 + an) / 2) * n = ((1 + n) / 2) * n
// (1 + 10) / 2.0 = 5.5


// Алина попросила Костю загадать число от 1 до 100(он загадал 67)
// Алгоритм Бинарного поиска
// Это число больше чем (1 + 100) / 2 = 50? Да
// Это число больше чем (50 + 100) / 2 = 75? Нет 
// Это число больше чем (50 + 75) / 2 = 62? Да
// Это число больше чем (62 + 75) / 2 = 68? Нет
// Это число больше чем (62 + 68) / 2 = 65? Да
// Это число больше чем (65 + 68) / 2 = 66? Да
// Это число больше чем (66 + 68) / 2 = 67? Нет
// (66, 67)
// 100 вариантов(n) - log2(100) = 7


// Алгоритм пузырьковой сортировки
// Console.Clear();
// Console.Write("Введите кол-во элементов: ");
// int n = int.Parse(Console.ReadLine()!);
// int[] array = new int[n];
// for (int i = 0; i < array.Length; i++)
//     array[i] = new Random().Next(-20, 21); // [-20; 20]
// Console.WriteLine($"Начальный массив: [{string.Join(", ", array)}]");
// for (int i = 0; i < array.Length; i++)
// {
//     for (int j = 0; j < array.Length - 1 - i; j++)
//     {
//         if (array[j] > array[j + 1])
//             (array[j], array[j + 1]) = (array[j + 1], array[j]);
//     }
// }
// Console.WriteLine($"Конечный массив: [{string.Join(", ", array)}]");
// [-6, 4, 3, -9, 11]        //максимальное число после первой итерации сохраняется(число 11)
// [-6, 3, -9, 4, 11]


// Последовательность Фибонначчи


int fib(int n)              //рекурсивный подход
{
    if (n == 0)
        return 0;
    if (n == 1)
        return 1;
    return fib(n - 1) + fib(n - 2);
}


Console.Clear();
Console.Write("Введите число: ");
int n = int.Parse(Console.ReadLine()!), a0 = 0, a1 = 1, x;
for (int i = 0; i < n; i++)
{
    x = a0 + a1;
    a0 = a1;
    a1 = x;
}
Console.WriteLine($"I - {a0}"); // O(39)             // 1й вывод, а0 - нужное значение
Console.WriteLine($"II(рекурсия) - {fib(n)}"); // O(2 ^ 39)
// 0 1 1 2 3 5 8
// 0 1 2 3 4 5 6 7

// Быстрая сортировка (рекурсивные вызовы)
// [5, 4, 0, 2, 1]
// Опорный элемент - 5
// Первый массив < 5 [4, 0, 2, 1]
// Второй массив = 5 [5]
// Третий массив > 5 []

// [4, 0, 2, 1]
// Опорный элемент - 4
// Первый массив < 4 [0, 2, 1]
// Второй массив = 4 [4]
// Третий массив > 4 []

// [0, 2, 1]
// Опорный элемент - 0
// Первый массив < 0 []
// Второй массив = 0 [0]
// Третий массив > 0 [2, 1]
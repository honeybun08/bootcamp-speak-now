const int N = 1000; //размер матрицы (по факту будет 1000 * 1000 размер, т.к. это матрица)
const int THREADS_NUMBER = 10;

int[,] serialMulRes = new int[N, N]; //результат выполнения умножения матриц в однопотоке(послед.умножение матриц)
int[,] threadMulRes = new int[N, N]; //результат параллельного умножения матриц(в мультипотоке)

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

SerialMatrixMul(firstMatrix, secondMatrix);
PrepareParallelMatrixMul(firstMatrix, secondMatrix);
Console.WriteLine(EqualityMatrix(serialMulRes, threadMulRes));



int[,] MatrixGenerator(int rows, int columns)
{
    Random _rand = new Random();
    int[,] res = new int[rows, columns];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rand.Next(-100, 100); // _rand - уже имеющийся объект рандомизатора
        }
    }
    return res;
}

void SerialMatrixMul(int[,] a, int[,] b) // послед.умножение матриц
{                                              // остановка программы
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножить такие матрицы"); // если чсило столбцов НЕ = числу строк

    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes[i, j] += a[i, k] * b[k, j];
            }                    // 1 матрица   2 матрица
        }
    }
}

void PrepareParallelMatrixMul(int[,] a, int[,] b)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножить такие матрицы");
    int eachThreadCalc = N / THREADS_NUMBER; // идет разделеление N равномерно на кол-во потоков через переменную
    Thread[] arr = new Thread[2]; 
    var threadsList = new List<Thread>(); // нужно где-то хранить потоки(улучшенный массив = коллекция)
    for (int i = 0; i < THREADS_NUMBER; i++) // задаем каждый поток, от 0 до 9 получаем 10 потоков
    {
        // начало одного потока
        int startPos = i * eachThreadCalc; // для первого потока начало от 0, потом 100,200,300 и 400 для 5го потока
        // конец одного потока(т.к. после равномерного распределения N что-то останется и пойдет в послед.поток)
        int endPos = (i + 1) * eachThreadCalc; // а если сделать i++, то оно перезапишется в 52 строке и пойдет на startPos
        //если последний поток
        if (i == THREADS_NUMBER - 1) endPos = N; // перекидываем остатки на последний поток
        threadsList.Add(new Thread(() => ParallelMatrixMul(a, b, startPos, endPos))); // в поток перекидываем функцию
        threadsList[i].Start(); // запускаем конкретный,заданный нами поток
    }
    for (int i = 0; i < THREADS_NUMBER; i++) // нужно подождать, пока все потоки завершат свою работу
    {
        threadsList[i].Join(); // присоединение всего к главному потоку
        // и все потоки сами в MulRes(в ячейки) добавят все данные и создадут массив 
    } 
    // и по факту мы создаем каждый поток по отдельности и заполняем их(создаем для кадого диапазон), а запускаем их по очереди(создали -> запустили) 
} // основной поток - это то, где запускается основная прогамма(без пареллельности)

void ParallelMatrixMul(int[,] a, int[,] b, int startPos, int endPos) // основа предид. метод для обычного умножения
{
    for (int i = startPos; i < endPos; i++) // идем от начала до конца 
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                threadMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

bool EqualityMatrix(int[,] fmatrix, int[,] smatrix) // метод сравнения двух матриц
{
    bool res = true;

    for (int i = 0; i < fmatrix.GetLength(0); i++)
    {
        for (int j = 0; j < fmatrix.GetLength(1); j++)
        {
            res = res && (fmatrix[i, j] == smatrix[i, j]);
        }
    }

    return res;
}


Console.Clear();
while (Main()) {}

bool Main()
{
    var taskNumber = ReadInt("номер задачи (54, 56, 58, 60 или 62; 0 для выхода)");
    switch (taskNumber) {
        // Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
        case 54:
        {   
            WriteLine("\nСоздадим двумерный массив заполненный случайными числами:", ConsoleColor.Yellow); 

            var arraySize = ReadIntArray("размеры массива (m, n)", 2, Limits.GreaterThanZero);
            var rows = arraySize[0];
            var cols = arraySize[1];
            var array2d = GetRandomIntArray(rows, cols, 0, 10);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Write2DIntArray(array2d);
            WriteLine("Отсортируем строки массива по убыванию:", ConsoleColor.Yellow); 
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < cols; i++)
            {
                var checkIndex = 0;
                while (checkIndex < rows)
                {
                    for (int j = checkIndex; j < rows; j++)
                    {
                        if (array2d[checkIndex, i] < array2d[j, i])
                        {
                            var temp = array2d[checkIndex, i];
                            array2d[checkIndex, i] = array2d[j, i];
                            array2d[j, i] = temp;
                        }            
                    }
                    checkIndex++;
                }
            }
            Write2DIntArray(array2d);
            Console.ResetColor();
            break;
        }
        // Задайте прямоугольный двумерный массив. Напишите программу, 
        // которая будет находить строку с наименьшей суммой элементов.
        case 56:
        {              
            WriteLine("\nСоздадим прямоугольный двумерный массив заполненный случайными числами:", ConsoleColor.Yellow); 

            var arraySize = ReadInt("размер массива", true);
            var rows = arraySize;
            var cols = arraySize;
            var array2d = GetRandomIntArray(rows, cols, 0, 10);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Write2DIntArray(array2d);
            Console.ResetColor();
            var minSumIndex = 0;         
            var minSum = int.MaxValue;   
            for (int i = 0; i < cols; i++)
            {
                var sum = 0;
                for (int j = 0; j < rows; j++)
                {
                    sum += array2d[j, i];                    
                }
                if (sum < minSum) {
                    minSum = sum;
                    minSumIndex = i;
                }
            }
            minSumIndex++;
            WriteLine($"{minSumIndex} - строка с наименьшей суммой элементов", ConsoleColor.Green);
            break;
        }
        //Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
        case 58:
        {             
            WriteLine("\nЗададим две матрицы одинакового размера заполненные случайными числами:", ConsoleColor.Yellow); 
            var matrixSize = ReadInt("размер матриц", true);

            var mA = GetRandom2DIntArray(matrixSize, matrixSize, 1, 10);  
            var mB = GetRandom2DIntArray(matrixSize, matrixSize, 1, 10);  

            Console.ForegroundColor = ConsoleColor.Yellow;
            Write2DIntArray(mA);
            Console.WriteLine("умножим на");
            Write2DIntArray(mB);
            Console.ResetColor();

            var mResult = new int[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    for (int k = 0; k < matrixSize; k++)
                    {
                       mResult[i, j] += mA[k, j] * mB[i, k];
                    }
                }               
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Результирующая матрица:");
            Write2DIntArray(mResult);
            Console.ResetColor();
            break;
        }
        // Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
        // Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
        case 60:
        {
            WriteLine("\nСоздадим массив 2 x 2 x 2 и заполним его неповторяющимися двузначными числами\n", ConsoleColor.Yellow); 
            var size = 2;
            var array3d = new int[size, size, size];
            var randomNumbers = new int[size * size * size];
            var rnd = new Random();
            
            Console.ForegroundColor = ConsoleColor.Green;

            var numbersCount = 0;
            for (int k = 0; k < size; k++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        bool unique = false;
                        while (!unique) 
                        {
                            var matched = false;
                            var newRandomNumber = rnd.Next(10, 100);
                            for (int l = 0; l < randomNumbers.Length; l++)
                            {
                                if (newRandomNumber == randomNumbers[l])
                                {
                                    matched = true;
                                    break;
                                }
                            }
                            unique = !matched;
                            if (unique)
                            {
                                randomNumbers[numbersCount] = newRandomNumber;
                                numbersCount++;
                            }
                        }
                        array3d[i, j, k] = randomNumbers[numbersCount - 1];
                        var line = (numbersCount % 2 != 0) ? " " : "\n";
                        Console.Write($"{array3d[i, j, k]}({i}{j}{k}){line}");
                    }                    
                }                
            }
            Console.ResetColor();
            Console.Write("\n");
            break;
        }
        // Напишите программу, которая заполнит спирально массив 4 на 4
        case 62:
        {
            WriteLine("\nСоздадим массив и заполним его по спирали (по условию задачи размер 4 x 4)\n", ConsoleColor.Yellow); 
            var dimensions = ReadIntArray("размеры массива", 2, Limits.GreaterThanZero);
            var width = dimensions[0];
            var height = dimensions[1];
            var array2d = new int[width, height];
            var indexesArray = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    indexesArray[i, j] = width * j + i;
                }
            }            

            var numbers = 0;
            while (numbers < width * height) 
            {
                for (int i = 0; i < indexesArray.GetLength(0); i++)
                {
                    var index = indexesArray[i, 0];
                    array2d[index % width, index / width] = numbers;
                    numbers++; 
                }
                indexesArray = CutLineAndRotateCCW(indexesArray);
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Write2DIntArray(array2d, width * height);
            
            Console.ResetColor();
            Console.Write("\n");
            break;
        }
        case 0:
            return false;
        default:
        {
            WriteLine("Неверный номер задачи", ConsoleColor.Red);   
            break;
        }		
    }
    return true;
}

int[,] CutLineAndRotateCCW(int[,] array)
{   
    // уменьшим ширину нового массива на 1
    var rows = array.GetLength(1) - 1;
    var cols = array.GetLength(0);

    var newArray = new int[rows, cols];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            // будем брать значение из старого массива со смещением по Y на 1
            var shiftOldX = i + 1; 
            newArray[i, j] = array[(cols - 1) - j, shiftOldX];
        }       
    }
    
    return newArray;
}

// Цветное сообщение
void WriteLine(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);   
    Console.ResetColor();
}

// Считывает значение пользователя из строки ввода
int ReadInt(string argumentName, bool greaterThanZero = false)
{
    while (true) {
        Console.Write($"Введите {argumentName}: "); 
        try
        {
            var intInput = int.Parse(Console.ReadLine());            
            //убедимся, что число больше нуля
            if (greaterThanZero && intInput <= 0) 
            {
                WriteLine("Требуется положительное число больше 0", ConsoleColor.Red);
                continue;
            }
            return intInput;
        }
        catch (Exception e)
        {
            switch (e)
            {
                case ArgumentOutOfRangeException:
                    WriteLine("Слишком большое значение", ConsoleColor.Red);
                break;
                default:
                    WriteLine("Некорректное значение", ConsoleColor.Red);
                break;
            }            
        }
    }
}

// Считывает значения пользователя из строки ввода, разделенные запятой
// Можно указать максимально допустимое количество чисел
int[] ReadIntArray(string argumentName, int numbersCount = 0, Limits limits = Limits.None)
{
    while (true) {
        Console.WriteLine($"Введите {argumentName}, значения разделите запятыми: ");
        var stringValue = Console.ReadLine();
        stringValue = stringValue.Replace(" ", string.Empty);
        var stringArray = stringValue.Split(",");
        if (numbersCount > 0 && stringArray.Length != numbersCount)
        {
            WriteLine("Некорректное количество значений", ConsoleColor.Red);
            continue;
        }
        bool error = false;
        var intArray = new int[stringArray.Length];
        for (int i = 0; i < stringArray.Length; i++)
        {
            if (int.TryParse(stringArray[i], out int element)) 
            {
                intArray[i] = element;
                if (limits == Limits.GreaterThanZero && intArray[i] <= 0) 
                {
                    WriteLine("Все числа должны быть положительными и быть больше 0", ConsoleColor.Red);
                    error = true;
                    break;
                }
                if (limits == Limits.GreaterOrEqualsZero && intArray[i] < 0) 
                {
                    WriteLine("Все числа должны быть положительными", ConsoleColor.Red);
                    error = true;
                    break;
                }
            } else {
                WriteLine("Введены некорректные значения", ConsoleColor.Red);
                    error = true;
                    break;
            }
        }
        if (error)
        {
            continue;
        }
        return intArray;
    }   
}

// Выводит двумерный массив в консоль
void Write2DIntArray(int[,] array, int fillZeroDigits = 0)
{
    var lengthX = array.GetLength(0);
    var lengthY = array.GetLength(1);
    
    Console.Write("\n");
    for (int y = 0; y < lengthY; y++)
    {

        for (int x = 0; x < lengthX; x++)
        {
            if (fillZeroDigits > 0)
            {
                int length = fillZeroDigits.ToString("D").Length;
                Console.Write(array[x, y].ToString("D" + length) + " ");      
            } 
            else 
            {
                Console.Write($"{array[x, y]} ");            
            }
        }
        Console.Write("\n");
    }
    Console.Write("\n");
}

int[,] GetRandom2DIntArray(int sizeFrom, int sizeTo, int valuesFrom, int valuesTo)
{
    var rnd = new Random();
    var n = rnd.Next(sizeFrom, sizeTo);
    var m = rnd.Next(sizeFrom, sizeTo);
    int[,] array2d = new int[m, n];
    for (int x = 0; x < m; x++)
    {
        for (int y = 0; y < n; y++)
        {
            array2d[x, y] = rnd.Next(valuesFrom, valuesTo);
        }
    }    
    return array2d;
}

int[,] GetRandomIntArray(int cols, int rows, int rndA, int rndB)
{
    int[,] array2d = new int[cols, rows]; 
    var rnd = new Random();

    for (int i = 0; i < cols; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            array2d[i, j] = rnd.Next(rndA, rndB);
        }
    }
    return array2d;
}

enum Limits
{
    None,
    GreaterThanZero,
    GreaterOrEqualsZero
}
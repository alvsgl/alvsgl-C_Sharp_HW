Console.Clear();
while (Main()) {}

bool Main()
{
    var taskNumber = ReadInt("номер задачи (47, 50 или 52; 0 для выхода)");
    switch (taskNumber) {
        // Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
        case 47:
        {   
            WriteLine("\nСоздадим двумерный массив", ConsoleColor.Yellow);  
            var array = ReadIntArray("размеры массива m, n", 2, Limits.GreaterThanZero);     
            WriteLine("Заполняем массив натуральными числами...", ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.Green;
            
            var m = array[0];
            var n = array[1];
            float[,] array2d = new float[m, n]; 
            var rnd = new Random();

            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    array2d[x, y] = rnd.Next(-1000, 1000) * 0.1f;
                }
            }
            
            Write2DFloatArray(array2d);            
            Console.ResetColor();
            break;
        }
        // Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
        // и возвращает значение этого элемента или же указание, что такого элемента нет.
        case 50:
        {              
            var array2d = GetRandom2DIntArray(3, 5, 1, 10);  
            Console.ForegroundColor = ConsoleColor.Yellow;
            Write2DIntArray(array2d);
            Console.ResetColor();

            var rows = array2d.GetLength(0);
            var cols = array2d.GetLength(1);

            var coordinates = ReadIntArray("позицию элемента в массиве (m, n)", 2, Limits.GreaterOrEqualsZero);  
            Write($"{coordinates[0]}, {coordinates[1]} -> ", ConsoleColor.Green);
            if (coordinates[0] > rows - 1 || coordinates[1] > cols - 1)
            {
                Write("такого числа в массиве нет\n", ConsoleColor.Green);
            }
            else
            {
                Write($"{array2d[coordinates[0], coordinates[1]]}\n", ConsoleColor.Green);
            }

            break;
        }
        //Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
        case 52:
        {             
            WriteLine("\nВычислим среднее арифметическое для каждого столбца массива", ConsoleColor.Yellow);  

            var array2d = GetRandom2DIntArray(3, 5, 1, 10);  
            Console.ForegroundColor = ConsoleColor.Yellow;
            Write2DIntArray(array2d);
            Console.ResetColor();

            var rows = array2d.GetLength(0);
            var cols = array2d.GetLength(1);

            Write("Среднее арифметическое каждого столбца: ", ConsoleColor.Green);
            for (int x = 0; x < rows; x++)
            {
                var mid = 0f;
                for (int y = 0; y < cols; y++)
                {
                    mid += array2d[x, y];
                }
                mid /= cols;
                var delimeter = x < rows - 1 ? "; " : ".";

                var value = IsInteger(mid) ? $"{mid:F0}" : $"{mid:F2}";
                Write($"{value}{delimeter}", ConsoleColor.Green);
            }
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

// Цветное сообщение
void WriteLine(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);   
    Console.ResetColor();
}

// Цветное сообщение
void Write(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.Write(text);   
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
void Write2DIntArray(int[,] array)
{
    var lengthX = array.GetLength(0);
    var lengthY = array.GetLength(1);
    
    Console.Write("\n");
    for (int y = 0; y < lengthY; y++)
    {

        for (int x = 0; x < lengthX; x++)
        {
            Console.Write($"{array[x, y]} ");            
        }
        Console.Write("\n");
    }
    Console.Write("\n");
}

// Выводит двумерный массив натуральных чисел в консоль
void Write2DFloatArray(float[,] array)
{
    var lengthX = array.GetLength(0);
    var lengthY = array.GetLength(1);

    Console.Write("\n");
    for (int y = 0; y < lengthY; y++)
    {
        for (int x = 0; x < lengthX; x++)
        {            
            Console.Write(IsInteger(array[x, y]) ? $"{array[x, y]:F0} " : $"{array[x, y]:F1} ");
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

bool IsInteger(float value)
{
    return value % Math.Floor(value) == 0;
}

enum Limits
{
    None,
    GreaterThanZero,
    GreaterOrEqualsZero
}
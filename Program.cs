Console.Clear();
while (Main()) {}

bool Main()
{
    var taskNumber = ReadInt("номер задачи (34, 36 или 38; 0 для выхода)");
    switch (taskNumber) {
        // Задайте массив заполненный случайными положительными трёхзначными числами. 
        // Напишите программу, которая покажет количество чётных чисел в массиве.
        case 34:
        {   
            WriteLine("\nЗаполним массив случайными трехзначными числами", ConsoleColor.Yellow);  
            var arrayLength = ReadInt("длину массива", true);          
            var array = new int[arrayLength];
            var rnd = new Random();
            var count = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = rnd.Next(100, 1000);
                if (array[i] % 2 == 0)
                {
                    count++;
                }
            }
            WriteLine("Посчитаем четные числа в массиве", ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            WriteArrayInt(array);
            Console.Write($"] -> {count}\n\n");
            Console.ResetColor();
            break;
        }
        // Задайте одномерный массив, заполненный случайными числами.
        // Найдите сумму элементов, стоящих на нечётных позициях.
        case 36:
        {   
            WriteLine("\nЗаполним массив случайными числами", ConsoleColor.Yellow);  
            var arrayLength = ReadInt("длину массива", true);          
            var array = new int[arrayLength];
            var rnd = new Random();
            var sum = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = rnd.Next(-100, 100);
                if (array[i] % 2 != 0)
                {
                    sum += array[i];
                }
            }
            WriteLine("Посчитаем сумму нечетных чисел в массиве", ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            WriteArrayInt(array);
            Console.Write($"] -> {sum}\n\n");
            Console.ResetColor();
            break;
        }        

        case 38:
        {   
            WriteLine("\nЗаполним массив случайными вещественными числами", ConsoleColor.Yellow);  
            var arrayLength = ReadInt("длину массива", true);          
            var array = new float[arrayLength];
            var rnd = new Random();
            float min = int.MaxValue;
            float max = int.MinValue;
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = rnd.Next(-10000, 10000) * 0.01f;
                if (array[i] > max)
                {
                    max = array[i];
                }
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            var result = max - min;
            WriteLine("Найдем разницу между максимальным и минимальным элементами массива", ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[");
            WriteFloatInt(array);
            Console.Write($"] -> {result:F2}\n\n");
            Console.ResetColor();
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

// Выводит в консоль содержимое int массива
void WriteArrayInt(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i]);
        if (i < array.Length - 1)
        {
            Console.Write(", ");
        } 
    }
}

// Выводит в консоль содержимое float массива
void WriteFloatInt(float[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]:F2}");
        if (i < array.Length - 1)
        {
            Console.Write(" ");
        } 
    }
}
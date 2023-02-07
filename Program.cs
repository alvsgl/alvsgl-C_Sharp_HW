Console.Clear();
while (Main()) {}

bool Main()
{
    var taskNumber = ReadInt("номер задачи (25, 27 или 29; 0 для выхода)");
    switch (taskNumber) {
        // Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
        case 25:
        {   
            WriteLine("\nВозведем число A в натуральную степень B", ConsoleColor.Yellow);  
            var a = ReadInt("А");            
            while(true) {                
                var b = ReadInt("B");
                if (b <= 0) 
                {
                    WriteLine("Число меньше единицы", ConsoleColor.Red);
                    continue;
                }
                var result = a;
                for (int i = 0; i < b - 1; i++)
                {
                    result *= a;
                }

                WriteLine($"{a}, {b} -> {result}", ConsoleColor.Green);
                break;
            }
            break;
        }
        // Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
        case 27:
        {   
            WriteLine("\nВычислим сумму цифр в числе", ConsoleColor.Yellow);  
            var number = ReadInt("число");            
            var array = IntToArray(number, number.ToString().Length);
            var sum = 0;
            foreach (int element in array)
            {
                sum += element;
            }
            WriteLine($"{number} -> {sum}", ConsoleColor.Green);
            break;
        }
        // Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
        case 29:
        {   
            var random = new Random();
            WriteLine("\nСоздадим массив из 8 чисел и выведем его в консоль", ConsoleColor.Yellow);  
            Console.ForegroundColor = ConsoleColor.Green;
            int[] array = new int[8];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 99);
            }
            WriteArrayInt(array);
            Console.Write(" -> [");
            WriteArrayInt(array);
            Console.Write("]\n\n");
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
int ReadInt(string argumentName)
{
    while (true) {
        Console.Write($"Введите {argumentName}: ");
        try
        {
            return int.Parse(Console.ReadLine());            
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

// Возвращает массив из цифр числа, требует заранее определить количество цифр
int[] IntToArray(int value, int arraySize)
{
    var array = new int[arraySize];
    var number = value;
    for (int i = array.Length; i--> 0;)
    {
        array[i] = number % 10;
        number /= 10;
    }
    return array;
}

// Выводит в консоль содержимое массива
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
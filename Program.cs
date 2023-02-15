Console.Clear();
while (Main()) {}

bool Main()
{
    var taskNumber = ReadInt("номер задачи (41 или 43; 0 для выхода)");
    switch (taskNumber) {
        // Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
        case 41:
        {   
            WriteLine("\nЗаполним массив", ConsoleColor.Yellow);  
            var array = ReadIntArray("значения массива");     
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    count++;
                }
            }
            WriteLine("Посчитаем скоько чисел в массиве больше нуля", ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.Green;
            WriteArrayInt(array);
            Console.Write($" -> {count}\n\n");
            Console.ResetColor();
            break;
        }
        // Напишите программу, которая найдёт точку пересечения двух прямых,  
        // заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; 
        // значения b1, k1, b2 и k2 задаются пользователем.
        case 43:
        {   
            WriteLine("\nНайдем точку пересечения двух прямых\nзаданных уравнениями y = k1 * x + b1, y = k2 * x + b2", ConsoleColor.Yellow);  
            var array = ReadIntArray("k1, b1, k2, b2", 4);          
            Console.ForegroundColor = ConsoleColor.Green;
            int k1 = array[0], b1 = array[1], k2 = array[2], b2 = array[3];
            if (k1 == k2 && b1 == b2)
            {
                WriteLine($"b1 = {b1}, k1 = {k1}, b2 = {b2}, k2 = {k2} -> Прямые совпадают\n\n", ConsoleColor.Green);
                break;
            } 
            else if (k1 == k2) 
            {
                WriteLine($"b1 = {b1}, k1 = {k1}, b2 = {b2}, k2 = {k2} -> Прямые параллельны\n\n", ConsoleColor.Green);
                break;
            }              
            var x = (b2 - b1) / (k1 - k2);
            var y = (k1 * (b2 - b1)) / (k1 - k2) + b1;
            WriteLine($"b1 = {b1}, k1 = {k1}, b2 = {b2}, k2 = {k2} -> ({x}; {y})\n\n", ConsoleColor.Green);
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

// Считывает значения пользователя из строки ввода, разделенные запятой
// Можно указать максимально допустимое количество чисел
int[] ReadIntArray(string argumentName, int numbersCount = 0)
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
        var intArray = new int[stringArray.Length];
        for (int i = 0; i < stringArray.Length; i++)
        {
            if (int.TryParse(stringArray[i], out int element)) 
            {
                intArray[i] = element;
            } else {
                WriteLine("Введены некорректные значения", ConsoleColor.Red);
                continue;
            }
        }
        return intArray;
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
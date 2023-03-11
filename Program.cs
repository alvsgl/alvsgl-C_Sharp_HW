Console.Clear();
while (Main()) {}

bool Main()
{
    var taskNumber = ReadInt("номер задачи (64, 66 или 68; 0 для выхода)");
    switch (taskNumber) {
        // Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1.
        // Выполнить с помощью рекурсии.
        case 64:
        {   
            WriteLine("\nВыведем все натуральные числа в промежутке от N до 1", ConsoleColor.Yellow);  
            var n = ReadInt("N", 1);     

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\nN = {n} -> \"");
            WriteSequenceRecoursive(n);
            Console.Write("\"\n");
            Console.ResetColor();
            break;
        }
        // Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
        case 66:
        {              
            WriteLine("\nНайдем сумму натуральных элементов в промежутке от M до N", ConsoleColor.Yellow);  
            while (true) {
                var mn = ReadIntArray("значения M и N", 2, Limits.GreaterThanZero);   
                var M = mn[0];
                var N = mn[1];  
                if (M >= N)
                {
                    WriteLine("\nЗначение N должно быть больше значения M", ConsoleColor.Red);  
                    continue;
                }
                var result = GetSumRecoursive(M, N);
                WriteLine($"\nM = {M}; N = {N} -> {result}\n", ConsoleColor.Green);
                break;
            }
            break;
        }
        // Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
        case 68:
        {             
            while (true) {
                WriteLine("\nВычислим функцию Аккермана для неотрицательных n и m", ConsoleColor.Yellow);  
                var nm = ReadIntArray("значения n и m", 2, Limits.GreaterOrEqualsZero);   
                var n = nm[0];
                var m = nm[1]; 
                
                var result = AkkermanRecoursive(n, m);
                WriteLine($"\nn = {n}, m = {m} -> A(n, m) = {result}\n", ConsoleColor.Green);
                break;
            }
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

void WriteSequenceRecoursive(int value)
{
    var delimiter = value > 1 ? ", " : "";
    Console.Write($"{value}{delimiter}");

    if (value > 1)
    {
        value--;
        WriteSequenceRecoursive(value);
    }
}

int GetSumRecoursive(int nextValue, int finalValue, int sum = 0)
{
    if (nextValue <= finalValue)
    {
        sum += nextValue;
        nextValue++;        
    } else {
        return sum;
    }
    return GetSumRecoursive(nextValue, finalValue, sum);
}

int AkkermanRecoursive(int n, int m)
{
    if (n == 0)
    {
        return m + 1;
    }
    else
    {
        if (n != 0 && m == 0)
        {
            return AkkermanRecoursive(n - 1, 1);
        }
        else
        {
            return AkkermanRecoursive(n - 1, AkkermanRecoursive(n, m - 1));
        }
    }
}

// Цветное сообщение
void WriteLine(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);   
    Console.ResetColor();
}

// Считывает значение пользователя из строки ввода
int ReadInt(string argumentName, int greaterThanValue = -1)
{
    while (true) {
        Console.Write($"Введите {argumentName}: ");
        try
        {
            var intInput = int.Parse(Console.ReadLine());            
            //убедимся, что число больше нуля
            if (greaterThanValue >= 0 && intInput <= greaterThanValue) 
            {
                WriteLine($"Требуется положительное число больше {greaterThanValue}", ConsoleColor.Red);
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

enum Limits
{
    None,
    GreaterThanZero,
    GreaterOrEqualsZero
}
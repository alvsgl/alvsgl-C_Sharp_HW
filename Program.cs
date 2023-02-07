Console.Clear();
while (Main()) {}

bool Main()
{
    var taskNumber = ReadInt("номер задачи (19, 21 или 23; 0 для выхода)");
    switch (taskNumber) {
        // Напишите программу, которая принимает на вход пятизначное число 
        // и проверяет, является ли оно палиндромом.
        case 19:
        {   
            const int digitsCount = 5;

            WriteLine("\nОпределим, является ли пятизначное число палиндромом", ConsoleColor.Yellow);              
            var value = ReadInt("пятизначное число", digitsCount);
            var digitsArray = IntToArray(value, digitsCount);
            bool result = ArrayIsPalindrome(digitsArray);
            WriteLine($"{value} -> {(result ? "да" : "нет")}\n", ConsoleColor.Green);
            break;
        }
        // Напишите программу, которая принимает на вход координаты двух точек 
        // и находит расстояние между ними в 3D пространстве.
        case 21:
        {   
            const int dimensionsCount = 3;

            WriteLine("\nВычислим расстояние между двумя точками в 3D пространстве", ConsoleColor.Yellow);    

            var v1 = ReadIntArray("кординаты первой точки (X, Y, Z)", dimensionsCount);
            var v2 = ReadIntArray("кординаты второй точки (X, Y, Z)", dimensionsCount);
            
            var sum = 0;
            for (int i = 0; i < dimensionsCount; i++)
            {
                sum += (int)Math.Pow(v1[i] - v2[i], 2);
            }
            var distance = Math.Sqrt(sum);
            Console.WriteLine("\nРасстояние между точками:");
            WriteLine($"A ({v1[0]}, {v1[1]}, {v1[2]}); B ({v2[0]}, {v2[1]}, {v2[2]}) -> {distance:F2}\n", ConsoleColor.Green);
            break;
        }
        case 23:
        {   
            // Напишите программу, которая принимает на вход число (N) и выдает таблицу кубов чисел от 1 до N
            WriteLine("\nСоздадим последовательность значений от 1 до N и возведем их в куб", ConsoleColor.Yellow);
            while(true) {
                 var n = ReadInt("число N (N > 0)");
                if (n <= 0) 
                {
                    WriteLine("Число меньше единицы", ConsoleColor.Red);
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{n} -> ");
                for (int i = 0; i < n; i++)
                {
                    Console.Write((int)Math.Pow(i + 1, 3));
                    if (i < n - 1)
                    {
                        Console.Write(", ");
                    } 
                    else 
                    {
                        Console.Write("\n\n");
                    }
                }
                Console.ResetColor();
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

// Цветное сообщение
void WriteLine(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);   
    Console.ResetColor();
}

// Считывает значение пользователя из строки ввода
// Можно указать максимально допустимое количество цифр в запрашиваемом числе
int ReadInt(string argumentName, int digitsCount = 0)
{
    while (true) {
        Console.Write($"Введите {argumentName}: ");
        try
        {
            var value = int.Parse(Console.ReadLine());
            if (digitsCount == 0 || CheckDigits(value, digitsCount)) {
                return value;
            }
            Console.WriteLine($"Необходимо ввести число состоящее из {digitsCount} цифр");
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

// Проверка соответствия числа на количество заданных цифр
bool CheckDigits(int value, int maxDigits)
{
    var topValue = Math.Pow(10, maxDigits);
    var bottomValue = Math.Pow(10, maxDigits - 1);
    return value < topValue && value >= bottomValue;
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

// Определяем, являетсяи ли последовательность в массиве палиндромом
bool ArrayIsPalindrome(int[] array)
{
    var halfSize = array.Length / 2;
    var fullSize = array.Length - 1;
    bool isPalindrome = true;
    // идем до середины массива и сравниваем значение с зеркальным значением второй половины 
    for (int i = 0; i < halfSize; i++)
    {
        if (array[i] != array[fullSize - i])
        {
            isPalindrome = false;
            break;
        }
    }
    return isPalindrome;
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
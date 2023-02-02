Console.Clear();
bool isWork = true;

while (isWork) {

    Console.Write("\nВведите номер задачи (10, 13, or 15): ");

    if (int.TryParse(Console.ReadLine(), out int i))
    {
        switch (i)
        {
            case 10:
            {
                Console.WriteLine("\nНайдите вторую цифру трехзначного числа");
                bool done = false;
                while (!done) 
                {                    
                    Console.Write("Введите целое трехзначное число: ");
                    int a = 0;
                    try
                    {
                        a = int.Parse(Console.ReadLine());
                    } 
                    catch
                    {
                        Console.WriteLine("Некорректное значение");
                        continue;
                    }
                    if (a > 99 && a < 1000)
                    {
                        float result = a / 10 % 10;
                        Console.WriteLine("{0} -> {1}", a, result);
                        done = true;
                    } 
                    else
                    {
                        Console.WriteLine("Неправильное количество цифр в числе (должно быть три)");
                    }
                }
                break;
            }
            case 13:
            {
                Console.WriteLine("\nНайти вторую цифру числа");
                bool done = false;
                while (!done) 
                {  
                    Console.Write("Введите целое число: ");
                    int a = 0;
                    try
                    {
                        a = int.Parse(Console.ReadLine());
                    } 
                    catch
                    {
                        Console.WriteLine("Некорректное значение");
                        continue;
                    }
                    if (a < 0)
                    {
                        a = Math.Abs(a);
                    }
                    int count = 0;
                    int num = a;
                    while (num > 0) {
                        count++;
                        num = (num / 10);
                    }
                    int mult = (int)Math.Pow(10, count - 1);
                    if (mult < 100)
                    {
                        Console.WriteLine("{0} -> третьей цифры нет", a);
                    } else {
                        mult /= 100;
                        Console.WriteLine("{0} -> {1}", a, a / mult % 10);
                    }
                    done = true;
                }
                break;
            }
            case 15:
            {
                Console.WriteLine("\nЯвляется ли цифра выходным днем недели");
                bool done = false;
                while (!done) 
                {  
                    Console.Write("Введите целое число (1 - 7): ");
                    int a = 0;
                    try
                    {
                        a = Math.Clamp(int.Parse(Console.ReadLine()), 1, 7);
                    } 
                    catch
                    {
                        Console.WriteLine("Некорректное значение");
                        continue;
                    }                
                    if (a > 5)
                    {
                        Console.WriteLine("{0} -> да", a);
                    }
                    else 
                    {
                        Console.WriteLine("{0} -> нет", a);
                    }
                    done = true;
                }
                break;
            }
            
            default:
            {
                Console.WriteLine("Задача с таким номером отсутствует");
            }
            break;
        }
    } else {
        Console.WriteLine("Некорректное значение, выход");
        break;
    }
}
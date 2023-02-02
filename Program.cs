Console.Clear();
bool isWork = true;

while (isWork) {

    Console.Write("\nEnter a number of a task (2, 4, 6 or 8): ");

    if (int.TryParse(Console.ReadLine(), out int i))
    {
        switch (i)
        {
            case 2:
            {
                Console.WriteLine("\nFind biggest number of two");
                Console.Write("Enter first integer number: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Enter second integer number: ");
                int b = int.Parse(Console.ReadLine());
                
                int max = a;
                if (a < b) 
                {
                    max = b;
                }

                Console.WriteLine("a = {0}; b = {1} -> max = {2}", a, b, max);
                break;
            }
            case 4:
            {
                Console.WriteLine("\nFind biggest number of three");
                Console.Write("Enter first integer number: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Enter second integer number: ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("Enter third integer number: ");
                int c = int.Parse(Console.ReadLine());

                int max = a;
                if (a < b || a < c) 
                {
                    max = b;
                    if (b < c)
                    {
                        max = c;
                    }
                }
                Console.WriteLine("{0}, {1}, {2} -> {3}", a, b, c, max);
                break;
            }
            case 6:
            {
                Console.WriteLine("\nFind if number is even");
                Console.Write("Enter integer number: ");
                int a = int.Parse(Console.ReadLine());
                string result = "No";
                if (a % 2 == 0) 
                {
                    result = "Yes";
                }
                Console.WriteLine("{0} -> {1}", a, result);
                break;
            }
            case 8:
            {
                Console.WriteLine("Get even numbers sequence from 1 to N");
                Console.Write("Enter integer number (N): ");
                int a = int.Parse(Console.ReadLine());
                int count = a;
                int number = 0;
                Console.Write("{0} -> ", a);
                while (count > 0)
                {
                    number++;
                    if (number % 2 == 0) 
                    {
                        Console.Write(number);
                        if (count >  2)
                        {
                            Console.Write(", ");
                        }
                    }
                    count--;           
                }
            }
            break;
            default:
            {
                Console.WriteLine("Wrong task number");
            }
            break;
        }
    } else {
        Console.WriteLine("Incorrect task number, exit");
        break;
    }
}
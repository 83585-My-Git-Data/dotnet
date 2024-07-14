namespace Calculator2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1, num2, result = 0;
            char operation;
            bool continueCalculation = true;

            do
            {
                Console.Write("Enter first number: ");
                num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter an operator (+, -, *, /): ");
                operation = Console.ReadLine()[0];

                Console.Write("Enter second number: ");
                num2 = Convert.ToDouble(Console.ReadLine());

                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            Console.WriteLine("Error: Division by zero");
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        continue;
                }

                Console.WriteLine("Result: " + result);

                Console.Write("Do you want to continue (y/n)? ");
                continueCalculation = Console.ReadLine().ToLower() == "y";

            } while (continueCalculation);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session003_ConditionalsAndExceptionHandling
{
    class Session003
    {
        static void Main(string[] args)
        {
            //CONDITIONALS

            ///(skip to switch case)
            var order = 1;

            switch (order)
            {
                case 1:
                    Console.WriteLine("Fries");
                    goto case 2;
                case 2:
                    Console.WriteLine("Burger");
                    goto case 3;
                case 3:
                    Console.WriteLine("Ice cream");
                    goto case 4;
                case 4:
                    Console.WriteLine("Chicken");
                    break;
                default:
                    Console.WriteLine("Everything");
                    break;
            }

            Console.WriteLine();

            do
            {
                Console.WriteLine("Output me");
            } while (order > 3);

            while (order > 3)
            {
                Console.WriteLine("Output me too");
            }

            //do while loops execute at least once, even if condition is not satisfied.

            Console.WriteLine();

            for(int i=0; i<10; i++)
            {
                if((i % 2 == 0))
                {
                    continue;
                }

                if (i == 9)
                {
                    break;
                }

                Console.WriteLine(i);

                //putiing the condition if i==9 after the console output adds 9 to he list.
                
            }

            //EXCEPTION HANDLING
            Console.WriteLine();

            float num1 = 5;
            float num2 = 0;

            //my version
            Console.WriteLine("My version: 5 / 0 = {0}", DivideNums(num1, num2, "Can't divide by zero."));

            Console.WriteLine();

            //derek's version
            try
            {
                Console.WriteLine("Derek's version: 5 / 0 = {0}", DivideNums(num1, num2));
            }catch(DivideByZeroException ex)
            {
                Console.WriteLine("Can't divide by zero.");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }

        public static float DivideNums(float x, float y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }

            return x / y;

        }

        public static float DivideNums(float x, float y, string message)
        {

            float quotient = float.PositiveInfinity;

            try
            {
                if (y == 0)
                {
                    throw new DivideByZeroException();
                }

                quotient =  x / y;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(message);
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }

            return quotient;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session004_MethodsAndEnums
{
    class Session004
    {
        static void Main(string[] args)
        {
            //PASSING BY VALUE
            float x = 5f;
            float y = 4f;

            Swap(x, y);

            Console.WriteLine("You can see that they are still not swapped here\n" +
                "x = {0}\ny = {1}", x, y);

            //by default, c# is pass by value
            //it can be changed explicitly using "ref"

            Swap(ref x, ref y);

            Console.WriteLine("You can see that they are SWAPPED here\n" +
                "x = {0}\ny = {1}", x, y);

            //swap back for next experiment
            Swap(ref x, ref y);

            //if using default, it can be swapped using "out".
            //See the method below to know how

            float nX = 0, nY = 0;

            Swap(x, y, out nX, out nY);

            x = nX;
            y = nY;

            Console.WriteLine("You can see that they are SWAPPED AGAIN here\n" +
                "x = {0}\ny = {1}", x, y);

            Console.WriteLine();
            Console.WriteLine("x : 5 + y : 4 = {0}", GetSum(x, y));

            //OUT PARAMETER
            Console.WriteLine();

            float doubled;
            bool flag = DoubleTrouble(2, out doubled);
            Console.WriteLine("var : 5 * 2 = {0} -> flag {1}", doubled, flag);

            //PARAMS
            Console.WriteLine();
            Console.WriteLine("GetSumMore: {0}", GetSumMore(1,2,3));

            //ENUMS
            Console.WriteLine();

            CarColor car1 = CarColor.Orange;
            PaintCar(car1);

            Console.ReadLine();

        }

        //Use out parameter in DouleTrouble

        //out parameter is like "return" but you declare it in advance.
        //for returning other data types i guess
        private static bool DoubleTrouble(int v, out float doubled)
        {
            bool flag = false;
            doubled = v * 2;

            if (doubled == 10)
            {
                flag = true;
            }

            return flag;
        }

        //GetSum
        public static float GetSum(float x = 1f, float y = 1f)
        {
            return x + y;
        }

        //'params' works like '...' in java
        //like in java, it should be at the last parameter
        //'params' should be a 1D array
        public static float GetSumMore(params float[] nums)
        {
            float sum = 0f;
            foreach (float f in nums)
            {
                sum += f;
            }
            return sum;
        }


        //Swap function will show pass by value vs. pass by reference clearly
        public static void Swap(float x = 1f, float y = 1f)
        {
            float temp = x;
            x = y;
            y = temp;
        }

        public static void Swap(float x, float y, out float nX, out float nY)
        {
            float temp = x;
            x = y;
            y = temp;

            nX = x;
            nY = y;

        }

        public static void Swap(ref float x, ref float y)
        {
            float temp = x;
            x = y;
            y = temp;
        }

        static void PaintCar(CarColor cc)
        {
            Console.WriteLine("The car was painted {0} with the code {1}", cc, (int)cc);
        }

    }

    enum CarColor : byte
    {
        White = 0,
        Orange,
        Blue,
        Green,
        Red,
        Yellow
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session013_LambdaLINQMethods
{

    //this covers multiple topics that
    //works with lists of data
    //include lambda, where, tolist, select
    //zip aggregate, average
    class Session013
    {
        //assign lambda expression to delegate
        public delegate double DoubleIt(double val);

        static void Main(string[] args)
        {
            //Lambda
            //input params in left
            //code to execute on the right
            DoubleIt wham = (x => x * 2);
            Console.WriteLine("Simple lambda delegate(Wham): {0}",
                wham(5));

            //Search all even numbers in a numlist
            //using lambda
            List<int> numList = new List<int>() { 1,3,4,6,2,8,6 };

            Console.WriteLine("All even numbers in numList: ");
            var evenList = numList.Where(x => x % 2 == 0).ToList<int>();
            foreach(int i in evenList)
            {
                Console.WriteLine(i);
            }

            //range example
            var rangelist = numList.Where(x => (x > 3) && (6 >= x)).ToList<int>();
            Console.WriteLine("Numbers between 3 and 6(inclusive of 6): {0}",
                string.Join(", ", rangelist));

            //find the number of heads and tails
            Random r = new Random();

            List<int> flipList = new List<int>();
            for(int i=0; i<100; i++)
            {
                flipList.Add(r.Next(1, 3));
            }

            Console.WriteLine();
            Console.WriteLine("Head count: {0}",
                flipList.Where(x => x == 1).ToList().Count());

            Console.WriteLine("Tail count: {0}",
                flipList.Where(x => x == 2).ToList().Count());

            //find all name starting with 's'
            var nameList = new List<string>() {
                "Manta", "Chino", "Saxony", "Sandy", "Boss"
            };

            Console.WriteLine("Names starting with s: {0}",
                string.Join(" ",
                nameList.Where(x => x.StartsWith("s",
                StringComparison.OrdinalIgnoreCase)).ToList()));

            //SELECT
            //executes function on each item in list.

            var ten = new List<int>();
            ten.AddRange(Enumerable.Range(1, 10));

            var squares = ten.Select(x => x * x);
            Console.WriteLine("Squares using select: {0}",
                string.Join(" ", squares));

            //ZIP
            //applies function to two lists

            //example, add 2 lists together
            var one = new List<int>() { 1, 3, 5 };
            var two = new List<int>() { 2, 4 };

            //takes as length the list with the less count of items
            //output: 3 7

            Console.WriteLine("Sum of one and two: {0}",
                string.Join(" ", one.Zip(two, (x,y) => x + y).ToList()));
            Console.WriteLine();

            //AGGREGATE
            //performs operation on each item in a list
            //carries result forward

            var numList2 = new List<int>() { 1, 2, 3, 4, 5};
            Console.WriteLine("Sum of one and two: {0}",
                string.Join(" ", numList2.Aggregate((x,y) => x+y)));
            Console.WriteLine();

            #region derek code

            // ---------- AVERAGE ----------
            // Get the average of a list of values
            var numList3 = new List<int>() { 1, 2, 3, 4, 5 };

            // AsQueryable allows you to manipulate the
            // collection with the Average function
            Console.WriteLine("AVG : {0}",
                numList3.AsQueryable().Average());

            // ---------- ALL ----------
            // Determines if all items in a list
            // meet a condition
            var numList4 = new List<int>() { 1, 2, 3, 4, 5 };

            Console.WriteLine("All > 3 : {0}",
                numList4.All(x => x > 3));

            // ---------- ANY ----------
            // Determines if any items in a list
            // meet a condition
            var numList5 = new List<int>() { 1, 2, 3, 4, 5 };

            Console.WriteLine("Any > 3 : {0}",
                numList5.Any(x => x > 3));

            // ---------- DISTINCT ----------
            // Eliminates duplicates from a list
            var numList6 = new List<int>() { 1, 2, 3, 2, 3 };

            Console.WriteLine("Distinct : {0}",
                string.Join(", ", numList6.Distinct()));

            // ---------- EXCEPT ----------
            // Receives 2 lists and returns values not
            // found in the 2nd list
            var numList7 = new List<int>() { 1, 2, 3, 2, 3 };
            var numList8 = new List<int>() { 3 };

            Console.WriteLine("Except : {0}",
                string.Join(", ", numList7.Except(numList8)));

            // ---------- INTERSECT ----------
            // Receives 2 lists and returns values that
            // both lists have
            var numList9 = new List<int>() { 1, 2, 3, 2, 3 };
            var numList10 = new List<int>() { 2, 3 };

            Console.WriteLine("Intersect : {0}",
                string.Join(", ", numList9.Intersect(numList10)));


            #endregion

            Console.ReadLine();

        }

    }
}

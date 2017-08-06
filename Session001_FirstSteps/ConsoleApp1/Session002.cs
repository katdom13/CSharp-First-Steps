using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session002_ArraysAndLoops
{
    class Session002
    {
        public static int[] theArray; 

        static void Main(string[] args)
        {
            //IMPLICIT TYPING
            var intVal = 1234;

            Console.WriteLine("intVal Type: {0}", intVal.GetTypeCode());

            //ARRAYS
            int[] favNums = new int[3];

            //1 
            favNums[0] = 0;

            Console.WriteLine("0th index of favNums: " +favNums[0]);

            //Clear array
            Array.Clear(favNums, 0, favNums.Length);

            //2
            favNums = new int[] { 2, 3, 4, 5 };

            Console.WriteLine("0th index of favNums: " + favNums[0]);

            //var can also be used as long as the data type is the same for all elements.
            var people = new[] { "Bob", "Sue", "John","Barry" };

            Console.WriteLine("Type: " +people.GetType());
            Console.WriteLine("Type at 0th index: " +people[0].GetType());

            //Objects can have elements with different data types
            object[] objArray = {"Paul", 3.14, 'A' };

            Console.WriteLine("Array type: " +objArray.GetType());
            Console.WriteLine("Element type at 1st index: " +objArray[1].GetType());

            //Use loops to iterate through an array
            for (int i=0; i<objArray.Length; i++)
            {
                Console.WriteLine("Element {0}: {1}", i, objArray[i]);
            }

            //or use for each
            Console.WriteLine();

            int k = 0;
            foreach (object o in objArray)
            {
                Console.WriteLine("Object {0}: {1}", k, objArray[k]);
                k++;
            }

            Console.WriteLine();

            //MULTI DIMENSIONAL ARRAYS
            string[,] custNames = {
                                        {"Bob", "Smith" },
                                        {"John", "Doe" },
                                        {"Sally", "Smith" }
                                    };

            int rowCustNames = custNames.GetLength(0);
            int colCustNames = custNames.GetLength(1);

            Console.WriteLine("This is a {0} by {1} 2D Array.", rowCustNames, colCustNames);

            //print all names
            for(int i=0; i<rowCustNames; i++)
            {
                Console.Write("Row {0}: ", i);
                for(int j=0; j<colCustNames; j++)
                {
                    Console.Write(custNames[i, j] +" ");                }
                Console.WriteLine();
            }

            //3D arrays example
            //this is a 2 by 3 by 4 3D array
            int[,,] definition = {
                                        {//Zs
                                           {001, 002,003,004 },
                                           { 005, 006, 007, 008},
                                           { 009, 010, 011, 012}
                                        },
                                        {
                                           { 013, 014, 015, 016},
                                           { 017, 018, 019, 020},
                                           { 021, 022, 023, 024}
                                        }
                                    };

            int zedCount = definition.GetLength(0);
            int rowCount = definition.GetLength(1);
            int colCount = definition.GetLength(2);

            Console.WriteLine("Zedcount: " + zedCount);
            Console.WriteLine("Rowcount: " + rowCount);
            Console.WriteLine("Colcount: " + colCount);

            Console.WriteLine("Element at X == 0, Y == 1, Z == 0: " + definition[0, 0, 1]); //get 002

            //basically, a 2x3x4 is a 2 3by4 matrix
            //in theory, a 4x2x3x4 is a 4 2 3by4 matrix and so on...

            Console.WriteLine();

            //ARRAY OPERATIONS

            //default
            int[] nums = { 1, 4, 9, 2 };

            //copy
            int[] numcontainer1 = new int[nums.Length];
            nums.CopyTo(numcontainer1, 0); /*<-- 0 is destination index*/
            
            //custom method
            PrintArray(nums, "Element");

            //sort
            Array.Sort(numcontainer1);
            PrintArray(numcontainer1, "Element");

            //reverse
            Array.Reverse(numcontainer1);
            PrintArray(numcontainer1, "Element");

            //set value of element at 0th index(9) to 1;
            numcontainer1.SetValue(1, 0);
            PrintArray(numcontainer1, "Element");

            //find index of 1
            Console.WriteLine("Index of 1: {0}", Array.IndexOf(numcontainer1, 1));

            //copy part of array
            theArray = new int[5];

            Array.Copy(nums, 1, theArray, 0, 2);

            PrintArray(theArray, "theArray");

            theArray = Array.FindAll(numcontainer1, LessThanFour); /*LessThanFour is a predicate*/

            //find all that is less than 4
            Console.WriteLine("Elements in array less than 4: ");

            PrintArray(theArray, "");

            //STRINGBUILDER

            Console.WriteLine();

            //by default, a strinbuilder's size is 16 characters
            StringBuilder sb = new StringBuilder("Random Text");

            //it can be changed
            StringBuilder sb2 = new StringBuilder("More stuff that is important", 56);

            Console.WriteLine("sb Capaciy: {0}", sb.Capacity);
            Console.WriteLine("sb Length: {0}", sb.Length);

            Console.WriteLine("sb2 Capaciy: {0}", sb2.Capacity);
            Console.WriteLine("sb2 Length: {0}", sb2.Length);

            //can append
            sb2.Append("\nMore important text");
            sb2.Append(string.Concat("\n", "Best customer: ", "Norma Jean"));

            CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");

            string anotherCust = string.Concat(custNames[0, 0], " ", custNames[0, 1]);
            sb2.AppendFormat(enUS, "\nAnother Best Customer: {0}", anotherCust);

            Console.WriteLine(sb2.ToString());

            Console.WriteLine();
            Console.WriteLine("Changed \"text\" to \"characters\": ");
            sb2.Replace("text", "characters");

            Console.WriteLine(sb2.ToString());

            Console.WriteLine();
            //clear a stringbuilder
            sb2.Clear();
            Console.WriteLine(sb2.ToString());

            sb2.Append("Random Text");

            //check for equality
            Console.WriteLine("sb==sb2: {0}", sb.Equals(sb2));

            StringBuilder sb3 = new StringBuilder("Random Text");
            Console.WriteLine("sb==sb3: {0}", sb.Equals(sb3));

            sb2.Insert(sb2.Length, " That's great");
            Console.WriteLine("Inserted: " +sb2.ToString());
            //Console.WriteLine(sb.Length);

            sb2.Remove(12, 7);
            Console.WriteLine("Removed: " +sb2.ToString());
        
            Console.ReadLine();
            
        }

        private static void PrintArray(int[] nums, string message)
        {
            int z = 0;
            foreach(int i in nums)
            {
                Console.WriteLine(message +"{0} : {1}", z, nums[z]);
                z++;
            }
            Console.WriteLine();
        }
        
        private static bool LessThanFour(int value)
        {
            return value < 4;
        }

    }
}

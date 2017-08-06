using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session001_FirstSteps
{
    class Session001
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Session 001: First Steps");

            for (int i=0; i<args.Length; i++)
            {
                Console.WriteLine("Args {0} : {1}", i, args[i]);
            }

            //get array of commandline arguments;

            string[] myArgs = Environment.GetCommandLineArgs();

            Console.WriteLine(string.Join(" ", myArgs));
            
            //DATA TYPES EXAMPLE

            Console.WriteLine("Biggest Int: {0}", int.MaxValue);
            Console.WriteLine("Smallest Int: {0}", int.MinValue);

            //bools start in capital letter in C#;
            //PARSING
            bool canIvote = bool.Parse("True");
            int intFromStr = int.Parse("-19");
            double dblFromStr = double.Parse("1");
            float fltFromStr = float.Parse("1.33333");

            Console.WriteLine("Parsed bool : {0}", canIvote);
            Console.WriteLine("Parsed int : {0}", intFromStr);
            Console.WriteLine("Parsed double : {0}", dblFromStr);
            Console.WriteLine("Parsed float : {0}", fltFromStr);

            //DATETIME & TIMESPAN

            DateTime dt = new DateTime(1998, 02, 13);
            Console.WriteLine("Your datetime: {0}", dt);

            DateTime newDT = new DateTime();
            newDT = dt.AddDays(4.5);
            newDT = newDT.AddMonths(2);
            newDT = newDT.AddYears(10);

            //newDT should be April 17, 2008;
            Console.WriteLine("Your new datetime: {0}", newDT);

            TimeSpan ts = new TimeSpan(12, 30, 0);
            Console.WriteLine("Your timespan: {0}", ts);

            TimeSpan newTS = new TimeSpan();
            newTS = ts.Subtract(new TimeSpan(0, 15, 0));
            newTS = newTS.Add(new TimeSpan(1, 0, 1));
            
            //new timespan should be 13:15:01
            Console.WriteLine("Your new timespan: {0}", newTS);

            newDT = newDT.Subtract(newDT.TimeOfDay);
            newDT = newDT.AddHours(newTS.Hours);
            newDT = newDT.AddMinutes(newTS.Minutes);
            newDT = newDT.AddSeconds(newTS.Seconds);

            Console.WriteLine("Updated time of date {0}: ", newDT);

            //FORMATTING

            Console.WriteLine("Currency: {0:c}", 20.00);

            //the four after d signifies the number of digits including current
            Console.WriteLine("Pad with zeroes: {0:d4}", 23);
            Console.WriteLine("3 Decimal Places: {0:f3}", 3.141516);
            Console.WriteLine("Commas + decimals: {0:n}", 2300000);

            //STRINGS

            string randString = "This is a string";

            Console.WriteLine(string.Concat("Your String: ", randString));
            Console.WriteLine("String Length: {0}", randString.Length);

            //Check if it contains "is"
            Console.WriteLine(randString.Contains("is"));

            //get index of first occurrence of 'h'
            Console.WriteLine("First occurrence of 'h': {0}", randString.IndexOf('h'));

            //get index of first occurrence of "is"
            Console.WriteLine(string.Concat("First occurrence of \"is\": ", randString.IndexOf("is")));

            //remove number of characters (6) starting at a given index (10)
            Console.WriteLine("Removed string: {0}", randString.Remove(10, 6));

            //add a string starting at a given index
            Console.WriteLine("Added string: {0}", randString.Insert(10, "simple "));

            //replace a string with another
            Console.WriteLine("Replaced \"string\": {0}", randString.Replace("string", "sentence"));
            Console.WriteLine("Replaced \"is\": {0}", randString.Replace("is", "at"));

            //COMPARISON

            // - string1 preceeds string2
            // 0 string1 == string2
            // + string2 preceeds string1

            Console.WriteLine("Compare A to Z: {0}", 
                string.Compare("A", "Z", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("A == a: {0}", string.Compare("A", "a",
                StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Compare B to A: {0}",
                string.Compare("B", "A", StringComparison.OrdinalIgnoreCase));

            //CONSOLE INPUT

            Console.Write("Input your name: ");
            string name = Console.ReadLine();

            SayHello(name);
            SayHello();

            Console.ReadLine();

            
        }

        public static void SayHello()
        {
            Console.Write("Input your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Why hello there, " +name);
        }

        public static void SayHello(string name)
        {
            Console.WriteLine("Hello " +name);
        }

    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session011_Collections
{
    class Session011
    {
        static void Main(string[] args)
        {
            //#region provides a way to collapse blocks of code

            //ARRAYLISTS
            #region ArrayList Code

            //ArrayList can hold multiple data types
            ArrayList aList = new ArrayList();

            //add elements to a list
            aList.Add("Bob");
            aList.Add(40);

            //get number of items
            Console.WriteLine("Count: {0}", aList.Count);

            //capacity automatically increases as items are added.
            //capacity increases by 2 every add statement.

            Console.WriteLine("Capacity: {0}", aList.Capacity);

            Console.WriteLine();

            ArrayList aList2 = new ArrayList();

            //add a whole list or array to a list
            aList2.AddRange(new string[] { "Mike", "Bob", "Egg" });

            aList.AddRange(aList2);

            //print all
            Console.WriteLine("aList: ");
            PrintArray(aList);

            Console.WriteLine("aList2: ");
            PrintArray(aList2);

            //lists can only be sorted 
            //if the data types are the same

            aList2.Sort();
            aList2.Reverse();

            Console.WriteLine("Sorted aList2:");
            PrintArray(aList2);

            //insert at third position
            aList.Insert(2, "Turkey");

            Console.WriteLine("Inserted 'Turkey' at third position: ");
            PrintArray(aList);

            //get first two items and put it 
            //in another list

            ArrayList range = aList2.GetRange(0, 2);
            Console.WriteLine("Range: ");
            PrintArray(range);

            //whole aList
            PrintArray(aList);

            //remove the first item
            aList.RemoveAt(0);

            //remove first 2 items
            aList.RemoveRange(0, 2);

            Console.WriteLine("Removed some: ");
            PrintArray(aList);

            //search for a match starting at the
            //provided index (0).
            Console.WriteLine("Egg Index: {0}",
                aList.IndexOf("Egg", 0));

            //convert an array into a list
            Console.WriteLine();
            string[] customers = { "Bob", "Sally", "John" };
            ArrayList customerList = new ArrayList();
            customerList.AddRange(customers);

            Console.WriteLine("Customer list from an array: ");
            PrintArray(customerList);

            customerList.Insert(1, "Mike");
            customerList.AddRange(new string[] { "Monty", "Roman", "Dave" });

            //convert a list into an array
            string[] extendedList = (string[])
                customerList.ToArray(typeof(string));

            Console.WriteLine("Extended array of customers" +
                " from a list: ");
            PrintArray(extendedList);

            //clear a list
            aList2.Clear();

            Console.WriteLine("Empty/Cleared");
            PrintArray(aList2);
            
            #endregion

            //DICTIONARIES
            #region Dictionary Code

            //dictionaries are key value pairs
            //much like maps in java

            Dictionary<string, string> superheroes =
                new Dictionary<string, string>();

            superheroes.Add("Spiderman", "Peter Parker");
            superheroes.Add("Quicksilver", "Pietro Maximoff");
            superheroes.Add("Flash", "Wally West");

            Console.WriteLine("Initial: ");
            PrintKeyValue(superheroes);

            //remove a key value
            superheroes.Remove("Flash");
            Console.WriteLine("Removed Flash: ");
            PrintKeyValue(superheroes);

            Console.WriteLine("Count of key: {0}",
                superheroes.Count);

            Console.WriteLine();

            Console.WriteLine("Contains key Superman: {0}", 
                superheroes.ContainsKey("Superman"));
            Console.WriteLine("Contains value Peter Parker: {0}", 
                superheroes.ContainsValue("Peter Parker"));

            Console.WriteLine();

            //get the value of a key
            //and store it in a string

            superheroes.TryGetValue("Superman", out string test);

            Console.WriteLine($"Superman: {test}");
            //return empty because there is no 'Superman' key
            //in dictionar

            superheroes.TryGetValue("Spiderman", out string spiderman);

            Console.WriteLine($"Spiderman: {spiderman}");
            
            Console.WriteLine();

            //clear dictionary
            superheroes.Clear();

            #endregion

            //QUEUE
            #region Queue Code

            //Queue is FIFO

            Queue q = new Queue();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            //output queue
            PrintArray(q);

            Console.WriteLine("1 in queue: {0}", q.Contains(1));

            Console.WriteLine();

            //remove first item in queue
            Console.WriteLine("Dequeued: {0}", q.Dequeue());

            Console.WriteLine();

            //peek
            Console.WriteLine("Peek: {0}", q.Peek());

            Console.WriteLine();

            //copy queue to array
            object[] qArray = q.ToArray();

            Console.WriteLine("Queue to array: {0}", string.Join(", ", qArray));

            //clear a queue
            q.Clear();

            #endregion

            //STACKS
            #region Stack Code

            //Stack is FILO
            Stack s = new Stack();

            s.Push(1);
            s.Push(2);
            s.Push(3);

            Console.WriteLine("Stack: ");
            PrintArray(s);

            Console.WriteLine();

            Console.WriteLine("Peek: {0}", s.Peek());

            Console.WriteLine();

            //contains 2
            Console.WriteLine("Contains 2: {0}", s.Contains(2));

            Console.WriteLine();

            //remove
            Console.WriteLine("Remove: {0}", s.Pop());

            Console.WriteLine();

            //stack to array
            object[] sArray = s.ToArray();

            Console.WriteLine("Stack to array: {0}", string.Join(", ", sArray));

            #endregion

            Console.ReadLine();

        }

        //iterate through collection
        public static void PrintArray(ICollection c)
        {
            foreach(object o in c)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();
        }

        //cycle through key value pairs
        public static void PrintKeyValue(Dictionary<string, string> d)
        {
            foreach(KeyValuePair<string, string> item
                in d)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            Console.WriteLine();
        }

    }
}

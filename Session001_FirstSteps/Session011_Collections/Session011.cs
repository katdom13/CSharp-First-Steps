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


            #endregion

            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Session016_Threads
{
    class Session016
    {
        static void Main(string[] args)
        {

            /*
            #region Simple Thread

            //SIMPLE THREAD EXAMPLE

            //create a new thread and start it
            //Thread t = new Thread(Print1); //Print1 is a custom method
            Thread t = new Thread(new ThreadStart(Print1));
            t.Start();

            //Main is another thread
            //this is a code/thread in main that will run
            //side by side with 't'

            //this code runs randomly,
            //sometimes main printing 0 get executed first,
            //sometimes the Print1 method.
            for(int i=0; i<1000; i++)
            {
                Console.Write(0);
            }

            Console.WriteLine();

            #endregion

            #region Thread Sleep

            //SLEEP EXAMPLE

            int num = 1;
            for(int i=0; i<10; i++)
            {
                Console.WriteLine(num);

                //Pause for 1 second
                Thread.Sleep(1000);

                num++;
            }
            Console.WriteLine("End of Thread");

            Console.WriteLine();

            #endregion

            */

            //LOCK EXAMPLE

            //lock keeps other threads from enterin
            // a statement block until another threa
            //leaves

            BankAccount acct1 =
                new BankAccount(10);

            //instantiate threads
            Thread[] threads = new Thread[15];

            //CurrentThread gives you
            //the current running thread
            Thread.CurrentThread.Name = "main";

            //initiate 'threads' to
            //run IssueWithdraw
            for(int i=0; i<threads.Length; i++)
            {
                threads[i] =
                    new Thread(
                        new ThreadStart(acct1.IssueWithdraw));

                threads[i].Name = string.Concat("thread",
                    string.Format("{0:d2}", i));
            }

            //start all threads
            for(int i=0; i<threads.Length; i++)
            {
                //check if thread has started

                //of course initially they're not
                Console.WriteLine($"{threads[i].Name} " +
                    $"Alive : {threads[i].IsAlive}\n");
                
                threads[i].Start();

                //now they should be alive.
                Console.WriteLine($"{threads[i].Name} " +
                    $"Alive : {threads[i].IsAlive}\n");

            }

            //PASSING DATA TO THREADS

            //a workaround for pointing to
            //thread methods with arguments
            //is to use lambda expressions

            //one won't suffer thread interruption
            //when the data isn't that big.
            Thread thread = new Thread(
                    new ThreadStart(() => CountTo(100))
                );

            thread.Start();
            
            //multiline lambdas can also be used
            new Thread(
                
                () =>
                {
                    CountTo(5);
                    CountTo(6);
                }
                
                ).Start();

            //thread.Start();

            Console.ReadLine();
        }

        public static void Print1()
        {
            for(int i=0; i<1000; i++)
            {
                Console.Write(1);
            }
        }

        public static void CountTo(int to)
        {
            Console.WriteLine("Counting to {0}...", to);
            for(int i=1; i<=to; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

    }
}

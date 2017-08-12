using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Session016_Threads
{
    class BankAccount
    {
        //the lock
        private Object acctLock = new Object();
        public double Balance { get; set; }
        public string Name { get; set; }

        public BankAccount(double bal)
        {
            Balance = bal;
        }

        public double Withdraw(double amt)
        {
           
            lock (acctLock)
            {
                //this statement was merely added
                //to see the thread that runs
                //for the session016
                
                //if this statement is outside the lock,
                //it would unsync with the withdrawal.
                //that's why it is here
                Console.Write($"{Thread.CurrentThread.Name}: ");

                if (Balance >= amt)
                {
                    Balance -= amt;
                    Console.WriteLine($"Withdrew {amt} and {Balance} left in" +
                        $" account.");
                }
                else if((Balance - amt) < 0)
                {
                    Console.WriteLine($"The amount to be wihdrawn is bigger than" +
                    $" the current balance.\n" +
                    $"Current balance: {Balance}");
                }
            }

            Console.WriteLine();

            return Balance;
        }
        
        //You can only point at methods
        //without arguments and return nothing
        public void IssueWithdraw()
        {
            Withdraw(1);
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session012_GenericsAndDelegates
{
    class Session012
    {
        static void Main(string[] args)
        {
            #region Generic Collections

            //generic collections are type safe
            //and provide performance benefits
            
            List<Animal> animals = new List<Animal>();
            List<Int32> numList = new List<Int32>();

            //add an int
            numList.Add(100);
            PrintCollection<int>(numList);
            
            //add animals to animalList

            animals.Add(new Animal() { Name = "Doug" });
            animals.Add(new Animal("Sally"));

            Animal paul = new Animal("Paul");
            animals.Add(paul);
            //insert in index 2
            animals.Insert(2, new Animal() { Name = "Steve" });

            //remove at index 1
            animals.RemoveAt(1);

            Console.WriteLine("Animals: ");
            PrintCollection<Animal>(animals);

            //get animal count
            Console.WriteLine("Animal count: {0}", animals.Count);
            Console.WriteLine();

            int x = 5, y = 4;
            Animal.Swap<int>(ref x, ref y);
            Animal.GetSum<int>(x, y);

            Console.WriteLine();

            string x1 = "4", y1 = "6";
            Animal.Swap<string>(ref x1, ref y1);
            Animal.GetSum<string>(x1, y1);

            Console.WriteLine();

            Rectangle<double> rect1 = new Rectangle<double>(20, 50);
            Console.WriteLine(rect1.GetArea());

            Rectangle<string> rect2 = new Rectangle<string>("20", "50");
            Console.WriteLine(rect2.GetArea());

            #endregion

            //DELEGATE
            Console.WriteLine();

            Arithmetic add = new Arithmetic(Add);
            Arithmetic subtract = new Arithmetic(Subtract);

            Arithmetic addsub = add + subtract;

            Console.WriteLine($"6 + 10 = ");
            add(6, 10);

            Console.WriteLine($"6 - 10 = ");
            subtract(6, 10);

            Console.WriteLine();
            addsub(6, 10);

            Console.WriteLine();

            subtract = addsub - add;
            subtract(6, 10);

            Console.ReadLine();

        }

        //generic method
        //for unsure data types

        //iterate through items
        public static void PrintCollection<T>(ICollection<T> c)
        {
            foreach (T item in c)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        //generic structs
        struct Rectangle<T>
        {
            T Width { get; set; }
            T Length { get; set; }

            public Rectangle(T width, T length)
            {
                Width = width;
                Length = length;
            }

            public string GetArea()
            {
                double dblWidth = Convert.ToDouble(Width);
                double dblLength = Convert.ToDouble(Length);
                return string.Format($"{Width} * {Length} = {dblWidth * dblLength}");
            }
        }

        //delegates
        public delegate void Arithmetic(double num1, double num2);

        public static void Add(double num1, double num2)
        {
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        }

        public static void Subtract(double num1, double num2)
        {
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        }

    }
}

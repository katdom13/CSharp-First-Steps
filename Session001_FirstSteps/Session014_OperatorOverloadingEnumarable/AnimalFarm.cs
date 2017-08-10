using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session014_OperatorOverloadingEnumarable
{
    class AnimalFarm : IEnumerable
    {

        //IEnumerable provides for iteration
        //over a collection

        //hold a list of animals
        //the obective is to create your own collection
        private List<Animal> animalList =
            new List<Animal>();

        public AnimalFarm() { }
        public AnimalFarm(List<Animal> list)
        {
            this.animalList = list;
        }

        //complete with own indexer
        //to function get and set
        public Animal this[int index]
        {
            get
            {
                return (Animal)animalList[index];
            }
            set
            {
                animalList.Insert(index, value);
            }
        }

        //complete with own count function
        public int Count
        {
            //if the return statement is not inside 'get' block
            //it will throw an error
            get
            {
                return animalList.Count;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return animalList.GetEnumerator();  
        }
    }
}

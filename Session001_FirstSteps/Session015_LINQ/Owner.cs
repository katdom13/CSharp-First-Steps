using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session015_LINQ
{
    class Owner
    {
        public string Name { get; set; }
        public int OwnerID { get; set; }

        public Owner(string name = "No name")
        {
            Name = name;
        }

        public override string ToString()
        {
            return 
                $"Name: {Name}\n" +
                $"ID: {OwnerID}\n";
        }

    }
}

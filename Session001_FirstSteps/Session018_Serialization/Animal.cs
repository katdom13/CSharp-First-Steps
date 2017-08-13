using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Session018_Serialization
{
    //this defines that you want to serialize
    //this class
    //attributes are like annotation
    [Serializable()]

    //just implement the ISerializable interface
    public class Animal : ISerializable
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int AnimalID { get; set; }

        public Animal() { }
        public Animal(string name = "No name",
            double weight = 0,
            double height = 0)
        {
            Name = name;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return
                $"Name: {Name}\n" +
                $"Weight: {Weight}\n" +
                $"Height: {Height}\n" +
                $"AnimalID: {AnimalID}\n";
        }

        //Serialize functio
        //stores object data in files
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //serials are key-value pairs
            info.AddValue("Name", Name);
            info.AddValue("Weight", Weight);
            info.AddValue("Height", Height);
            info.AddValue("ID", AnimalID);
        }

        //de serialize function
        //in the form of a constructor
        public Animal(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Weight = (double)info.GetValue("Weight", typeof(double));
            Height = (double)info.GetValue("Height", typeof(double));
            AnimalID = (int)info.GetValue("ID", typeof(int));
        }

    }
}

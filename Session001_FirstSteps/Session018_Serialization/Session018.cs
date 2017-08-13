using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Session018_Serialization
{
    class Session018
    {
        static void Main(string[] args)
        {

            //create an animal object
            Animal bowser =
                new Animal("Bowser", 45, 25);

            //specify your directory
            DirectoryInfo dir =
                new DirectoryInfo(".");

            string dirpath = string.Concat(dir.Parent.Parent.FullName, @"\Extra Files");

            dir = new DirectoryInfo(dirpath);

            if (!dir.Exists)
            {
                Console.WriteLine("No directory found.\n" +
                    "Creating directory...");
                dir.Create();
            }

            //serialize the object data to a file

            //first create the portal for the file action
            Stream stream =
                File.Open(string.Concat(dirpath, "\\AnimalData.dat"), FileMode.OpenOrCreate);

            //create the binary formatter
            BinaryFormatter bf =
                new BinaryFormatter();

            //send object data to file
            //using stream portal
            bf.Serialize(stream, bowser);

            //close portal
            stream.Close();

            //delete bowser data
            bowser = null;



            //retrieve from file
            stream = File.Open(string.Concat(dirpath, @"\AnimalData.dat"), FileMode.OpenOrCreate);
            bf = new BinaryFormatter();

            //cast first
            bowser = (Animal)bf.Deserialize(stream);

            //close stream
            stream.Close();

            Console.WriteLine($"Bowser deserialized: \n" +
                $"{bowser.ToString()}");

            Console.WriteLine();

            //try with xml

            //change some values first
            bowser.Weight = 100;
            bowser.Name = "Koopa";

            XmlSerializer serializer =
                new XmlSerializer(typeof(Animal));

            using(Stream s = File.Open(string.Concat(dirpath, @"\C#Data1.dat"),
                FileMode.OpenOrCreate))
            {
                serializer.Serialize(s, bowser);
            }

            bowser = null;

            //read

            serializer = new XmlSerializer(typeof(Animal));

            using (StreamReader r = new StreamReader(string.Concat(dirpath, @"\C#Data1.dat"))){
                bowser = (Animal)serializer.Deserialize(r);
            }
            
            Console.WriteLine("Bowser deserialized in xml: ");
            Console.WriteLine(bowser.ToString());

            //SAVE A COLLECTION
            List<Animal> animalList = new List<Animal>()
            {
                new Animal("Mario", 60, 20),
                new Animal("Luigi", 50, 30),
                new Animal("Mario", 30, 25),
            };

            serializer = new XmlSerializer(typeof(List<Animal>));

            using (Stream fs = File.Open(string.Concat(dirpath, @"\C#Data2.dat"),
                FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, animalList);
            }

            animalList = null;

            //read

            serializer = new XmlSerializer(typeof(List<Animal>));

            using(StreamReader r = new StreamReader(string.Concat(dirpath, @"\C#Data2.dat")))
            {
                animalList = (List<Animal>) serializer.Deserialize(r);
            }

            Console.WriteLine("Deserialized collection: ");
            foreach(Animal a in animalList)
            {
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine();
            
            Console.ReadLine();

        }
    }
}

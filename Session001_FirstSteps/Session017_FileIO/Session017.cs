using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session017_FileIO
{
    class Session017
    {
        static void Main(string[] args)
        {

            #region Directory Operations

            //DIRECTORY OPERATIONS

            //get access to current directory
            //period => current
            DirectoryInfo currDir =
                new DirectoryInfo(".");

            //outputs 'Debug'
            Console.WriteLine("Current directory: {0}",
                currDir.Name);

            Console.WriteLine();

            //string path =
                //@"C:\Users\Kat Mem\Documents\Visual Studio 2017\Projects\CSharp Beginner\Session001_FirstSteps\Session017_FileIO\Extra Files";

            string path = string.Concat(
                new DirectoryInfo(".").Parent.Parent.FullName, @"\Extra Files"
                );

            DirectoryInfo myDir = new
                DirectoryInfo(path);

            //if the directory aove does not exist,
            //create it.
            if (!myDir.Exists)
            {
                Console.WriteLine("No directory found.\n" +
                    "Creating directory...");
                myDir.Create();
            }

            //get directory path
            Console.WriteLine("Full name: {0}",
                myDir.FullName);

            //get directory level name
            Console.WriteLine("Current level: {0}",
                myDir.Name);

            //get parent directory
            Console.WriteLine("Parent directory: {0}",
                myDir.Parent);

            //get type of object
            Console.WriteLine("Type: {0}",
                myDir.Attributes);

            //get time of creation
            Console.WriteLine("Time created: {0}",
                myDir.CreationTime);

            Console.WriteLine();

            //CREATE AND DELETE DIRECTORY

            //manipulate directory full name
            string[] pathPiece = myDir.FullName.Split('\\');
            string[] totalPath = new string[3];

            Array.Copy(pathPiece, 0, totalPath, 0, 3);
            
            //sample create
            DirectoryInfo dataDir =
                new DirectoryInfo(
                    string.Concat(string.Join(@"\", totalPath), @"\Documents\New Folder from code")
                    );

            dataDir.Create();

            //sample delete
            dataDir.Delete(true);

            #endregion


            #region FILE I/O
            //FILE READING AND WRITING

            //write a string array to a text file
            string[] customers =
            {
                "Manta Sunday",
                "Chino Sunday",
                "Thor Sunday",
                "Sif Sunday"
            };

            //specify path and filename
            string textFilePath
                = string.Concat(path, @"\testFile1.txt");

            //write the array to the text file.
            File.WriteAllLines(textFilePath, customers);

            //read lines from text file
            Console.WriteLine($"File contents: ");
            foreach(string c in File.ReadAllLines(textFilePath))
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();

            //append text file
            string[] sentence =
            {
                "\n",
                "Some new sentence."
            };

            File.AppendAllLines(textFilePath, sentence);

            Console.WriteLine("Appended sentence: ");
            foreach (string c in File.ReadAllLines(textFilePath))
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();

            //GETTING FILE DATA

            //get all txt files in a directory
            FileInfo[] txtFiles = myDir.GetFiles("*.txt",
                SearchOption.AllDirectories);

            //get number of matches
            Console.WriteLine("Matches: {0}",
                txtFiles.Length);

            //get filenames and file size
            foreach(FileInfo f in txtFiles)
            {
                Console.WriteLine($"Name: {f.Name}\n" +
                    //text => 'Archive' type
                    $"Type: {f.Attributes}\n" +
                    $"File Size: {f.Length} bytes");
            }
            Console.WriteLine();

            #endregion

            #region Playing With Bytes
            //FILESTREAMS

            //filestreams are used to read and write a byte
            //or array of bytes

            string textFilePath2 =
                string.Concat(myDir, @"\testFile2.txt");

            //check if exists
            FileInfo present =
                new FileInfo(textFilePath2);

            //if not, create one
            if (!present.Exists)
                Console.WriteLine("It does not exist yet");
            else
                Console.WriteLine("The file {0} exists and is not empty.",
                    present.Name);

            Console.WriteLine();

            //create or overwrite anyway
            FileStream fs =
                File.Open(textFilePath2, FileMode.Create);

            string randStr = "This is some random string\n" +
                "to write.";

            //convert to byte array
            byte[] randByteArray =
                Encoding.Default.GetBytes(randStr);

            //write to file by defining the byte array
            //and index to start writing
            //and length of chars to be written
            fs.Write(randByteArray, 0, randByteArray.Length);

            //get current position
            Console.WriteLine("Current cursor position: {0}",
                fs.Position);

            //reset position
            //otherwise you won't be able to read it properly
            fs.Position = 0;

            //=====reading======

            Console.WriteLine();

            //create byte array to hold data
            byte[] fileByte = new byte[
                Convert.ToByte(new FileInfo(textFilePath2).Length)
                ];
            
            //put bytes in array
            for(int i=0; i<fileByte.Length; i++)
            {
                fileByte[i] = (byte)fs.ReadByte();
            }

            //convert from byte array to string for reading
            Console.WriteLine(present.Name +": ");
            Console.WriteLine(Encoding.Default.GetString(fileByte));
            Console.WriteLine(new FileInfo(textFilePath2).Length);
            Console.WriteLine();

            fs.Close();

            #endregion

            #region StreamWriter and StreamReader

            //STREAMWRITER / STREAMREADER
            //best for reading and writing strings

            string textFilePath3 =
                string.Concat(myDir, @"\testFile3.txt");

            //create a text file
            StreamWriter sw = File.CreateText(textFilePath3);

            //streamwriters are like portals for file or other actions

            sw.Write("This is a random ");
            sw.WriteLine("sentence!");
            sw.WriteLine("This is another one");

            //close streamwriter
            sw.Close();

            //open file for reading
            StreamReader sr =
                File.OpenText(textFilePath3);

            //peek return next char as unicode number.
            //use convert to change to a char
            Console.WriteLine("Peek: {0}", 
                Convert.ToChar(sr.Peek()));

            //read
            Console.WriteLine("1st char: {0}",
                sr.Read());

            //read the rest
            Console.WriteLine("Everything else: {0}",
                sr.ReadToEnd());

            sr.Close();

            Console.WriteLine();

            //append the file
            StreamWriter sw2 = File.AppendText(textFilePath3);

            sw2.Write("Hey I am ");
            sw2.WriteLine("appending this text file ;)");

            sw2.Close();

            //read again
            Console.WriteLine("Appended stream: ");
            StreamReader sr2 = File.OpenText(textFilePath3);

            Console.WriteLine(sr2.ReadToEnd());

            sr2.Close();

            //Console.WriteLine(myDir.FullName);

            #endregion

            #region BinaryWriter and BinaryReader

            //BINARYWRITER / BINARYREADER
            //used to read and write data types

            //file type is dat
            string textFilePath4 =
                string.Concat(myDir, @"\testFile4.dat");

            //get file
            FileInfo datFile = new FileInfo(textFilePath4);

            //open file
            BinaryWriter bw =
                new BinaryWriter(datFile.OpenWrite());

            //data to save to the file
            string randText = "Random text";
            int myAge = 19;
            double height = 5.2;

            //write data to file
            bw.Write(randText);
            bw.Write(myAge);
            bw.Write(height);
            bw.Write("Sample");

            //close
            bw.Close();

            //read

            //open file for reading this time
            BinaryReader br =
                new BinaryReader(datFile.OpenRead());

            //output data

            //data should be read in the order
            //they were written
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadDouble());
            Console.WriteLine(br.ReadString());

            br.Close();

            Console.WriteLine();

            //append the file

            BinaryWriter bw2 =
                new BinaryWriter(datFile.Open(FileMode.Open));

            bw2.Write(10001);
            bw2.Write("Space Odyssey");

            bw2.Close();

            //read again
            BinaryReader br2 =
                new BinaryReader(datFile.OpenRead());

            //reads only the appended item
            Console.WriteLine(br2.ReadString());

            //custom data types will be covered by serialization
            //next session

            br2.Close();

            #endregion
            
            Console.ReadLine();

        }
    }
}

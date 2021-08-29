using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region FileStream
            FileStream F = new FileStream("test.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            for (int i = 0; i < 20; i++)
            {
                F.WriteByte((byte)i);
            }
            F.Position = 0;
            for (int i = 0; i < 20; i++)
            {
                Console.Write(F.ReadByte() + " ");
            }
            F.Close();
            Console.WriteLine("");
            #endregion

            #region StreamReader and StreamWriter
            try
            {
                List<string> names = new List<string> { "Pran", "Pratik" };
                using (StreamWriter sw = new StreamWriter("Example.txt"))
                {
                    foreach (string item in names)
                        sw.WriteLine(item);
                    {

                    }
                }

                //using closes the streamreader when the block is over
                using (StreamReader sr = new StreamReader("Example.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region Binary Reader
            int num = 25;
            double d = 3.14;
            bool b = true;
            string s = "Hello";

            BinaryReader br;
            BinaryWriter bw;

            try
            {
                bw = new BinaryWriter(new FileStream("mydata", FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
                return;
            }

            try
            {
                bw.Write(num);
                bw.Write(d);
                bw.Write(b);
                bw.Write(s);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot write to file.");
                return;
            }
            bw.Close();

            try
            {
                br = new BinaryReader(new FileStream("mydata", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }

            try
            {
                num = br.ReadInt32();
                Console.WriteLine("Integer data: {0}", num);
                d = br.ReadDouble();
                Console.WriteLine("Double data: {0}", d);
                b = br.ReadBoolean();
                Console.WriteLine("Boolean data: {0}", b);
                s = br.ReadString();
                Console.WriteLine("String data: {0}", s);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read from file.");
                return;
            }
            br.Close();
            #endregion

            #region Directory
            DirectoryInfo directoryInfo = new DirectoryInfo(@"./");
            FileInfo[] f = directoryInfo.GetFiles();
            foreach (FileInfo file in f)
            {
                Console.WriteLine("File Name: {0} Size: {1}", file.Name, file.Length);
            }

            Console.ReadLine();
            #endregion


        }
    }
}

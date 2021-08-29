using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotNetFileIO
{
    class SerialDemo
    {
        public void SerializeNow(ClassToSerialize c)
        {
            FileStream f = new FileStream("Stemp.dat",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, c);
            f.Close();
        }
        public void DeserializeNow()
        {
            ClassToSerialize c = new ClassToSerialize();
            FileStream f = new FileStream("Stemp.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            c = (ClassToSerialize)b.Deserialize(f);
            Console.WriteLine(c);
            f.Close();
        }
        public void SerializeNowXml(ClassToSerialize c)
        {
            FileStream f = new FileStream("Stemp.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer x = new XmlSerializer(typeof(ClassToSerialize));
            x.Serialize(f, c);
            f.Close();
        }
        public void DeserializeNowXml()
        {
            FileStream f = new FileStream("Stemp.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer x = new XmlSerializer(typeof(ClassToSerialize));
            ClassToSerialize c;
            c = (ClassToSerialize)x.Deserialize(f);
            Console.WriteLine(c);
        }
        static void Main(string[] args)
        {
            SerialDemo sd = new SerialDemo();
            ClassToSerialize c = new ClassToSerialize
            {
                Age = 20,
                Name = "Pratik"
            };
            //sd.SerializeNow(c);
            //sd.DeserializeNow();
            sd.SerializeNowXml(c);
            sd.DeserializeNowXml();
            Console.ReadLine();
        }
    }
    [Serializable]
    public class ClassToSerialize
    {
        public int Age { get; set; }
        public string Name { get; set; }        
        public override string ToString()
        {
            return string.Format($"Age: {Age} Name: {Name}");
        }
    }
}

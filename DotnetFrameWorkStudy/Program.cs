using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DotnetFrameWorkStudy
{
    [Serializable]
    public struct Data
    {
        public int dataInt;
        public float dataFloat;
        public string dataString;
    }

    public class TestClass
    { 
        public TestClass()
        {

        }

        ~TestClass()
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Data[] data = new Data[2];
            
            data[0].dataInt = 1;
            data[0].dataFloat = 3.14f;
            data[0].dataString = "Test1";

            data[1].dataInt = 2;
            data[1].dataFloat = 6.28f;
            data[1].dataString = "Test2";

            using (FileStream fs1 = new FileStream("SerializeData.txt", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs1, data);
            }

            Data[] tempArr;

            using (FileStream fs2 = new FileStream("SerializeData.txt", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                tempArr = (Data[])bf.Deserialize(fs2);
            }

            foreach(Data tempData in tempArr)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"dataInt : {tempData.dataInt}");
                sb.AppendLine($"dataFloat : {tempData.dataFloat}");
                sb.AppendLine($"dataString : {tempData.dataString}");
                Console.WriteLine(sb.ToString());
            }
        }
    }
}

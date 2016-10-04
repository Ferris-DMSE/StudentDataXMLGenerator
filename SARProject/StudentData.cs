using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization;

namespace StudentDataXMLGenerator
{
    [DataContract]
    public class StudentData
    {
        private List<Student> studentList = new List<Student>();
        private const string FILEPATH = "..\\..\\ExampleXMLResults\\studentDataList.xml";
        
        [DataMember (Order = 0)]
        public List<Student> StudentDirectory
        {
            get { return studentList; }
            set { studentList = value; }
        }

        public static bool FileExists
        {
            get
            {
                if (File.Exists(FILEPATH))
                {
                    return true;
                }
                return false;
            }
        }

        public static string RelativePath
        {
            get { return FILEPATH; }
        }

        public StudentData() { }

        public void Save()
        {
            var settings = new XmlWriterSettings { Indent = true };
            try
            {
                using (var writer = XmlWriter.Create(FILEPATH,settings))
                {
                    var serializer = new DataContractSerializer(typeof(StudentData));
                    serializer.WriteObject(writer, this);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static StudentData Load()
        {
            StudentData data;
            var deserializer = new DataContractSerializer(typeof(StudentData));

            try
            {
                if (!System.IO.File.Exists(FILEPATH))
                {
                    return null;
                }

                using (Stream stream = File.OpenRead(FILEPATH))
                {
                    data = (StudentData)deserializer.ReadObject(stream);
                }

                return data;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }


    }
}

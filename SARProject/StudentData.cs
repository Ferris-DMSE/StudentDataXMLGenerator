using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentDataXMLGenerator
{
    public class StudentData
    {
        private List<Student> studentList = new List<Student>();
        private const string FILEPATH = "..\\..\\ExampleXMLResults\\studentDataList.xml";

        public List<Student> StudentDirectory
        {
            get { return studentList; }
            set { studentList = value; }
        }

        public bool FileExists
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

        public StudentData() { }

        public void Save()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(StudentData));
                writer = new StreamWriter(FILEPATH, false);
                serializer.Serialize(writer, this);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
                if (writer != null)
                    writer.Close();
            
        }

        public static StudentData Load()
        {
            var serializer = new XmlSerializer(typeof(StudentData));
            TextReader reader = null;
            try
            {
                if (System.IO.File.Exists(FILEPATH))
                {
                    reader = new StreamReader(FILEPATH, false);
                    return serializer.Deserialize(reader) as StudentData;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }        
        }


    }
}

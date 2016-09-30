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
        private const string FILEPATH = @"C:\Users\USER\Dropbox\CSharp\SARProject\SARProject\ExampleXMLResults\studentDataList.xml";

        public List<Student> StudentDirectory
        {
            get { return studentList; }
            set { studentList = value; }
        }

        public StudentData() { }

        public void Save()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer( StudentDirectory.GetType());
                writer = new StreamWriter(FILEPATH, false);
                serializer.Serialize(writer, StudentDirectory);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
                if (writer != null)
                    writer.Close();
            
        }

        public static List<Student> Load()
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            TextReader reader = null;
            try
            {
                if (System.IO.File.Exists(FILEPATH))
                {
                    reader = new StreamReader(FILEPATH, false);
                    return serializer.Deserialize(reader) as List<Student>;
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

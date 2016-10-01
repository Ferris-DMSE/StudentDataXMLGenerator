using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using RandomNameGenerator;


namespace StudentDataXMLGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Random randomObj = new Random();


            //If file exists, and everything loads correctly...
            StudentData studentData = StudentData.Load();

            if (studentData != null)
            {
                Console.WriteLine("Student Data Loaded. \n");
                foreach (var item in studentData.StudentDirectory)
                {
                    Console.WriteLine(item.FirstName + ", " + item.LastName);
                }
            }

            //Make new everything.
            else
            {
                studentData = generateStudentData(randomObj);
                Console.WriteLine("Students generated and exported to xml file.");
            }

            Console.WriteLine("Input a name to search for.");
            string userInput = Console.ReadLine().ToUpper();
                        
            
            var query = from s in studentData.StudentDirectory
                        where s.FirstName == userInput || s.LastName == userInput
                        select s;

            if (query.Count() == 0)
                Console.WriteLine("Nothing Found");

            foreach (Student student in query)
            {
                Console.WriteLine();//newline
                Console.WriteLine(student.FirstName + ", " + student.LastName);
                foreach (Course course in student.CoursesRegistered)
                {
                    Console.WriteLine(course.ToString());
                }
            }
            Console.ReadKey();

        }

        private static StudentData generateStudentData(Random r)
        {
            List<Student> studentData = new List<Student>();
            for (int i = 0; i < 50; i++)
            {
                studentData.Add(new Student(NameGenerator.GenerateFirstName((Gender)r.Next(2)), NameGenerator.GenerateLastName()));
            }
            foreach (Student s in studentData)
            {
                int randomNumberOfClasses = r.Next(2, 15);
                for (int i = 0; i < randomNumberOfClasses; i++)
                {
                    Course newCourse = RandomCourseGenerator.GenerateCourse();
                    s.CoursesRegistered.Add(newCourse);
                }

            }
            StudentData sd = new StudentData();
            sd.StudentDirectory = studentData;
            sd.Save();
            return sd;
        }
    }
}

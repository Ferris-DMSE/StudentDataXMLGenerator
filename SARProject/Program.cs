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
            //Random object needed to help generate random values in the generator.
            Random randomObj = new Random();
            //Student Data object for the program.
            StudentData studentData;


            Console.WriteLine("Welcome to the Student Data XML Generator.");
            Console.WriteLine();
            Console.WriteLine("To generate a new Student Data XML file, please enter the number 1.\n" +
                "To view the last generated Student Data XML file, please enter the number 2.\n" +
                "To exit the application, please enter the letter q or spell out quit.");
            Console.Write("Enter value here: ");
            string userInput = Console.ReadLine();


            if (userInput == "1")
            {
                //Generate new Student Data XML File
            }
            else if (userInput == "2")
            {
                //Load up and display last known xml file
                //Make sure to handle if there is no file but the user still selected this option.
                if (StudentData.FileExists)
                {
                    studentData = StudentData.Load();
                }
                else
                {
                    Console.WriteLine("There is no previous XML file. Perhaps someone deleted it or this is the first time creating the file?");
                    Console.WriteLine("Would you like to create a new file now? y = yes, n = no");
                    Console.Write("(y,n): ");
                    
                }
            }
            else if (userInput.ToUpper() == "Q" || userInput.ToUpper() == "QUIT")
            {
                return; //exits the main method and quits the application.
            }





            //If file exists, and everything loads correctly...
            studentData = StudentData.Load();

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



        //    //Old query information I'm not ready to delete yet.

        //    Console.WriteLine("Input a name to search for.");
        //    string userInput = Console.ReadLine().ToUpper();
                        
            
        //    var query = from s in studentData.StudentDirectory
        //                where s.FirstName == userInput || s.LastName == userInput
        //                select s;

        //    if (query.Count() == 0)
        //        Console.WriteLine("Nothing Found");

        //    foreach (Student student in query)
        //    {
        //        Console.WriteLine();//newline
        //        Console.WriteLine(student.FirstName + ", " + student.LastName);
        //        foreach (Course course in student.CoursesRegistered)
        //        {
        //            Console.WriteLine(course.ToString());
        //        }
        //    }
        //    Console.ReadKey();

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentDataXMLGenerator
{
    public static class RandomCourseGenerator
    {
        enum CourseType { GeneralEducation, Elective, Core }
        enum Semester { Fall, Spring, Summer}

        static string FILEPATH = @"..\..\GenEdID.txt";
        static Random r = new Random();

        public static Course GenerateCourse()
        {
            
            Course course = new Course();

            course.CourseNumber = generateCourseNumbers();

            course.Name = generateCourseName(course.CourseNumber);

            course.CourseType = generateCourseType((CourseType)r.Next(3));

            course.Credits = r.Next(6);

            course.Grade = generateGrades();

            course.Semester = generateSemester((Semester)r.Next(3));

            course.Year = r.Next(2000, DateTime.Now.Year + 1);

            return course;
        }

        private static string generateSemester(Semester sem)
        {
            switch (sem)
            {
                case Semester.Fall:
                    return "Fall";
                case Semester.Spring:
                    return "Spring";
                case Semester.Summer:
                    return "Summer";
                default:
                    return "Something went wrong";
            }
        }

        private static string generateGrades()
        {
            
            int randomGrade = r.Next(7);
            switch (randomGrade)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "I";
                case 6:
                    return "W";

                default:
                    return "Something went wrong";
            }



        }

        private static string generateCourseType(CourseType courseType)
        {
            switch (courseType)
            {
                case CourseType.GeneralEducation:
                    return "General Education";
                case CourseType.Elective:
                    return "Elective";
                case CourseType.Core:
                    return "Core";
                default:
                    return "Something Messed up";
            }
        }

        public static string generateCourseName(string courseID)
        {
            
            string courseName = "";

            switch (courseID.Substring(0,4))
            {
                case "ANHH":
                    courseName = "Intro Physical Anthropology";
                    break;
                case "ARCH":
                    courseName = "Intro to Archaeology";
                    break;
                case "ARTS":
                    courseName = "Art History";
                    break;
                case "BIOL":
                    courseName = "Science of the Human Body";
                    break;
                case "CHEM":
                    courseName = "All We Eat Is Chemicals, A Guide To Knowing That Chemicals Are Alright";
                    break;
                case "ECON":
                    courseName = "Principles of MicroEconomics";
                    break;
                case "FILM":
                    courseName = "Introduction to Many Moving Still Pictures";
                    break;
                case "FREN":
                    courseName = "French, the language of romance";
                    break;
                case "GEOG":
                    courseName = "Intro to Rock Studies";
                    break;
                case "GERM":
                    courseName = "DEUTSCHLAND!";
                    break;
                case "HISH":
                    courseName = "HISH???";
                    break;
                case "HIST":
                    courseName = "History of Science and Racism";
                    break;
                case "HUMH":
                    courseName = "Human Sciences";
                    break;
                case "HUMN":
                    courseName = "Human Services";
                    break;
                case "HVAC":
                    courseName = "How to make your homes cold and hot";
                    break;
                case "LANG":
                    courseName = "English and how it's overly complicated";
                    break;
                case "LITH":
                    courseName = "How to read too far into an authors words";
                    break;
                case "LITR":
                    courseName = "Who Likes Literature? This guy!";
                    break;
                case "MFGE":
                    courseName = "Manufacturing and Engineering";
                    break;
                case "MKTG":
                    courseName = "Human Knowledge of Marketing";
                    break;
                case "MUSI":
                    courseName = "Music you don't care about because we need a class in music";
                    break;
                case "PHIL":
                    courseName = "Arguements you can't win, A philosophy Introduction.";
                    break;
                case "PHOT":
                    courseName = "Photography Basics, Just take pictures";
                    break;
                case "PHYS":
                    courseName = "General Physics 1";
                    break;
                case "PLSC":
                    courseName = "WTF is PLSC?";
                    break;
                case "PSYC":
                    courseName = "Intro to Psychology, where everyone is some sort of crazy";
                    break;
                case "RELG":
                    courseName = "Comparative Religions";
                    break;
                case "SOCY":
                    courseName = "Sociology, why it isn't a made up science";
                    break;
                case "SPAN":
                    courseName = "Why Spanish isn't the end of the world";
                    break;
                case "SSCI":
                    courseName = "SUPER FUN CLASS TIME";
                    break;
                case "THTR":
                    courseName = "Why THESPIAN isn't a bad word";
                    break;
                case "WGST":
                    courseName = "WHAT IS WGST?";
                    break;
                default:
                    courseName = "Some Kind of Error, An Introduction";
                    break;
            }
            return courseName;
        }

        public static string generateCourseNumbers()
        {
            List<string> courseIDs = new List<string>();

            var textLines = File.ReadAllLines(FILEPATH);
            foreach (var line in textLines)
            {
                string[] idArray = line.Split(',');
            
                foreach (var item in idArray)
                {
                    courseIDs.Add(item);
                }
            }

            

            int range = courseIDs.Count;
            int index = r.Next(range);
            return courseIDs[index] + "-" + r.Next(100, 1000).ToString();
        }

        
    }

   
}

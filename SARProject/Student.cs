using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataXMLGenerator
{

    /* 
     * */
    public class Student
    {
        private static int studentIDCount = 100001;

        #region Constructors

        public Student(string firstName, string lastName)
        {
            //Assign unique value based on static class level incremented id field.
            id = studentIDCount;
            studentIDCount++;

            this.firstName = firstName;
            this.lastName = lastName;
            coursesRegistered = new List<Course>();
            

        }

        public Student() { }


        #endregion

        private string firstName;
        private string lastName;
        private int id;
        private List<Course> coursesRegistered;

        #region Properties

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Count() <= 30)
                {
                    firstName = value;
                }
            }

        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Count() <= 30)
                {
                    lastName = value;
                }
            }

        }

        public List<Course> CoursesRegistered
        {
            get { return coursesRegistered; }
            set { coursesRegistered = value; }
        }

        #endregion

    }
}

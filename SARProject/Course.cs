using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataXMLGenerator
{
    public class Course
    {
        private static int uniqueID = 1000;

        #region Constructors

        
        public Course() { uniqueID++; }

        #endregion

        #region Public Properties

        public int UniqueID { get { return uniqueID; } private set { uniqueID = value; } }
        public string CourseNumber { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string Semester { get; set; }
        public string CourseType { get; set; }
        public string Grade { get; set; }


        #endregion

        public override string ToString()
        {
            return CourseNumber + "\n" +
                Name + "\n" +
                Credits.ToString() + "\n" +
                Semester + "\n" +
                CourseType + "\n" +
                Grade + "\n";
        }

    }
}

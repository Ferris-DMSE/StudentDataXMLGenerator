using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataXMLGenerator
{
    public class Course
    {
        #region Constructors

        #endregion

        #region Public Properties

        public string ID { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string Semester { get; set; }
        public string CourseType { get; set; }
        public string Grade { get; set; }


        #endregion

        public override string ToString()
        {
            return ID + "\n" +
                Name + "\n" +
                Credits.ToString() + "\n" +
                Semester + "\n" +
                CourseType + "\n" +
                Grade + "\n";
        }

    }
}

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

        #region Private Fields

        private string id;
        private string name;
        private int credits;
        private string semester;
        private string courseType;
        private string grade;

        #endregion

        #region Public Properties

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Credits
        {
            get { return credits; }
            set { credits = value; }
        }

        public string Semester
        {
            get { return semester; }
            set { semester = value; }
        }

        public string CourseType
        {
            get { return courseType; }
            set { courseType = value; }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

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

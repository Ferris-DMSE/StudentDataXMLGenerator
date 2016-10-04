using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace StudentDataXMLGenerator
{
    [DataContract]
    public class Course
    {
        #region Class Level Variables

        private static int uniqueID = 1000;

        #endregion

        #region Constructors

        public Course() { uniqueID++; }

        #endregion

        #region Public Properties

        [DataMember(Order = 0)]
        public int UniqueID { get { return uniqueID; } private set { uniqueID = value; } }

        [DataMember(Order = 1)]
        public string CourseNumber { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public int Credits { get; set; }

        [DataMember(Order = 4)]
        public int Year { get; set; }

        [DataMember(Order = 5)]
        public string Semester { get; set; }

        [DataMember(Order = 6)]
        public string CourseType { get; set; }

        [DataMember(Order = 7)]
        public string Grade { get; set; }


        #endregion

        //public override string ToString()
        //{
        //    return CourseNumber + "\n" +
        //        Name + "\n" +
        //        Credits.ToString() + "\n" +
        //        Semester + "\n" +
        //        CourseType + "\n" +
        //        Grade + "\n";
        //}

    }
}

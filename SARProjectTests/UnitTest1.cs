using System;
using Xunit;
using StudentDataXMLGenerator;



namespace StudentDataXMLGeneratorTests
{
    
    public class SARModelTests
    {
        [Fact]
        public void True()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Student_Initialize_Test()
        {
            //arrange
            string firstName = "Mike";

            //Act
            Student mike = new Student("Mike", "Manley");

            //assert
            Assert.Equal(firstName, mike.FirstName);
        }

        [Fact]
        public void StudentStorage_Initialize_WithStudent()
        {
            //Arrange
            Student mike = new Student("Mike", "Manley");
            Student brian = new Student("Brian", "Manley");

            //Act
            StudentData students = new StudentData();
            students.StudentDirectory.Add(mike);
            students.StudentDirectory.Add(brian);

            //Assert
            Assert.Equal(2, students.StudentDirectory.Count);
            Assert.Equal("Mike", students.StudentDirectory[0].FirstName);
        }

        [Fact]
        public void StudentStorage_Save_WithStudent()
        {
            //Arrange
            Student mike = new Student("Mike", "Manley");
            Student brian = new Student("Brian", "Manley");
            StudentData students = new StudentData();
            students.StudentDirectory.Add(mike);
            students.StudentDirectory.Add(brian);

            //Act

            students.Save();

            //Assert
            Assert.Equal(2, students.StudentDirectory.Count);
            Assert.Equal("Mike", students.StudentDirectory[0].FirstName);
        }


    }
}

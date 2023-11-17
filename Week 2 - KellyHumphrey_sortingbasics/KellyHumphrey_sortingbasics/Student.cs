using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KellyHumphrey_sortingbasics
{
    public  class Student : IComparable<Student>
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CourseID { get; set; }
        public double CourseGrade { get; set; }

        


        public Student(int studentID, string lastName, string firstName, string counselID, double courseGrade)
        {
            this.StudentID = studentID;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.CourseID = counselID;
            this.CourseGrade = courseGrade;
        }

        public static List<Student> getTestStudents()
        {
            // For testing purposes some duplicate student infomation will be used.

            List<Student> students = new List<Student>();
            students.Add(new Student(1, "Jones", "Joan", "art0024", 3.0));
            students.Add(new Student(2, "Einstein", "Jose", "math0001", 3.3));
            students.Add(new Student(5, "Gonzales", "Miranda", "cs0024", 2.7));
            students.Add(new Student(4, "Lee", "Kim", "bs0024", 2.7));
            students.Add(new Student(3, "Jaspers", "Rachel", "cs0001", 2.7));
            students.Add(new Student(6, "gates", "Bill", "cs0001", 4.0));
            students.Add(new Student(6, "Gates", "Bill", "art0024", 3.0));
            students.Add(new Student(6, "Gates", "bill", "art0024", 1.0));
            students.Add(new Student(7, "Allison", "George", "math0023", 2.7));
            students.Add(new Student(7, "Allison", "Alice", "cs0001", 2.7));
            students.Add(new Student(8, "Sills", "Carol", "cs0001", 1.7));
            students.Add(new Student(8, "Sills", "Albert", "cs0001", 2.7));
            students.Add(new Student(9, "Starr", "Bert", "chem0020", 3.7));
            return students;
        }

        public override string ToString()
        {
            string studentData = string.Format ("{0,-16}{1,-16}{2,-16}{3,-16}{4,-16}", StudentID,LastName, FirstName, CourseID, CourseGrade);
            return studentData;
        }

        public static string ColumnHeader()
        {
            string header = string.Format("{0,-16}{1,-16}{2,-16}{3,-16}{4,-16}","Student ID","Last Name", "First Name", "Course ID", "Course Grade");
            return header;
        }

        public static string SortTitle(string sortType)
        {
            return sortType;
        }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;    

            if (string.Compare(LastName.ToUpper(), other.LastName.ToUpper()) == 0)
            {
                return string.Compare(FirstName.ToUpper(), other.FirstName.ToUpper());
            }
            else
            {
                return string.Compare(LastName.ToUpper(), other.LastName.ToUpper());
            }
        }

    }
}

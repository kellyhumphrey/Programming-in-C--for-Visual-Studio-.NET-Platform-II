using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KellyHumphrey_sortingbasics
{
    public class StuSortCourseGradeLastFirst : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if(x.CourseGrade.CompareTo(y.CourseGrade) == 0)
            {
                if(x.LastName.CompareTo(y.LastName) == 0)
                {
                    return x.FirstName.CompareTo(y.FirstName);
                }
                else
                {
                    return x.LastName.CompareTo(y.LastName);
                }
            }
            else
            {
                return x.CourseGrade.CompareTo(y.CourseGrade);
            }

        }

        
    }
}

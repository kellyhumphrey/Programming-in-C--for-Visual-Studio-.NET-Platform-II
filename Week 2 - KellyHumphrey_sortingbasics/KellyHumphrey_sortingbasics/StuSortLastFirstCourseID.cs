using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KellyHumphrey_sortingbasics
{
    public class StuSortLastFirstCourseID : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.LastName.ToUpper().CompareTo(y.LastName.ToUpper()) == 0)
            {
                if (x.FirstName.ToUpper().CompareTo(y.FirstName.ToUpper()) == 0)
                {
                    return x.CourseID.ToUpper().CompareTo(y.CourseID.ToUpper());
                }
                else
                {
                    return x.FirstName.ToUpper().CompareTo(y.FirstName.ToUpper());
                }
            }
            else
            {
                return x.LastName.ToUpper().CompareTo(y.LastName.ToUpper());
            }

        }
    }
}

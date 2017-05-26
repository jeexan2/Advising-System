using CoreDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvisingSystemAssignment.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Course> Courses { get; set; }
        public User User { get; set; }
    }
}
using CoreDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvisingSystemAssignment.Models
{
    public class DepartmentPageModel
    {
        List<Department> Departments { get; set; }
        List<Course> Courses { get; set; }
    }
}
using CoreDomain.Domain;
using Domain.DepartmentDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvisingSystemAssignment.Models
{
    public class DeptViewModel
    {
        
        public List<Department> DeptList { get; set; }
        public Department dept { get; set; }

       
    }
}
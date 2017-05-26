using CoreDomain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvisingSystemAssignment.Models
{
    public class CourseModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Course Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Subject Code Required")]
        public string Code { get; set; }
        [Required(ErrorMessage ="Enter the Credit of the Course")]
        public double Credit { get; set; }
        public Department Dept { get; set; }
    }
}
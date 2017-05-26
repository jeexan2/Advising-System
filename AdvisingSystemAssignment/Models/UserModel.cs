using CoreDomain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdvisingSystemAssignment.Models
{
    public class UserModel
    {
        /** 
         public int Id { get; set; }
         [Required(ErrorMessage ="First Name is required!")]
         public string FirstName { get; set; }
         [Required(ErrorMessage = "Last Name is required!")]
         public string LastName { get; set; }
         [Required(ErrorMessage = "Email is required!")]
         public string Email { get; set; }
         [Required(ErrorMessage = "Password is required!")]
         public string Password { get; set; }**/
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required!")]
        public string LastName { get; set; }
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string PassWord { get; set; }
        public virtual IList<Department> Departments { get; set; }
        public string UserRole { get; set; }

        //public virtual IList<Department> Departments { get; set; }
        //public string UserRole { get; set; }
        //public string Status { get; set; }


    }
}
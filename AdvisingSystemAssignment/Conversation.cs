using AdvisingSystemAssignment.Models;
using CoreDomain.Domain;
using Domain.DepartmentDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvisingSystemAssignment
{
    public static class Conversation
    {
        public static UserModel UserConv(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StudentId = user.StudentId,
                PassWord = user.PassWord,
                Departments = user.Departments,
                UserRole = user.UserRole

            };
        }
        public static User UserModelConv(UserModel user)
        {
            return new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StudentId = user.StudentId,
                PassWord = user.PassWord,
                Departments = user.Departments,
                UserRole = user.UserRole,
              
            };
        }
        public static DepartmentModel DeptConv(Department dept)
        {
            return new DepartmentModel
            {
                Id = dept.Id,
                Name = dept.Name,
                Courses = dept.Courses,
            };
        }
        public static Department DeptModelConv(DepartmentModel dept)
        {
            return new Department
            {
                Id = dept.Id,
                Name = dept.Name,
                Courses = dept.Courses,
            };
        }
        public static CourseModel CourseConv(Course course)
        {
            return new CourseModel
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit
            };
        }
        public static Course CourseModelConv(CourseModel course)
        {
            return new Course
            {
                Id = course.Id,
                Name = course.Name,
                Code = course.Code,
                Credit = course.Credit
            };
        }
        public static List<DeptListModel> DeptListConv(List<Department> Depts)
        {
            //Depts = DepartmentQuery.DeptList();
            List<DeptListModel> retdepts = new List<DeptListModel>();
            
            foreach(var dept in Depts)
            {
                DeptListModel rDept = new DeptListModel {
                    Name = dept.Name,
                    Id = dept.Id
                };
                retdepts.Add(rDept);
            }
            return retdepts;
        }
    }
}
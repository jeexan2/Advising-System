using AdvisingSystemAssignment.Models;
using CoreDomain.Domain;
using Domain.CourseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvisingSystemAssignment.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateCourse(CourseModel course)
        {
            Course _course = Conversation.CourseModelConv(course);
         //   if (!ModelState.IsValid)
           //     return View("Create", _course);
            try
            {
                if (ModelState.IsValid)
                {
                    CourseQuery.Creator(_course);
                }
                return View(_course);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            
        }
    }
}
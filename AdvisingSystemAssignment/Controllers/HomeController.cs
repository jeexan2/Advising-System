using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdvisingSystemAssignment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {      
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       [Authorize(Roles ="Student")]
        public ActionResult DashBoard()
        {
          
            return View(Domain.CourseDAL.CourseQuery.CourseList());
        }
        [Authorize(Roles="Admin")]
        public ActionResult StudentList()
        {
            return View(Domain.UserDAL.UserQuery.UsersList());
        }
        [Authorize(Roles="Admin")]
        public ActionResult DepartmentPage()
        {
            return View();
        }
    }
}
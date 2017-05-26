using AdvisingSystemAssignment.Models;
using CoreDomain.Domain;
using Domain.DepartmentDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvisingSystemAssignment.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            List<Department> Dept = new List<Department>();
            Dept = DepartmentQuery.DeptList();
            return View(Dept);
        }
       
        public ActionResult Show()
        {
            List<DeptListModel> depts = new List<DeptListModel>();
            depts = Conversation.DeptListConv(DepartmentQuery.DeptList());
            return View(depts);

        }
        public ActionResult DeptCreator(DepartmentModel dept)
        {
          
            Department _dept = Conversation.DeptModelConv(dept);
            if (!ModelState.IsValid)
                return View("Create", _dept);
            try
            {
                if (ModelState.IsValid)
                {
                    DepartmentQuery.Creator(_dept);
                }
                return View(_dept);
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
        
        [AllowAnonymous]
      
        
        public ActionResult DeptPage()
        {
            Department d = new Department();

            DeptViewModel tdept = new DeptViewModel
            {
                DeptList = DepartmentQuery.DeptList(),
                dept = new Department()
             };
            
            return View(tdept);
        }
        public ActionResult DeptCreate(Department dept)
        {
            
          
            
                DepartmentQuery.Creator(dept);

            return RedirectToAction("DeptPage", "Department");
            
        }
        [HttpPost]
       public ActionResult PartialViewDemo()
        {
            return PartialView(DepartmentQuery.DeptList());
        }
        public void Save(Department dept)
        {
            DepartmentQuery.Creator(dept);
        }
    }
}
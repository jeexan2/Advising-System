using AdvisingSystemAssignment.Models;
using CoreDomain;
using CoreDomain.Domain;
using Domain.UserDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;

namespace AdvisingSystemAssignment.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View(UserQuery.UsersList());
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            User _user = Conversation.UserModelConv(user);
           
            if (!ModelState.IsValid)
                return View("Create", _user);
            try
            {
                if (ModelState.IsValid)
                {
                    
                    UserQuery.Registration(_user);
                    ModelState.Clear();
                    ViewBag.Message = _user.FirstName + " " + _user.LastName + "  Successfully Registered!";
                }
                return View(_user);
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
        /** public ActionResult Login()
         {
             if (!ModelState.IsValid)
                 return View();
              

         }**/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            User _user = Conversation.UserModelConv(user);
           // ViewBag.Message = _user.FirstName + " " + _user.LastName + "  Successfully LoggedIn!";
           
            ViewBag.Message = _user.FirstName + " " + _user.LastName + "  Successfully LoggedIn2!";
            if (_user != null)
            {
                _user = UserQuery.LoginQuery(_user);
               if(_user!=null){
                   if(_user.UserRole != "Admin") Domain.UserAuthentication.Authentication.SaveAuthenticationInformation(_user.StudentId, _user.FirstName, "Student", true);
                   else if(_user.UserRole == "Admin") Domain.UserAuthentication.Authentication.SaveAuthenticationInformation(_user.StudentId, _user.FirstName, "Admin", true);
                    bool val = (System.Web.HttpContext.Current.User != null) && (System.Web.HttpContext.Current.User.Identity.IsAuthenticated);

                    // ViewBag.Message = _user.FirstName + " " + _user.LastName + "  Successfully LoggedIn!";
                    if (val && _user.UserRole != "Admin") return RedirectToAction("DashBoard", "Home");
                    else if (val && _user.UserRole == "Admin") return RedirectToAction("StudentList", "Home");
                    else
                        return RedirectToAction("Index", "Home");
                }
              
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            /** if (!ModelState.IsValid)
             {
                 ViewBag.Messsage = "Error not Valid";
                 return View(_user);
             }
             _user = UserQuery.LoginQuery(_user);
             if(_user != null)
             {
                FormsAuthentication.SetAuthCookie(_user.StudentId, false);
                 var authTicket = new FormsAuthenticationTicket(1, _user.StudentId, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.UserRole);
                 string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                 var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                 HttpContext.Response.Cookies.Add(authCookie);
                 ViewBag.Message = _user.FirstName + " " + _user.LastName + "  Successfully LoggedIn!";
                 return View(_user);
             }
             else
             {
                 ViewBag.Messsage = "Error";
                 ModelState.AddModelError("", "Invalid login attempt.");
                 return View();
             }**/
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
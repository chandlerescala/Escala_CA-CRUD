using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Escala_CA_CRUD.Controllers
{
    [Authorize(Roles = "User")] //set filter
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            List<user> userList = _userRepo.GetAll();
            return View(userList);
        }
        [AllowAnonymous] //Override
        public ActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
                return RedirectToAction("Index");

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(user u)
        {
            var user = _userRepo.Table.Where(m => m.username == u.username).FirstOrDefault();
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(u.username, false); //Set Cookie
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "User not Exist or Incorrect Password");

            return View();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(user u)
        {
            _userRepo.Create(u);
            TempData["Msg"] = $"User {u.username} added!";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_userRepo.Get(id));
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int id)
        {
            return View(_userRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(user u)
        {
            _userRepo.Update(u.id, u);
            TempData["Msg"] = $"User {u.username} updated!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int id)
        {
            _userRepo.Delete(id);
            TempData["Msg"] = $"User deleted!";
            return RedirectToAction("Index");
        }
    }
}
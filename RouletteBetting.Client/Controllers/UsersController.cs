using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RouletteBetting.BusinessLogic;
using RouletteBetting.ViewModels;

namespace RouletteBetting.Client.Controllers
{
    public class UsersController : Controller
    {
        private static string baseUri = ConfigurationManager.AppSettings["WebApiUriBase"];
        private static string getUsersUri = ConfigurationManager.AppSettings["GetUsers"];
        private static string createUserUri = ConfigurationManager.AppSettings["CreateUser"];

        // GET: Users
        public ActionResult Index()
        {
            string uri = string.Concat(baseUri, getUsersUri);
            IEnumerable<UserViewModel> users = BusinessClientWebApp.GetInstance().GetUsers(uri);
            return View(users);
        }


        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string name = collection.GetValue("UserName").AttemptedValue;
                string uri = string.Concat(baseUri, createUserUri, "?name=" + name);
                BusinessClientWebApp.GetInstance().CreateUser(uri);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

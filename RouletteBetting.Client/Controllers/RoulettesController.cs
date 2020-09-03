using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using RouletteBetting.BusinessLogic;
using RouletteBetting.ViewModels;

namespace RouletteBetting.Client.Controllers
{
    public class RoulettesController : Controller
    {
        private static string baseUri = ConfigurationManager.AppSettings["WebApiUriBase"];
        private static string createRouletteUri = ConfigurationManager.AppSettings["CreateRoulette"];
        private static string getRoulettesUri = ConfigurationManager.AppSettings["GetRoulettes"];
        private static string openRouletteUri = ConfigurationManager.AppSettings["OpenRoulette"];
        private static string closeRouletteUri = ConfigurationManager.AppSettings["CloseRoulette"];
        private static string betByNumberUri = ConfigurationManager.AppSettings["MakeBetByNumber"];
        private static string betByColorUri = ConfigurationManager.AppSettings["MakeBetByColor"];

        // GET: Roulettes
        public ActionResult Index()
        {
            string uri = string.Concat(baseUri, getRoulettesUri);
            IEnumerable<RouletteViewModel> roulettes = BusinessClientWebApp.GetInstance().GetRoulettes(uri);

            return View(roulettes);
        }

        // GET: Roulettes/Create
        public ActionResult Create()
        {
            try
            {
                // TODO: Add insert logic here
                string uri = string.Concat(baseUri, createRouletteUri);
                BusinessClientWebApp.GetInstance().CreateUser(uri);
            }
            catch
            {

            }

            return RedirectToAction("Index");
        }

        // GET: Roulettes/Open/5
        public ActionResult Open(int id)
        {
            string uri = string.Concat(baseUri, openRouletteUri, "?rouletteId=" + id);
            BusinessClientWebApp.GetInstance().OpenRoulette(uri);

            return RedirectToAction("Index");
        }

        // GET: Roulettes/Bets/5
        public ActionResult Bets(int id)
        {
            string uri = string.Concat(baseUri, closeRouletteUri, "?rouletteId=" + id);
            List<GetBetViewModel> bets = BusinessClientWebApp.GetInstance().CloseRoulette(uri);
            if (bets != null && bets.Count > 0)
            {
                return View(bets);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //GET: Roulettes/MakeBetByNumber/1
        public ActionResult MakeBetByNumber(int id)
        {
            return View();
        }

        //POST: Roulettes/MakeBetByNumber/1
        [HttpPost]
        public ActionResult MakeBetByNumber(int id, FormCollection collection)
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"UserId", collection.GetValue("UserId").AttemptedValue },
                {"Money",  collection.GetValue("Money").AttemptedValue},
                {"Number",  collection.GetValue("Number").AttemptedValue}
            };
            HttpContent content = new FormUrlEncodedContent(values);
            string uri = string.Concat(baseUri, betByNumberUri);
            string result = BusinessClientWebApp.GetInstance().MakeBet(uri, content);

            return RedirectToAction("Index");
        }

        //GET: Roulettes/MakeBetByColor/1
        public ActionResult MakeBetByColor(int id)
        {
            return View();
        }

        //POST: Roulettes/MakeBetByColor/1
        [HttpPost]
        public ActionResult MakeBetByColor(int id, FormCollection collection)
        {
            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"UserId", collection.GetValue("UserId").AttemptedValue },
                {"Money",  collection.GetValue("Money").AttemptedValue},
                {"Color",  collection.GetValue("Color").AttemptedValue}
            };
            HttpContent content = new FormUrlEncodedContent(values);
            string uri = string.Concat(baseUri, betByColorUri);
            string result = BusinessClientWebApp.GetInstance().MakeBet(uri, content);

            return RedirectToAction("Index");
        }
    }
}

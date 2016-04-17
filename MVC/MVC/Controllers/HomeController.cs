using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC.Models;
using System.Data.Entity;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public  ActionResult Index()
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
        public ActionResult Message()
        {
                        MessageBoardEntities1 db = new MessageBoardEntities1();
            var a = db.message.Where(d =>d.ID>0);
        return View(a.ToList() );
        }

    }
}
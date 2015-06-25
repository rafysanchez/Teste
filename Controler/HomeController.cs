using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SolvEuler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Resolução do Euler 11 !";

            return View();
        }


        [HttpPost]
        public ActionResult Index(string  req = "xx")
        {
            decimal resultado = 0;
            Euler euler = new Euler();

            if (req!=null &&
                req.Length>0)
            {
                resultado = euler.Solve();
            }

            
            ViewBag.Message = "Resolução do Euler!";
            ViewBag.Resultado = resultado;
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }

    
    }
}

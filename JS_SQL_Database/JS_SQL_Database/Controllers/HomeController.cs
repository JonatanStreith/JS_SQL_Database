using JS_SQL_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JS_SQL_Database.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            //DataHandler.AddData();

            return View();
        }


        public ActionResult DisplayData()
        {



            return View();
        }

        [HttpPost]
        public ActionResult RequestData(string pressedButton)
        {

            //List<SchoolData> retrievedData = DataHandler.RetrieveData(buttonPressed);

            return PartialView("PV_Table", pressedButton);
        }










        public ActionResult EnterData()
        {


            return View();
        }


    }
}
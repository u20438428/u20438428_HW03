using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u20438428_HW03.Models;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;


namespace u20438428_HW03.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string Answer) 
        {
            

            
            
            if (files != null && files.ContentLength > 0)
            {


                var fileNameTwo = Path.GetFileName(files.FileName);

                var docRadio = Request.Form["doc"];

                var pathTwo = "";

                if (Answer == "A")
                {
                    pathTwo = Path.Combine(Server.MapPath("~/App_Data/Media/Documents/"), fileNameTwo);
                }

                else if (Answer == "B")
                {
                    pathTwo = Path.Combine(Server.MapPath("~/images/"), fileNameTwo);
                }
                else if (Answer == "C")
                {
                    pathTwo = Path.Combine(Server.MapPath("~/videos/"), fileNameTwo);
                }

                //var path = Path.Combine(Server.MapPath("~/App_Data/media/Documents"), fileName);



                files.SaveAs(pathTwo);
            }




            return RedirectToAction("Index");
        }

        

        public ActionResult About()
        {
            String path = Server.MapPath("~/image/");
            string[] imagefiles = Directory.GetFiles(path);
            ViewBag.images = imagefiles;

            return View();
        }

        
    }
}
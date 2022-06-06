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
                

                var fileName = Path.GetFileName(files.FileName);

                var docRadio = Request.Form["doc"];

                var path="";
                
                if(Answer=="A")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/Media/Documents"), fileName);
                }
                else if(Answer == "B")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/Media/Images"), fileName);
                }
                else if (Answer == "C")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/Media/Videos"), fileName);
                }

                //var path = Path.Combine(Server.MapPath("~/App_Data/media/Documents"), fileName);



                files.SaveAs(path);
            }

            


            return RedirectToAction("Index");
        }

        

        public ActionResult About()
        {
            String path = Server.MapPath("~/person/");
            string[] imagefiles = Directory.GetFiles(path);
            ViewBag.images = imagefiles;

            return View();
        }

        
    }
}
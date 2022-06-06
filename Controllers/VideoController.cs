using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u20438428_HW03.Models;
using System.IO;

namespace u20438428_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Image
        public ActionResult VideoView()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/videos/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);


        }

        public FileResult DownloadFile(string fileName)
        {

            string path = Server.MapPath("~/videos/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {


            string path = Server.MapPath("~/videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("VideoView");
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Model;
using FileModel = MiniCloudMVC.Models.FileModel;

namespace MiniCloudMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var fileModels = new List<FileModel>();

            using (var context = new MiniCloudEntities())
            {
                var userId = User.Identity.GetUserId();

                foreach (var file in context.Files.Where(x => x.OwnerId.Equals(userId)))
                {
                    fileModels.Add(new FileModel
                    {
                        FileName = file.Name,
                        CreationDate = file.CreationDate,
                        FileLink = file.Uri,
                        Size = file.FileSizeInByte
                    });
                }
            }

            return View(fileModels);
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase filePath)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/FileUploads/"), fileName);

                    file.SaveAs(path);

                    var uploadFile = new FileModel(path, fileName, User.Identity.GetUserId());

                    uploadFile.Upload();

                    TempData["success"] = "File successfully uploaded";
                }
            }

            return RedirectToAction("Index");
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
    }
}
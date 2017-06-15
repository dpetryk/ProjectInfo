using ProjectInfo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectInfo.Controllers
{
    public class AttachmentsController : Controller
    {
        // GET: Attachments
        public ActionResult Upload()
        {
            return PartialView("_Upload");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(Attachment attachment)
        {
            try
            {
                if (attachment.File.ContentLength > 0)
                {
                    var whichProject = Url.RequestContext.RouteData.Values["id"];
                    var fileName = Path.GetFileName(attachment.File.FileName);
                    var pathDir = Path.Combine(Server.MapPath("~/Content/files"), (string)whichProject); ;
                    var pathFile = Path.Combine(pathDir, fileName);
                    
                    if (!Directory.Exists(pathDir)){
                        DirectoryInfo di = Directory.CreateDirectory(pathDir);
                    };
                    attachment.File.SaveAs(pathFile);

                }
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show("No file attached");
            };



            //return Redirect(Request.UrlReferrer.ToString());

            // return RedirectToAction("Details", "Projects", new { id = Url.RequestContext.RouteData.Values["id"] });
            return PartialView("_Upload");
            //return view(Request.UrlReferrer.PathAndQuery);
        }

        public PartialViewResult Index(int id)
        {
            List<string> items = new List<string>();

            if (Directory.Exists(Server.MapPath("~/Content/files/" + id + "/"))){
                var dir = new DirectoryInfo(Server.MapPath("~/Content/files/" + id + "/"));
                FileInfo[] fileNames = dir.GetFiles("*.*");
                
                foreach (var file in fileNames)
                {
                    items.Add(file.Name);
                }
                return PartialView(items);
            }
            return PartialView(items);
        }

        public FileResult Download(string fileName, int? projectId)
        {
            return File(Server.MapPath("~/Content/files/") + projectId + "/" + fileName, System.Net.Mime.MediaTypeNames.Application.Octet);
        }

        public ActionResult Delete(string fileName, int projectId)
        {
            FileInfo file = new FileInfo(Server.MapPath("~/Content/files/") + projectId + "/" + fileName);
            file.Delete();
            DirectoryInfo dir = new DirectoryInfo((Server.MapPath("~/Content/files/") + projectId));
            FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var item in fileNames)
            {
                items.Add(item.Name);
            }
            if (items.Count < 1 ){
                dir.Delete();
            }


            return RedirectToAction("Details", "Projects", new { id = projectId });

        }
    }
}
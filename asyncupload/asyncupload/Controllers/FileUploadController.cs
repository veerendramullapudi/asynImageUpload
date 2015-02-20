using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace asyncupload.Controllers
{
    public class FileUploadController : Controller
    {
        //
        // GET: /FileUpload/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult regiser()
        {
            return View();
        }

        img i;
        public async Task<String> Upload()
        {
            if (Request.Files.Count > 0)
            {
                Stream fis = Request.Files[0].InputStream;
                byte[] data = new Byte[Request.Files[0].ContentLength];
                await fis.ReadAsync(data, 0, data.Length);

                veeruEntities1 e = new veeruEntities1();
                i = new img() { image = data };
                e.imgs.Add(i);
                e.SaveChanges();
                return "Upload Success";
            }
            else
            {
                return "Unsuccessful";
            }
       }
       public byte [] ConvertTOBytes(HttpPostedFileBase image)
        {
            byte[] imagebytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imagebytes = reader.ReadBytes((int)image.ContentLength);
            return imagebytes;
        }
     
    }
}

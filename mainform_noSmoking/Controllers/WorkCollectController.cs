using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.WorkCollect;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace mainform_noSmoking.Controllers
{
    public class WorkCollectController : Controller
    {
        public static WorkCollectModel Model { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        public WorkCollectController(IHostingEnvironment hostingEnvironment)
        {
            Model ??= new WorkCollectModel();
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult WorkCollect()
        {
            Model.GetDistrict();

            return View(Model);
        }
        [HttpGet]
        [Route("[controller]/[action]/{district}")]
        public IActionResult GetSchule(string district)
        {
            Model.GetSchules(district);

            return Json(Model.Schules);
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> ProvePrint(IFormCollection data)
        {
            Model.PostSaveWork(data);

            return await Task.Run(() => View("ProvePrint", Model));
        }

        [HttpPost]
        public IActionResult GetBase64(string file_name, string base64)
        {
            string wwwRoot = _hostingEnvironment.WebRootPath + "\\Works";
            string path = Path.Combine(wwwRoot, DateTime.Now.ToString("MMddhhmmss") + file_name);//for local test
            //string path = System.IO.Path.Combine("C:\\inetpub\\wwwroot\\quitSmoking\\wwwroot\\Works", DateTime.Now.ToString("MMddhhmmss") + file_name);//for VM

            int index = base64.IndexOf("base64,");
            string pureBase64 = base64[(index + 7)..];

            byte[] base64Byte = Convert.FromBase64String(pureBase64);
            System.IO.File.WriteAllBytes(path, base64Byte);

            //using (var ms = new MemoryStream(base64Byte))
            //{
            //    using (Image image = Image.FromStream(ms))
            //    {
            //        image.Save(path);                    
            //    }
            //}
            
            path = path[(path.IndexOf("\\Works"))..];

            Model.PostSaveFileInfo(file_name, base64, path);

            return Json("");
        }

        [HttpGet]
        public IActionResult GetInfo()
        {
            var tmp = new
            {
                Student_name = Model.StudentInfo.Student_name,
                Schle_name = Model.SchuleInfo.Schule_name,
                Student_grade = Model.StudentInfo.Student_grade,
                Student_class = Model.StudentInfo.Student_class
            };

            return Json(tmp);
        }
    }
}

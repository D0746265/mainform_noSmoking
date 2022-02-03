using mainform_noSmoking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.Home;
using mainform_noSmoking.Models.SQLModel;

namespace mainform_noSmoking.Controllers
{
    public class HomePageController : Controller
    {
        public HomeModel Model { get; set; }

        private readonly ILogger<HomePageController> _logger;

        public HomePageController(ILogger<HomePageController> logger)
        {
            Model ??= new HomeModel();
            _logger = logger;
        }

        public IActionResult HomePage()
        {//Initial load HomePage
            Model.GetWorks();

            return View(Model);
        }
        [Route("[controller]/[action]")]
        public IActionResult Works(int grade = 0, int status = 0)
        {//Works Page
            Model.Initial();
            Model.ShowWorks(0, 1);
            if (status == 1)
                Model.ShowWorks(grade, status);


            return View(Model);
        }
        [HttpGet]
        [Route("[controller]/[action]/{district}")]
        public IActionResult GetSchule(string district)
        {//Works
            Model.GetSchules(district);            

            return Json(Model.ShareModel.SchuleSelectList);
        }
        [HttpGet]
        [Route("[controller]/[action]/{schule_id}")]
        public IActionResult ShowSchuleWorks(int schule_id)
        {//Works
            Model.GetSchuleWorks(schule_id);

            return PartialView("_WorksPartial",Model);
        }
        [HttpGet]
        [Route("[controller]/[action]/{grade}/{status}")]
        public IActionResult GetGradeWorks(int grade, int status, int schule_id = 0)
        {//Works 
            Model.GetWorks(schule_id, grade, status);

            return PartialView("_WorksPartial", Model);
        }
        [HttpGet]
        public IActionResult GetWork(int id)
        {//Works get modal show
            Model.GetImage(id);

            return PartialView("_WorkModalPartial", Model);
        }
        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult GetGradeWorksFromHomePage(int grade, int status, int schule_id = 0)
        {//HomePage
            Model.Initial();
            Model.GetWorks(schule_id, grade, status);

            return View("Works", Model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

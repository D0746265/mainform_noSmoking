using mainform_noSmoking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.Home;
using ReflectionIT.Mvc.Paging;
using mainform_noSmoking.Models.Grading;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mainform_noSmoking.Controllers
{
    public class HomePageController : Controller
    {
        public HomeModel Model { get; set; }
        public static List<SelectListItem> SchuleSelectList { get; set; }

        private readonly ILogger<HomePageController> _logger;

        public HomePageController(ILogger<HomePageController> logger)
        {
            Model ??= new HomeModel();
            _logger = logger;
        }

        public IActionResult HomePage()
        {//Initial load HomePage
            Model.GetHomePageWorks(5);

            return View(Model);
        }

        [HttpGet]
        [Route("[controller]/[action]/{district}")]
        public IActionResult GetSchule(string district)
        {//Works
            Model.GetSchules(district);
            SchuleSelectList = Model.ShareModel.SchuleSelectList;

            return Json(Model.ShareModel.SchuleSelectList);
        }

        public IActionResult Index(int Location_name_value = 0, int schule_id = 0, int grade = 0, int status = 1, int pageIndex = 1)
        {
            return RedirectToAction("Works", new { Location_name_value, schule_id, grade, status, pageIndex });
        }

        [Route("[controller]/[action]")]
        public IActionResult Works(int Location_name_value = 0, int schule_id = 0, int grade = 0, int status = 1, int pageIndex = 1)
        {//Works Page
            Model.Initial();
            
            Model.GetWorks(schule_id, grade, 1);

            //make the SelectList Item to be 'selected' by compare "Location_name_value"
            Model.ShareModel.DistrictList.Where(f => f.Value == Location_name_value.ToString()).First().Selected = true;

            //pass the schuleSelectList to make the list exist when refresh the page
            if(SchuleSelectList != null)
            {
                foreach(SelectListItem each in SchuleSelectList)
                {
                    each.Selected = false;
                }
            }
            Model.ShareModel.SchuleSelectList = SchuleSelectList;

            try
            {
                Model.ShareModel.SchuleSelectList.Where(f => f.Value == schule_id.ToString()).First().Selected = true;
            }
            catch (ArgumentNullException) { Model.ShareModel.SchuleSelectList = new(); }
            catch (InvalidOperationException) { Model.ShareModel.SchuleSelectList = new(); }

            //pass the GradeSelectList 
            Model.ShareModel.GradeSelectList.Where(f => f.Value == grade.ToString()).First().Selected = true;

            Model.ViewModelsInPaging = PagingList.Create(Model.ViewModels, 12, pageIndex);
            Model.ViewModelsInPaging.RouteValue = new Microsoft.AspNetCore.Routing.RouteValueDictionary
            {
                {"Location_name_value", Location_name_value },
                {"schule_id", schule_id },
                {"grade", grade },
                {"status", status }
            };

            return View(Model);
        }

        //[HttpGet]
        //[Route("[controller]/[action]/{schule_id}")]
        //public IActionResult ShowSchuleWorks(int schule_id)
        //{//Works
        //    Model.GetSchuleWorks(schule_id);
        //    Model.ViewModelsInPaging = PagingList.Create(Model.ViewModels, 1, 1);

        //    return PartialView("_WorksPartial",Model);
        //}

        //[HttpGet]
        //[Route("[controller]/[action]/{grade}/{status}")]
        //public IActionResult GetGradeWorks(int grade, int status, int schule_id = 0)
        //{//Works 
        //    Model.GetWorks(schule_id, grade, status);
        //    Model.ViewModelsInPaging = PagingList.Create(Model.ViewModels, 1, 1);

        //    return PartialView("_WorksPartial", Model);
        //}

        [HttpGet]
        public IActionResult GetWork(int id)
        {//Works get modal show
            Model.GetImage(id);

            return PartialView("_WorkModalPartial", Model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

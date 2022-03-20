using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using mainform_noSmoking.Models.AwardList;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;

namespace mainform_noSmoking.Controllers
{
    public class AwardListController : Controller
    {   
        public AwardListModel Model { get; set; }
        public static List<SelectListItem> SchuleSelectList { get; set; }

        public AwardListController()
        {
            Model ??= new AwardListModel();
        }
        public async Task<IActionResult> Index(int Location_name_value = 0, int schule_id = 0, int grade = 0, int status = 1, int pageIndex = 1)
        {
            return await Task.Run(() => RedirectToAction("AwardList", new { Location_name_value, schule_id, grade, status, pageIndex }));
        }
        public async Task<IActionResult> AwardList(int Location_name_value = 0, int schule_id = 0, int grade = 0, int status = 1, int pageIndex = 1)
        {
            Model.GetWorks(schule_id, grade, 1);

            //make the SelectList Item to be 'selected' by compare "Location_name_value"
            Model.ShareModel.DistrictList.Where(f => f.Value == Location_name_value.ToString()).First().Selected = true;

            //pass the schuleSelectList to make the list exist when refresh the page
            if (SchuleSelectList != null)
            {
                foreach (SelectListItem each in SchuleSelectList)
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
            return await Task.Run(() => View(Model));
        }
        [HttpGet]
        [Route("[controller]/[action]/{district}")]
        public async Task<IActionResult> GetSchule(string district)
        {//Works
            Model.GetSchules(district);
            SchuleSelectList = Model.ShareModel.SchuleSelectList;

            return await Task.Run(() => Json(Model.ShareModel.SchuleSelectList));
        }
        [HttpGet]
        public async Task<IActionResult> GetWork(int id)
        {//Works get modal show
            Model.GetImage(id);

            return await Task.Run(() => PartialView("_WorkModalPartial", Model));
        }
    }
}

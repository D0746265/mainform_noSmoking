using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mainform_noSmoking.Models.Grading;

namespace mainform_noSmoking.Controllers
{
    public class GradingController : Controller
    {
        public GradingModel Model { get; set; }
        public GradingController()
        {
            Model ??= new GradingModel();
            Model.ShareModel ??= new Models.ShareModel();
        }
        public async Task<IActionResult> Grading(int grade = 0, int status = 0)
        {
            Model.GetAllWork(grade, status);

            return await Task.Run(() => View(Model));
        }

        [HttpGet]
        public async Task<IActionResult> GetWork(int id)
        {
            Model.GetImage(id);

            return await Task.Run(() => PartialView("_GradingModalPartial", Model));
        }

        [HttpGet]
        [Route("[controller]/[action]/{student_id}/{pass_status}")]
        public IActionResult Pass(int student_id, int pass_status)
        {
            Model.SetPassStatus(student_id, pass_status);

            return Json("");
        }

        [HttpGet]
        [Route("[controller]/[action]/{grade}/{status}")]
        public IActionResult GetGradeWorks(int grade, int status)
        {
            Model.GetWorksByGrade(grade, status);

            return PartialView("_GradingPartial", Model);
        }
    }
}

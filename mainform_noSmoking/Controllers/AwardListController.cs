using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainform_noSmoking.Controllers
{
    public class AwardListController : Controller
    {
        public IActionResult AwardList()
        {
            return View();
        }
    }
}

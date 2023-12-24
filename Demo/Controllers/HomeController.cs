using Demo.Language;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{

    [Authorize(Roles ="Admin,Test,User")]
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<sharedResource> localizer;

        public HomeController( IStringLocalizer<sharedResource> localizer )
        {
            this.localizer = localizer;
        }
        public IActionResult Index()
        {
            ViewBag.msg = localizer["DASHBOARD"];
            return View();
        }

          }
}

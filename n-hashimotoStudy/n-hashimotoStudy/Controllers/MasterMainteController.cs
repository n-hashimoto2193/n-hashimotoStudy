using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace n_hashimotoStudy.Controllers
{
    public class MasterMainteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
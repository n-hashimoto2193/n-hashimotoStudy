using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using n_hashimotoStudy.Data;
using n_hashimotoStudy.Models;

namespace n_hashimotoStudy.Controllers
{
    public class KintaiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KintaiController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 記録
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Rec(Kintai model)
        {
            DateTime nowTime = DateTime.Now;
             model.RecordingDate = nowTime;
            _context.Add(model);
            _context.SaveChanges();

            return View("Index",model);
        }
    }
}
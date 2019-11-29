using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // ユーザー情報
            var user = _context.ApplicationUsers.Where(t => t.UserName == User.Identity.Name)
                .FirstOrDefault();

            // 現在時刻
            DateTime nowTime = DateTime.Now;

            // 現在時刻をセット
            model.RecordingDate = nowTime;
            // 使用ユーザーをセット
            model.ApplicationUser = user;
            // DBに追加
            _context.Add(model);
            _context.SaveChanges();

            return View("Index");
        }
    }
}
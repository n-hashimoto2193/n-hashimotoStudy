using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using n_hashimotoStudy.Data;
using n_hashimotoStudy.Models;
using n_hashimotoStudy.Models.ViewModels;

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


        // TODO: 打刻時間を表示
        /// <summary>
        /// 時刻記録
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Rec(KintaiViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //トランザクション開始
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        // 現在時刻
                        DateTime nowTime = DateTime.Now;

                        // ユーザー情報を取得
                        var user = _context.ApplicationUsers.Where(t => t.UserName == User.Identity.Name)
                            .FirstOrDefault();
                        Kintai model = new Kintai();
                        // 現在時刻をセット
                        model.RecordingDate = nowTime;
                        // ユーザーをセット
                        model.ApplicationUser = user;

                        viewModel.TimeIn = model.RecordingDate.ToString("HH:mm");
                        // DBに追加
                        _context.Add(model);
                        // データベースに変更が反映
                        _context.SaveChanges();
                        // データベースの更新内容が有効
                        transaction.Commit();

                        // 勤怠管理画面に戻る
                        //return RedirectToAction(nameof(Index));
                        return View("Index", viewModel);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ModelState.AddModelError(string.Empty, "エラーが発生しました。");
                    }
                }
            }
            return View("Index", viewModel);
        }
    }
}
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
using n_hashimotoStudy.Services;

namespace n_hashimotoStudy.Controllers
{
    public class KintaiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private KintaiServices _services;

        public KintaiController(ApplicationDbContext context)
        {
            _services = new KintaiServices();
            _context = context;
        }

        public IActionResult Index()
        {
            // ユーザー情報を取得
            var user = _context.ApplicationUsers.Where(t => t.UserName == User.Identity.Name)
                .FirstOrDefault();
            KintaiViewModel model = new KintaiViewModel();

            // 打刻データを表示
            _services.RecData(model, _context, user);
            return View(model);
        }


        // TODO: 打刻時間を表示
        /// <summary>
        /// 時刻記録
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Rec(KintaiViewModel viewModel, string btn)
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
                        // 現在時刻(出勤期データ証拠用)をセット
                        model.RecordingDateEvidence = nowTime;
                        // 現在時刻をセット
                        model.RecordingDate = nowTime;

                        // 出勤した日をセット ※まだ正確でない
                        model.WorkDate = nowTime.ToString("yyyyMMdd");

                        // 区分:1(出勤)をセット
                        //if ("timeInRecBtn".Equals(btn))
                        //{
                        //    model.ShuttaiDivision = 1;
                        //    // viewModelに値を渡す
                        //    viewModel.TimeIn = model.RecordingDate.ToString("HH:mm");
                        //}
                        // 区分:2(退勤)をセット
                        if ("timeOutRecBtn".Equals(btn))
                        {
                            model.ShuttaiDivision = 2;
                            // viewModelに値を渡す
                            viewModel.TimeOut = model.RecordingDate.ToString("HH:mm");
                        }

                        // ユーザーをセット
                        model.ApplicationUser = user;

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
                return Json(new
                {
                    status = "success"
                });

            }
            return View("Index", viewModel);
        }
    }
}
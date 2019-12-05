using n_hashimotoStudy.Data;
using n_hashimotoStudy.Models;
using n_hashimotoStudy.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace n_hashimotoStudy.Services
{
    public class KintaiServices
    {

        /// <summary>
        /// ユーザーの打刻情報
        /// </summary>
        /// <param name="model">勤怠管理画面ViewModel</param>
        /// <param name="_context">DBコンテキスト</param>
        /// <param name="loginUser">ログインユーザー情報</param>
        public void RecData(KintaiViewModel model, ApplicationDbContext _context, ApplicationUser loginUser)
        {
            string dakokuData = GetRecDb(_context, loginUser);
            if (dakokuData == "")
            {
                model.TimeIn = "";
            }
            else
            {
                model.TimeIn = dakokuData;
            }
        }


        /// <summary>
        /// 打刻情報取得メソッド
        /// </summary>
        /// <param name="_context">DBコンテキスト</param>
        /// <param name="loginUser">ログインユーザー情報</param>
        /// <returns>DBから取得した打刻情報</returns>
        public string GetRecDb(ApplicationDbContext _context, ApplicationUser loginUser)
        {
            // 最新打刻(出勤)記録
            string latestRecord = "";

            // 打刻時間(RecordingDate)のデータをDBから呼び出す
            var kintaiRecord = _context.Kintais
                .OrderByDescending(p => p.RecordingDate)
                .Where(p => p.ApplicationUser.Id == loginUser.Id)
                .FirstOrDefault();
            if (kintaiRecord != null)
            {
                //勤怠テーブルから打刻時間(RecordingDate)を取得できた場合、"latestRecord"に代入                
                latestRecord = kintaiRecord.RecordingDate.ToString("HH:mm");
            }
            else
            {
                // 勤怠テーブル内に登録データがない場合、最新打刻(出勤)記録に「""」を返却
                latestRecord = "";
            }
            return latestRecord;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace n_hashimotoStudy.Models.ViewModels
{
    public class KintaiViewModel
{
        /// <summary>
        /// 出勤時刻
        /// </summary>
        [Display(Name = "出勤時刻")]
        public string TimeIn { get; set; }

        /// <summary>
        /// 退出時刻
        /// </summary>
        [Display(Name = "退出時刻")]
        public string TimeOut { get; set; }

    }
}

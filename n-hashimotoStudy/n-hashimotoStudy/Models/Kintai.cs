using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace n_hashimotoStudy.Models
{
    public class Kintai
    {
        /// <summary>
        /// 勤怠ID
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 打刻時間(打刻証拠用)
        /// </summary>
        public DateTime RecordingDateEvidence { get; set; }

        /// <summary>
        /// 打刻時間
        /// </summary>
        public DateTime RecordingDate { get; set; }

        /// <summary>
        /// 出退区分
        /// </summary>
        public int ShuttaiDivision { get; set; } // 出勤：1、退勤：2

        /// <summary>
        /// 出勤日付
        /// </summary>
        public string WorkDate { get; set; }

        [NotMapped]
        public long SystemUser { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}

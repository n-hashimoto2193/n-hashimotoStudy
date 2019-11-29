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
        /// 打刻時間
        /// </summary>
        public DateTime RecordingDate { get; set; }

        [NotMapped]
        public long SystemUser { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}

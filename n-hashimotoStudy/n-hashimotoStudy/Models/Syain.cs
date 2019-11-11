using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace n_hashimotoStudy.Models
{
    public class Syain
    {
        /// <summary>
        /// 社員ID
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 社員名
        /// </summary>
        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "社員名")]
        public string SyainName { get; set; }

        [Display(Name = "社員番号")]
        public string No { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [EmailAddress]
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }

        public Busho Busho { get; set; }

        public Role Role { get; set; }


    }
}

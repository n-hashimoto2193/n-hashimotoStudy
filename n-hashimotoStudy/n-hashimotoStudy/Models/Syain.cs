using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "社員番号")]
        public string No { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [EmailAddress]
        [Display(Name = "メールアドレス")]
        public string Email { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "{0} を選択してください")]
        [Display(Name = "所属部署")]
        public long BushoId { get; set; }

        [NotMapped]
        //[Required(ErrorMessage = "{0} を選択してください")]
        [Display(Name = "権限")]
        public long RoleId { get; set; }

        public virtual Busho Busho { get; set; }

        public virtual Role Role { get; set; }


    }
}

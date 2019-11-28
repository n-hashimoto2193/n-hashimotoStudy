using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace n_hashimotoStudy.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    /// <summary>
    /// 社員情報
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        ///// <summary>
        ///// 社員ID
        ///// </summary>
        //[Key]
        //public long Id { get; set; }

        /// <summary>
        /// 社員名
        /// </summary>
        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "社員名")]
        public string SyainName { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [StringLength(4, ErrorMessage = "社員番号は4桁で入力してください。")]
        [Remote("NoUniqueCheck", "ApplicationUsers", ErrorMessage = "同一の社員番号を持つユーザーが存在するため設定できません。")]
        [Display(Name = "社員番号")]
        public string SyainNo { get; set; }

        [Required(ErrorMessage = "{0} を入力してください")]
        [EmailAddress]
        [Display(Name = "メールアドレス")]
        public override string Email { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "{0} を選択してください")]
        [Display(Name = "所属部署")]
        public long BelongBusho { get; set; }

        [NotMapped]
        //[Required(ErrorMessage = "{0} を選択してください")]
        [Display(Name = "権限")]
        public long HasRole { get; set; }

        public virtual Busho Busho { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Kintai> Kintais { get; set; }


    }
}

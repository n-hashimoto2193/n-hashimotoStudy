using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace n_hashimotoStudy.Models
{
    public class Role
    {
        /// <summary>
        /// 権限ID
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 権限名
        /// </summary>
        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "権限名")]
        public string RoleName { get; set; }

    }
}

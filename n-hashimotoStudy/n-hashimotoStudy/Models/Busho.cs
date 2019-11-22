using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace n_hashimotoStudy.Models
{
    public class Busho
    {
        /// <summary>
        /// 所属部署ID
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 所属部署名
        /// </summary>
        [Required(ErrorMessage = "{0} を入力してください")]
        [Display(Name = "部署名")]
        public string BushoName { get; set; }

    }
}

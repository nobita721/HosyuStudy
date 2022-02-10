using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebFormBL.Models
{
    public class T_Shouhin
    {
        [Key, Display(Name = "商品ID")]
        [ScaffoldColumn(false)]
        public string ShouhinId { get; set; }

        [Display(Name = "商品名")]
        public string ShouhinName { get; set; }

        [Display(Name = "商品詳細")]
        public string ShouhinDetail { get; set; }

        [Display(Name = "在庫数")]
        public int ZaikoSuu { get; set; }

        [Display(Name = "更新日時")]
        public DateTime UpdateDate { get; set; }

        public int Del_Flg { get; set; }
    }
}

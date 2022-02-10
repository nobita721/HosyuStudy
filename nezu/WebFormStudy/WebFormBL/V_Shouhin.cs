using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFormBL
{
    public class V_Shouhin
    {
        public string ShouhinId { get; set; }

        public int HistNo { get; set; }

        public string ShouhinName { get; set; }

        public string ShouhinDetail { get; set; }

        public int ZaikoSuu { get; set; }

        public DateTime UpdateDate { get; set; }

        public int Del_Flg { get; set; }
    }
}

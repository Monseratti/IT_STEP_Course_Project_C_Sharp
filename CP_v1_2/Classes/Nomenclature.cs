using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_v1_2
{
    public class Nomenclature
    {
        public int NomenclatureID { get; set; }
        [Required]
        public string NomenclatureName { get; set; }
        [Required]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public ICollection<CashFlow> CashFlows { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_v1_2
{
    public class CashFlow
    {
        [Key]
        public int ID { get; set; }
        public int WalletID { get; set; }
        public int NomenclatureID { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }

        public Wallet Wallet { get; set; }
        public Nomenclature Nomenclature { get; set; }
    }
}

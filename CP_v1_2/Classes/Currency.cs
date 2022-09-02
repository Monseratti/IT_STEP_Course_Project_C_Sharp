using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_v1_2
{
    public class Currency
    {
        [Key]
        public int CurrensyID { get; set; }
        public string CurrencyName { get; set; }
        public int CurrencyCode { get; set; }

        public ICollection<Wallet> Wallets { get; set; } 
    }
}

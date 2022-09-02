using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_v1_2
{
    public class Wallet
    {
        public int WalletID { get; set; }
        public string WalletName { get; set; }
        [DefaultValue(0)]
        public decimal WalletSum { get; set; } = 0;
        public int CurrencyID { get; set; }
        [Required]
        public int UserID { get; set; }

        public Currency Currency { get; set; }
        public User User { get; set; }
        public ICollection<CashFlow> CashFlows { get; set; }
    }
}

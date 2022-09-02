using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_v1_2
{
    public class PlanningCashFlow
    {
        [Key]
        public int PcfID { get; set; }
        public int CategoryID { get; set; }
        [DefaultValue(0)]
        public decimal Sum { get; set; }
        public int period_month { get; set; }
        public int period_year { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
    }
}

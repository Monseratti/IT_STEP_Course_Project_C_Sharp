using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_v1_2
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryType { get; set; }

        public ICollection<Nomenclature> Nomenclature { get; set; }
    }
}

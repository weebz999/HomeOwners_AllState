using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeOwners_AllState
{
   public class Coverage
    {
        public string Section { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<LimitsOfLiability> LimitsOfLiabilities { get; set; } = new List<LimitsOfLiability>();
        public List<Deductable> Deductables { get; set; } = new List<Deductable>();

    }
}

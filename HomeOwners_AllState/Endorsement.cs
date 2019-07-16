using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeOwners_AllState
{
   public class Endorsement
    {
        public string Section { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FormNumber { get; set; }
        public Amount TotalAmount { get; set; }
        public string ParentCoverage { get; set; }
        public string Type { get; set; }
    }
}

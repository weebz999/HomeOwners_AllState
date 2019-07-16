using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeOwners_AllState
{
    public class Discount
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Section { get; set; }
        public string Code { get; set; }
        public Amount TotalAmount { get; set; }
    }
}

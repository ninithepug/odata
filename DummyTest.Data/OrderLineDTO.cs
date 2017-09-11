using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c4codata
{
    public partial class OrderLineDTO
    {
        public System.Guid OrderLineID { get; set; }
        public Nullable<System.Guid> OrderID { get; set; }
        public Nullable<double> DTO_Amount { get; set; }

        public virtual OrderDTO Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c4codata
{
    public partial class OrderDTO
    {
        public OrderDTO()
        {
            this.OrderLines = new HashSet<OrderLineDTO>();
        }

        public System.Guid OrderID { get; set; }
        public string DTO_OrderPlacedBy { get; set; }
        public Nullable<System.DateTime> DTO_PlacedTime { get; set; }

       public virtual ICollection<OrderLineDTO> OrderLines { get; set; }
    }
}

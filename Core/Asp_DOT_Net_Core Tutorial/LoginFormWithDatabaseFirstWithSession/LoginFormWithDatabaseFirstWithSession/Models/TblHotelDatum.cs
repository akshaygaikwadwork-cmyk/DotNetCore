using System;
using System.Collections.Generic;

namespace LoginFormWithDatabaseFirstWithSession.Models
{
    public partial class TblHotelDatum
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string DishName { get; set; } = null!;
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public string DishImageName { get; set; } = null!;
        public DateTime? OrderDate { get; set; }
        public int IsDeleted { get; set; }
    }
}

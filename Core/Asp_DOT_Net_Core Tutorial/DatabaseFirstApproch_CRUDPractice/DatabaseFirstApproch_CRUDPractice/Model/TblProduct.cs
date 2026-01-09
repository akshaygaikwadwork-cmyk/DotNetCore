using System;
using System.Collections.Generic;

namespace DatabaseFirstApproch_CRUDPractice.Model
{
    public partial class TblProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? Stock { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DatabaseFirstApproch_CRUDPractice.Model
{
    public partial class TblDepartment
    {
        public int DId { get; set; }
        public string DepartmentName { get; set; } = null!;
    }
}

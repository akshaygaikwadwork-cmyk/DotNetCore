using System;
using System.Collections.Generic;

namespace LoginFormWithDatabaseFirstWithSession.Models
{
    public partial class TblDepartment
    {
        public int DId { get; set; }
        public string DepartmentName { get; set; } = null!;
    }
}

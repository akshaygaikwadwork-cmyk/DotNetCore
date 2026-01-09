using System;
using System.Collections.Generic;

namespace DatabaseFirstApproch_CRUDPractice.Model
{
    public partial class TblEmployeeDatum
    {
        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long Mobile { get; set; }
        public DateTime Dob { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public string Department { get; set; } = null!;
        public decimal Salary { get; set; }
        public string Address { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public int? IsDeleted { get; set; }
    }
}

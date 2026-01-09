using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApproch_CRUDPractice.Model
{
    public partial class TblEmployee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string EmpGender { get; set; } = null!;
        [Required]
        public decimal? EmpSalary { get; set; }
        [Required]
        public int? EmpAge { get; set; }
    }
}

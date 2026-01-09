using System;
using System.Collections.Generic;

namespace CRUD_WithWebAPI.Models
{
    public partial class TblStudentUsingEntity
    {
        public int Id { get; set; }
        public string StudName { get; set; } = null!;
        public string StudGender { get; set; } = null!;
        public int StudAge { get; set; }
        public int StudStandard { get; set; }
    }
}

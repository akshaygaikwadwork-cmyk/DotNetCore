namespace CreatingFornWithTagHelper.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; } // here we used enum for constant
        public int Age { get; set; }
        public string City { get; set; }
        public string Married { get; set; }
        public string Description { get; set; }
    }

    public enum Gender
    {
        Male,Female
    }

    //Enum  - collection of constant values
}

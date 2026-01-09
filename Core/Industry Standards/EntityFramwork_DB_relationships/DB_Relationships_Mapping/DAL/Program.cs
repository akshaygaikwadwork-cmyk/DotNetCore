using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize the database context
            using (var context = new DatabaseContext())
            {
                // Adding new Students and Courses
                AddStudentsAndCourses(context);
                // Fetching and displaying the data
                DisplayStudentsAndCourses(context);
            }
        }

        // Method to add students and courses
        static void AddStudentsAndCourses(DatabaseContext context)
        {
            // Creating new courses
            var course1 = new Course { CourseName = "ASP.NET Core" };
            var course2 = new Course { CourseName = "Machine Learning" };
            var course3 = new Course { CourseName = "Cloud Computing" };
            // Creating new students
            var student1 = new Student { Name = "Pranaya Rout", Courses = new List<Course> { course1, course2 } };
            var student2 = new Student { Name = "Rakesh Kumar", Courses = new List<Course> { course2, course3 } };
            var student3 = new Student { Name = "Anurag Mohanty", Courses = new List<Course> { course1, course3 } };
            // Adding the students (EF Core will automatically add the courses due to the relationship)
            context.Students.AddRange(student1, student2, student3);
            // Save changes to the database
            context.SaveChanges();
            Console.WriteLine("Students and Courses have been added to the database.\n");
        }
        // Method to fetch and display students with their enrolled courses
        static void DisplayStudentsAndCourses(DatabaseContext context)
        {
            // Fetch all students and their related courses using Include for eager loading
            var students = context.Students
                .Include(s => s.Courses) //Eager Load the Related Courses
                .ToList();
            // Iterate through each student and display the courses they are enrolled in
            foreach (var student in students)
            {
                Console.WriteLine($"Student Id: {student.Id}, Name: {student.Name}");
                // If the student is enrolled in any courses, display them
                if (student.Courses.Any())
                {
                    Console.WriteLine("Enrolled in the following courses:");
                    foreach (var course in student.Courses)
                    {
                        Console.WriteLine($"\tCoure Id:{course.Id}, Name:{course.CourseName}");
                    }
                }
                else
                {
                    Console.WriteLine("No courses enrolled.");
                }
                Console.WriteLine(); // For spacing
            }
        }
    }
}

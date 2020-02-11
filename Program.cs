using System;
using Spring_2020_Class_Project.Classes;
using System.Collections.Generic;
using System.Linq;


namespace Spring_2020_Class_Project
{
    class Program
    {
        static List<Student> studentsList = new List<Student>();
        static void Main(string[] args)
        {

            var inputtingStudent = true;

            while (inputtingStudent)
            {
                DisplayMenu();
                var option = Console.ReadLine();

                switch (int.Parse(option))
                {
                    case 1:
                        InputStudent();
                        break;
                    case 2:
                        DisplayStudents();

                        break;
                    case 3:
                        SearchStudents();
                        break;
                    case 4:
                        inputtingStudent = false;
                        break;
                }
            }
        }

        private static void DisplayStudents(IEnumerable<Student> students)
        {
            if (students.Any())
            {
                Console.WriteLine($"Student Id | Name | Class ");
                studentsList.ForEach(x =>
                {
                    Console.WriteLine(x.StudentDisplay);
                });
            }
            else
            {
                System.Console.WriteLine("no students found.");
            }
        }

        private static void DisplayStudents() => DisplayStudents(studentsList);

        private static void SearchStudents()
        {
            Console.WriteLine("Search string:");
            var searchString = Console.ReadLine();
            var students = studentsList.Where(x => x.FullName.Contains(searchString));
            DisplayStudents(students);
        }
        private static void DisplayMenu()
        {
            Console.WriteLine("Select from the following operations:");
            Console.WriteLine("1: Enter new student");
            Console.WriteLine("2: List all students");
            Console.WriteLine("3: Search for student by name");
            Console.WriteLine("4: Exit");
        }

        static void InputStudent()
        {
            var student = new Student();
            // Continue prompting the user for input until it is valid
            while (true)
            {
                // Prompt user
                Console.WriteLine("Enter Student Id");
                // Try to parse the user input 
                var studentIdSuccessful = int.TryParse(Console.ReadLine(), out var studentId);
                // If the input is valid 
                if (studentIdSuccessful)
                {
                    // Add input to the Student object 
                    student.StudentId = studentId;
                    // Exit the loop
                    break;
                }
            }
            Console.WriteLine("Enter First Name");
            var studentFirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            var studentLastName = Console.ReadLine();
            Console.WriteLine("Enter Class Name");
            var className = Console.ReadLine();
            Console.WriteLine("Enter Last Class Completed");
            var lastClass = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Enter Last Class Completed Date in format MM/dd/YYYY");
                var lastCompletedOnSuccessful = DateTimeOffset.TryParse(Console.ReadLine(), out var lastClassCompletedOn);
                if (lastCompletedOnSuccessful)
                {
                    student.LastClassCompletedOn = lastClassCompletedOn;
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Enter Start Date in format MM/DD/YYYY");
                var startDateSuccessful = DateTimeOffset.TryParse(Console.ReadLine(), out var startDate);
                if (startDateSuccessful)
                {
                    student.StartDate = startDate;
                    break;
                }
            }
            studentsList.Add(student);
        }
    }
}
using System;
using Lab2Net;
// Crear instructor con init-only props
var instructor = new Instructor
{
    Name = "Dr. Smith",
    Department = "Computer Science",
    Email = "smith@university.edu"
};
Console.WriteLine(instructor);

var baseCourse = new Courses("Programming 101", 3);
var student1 = new Student(1, "Alice", 20, new List<Courses> { baseCourse });
var newCourse = new Courses("Databases", 4);
//clone:
var student2 = student1 with { Courses = new List<Courses>(student1.Courses) { newCourse } };
Console.WriteLine($"Original Student: {student1.Name} ({student1.Courses.Count} courses)");
Console.WriteLine($"Cloned Student: {student2.Name} ({student2.Courses.Count} courses)");

List<String> students = new();
String name = null;
while (true)
{
    Console.Write("Enter student name or 'exit' to stop: ");
    name = Console.ReadLine();
    if (name == "exit")
        break;
    students.Add(name);
}
Console.WriteLine("\n List of students");
foreach (var student in students )
{
    Console.WriteLine($"-{student}");
}

//Step 4
void DescribeObject(object obj)
{
    if (obj is not null)
    {
        switch (obj)
        {
            case Student s when s.Courses.Count > 0:
                Console.WriteLine($"Student: {s.Name}, Courses: {s.Courses.Count}");
                break;
            case Student s:
                Console.WriteLine($"Student: {s.Name}, no courses yet");
                break;
            case Courses c:
                Console.WriteLine($"Courses: {c.Title}, Credits: {c.Credits}");
                break;
            default:
                Console.WriteLine("Null object");
                break;

        }
    }
}
DescribeObject(student1);
DescribeObject(newCourse);
DescribeObject("Random String");
Console.WriteLine();

//Step 5.
List<Courses> allCourses = new()
{
    new("Programming 101", 3),
    new("Databases", 4),
    new("AI Fundamentals", 5),
    new("History", 2)
};

var filter = static (Courses c) => c.Credits > 3;
var filtered = allCourses.Where(filter);

foreach (var c in filtered)
    Console.WriteLine($"{c.Title} ({c.Credits} credits)");

    


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPIDemo;

public static class StudentApi
{
    private static List<Student> students = new List<Student>
    {
        new Student { Id = 1, Name = "Nguyen Van A", Age = 20 },
        new Student { Id = 2, Name = "Tran Thi B", Age = 21 },
        new Student { Id = 3, Name = "Le Van C", Age = 22 }
    };

    public static void MapStudentApi(this IEndpointRouteBuilder app)
    {
        // Get all students
        app.MapGet("/students", () => students).WithName("GetAllStudents");

        // Get student by id
        app.MapGet("/students/{id}", (int id) =>
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return student is not null ? Results.Ok(student) : Results.NotFound();
        }).WithName("GetStudentById");

        // Create new student
        app.MapPost("/students", (Student student) =>
        {
            student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);
            return Results.Created($"/students/{student.Id}", student);
        }).WithName("CreateStudent");

        // Update student
        app.MapPut("/students/{id}", (int id, Student updatedStudent) =>
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student is null) return Results.NotFound();
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            return Results.Ok(student);
        }).WithName("UpdateStudent");

        // Delete student
        app.MapDelete("/students/{id}", (int id) =>
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student is null) return Results.NotFound();
            students.Remove(student);
            return Results.NoContent();
        }).WithName("DeleteStudent");
    }
}

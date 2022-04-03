namespace eAcademy.Domain;

public class Course
{
    public string Title { get; set; }
    public CourseType CourseType { get; set; }
    public InstructorsList Instructors { get; set; }
    public Price Price { get; set; }
}
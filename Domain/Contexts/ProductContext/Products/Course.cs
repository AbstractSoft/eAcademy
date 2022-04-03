namespace eAcademy.Domain.Contexts.ProductContext.Products;

public class Course : eAcademy.Domain.Contexts.ProductContext.Products.Contracts.Product
{
    private Course(Guid id, string code, string name, AuthorsList authors)
        : base(id, code, name, authors)
    {
    }

    public static Course Create(string code, string name, IReadOnlyList<string> authors, IReadOnlyList<string> instructors)
    {
        return Create(Guid.NewGuid(), code, name, authors, instructors);
    }

    public static Course Create(Guid id, string code, string name, IReadOnlyList<string> authors, IReadOnlyList<string> instructors)
    {
        var course = new Course(id, code, name, new AuthorsList(authors));
        course.Instructors = new InstructorsList(instructors);

//        eAcademy.Core.Domain.Events.Raise(new CourseCreated()
//        {
//            Course = course
//        });

        course.ValidateAndThrow();

        return course;
    }

    public InstructorsList Instructors { get; set; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new eAcademy.Domain.Contexts.ProductContext.Products.Validators.CourseValidator();
    }
}
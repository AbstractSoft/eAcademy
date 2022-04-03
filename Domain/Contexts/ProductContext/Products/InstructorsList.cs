namespace eAcademy.Domain.Contexts.ProductContext.Products;
// ToDo: PersonContext
public class InstructorsList : System.Collections.ObjectModel.ReadOnlyCollection<string>
{
    public InstructorsList(IReadOnlyList<string> authors) : base((IList<string>)authors)
    {
        throw new NotImplementedException();
    }
}
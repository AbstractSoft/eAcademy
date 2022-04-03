namespace eAcademy.Domain.Contexts.ProductContext.Products;
// ToDo: PersonContext
public class AuthorsList : System.Collections.ObjectModel.ReadOnlyCollection<string>
{
    public AuthorsList(IReadOnlyList<string> authors) : base((IList<string>)authors)
    {
        throw new NotImplementedException();
    }
}
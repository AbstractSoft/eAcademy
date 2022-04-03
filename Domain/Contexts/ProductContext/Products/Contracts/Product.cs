namespace eAcademy.Domain.Contexts.ProductContext.Products.Contracts;

public abstract class Product : eAcademy.Core.Domain.Entities.DomainEntity
{
    protected Product(Guid id, string code, string name, AuthorsList authors)
        : base(id)
    {
        Code = Code.Create(code);
        Name = name;
        Authors = authors;
    }

    public Code Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AuthorsList Authors { get; set; }
}
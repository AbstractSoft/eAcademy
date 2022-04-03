namespace eAcademy.Domain.Contexts.ProductContext.Products.Validators;

using FluentValidation;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CodeValidator : eAcademy.Core.Domain.Validators.BaseDomainValueObjectValidator<Code>
{
    public CodeValidator()
    {
        RuleFor(static x => x.Value)
            .NotNull();
    }
}
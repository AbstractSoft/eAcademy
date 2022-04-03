namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using FluentValidation;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class
    Test1DomainEntityValidator : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.Test1DomainEntity>
{
    public Test1DomainEntityValidator()
    {
        RuleFor(static x => x.StringProperty)
            .NotEmpty();
    }
}
namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class
    FakeEntity3EntityValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity3>
{
    public FakeEntity3EntityValidator()
    {
        FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(a => a.StringField));
    }
}
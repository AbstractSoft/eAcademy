namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class
    FakeEntity3EntityValidator
    : eAcademy.Core.Domain.Validators.BaseDomainEntityValidator<
        eAcademy.Core.Domain.UnitTests.Fakes.Entities.FakeEntity3>
{
    public FakeEntity3EntityValidator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(a => a.StringField));
    }
}
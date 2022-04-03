namespace eAcademy.Core.Domain.UnitTests.Fakes.Validators;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeValueObject3Validator : eAcademy.Core.Domain.Validators.BaseDomainValueObjectValidator<
    eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeValueObject3>
{
    public FakeValueObject3Validator()
    {
        FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.StringProperty));
    }
}
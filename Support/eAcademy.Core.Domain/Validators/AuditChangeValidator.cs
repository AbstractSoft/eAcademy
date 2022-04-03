namespace eAcademy.Core.Domain.Validators;

public class AuditChangeValidator : BaseDomainValueObjectValidator<eAcademy.Core.Domain.ValueObjects.AuditChange>
{
    public AuditChangeValidator()
    {
        FluentValidation.DefaultValidatorExtensions.Length(
            FluentValidation.DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.Name)), 3, 100);
        FluentValidation.DefaultValidatorOptions.WithMessage(
            FluentValidation.DefaultValidatorExtensions.Must(RuleFor(x => x.Date), BeAValidDate),
            x => $"'{x.GetType().Name}::Date' is required.");
    }

    private bool BeAValidDate(System.DateTime date)
    {
        return !date.Equals(default);
    }
}
namespace eAcademy.Core.Domain;

public abstract class AbstractBase : eAcademy.Core.Domain.Validators.IValidateable
{
    public virtual void ValidateAndThrow()
    {
        var validationResult = GetValidator()
            .Validate(new FluentValidation.ValidationContext<object>(this));

        if (validationResult?.IsValid == false) throw new FluentValidation.ValidationException(validationResult.Errors);
    }

    public AbstractBase Copy()
    {
        return Copy(System.Array.Empty<object>());
    }

    public AbstractBase Copy(params object[] parametersValues)
    {
        var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap(GetType(), GetType())
            .ConstructUsing(x => System.Activator.CreateInstance(GetType(), parametersValues)));

        config.AssertConfigurationIsValid();

        var mapper = config.CreateMapper();

        return (AbstractBase)mapper.Map(this, GetType(), GetType());
    }

    protected abstract FluentValidation.IValidator GetValidator();
}
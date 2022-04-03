namespace eAcademy.Core.Domain.Helpers;

public static class Constants
{
    public static T GetNullObject<T>()
        where T : eAcademy.Core.Domain.Entities.DomainEntity
    {
        return Activator.CreateInstance<T, System.Guid>(System.Guid.Empty) ??
               throw new System.InvalidOperationException();
    }

    public static T GetNullObject<T>(params object[] parametersValues)
        where T : eAcademy.Core.Domain.ValueObjects.ValueObject
    {
        return (T)(System.Activator.CreateInstance(typeof(T), parametersValues) ??
                   throw new System.InvalidOperationException());
    }

    public static string GetNullString()
    {
        return string.Empty;
    }

    public static System.Uri GetNullUri()
    {
        return new System.Uri("about:blank");
    }
}
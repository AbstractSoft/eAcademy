namespace eAcademy.Core.Domain.Helpers;

public static class Activator
{
    public static object CreateInstance(System.Type type)
    {
        try
        {
            var ctor = type.GetConstructor(System.Array.Empty<System.Type>());

            if (ctor != null) return ctor.Invoke(null);

            throw new System.InvalidOperationException("Parameterless constructor was not found for type " + type.Name);
        }
        catch (System.Reflection.TargetInvocationException ex)
        {
            if (ex.InnerException?.InnerException == null) throw;

            throw ex.InnerException.InnerException;
        }
    }

    public static TResult CreateInstance<TResult>()
        where TResult : class
    {
        return GetInstance<TResult>(null!, null!);
    }

    public static TResult CreateInstance<TResult, TParam>(params object[] parametersValues)
        where TResult : class
    {
        return GetInstance<TResult>(GetParametersTypes<TParam>(), parametersValues);
    }

    public static TResult CreateInstance<TResult, TParam1, TParam2>(params object[] parametersValues)
        where TResult : class
        where TParam1 : class
        where TParam2 : class
    {
        return GetInstance<TResult>(GetParametersTypes<TParam1, TParam2>(), parametersValues);
    }

    public static TResult CreateInstance<TResult, TParam1, TParam2, TParam3>(params object[] parametersValues)
        where TResult : class
        where TParam1 : class
        where TParam2 : struct
        where TParam3 : struct
    {
        return GetInstance<TResult>(GetParametersTypes<TParam1, TParam2, TParam3>(), parametersValues);
    }

    public static TResult CreateInstance<TResult, TParam1, TParam2, TParam3, TParam4>(
        params object[] parametersValues)
        where TResult : class
        where TParam1 : class
        where TParam2 : class
        where TParam3 : struct
        where TParam4 : struct
    {
        return GetInstance<TResult>(GetParametersTypes<TParam1, TParam2, TParam3, TParam4>(), parametersValues);
    }

    private static T GetInstance<T>(System.Type[] parametersTypes, params object[] parametersValues)
    {
        if (parametersTypes != null && parametersValues != null &&
            parametersTypes.Length != parametersValues.Length)
            throw new System.InvalidOperationException(
                "The number of parameter types is different than the number of parameter values");

        var type = typeof(T);
        var ctor = type.GetConstructor(parametersTypes ?? new System.Type[] { });
        if (ctor != null)
            return (T)ctor.Invoke(
                System.Reflection.BindingFlags.CreateInstance |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.OptionalParamBinding,
                null,
                parametersValues,
                System.Globalization.CultureInfo.InvariantCulture);

        throw new System.Reflection.TargetInvocationException(string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            "'{0}' failed to initialize. No suitable constructor method was found", type.FullName), null);
    }

    private static System.Type[] GetParametersTypes<T1>()
    {
        return new[] { typeof(T1) };
    }

    private static System.Type[] GetParametersTypes<T1, T2>()
    {
        return new[] { typeof(T1), typeof(T2) };
    }

    private static System.Type[] GetParametersTypes<T1, T2, T3>()
    {
        return new[] { typeof(T1), typeof(T2), typeof(T3) };
    }

    private static System.Type[] GetParametersTypes<T1, T2, T3, T4>()
    {
        return new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
    }
}
namespace eAcademy.Core.Domain.Helpers;

public static class EnumHelper
{
    public static T ToEnum<T>(string value)
        where T : struct
    {
        if (value == null) throw new System.ArgumentNullException(nameof(value));

        if (!typeof(T).IsEnum) throw new System.ArgumentException($"{typeof(T).Name} is not an enumeration.");

        if (System.Enum.TryParse(value, true, out T outEnum)) return outEnum;

        var type = typeof(T);

        var values = System.Enum.GetValues(type);

        foreach (var val in values)
        {
            var memInfo = type.GetMember(type.GetEnumName(val) ?? throw new System.InvalidOperationException());

            var descriptionAttribute = System.Linq.Enumerable.FirstOrDefault(memInfo[0]
                    .GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)) as
                System.ComponentModel.DescriptionAttribute;

            if (descriptionAttribute == null)
            {
                continue;
            }

            var descriptionValue = descriptionAttribute.Description;
            if (string.Compare(value, descriptionValue, System.StringComparison.OrdinalIgnoreCase) == 0)
            {
                return (T)val;
            }
        }

        throw new System.ArgumentOutOfRangeException(null,
            $"'{value}' does not exist in the enumeration {typeof(T).Name}.");
    }

    public static string GetDescriptionFromEnumValue(System.Enum value)
    {
        var attribute = System.Linq.Enumerable.SingleOrDefault(
            System.Reflection.CustomAttributeExtensions.GetCustomAttributes<System.ComponentModel.DescriptionAttribute>(
                value.GetType()
                    .GetField(value.ToString()) ?? throw new System.InvalidOperationException()));

        if (attribute == null)
            throw new System.ArgumentException(
                $"Enum does not contain a description for the given value. Type: '{value.GetType()}', Description '{value}'.");

        return attribute.Description;
    }

    public static T GetEnumValueFromDescription<T>(string description)
        where T : struct
    {
        var success = TryGetEnumValueFromDescription<T>(description, out var value);
        if (!success)
            throw new System.ArgumentException(
                $"Enum does not contain a value with the given description. Type: '{typeof(T)}', Description '{description}'.");

        return value;
    }

    private static bool TryGetEnumValueFromDescription<T>(string description, out T value)
        where T : struct
    {
        var type = typeof(T);
        if (!type.IsEnum) throw new System.ArgumentException($"Type argument must be enum. Type: '{type}'.");

        var fieldWithGivenDescription = System.Linq.Enumerable.SingleOrDefault(type.GetFields(), fieldInfo =>
        {
            var fieldDescriptionAttributes =
                System.Reflection.CustomAttributeExtensions
                    .GetCustomAttributes<System.ComponentModel.DescriptionAttribute>(fieldInfo);
            return System.Linq.Enumerable.Any(fieldDescriptionAttributes, fieldDescriptionAttribute =>
                string.Equals(fieldDescriptionAttribute.Description, description));
        });

        if (fieldWithGivenDescription == null)
        {
            value = default;
            return false;
        }

        value = (T)(fieldWithGivenDescription.GetRawConstantValue() ?? throw new System.InvalidOperationException());
        return true;
    }
}
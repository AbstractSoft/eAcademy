namespace eAcademy.Core.Domain.UnitTests;

[Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute]
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class EnumHelperTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ToEnum_ThrowsArgumentNullExceptionIfTheValueToConvertIsNull()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.ArgumentNullException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, static () =>
                    eAcademy.Core.Domain.Helpers.EnumHelper
                        .ToEnum<eAcademy.Core.Domain.UnitTests.Fakes.TestEnum>(null!),
                @"Value cannot be null. (Parameter 'value')");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ToEnum_ThrowsArgumentExceptionIfTheValueToConvertIsNotInEnum()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.ArgumentOutOfRangeException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, static () =>
                    eAcademy.Core.Domain.Helpers.EnumHelper.ToEnum<eAcademy.Core.Domain.UnitTests.Fakes.TestEnum>(
                        "value11"),
                "'value11' does not exist in the enumeration TestEnum.");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ToEnum_ThrowsArgumentExceptionIfTheTypeToConvertToIsNotInEnum()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.ArgumentException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, static () =>
                    eAcademy.Core.Domain.Helpers.EnumHelper.ToEnum<eAcademy.Core.Domain.UnitTests.Fakes.TestStruct>(
                        "value11"),
                "TestStruct is not an enumeration.");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ToEnum_WorksOkIfTheValueIsInEnumButWithDifferentCase()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(
            eAcademy.Core.Domain.UnitTests.Fakes.TestEnum.Value1,
            eAcademy.Core.Domain.Helpers.EnumHelper.ToEnum<eAcademy.Core.Domain.UnitTests.Fakes.TestEnum>("value1"));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ToEnum_WorksOkIfTheValueIsInEnumMemberDescriptionAttributeButWithDifferentCase()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(
            eAcademy.Core.Domain.UnitTests.Fakes.TestEnum.Value1,
            eAcademy.Core.Domain.Helpers.EnumHelper.ToEnum<eAcademy.Core.Domain.UnitTests.Fakes.TestEnum>("value_1"));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void GetDescriptionFromEnumValue_GetsDescriptionForEnumValueWithDescription()
    {
        var description =
            eAcademy.Core.Domain.Helpers.EnumHelper.GetDescriptionFromEnumValue(eAcademy.Core.Domain.UnitTests.Fakes
                .TestEnum.Value2);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(description, "Value_2");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void GetDescriptionFromEnumValue_ThrowsArgumentExceptionForEnumValueWithoutDescription()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<System.ArgumentException>(static () =>
            eAcademy.Core.Domain.Helpers.EnumHelper.GetDescriptionFromEnumValue(eAcademy.Core.Domain.UnitTests.Fakes
                .TestEnum.Value3));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void GetEnumValueFromDescription_GetsEnumValueForExistingDescription()
    {
        var result = eAcademy.Core.Domain.Helpers.EnumHelper
            .GetEnumValueFromDescription<eAcademy.Core.Domain.UnitTests.Fakes.TestEnum>("Value_2");
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result,
            eAcademy.Core.Domain.UnitTests.Fakes.TestEnum.Value2);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void GetEnumValueFromDescription_ThrowsArgumentExceptionForNonExistingDescription()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<System.ArgumentException>(static () =>
            eAcademy.Core.Domain.Helpers.EnumHelper
                .GetEnumValueFromDescription<eAcademy.Core.Domain.UnitTests.Fakes.TestEnum>(
                    "NonExistentDescription"));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void GetEnumValueFromDescription_ThrowsArgumentExceptionForRetrievalByEnumName()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<System.ArgumentException>(() =>
            eAcademy.Core.Domain.Helpers.EnumHelper
                .GetEnumValueFromDescription<eAcademy.Core.Domain.UnitTests.Fakes.TestEnum>(
                    nameof(eAcademy.Core.Domain.UnitTests.Fakes.TestEnum.Value3)));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void GetEnumValueFromDescription_ThrowsArgumentExceptionIfTheTypeToConvertToIsNotAnEnum()
    {
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<System.ArgumentException>(() =>
            eAcademy.Core.Domain.Helpers.EnumHelper
                .GetEnumValueFromDescription<eAcademy.Core.Domain.UnitTests.Fakes.TestStruct>(
                    nameof(eAcademy.Core.Domain.UnitTests.Fakes.TestEnum.Value3)));
    }
}
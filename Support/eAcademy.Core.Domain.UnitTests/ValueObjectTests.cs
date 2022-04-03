namespace eAcademy.Core.Domain.UnitTests;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute]
public class ValueObjectTests
{
    private const string FullName = "SSW\\Jason";

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ShouldHaveCorrectDomainAndName()
    {
        var account = eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount.From(FullName);
        account.ValidateAndThrow();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("SSW", account.Domain);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Jason", account.Name);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ToStringReturnsCorrectFormat()
    {
        var account = eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount.From(FullName);
        account.ValidateAndThrow();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(FullName, account.ToString());
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ImplicitConversionToStringResultsInCorrectString()
    {
        var account = eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount.From(FullName);
        account.ValidateAndThrow();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(FullName, account);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ExplicitConversionFromStringSetsDomainAndName()
    {
        var account = (eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount)FullName;
        account.ValidateAndThrow();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("SSW", account.Domain);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Jason", account.Name);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ShouldThrowValidationExceptionForInvalidADAccount()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<FluentValidation.ValidationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, () =>
                {
                    var account = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount();
                    account.ValidateAndThrow();
                }, Constants.FakeADAccountValidationFailedMessage);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void EqualsReturnsFalseIfAValueObjectIsComparedWithNull()
    {
        var account = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(account.Equals(null!));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void EqualsReturnsFalseIfAValueObjectIsComparedWithOtherKindOfObject()
    {
        var account = new eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount();

        // ReSharper disable once SuspiciousTypeConversion.Global
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(account.Equals("test"));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void EqualsReturnsFalseIfAValueObjectMemberIsNull()
    {
        var account = eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount.From(FullName);
        var account2 = eAcademy.Core.Domain.UnitTests.Fakes.ValueObjects.FakeADAccount.From(FullName);
        account2.ResetName();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(account.Equals(account2));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void ValueObjectsWithDifferentValuesAreNotEqual()
    {
        var valueObj1 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObject
        {
            Thing = 1,
            ThingsEnumerable = new System.Collections.Generic.HashSet<int> { 1, 2 }
        };
        var valueObj2 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObject
        {
            Thing = 2,
            ThingsEnumerable = new System.Collections.Generic.HashSet<int> { 1, 2 }
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(valueObj1, valueObj2);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void EqualsWithEnumerableProperty()
    {
        var valueObj1 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObject
        {
            Thing = 1,
            ThingsEnumerable = new System.Collections.Generic.HashSet<int> { 2, 1 }
        };
        var valueObj2 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObject
        {
            Thing = 1,
            ThingsEnumerable = new System.Collections.Generic.HashSet<int> { 1, 2 }
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(valueObj1, valueObj2);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void EqualsWithCollectionProperty()
    {
        var valueObj1 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObject
        {
            Thing = 1,
            ThingsEnumerable = new System.Collections.Generic.List<int> { 1, 2 }
        };
        var valueObj2 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObject
        {
            Thing = 1,
            ThingsEnumerable = new System.Collections.Generic.List<int> { 1, 2 }
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(valueObj1, valueObj2);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void NotEqualWithCollectionProperty()
    {
        var valueObj1 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObject
        {
            Thing = 1,
            ThingsEnumerable = new System.Collections.Generic.List<int> { 2, 1 }
        };
        var valueObj2 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObject
        {
            Thing = 1,
            ThingsEnumerable = new System.Collections.Generic.List<int> { 1, 2 }
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(valueObj1, valueObj2);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void GetHashCode_DifferentPositionFieldValuesReturnDifferentHashes()
    {
        var valueObj1 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObjectForHash("a", "b");
        var valueObj2 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObjectForHash("b", "a");
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(
            valueObj1.GetHashCode(),
            valueObj2.GetHashCode()
        );
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void GetHashCode_DifferentValuesReturnDifferentHashes()
    {
        var valueObj1 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObjectForHash("ab", "c");
        var valueObj2 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObjectForHash("a", "bc");
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(
            valueObj1.GetHashCode(),
            valueObj2.GetHashCode()
        );
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void GetHashCode_SamePositionFieldValuesReturnSameHashes()
    {
        var valueObj1 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObjectForHash("a", "b");
        var valueObj2 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObjectForHash("a", "b");
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(
            valueObj1.GetHashCode(),
            valueObj2.GetHashCode()
        );
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void Copy_CreatesAnIdenticalCopyForAValueObjectWithoutCtorParams()
    {
        var valueObj1 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObject
        {
            Thing = 1,
            ThingsEnumerable = new System.Collections.Generic.List<int> { 2, 1 }
        };

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(valueObj1, valueObj1.Copy());
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void Copy_CreatesAnIdenticalCopyForAValueObjectWithCtorParams()
    {
        var valueObj1 = new eAcademy.Core.Domain.UnitTests.Fakes.Entities.CustomValueObjectForHash("a", "b");

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(valueObj1, valueObj1.Copy("a", "b"));
    }
}
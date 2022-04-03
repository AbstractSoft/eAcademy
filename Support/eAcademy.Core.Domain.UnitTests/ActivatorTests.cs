namespace eAcademy.Core.Domain.UnitTests;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute]
public class ActivatorTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void CreateInstance_CreatesTheRightInstanceOfClassWithoutCtorParametersUsingGenerics()
    {
        var iVar = System.Activator.CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass>();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(iVar,
            typeof(eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void CreateInstance_CreatesTheRightInstanceOfClassWithoutCtorParameters()
    {
        var iVar = System.Activator.CreateInstance(typeof(eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass));

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(iVar,
            typeof(eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void CreateInstance_CreatesANullObjectIfAClassWithoutCtorParametersGetsExtraParameters()
    {
        const string expectedExceptionMessage
            = "'eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass' failed to initialize. No suitable constructor method was found";
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.Reflection.TargetInvocationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, static () => eAcademy.Core.Domain.Helpers
                    .Activator
                    .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass, string>("abc"),
                expectedExceptionMessage);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void CreateInstance_ForAClassThatFailsToConstructThrowsException()
    {
        var outterEx =
            eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
                .ThrowsExceptionWithMessage<System.Reflection.TargetInvocationException>(
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, static () => eAcademy.Core.Domain.Helpers
                        .Activator
                        .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithExceptionThrownInCtor>(),
                    "Exception has been thrown by the target of an invocation.");

        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ContainsExceptionWithMessage<System.InvalidOperationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, outterEx, "Ctor exception");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void CreateInstance_CreatesTheRightInstanceOfClassWithOneCtorParameter()
    {
        var iVar = eAcademy.Core.Domain.Helpers.Activator
            .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithCtor1Param, string>("abc");

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(iVar,
            typeof(eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithCtor1Param));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedExceptionAttribute(typeof(System.InvalidOperationException))]
    public void CreateInstance_ThrowsInvalidOperationExceptionWhenTheArgumentWasNotProvided()
    {
        eAcademy.Core.Domain.Helpers.Activator
            .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithCtor1Param, string>();
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void CreateInstance_CreatesTheRightInstanceOfClassWithTwoCtorParameters()
    {
        var iVar = eAcademy.Core.Domain.Helpers.Activator
            .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithCtor2Params,
                string,
                eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass>("abc",
                System.Activator.CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass>());

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(iVar,
            typeof(eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithCtor2Params));
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedExceptionAttribute(typeof(System.InvalidOperationException))]
    public void CreateInstance_ThrowsInvalidOperationExceptionWhenTheArgumentsWereNotProvided()
    {
        eAcademy.Core.Domain.Helpers.Activator
            .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithCtor2Params,
                string,
                eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass>();
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedExceptionAttribute(typeof(System.InvalidOperationException))]
    public void CreateInstance_ThrowsInvalidOperationExceptionWhenThe1StArgumentWasNotProvided()
    {
        eAcademy.Core.Domain.Helpers.Activator
            .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithCtor2Params,
                string,
                eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass>(System.Activator
                .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass>());
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedExceptionAttribute(typeof(System.InvalidOperationException))]
    public void CreateInstance_ThrowsInvalidOperationExceptionWhenThe2NdArgumentWasNotProvided()
    {
        eAcademy.Core.Domain.Helpers.Activator
            .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithCtor2Params,
                string,
                eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass>("abc");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedExceptionAttribute(typeof(System.ArgumentException))]
    public void CreateInstance_ThrowsInvalidOperationExceptionWhenTheArgumentsAreSwapped()
    {
        eAcademy.Core.Domain.Helpers.Activator
            .CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithCtor2Params,
                string,
                eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass>(
                System.Activator.CreateInstance<eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass>(), "abc");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void CreateInstance_CreatesAnInstanceOfSpecifiedRefType()
    {
        var simpleClass =
            (eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass)eAcademy.Core.Domain.Helpers.Activator.CreateInstance(
                typeof(eAcademy.Core.Domain.UnitTests.Fakes.SimpleClass));

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(simpleClass);
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void CreateInstance_CreatesAnInstanceOfARefTypeWithPrivateCtorThrowsInvalidOperationException()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.InvalidOperationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That,
                static () => eAcademy.Core.Domain.Helpers.Activator.CreateInstance(
                    typeof(eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithPrivateCtor)),
                "Parameterless constructor was not found for type SimpleClassWithPrivateCtor");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void CreateInstance_CreatesAnInstanceOfAValueTypeThrowsInvalidOperationException()
    {
        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ThrowsExceptionWithMessage<System.InvalidOperationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That,
                static () => eAcademy.Core.Domain.Helpers.Activator.CreateInstance(
                    typeof(eAcademy.Core.Domain.UnitTests.Fakes.TestStruct)),
                "Parameterless constructor was not found for type TestStruct");
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute]
    public void
        CreateInstance_CreatesAnInstanceOfARefTypeThatThrowsInvalidOperationExceptionInCtorThrowsTargetInvocationException()
    {
        var outterEx =
            eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
                .ThrowsExceptionWithMessage<System.Reflection.TargetInvocationException>(
                    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That,
                    static () => eAcademy.Core.Domain.Helpers.Activator.CreateInstance(
                        typeof(eAcademy.Core.Domain.UnitTests.Fakes.SimpleClassWithExceptionThrownInCtor)),
                    "Exception has been thrown by the target of an invocation.");

        eAcademy.Core.Domain.UnitTests.TestingUtils.AssertExtensions
            .ContainsExceptionWithMessage<System.InvalidOperationException>(
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.That, outterEx, "Ctor exception");
    }
}
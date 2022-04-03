namespace eAcademy.Core.Domain.UnitTests.TestingUtils;

#region

using CoreConstants = eAcademy.Core.Domain.Helpers.Constants;

#endregion

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public static class AssertExtensions
{
    public static TException ThrowsExceptionWithMessage<TException>(
        this Microsoft.VisualStudio.TestTools.UnitTesting.Assert assert, System.Action action,
        string expectedMessage)
        where TException : System.Exception
    {
        var ex = Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<TException>(action);

        var normalized1 = System.Text.RegularExpressions.Regex.Replace(expectedMessage, @"\s", "");
        var normalized2 = System.Text.RegularExpressions.Regex.Replace(ex.Message, @"\s", "");

        // normalized1 = expectedMessage;
        // normalized2 = ex.Message;

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(normalized1, normalized2);

        return ex;
    }

    public static void ContainsExceptionWithMessage<TException>(
        this Microsoft.VisualStudio.TestTools.UnitTesting.Assert assert, System.Exception outterException,
        string expectedMessage)
        where TException : System.Exception
    {
        const string errWrongExceptionWasThrown = "Wrong type of exception was thrown";
        const string errWrongExceptionMessage = "Wrong exception message was returned";
        var expectedExceptionType = typeof(TException);

        var actualException = System.Linq.Enumerable.FirstOrDefault(EnumerateNestedExceptions(outterException),
            nestedException => nestedException.GetType() == expectedExceptionType);
        if (actualException == null)
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail(string.Format(
                System.Globalization.CultureInfo.InvariantCulture,
                "Expected:<{0}>. Actual:<{1}>. {2}", expectedExceptionType, outterException.GetType(),
                errWrongExceptionWasThrown));

        var normalizedExpectedMessage = System.Text.RegularExpressions.Regex.Replace(expectedMessage, @"\s", "");
        var normalizedActualMessage = System.Text.RegularExpressions.Regex.Replace(
            actualException?.Message ?? CoreConstants.GetNullString(),
            @"\s", "");

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(
            normalizedExpectedMessage,
            normalizedActualMessage,
            true,
            System.Globalization.CultureInfo.InvariantCulture,
            errWrongExceptionMessage);
    }

    private static System.Collections.Generic.IEnumerable<System.Exception> EnumerateNestedExceptions(
        System.Exception exception)
    {
        var currentException = exception;
        while (currentException != null)
        {
            yield return currentException;
            currentException = currentException.InnerException;
        }
    }
}
namespace Atata.KendoUI.Tests;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class PlainTestCaseSourceAttribute : TestCaseSourceAttribute
{
    public PlainTestCaseSourceAttribute(params object[] values)
        : base(typeof(PlainTestCaseSourceAttribute), nameof(GetValues), new object[] { values })
    {
    }

    public static IEnumerable<object> GetValues(object[] values) =>
        values;
}

namespace Atata.KendoUI.Tests;

public static class TestCaseSources
{
    public sealed class JQueryAttribute : PlainTestCaseSourceAttribute
    {
        public JQueryAttribute()
            : base([.. KendoLibraries.JQueryVersions.Select(x => $"{KendoLibraries.JQuery}/{x}")])
        {
        }
    }

    public sealed class AngularAttribute : PlainTestCaseSourceAttribute
    {
        public AngularAttribute()
            : base(KendoLibraries.Angular)
        {
        }
    }

    public sealed class ReactAttribute : PlainTestCaseSourceAttribute
    {
        public ReactAttribute()
            : base(KendoLibraries.React)
        {
        }
    }

    public sealed class VueAttribute : PlainTestCaseSourceAttribute
    {
        public VueAttribute()
            : base(KendoLibraries.Vue)
        {
        }
    }

    public sealed class AspNetMvcAttribute : PlainTestCaseSourceAttribute
    {
        public AspNetMvcAttribute()
            : base(KendoLibraries.AspNetMvc)
        {
        }
    }

    public sealed class AspNetCoreAttribute : PlainTestCaseSourceAttribute
    {
        public AspNetCoreAttribute()
            : base(KendoLibraries.AspNetCore)
        {
        }
    }
}

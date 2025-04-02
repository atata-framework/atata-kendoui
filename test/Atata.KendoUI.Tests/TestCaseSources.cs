namespace Atata.KendoUI.Tests;

public static class TestCaseSources
{
    public class JQueryAttribute : PlainTestCaseSourceAttribute
    {
        public JQueryAttribute()
            : base([.. KendoLibraries.JQueryVersions.Select(x => $"{KendoLibraries.JQuery}/{x}")])
        {
        }
    }

    public class AngularAttribute : PlainTestCaseSourceAttribute
    {
        public AngularAttribute()
            : base(KendoLibraries.Angular)
        {
        }
    }

    public class ReactAttribute : PlainTestCaseSourceAttribute
    {
        public ReactAttribute()
            : base(KendoLibraries.React)
        {
        }
    }

    public class VueAttribute : PlainTestCaseSourceAttribute
    {
        public VueAttribute()
            : base(KendoLibraries.Vue)
        {
        }
    }

    public class AspNetMvcAttribute : PlainTestCaseSourceAttribute
    {
        public AspNetMvcAttribute()
            : base(KendoLibraries.AspNetMvc)
        {
        }
    }

    public class AspNetCoreAttribute : PlainTestCaseSourceAttribute
    {
        public AspNetCoreAttribute()
            : base(KendoLibraries.AspNetCore)
        {
        }
    }
}

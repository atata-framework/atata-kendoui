using System.Collections.ObjectModel;

namespace Atata.KendoUI.Tests;

public static class KendoLibraries
{
    public const string JQuery = "jQuery";

    public const string Angular = "Angular";

    public const string React = "React";

    public const string Vue = "Vue";

    public const string AspNetMvc = "ASP.NET Mvc";

    public const string AspNetCore = "ASP.NET Core";

    public static readonly ReadOnlyCollection<string> JQueryVersions = new(new[]
    {
        "2020.3.1118",
        "2022.3.1109"
    });
}

@Echo OFF
SET PATH=C:\Program Files (x86)\MSBuild\14.0\Bin

MSbuild "src\Atata.KendoUI\Atata.KendoUI.csproj" /p:Configuration=Release
Echo Build process completed

..\nuget pack src\Atata.KendoUI.nuspec
Echo NuGet package created

Set /p Wait=Press Enter to continue...
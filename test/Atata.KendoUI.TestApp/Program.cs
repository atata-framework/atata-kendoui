var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

#pragma warning disable S4507 // Debugging features should not be enabled in production
app.UseDeveloperExceptionPage();
#pragma warning restore S4507 // Debugging features should not be enabled in production

app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

#pragma warning disable S6966 // Awaitable method should be used
app.Run();
#pragma warning restore S6966 // Awaitable method should be used

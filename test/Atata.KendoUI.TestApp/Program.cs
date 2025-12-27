var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

#pragma warning disable S6966 // Awaitable method should be used
app.Run();
#pragma warning restore S6966 // Awaitable method should be used

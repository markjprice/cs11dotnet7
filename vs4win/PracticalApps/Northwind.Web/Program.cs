using Packt.Shared; // AddNorthwindContext extension method

// configure services

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddNorthwindContext();
var app = builder.Build();

// configure the HTTP pipeline

if (!app.Environment.IsDevelopment())
{
  app.UseHsts();
}

app.Use(async (HttpContext context, Func<Task> next) =>
{
  RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;

  if (rep is not null)
  {
    WriteLine($"Endpoint name: {rep.DisplayName}");
    WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
  }

  if (context.Request.Path == "/bonjour")
  {
    // in the case of a match on URL path, this becomes a terminating
    // delegate that returns so does not call the next delegate
    await context.Response.WriteAsync("Bonjour Monde!");
    return;
  }

  // we could modify the request before calling the next delegate
  await next();

  // we could modify the response after calling the next delegate
});

app.UseHttpsRedirection();

app.UseDefaultFiles(); // index.html, default.html, and so on
app.UseStaticFiles();

app.MapRazorPages();
app.MapGet("/hello", () => "Hello World!");

// start the web server

app.Run();

WriteLine("This executes after the web server has stopped!");
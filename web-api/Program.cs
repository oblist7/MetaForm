using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "5173";


builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("FormSubmissions"));

builder.WebHost.UseUrls("http://localhost:8080");

var app = builder.Build();


app.UseCors("AllowAll");
app.UseHttpsRedirection();


app.Urls.Add($"http://0.0.0.0:{port}");

app.MapControllers();

app.Run();

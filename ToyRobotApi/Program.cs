using ToyRobotApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(new Robot(5));
// Add controllers support.
builder.Services.AddControllers();
var app = builder.Build();
// Map controller endpoints.
app.MapControllers();

app.Run();

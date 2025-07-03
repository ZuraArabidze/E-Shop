var builder = WebApplication.CreateBuilder(args);


// Add servvices to the container

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapGet("/", () => "Hello World!");

app.Run();

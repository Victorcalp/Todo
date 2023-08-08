using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //informa que vai usar controllers

builder.Services.AddDbContext<Context>(); //add serviço do BD

var app = builder.Build();

app.MapControllers(); //mapea os controllers

app.Run();

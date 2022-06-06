using Core.Interface;
using Infrastructure.Data;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IScrumBoardRepository, ScrumBoardRepository>();

WebApplication? app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
using CatalogoLivros.Application;
using CatalogoLivros.Infra;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfraServices(builder.Configuration);

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(configure =>
    configure
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
        .WithExposedHeaders("x-total-count")
        .WithExposedHeaders("content-disposition")
);
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

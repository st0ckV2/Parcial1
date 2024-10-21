using Microsoft.EntityFrameworkCore;
using Parcial1.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=con"));
builder.Services.AddTransient<SeederDB>();

var app = builder.Build();

SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory? scopeFactory = app.Services.GetService<IServiceScopeFactory>();
    using (IServiceScope? scope=scopeFactory!.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service!.SeedAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

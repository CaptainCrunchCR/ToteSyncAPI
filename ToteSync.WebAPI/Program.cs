using Microsoft.EntityFrameworkCore;
using ToteSync.DAL;

var builder = WebApplication.CreateBuilder(args);

// Get connection string for development
string? connectionStr;
if (builder.Environment.IsDevelopment())
{
    connectionStr = builder.Configuration["PostgreSQL:AdminConnectionString"];
}
else 
{
    connectionStr = builder.Configuration["PostgreSQL:OwnerConnectionString"];
}

builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseNpgsql(connectionStr, options => options.MigrationsAssembly("ToteSync.DAL"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Add services to the container.

builder.Services.AddControllers();

// Add swagger to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

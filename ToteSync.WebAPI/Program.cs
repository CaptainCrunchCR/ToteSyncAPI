using Microsoft.EntityFrameworkCore;
using ToteSync.DAL;
using ToteSync.DAL.Persistence;

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

//This should be commented or deleted, it is just for testing in ToteSync.PlaygroundTests project.
//builder.Services.AddScoped<DbContext, ApplicationDBContext>();

//Register concrete repositories as scoped services
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
builder.Services.AddScoped<IShoppingListItemRepository, ShoppingListItemRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

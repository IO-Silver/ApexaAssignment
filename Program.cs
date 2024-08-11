using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApexaAssignment.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApexaAssignmentContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ApexaAssignmentContext") ?? throw new InvalidOperationException("Connection string 'ApexaAssignmentContext' not found.")));

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Advisors}/{action=Index}/{id?}");

app.Run();

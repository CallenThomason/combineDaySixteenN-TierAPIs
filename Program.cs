using combineDaySixteenN_TierAPIs.Data;
using combineDaySixteenN_TierAPIs.Repositories;
using combineDaySixteenN_TierAPIs.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Registering our AppDbContext with Dependancy injection -> We use SQLite - > We're letting Ef core know we are using SQLite ->
//Getting our connection string location -> and that tell EF core where our Database is
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Whenever anyone asks for an ISupply, give them SupplyRepository
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();

//Whenever Anyone asks for an IsupplyService, give them SupplyService
builder.Services.AddScoped<ISupplyService, SupplyService>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using BankApp.Api.Data;
using BankApp.Api.Interfaces;
using BankApp.Api.Mappings;
using BankApp.Api.Repositories;
using BankApp.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BankAppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();
builder.Services.AddAutoMapper(cfg => { }, typeof(BankAccountMappingProfile));

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<BankAccountCore.IAccountNumberGenerator, BankAccountCore.AccountNumberGenerator>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

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

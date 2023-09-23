using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contract;
using Service;
using Service.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var provider = builder.Services.BuildServiceProvider();

var configService = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<HKRPInvoiceContext>(item => item.UseSqlServer(configService.GetConnectionString("dbcs")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
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

using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TravelCompany.Application.Mapper;
using TravelCompany.Application.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TravelCompanyContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
});

builder.Services.AddControllers().AddFluentValidation(s =>
{
	s.RegisterValidatorsFromAssemblyContaining<PhoneValidation>();
});

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(TravelCompanyMapper)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

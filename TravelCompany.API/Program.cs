using FluentValidation.AspNetCore;
using System.Reflection;
using TravelCompany.Application.Factories;
using TravelCompany.Application.Mapper;
using TravelCompany.Application.Service;
using TravelCompany.Application.Service.Interface;
using TravelCompany.Application.Validation;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(configuration);


builder.Services.AddControllers().AddFluentValidation(s =>
{
	s.RegisterValidatorsFromAssemblyContaining<PhoneValidation>();
});

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(TravelCompanyMapper)));

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
builder.Services.AddTransient<IRequestProviderService, RequestProviderService>();
builder.Services.AddTransient<DBContextFactory>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
	opt.AddPolicy(name: "MyAllowSpecificOrigins", builder =>
	{
		builder.WithOrigins("https://localhost:44303")
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");

app.UseCors("MyAllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Domain.Mapper;
using Services;
using Services.BusServices;
using Services.CompanyServices;
using Services.GenericRepo;
using Services.UnitOfWorkService;
using SwiftBusAPI.Extentions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // ✅ This enables controller discovery
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


// Custom services
builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); // ✅ Include this if you are using [Authorize] anywhere

app.MapControllers(); // ✅ This maps the controller endpoints

app.Run();

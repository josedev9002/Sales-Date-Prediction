using Microsoft.EntityFrameworkCore;
using Sales_Date_Prediction_.AutoMappers;
using Sales_Date_Prediction_.DTO_s;
using Sales_Date_Prediction_.Interfaces;
using Sales_Date_Prediction_.Models;
using Sales_Date_Prediction_.Repository;
using Sales_Date_Prediction_.Services;

var builder = WebApplication.CreateBuilder(args);


//conexiones base de datos
builder.Services.AddDbContext<StoreSampleContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreSampleConnection")).LogTo(Console.WriteLine));


// Add services to the container.
builder.Services.AddScoped<ICustomerServices, CustomersServices>();
builder.Services.AddScoped<IOrderServices, OrdersServices>();
builder.Services.AddScoped<IEmployeesServices, EmployeesServices>();
builder.Services.AddScoped<IShippersServices, ShippersServices>();
builder.Services.AddScoped<IProductsServices, ProductsServices>();
//configuración que me permite inyectar la cadena de conexión a los servicios sin exponerla
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


//mappers
builder.Services.AddAutoMapper(typeof(MappingProfiles));

//inyeccion dependencias repository
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrdersRepository>();
builder.Services.AddScoped<IRepository<EmployeesDTO>, EmployeesRepository>();
builder.Services.AddScoped<IRepository<Shipper>, ShippersRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductsRepository>();



builder.Services.AddControllers();
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

app.Run();

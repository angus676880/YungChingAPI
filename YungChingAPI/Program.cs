using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using YungChingAPI.Models;
using YungChingAPI.Repositorys;
using YungChingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add database
builder.Services.AddDbContext<MasterContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

// add service
builder.Services.AddScoped<IProductService, ProductService>();
// add repository
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();


builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
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

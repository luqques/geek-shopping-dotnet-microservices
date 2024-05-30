using AutoMapper;
using GeekShopping.ProductsApi.Config;
using GeekShopping.ProductsApi.Model.Context;
using GeekShopping.ProductsApi.Repository;
using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];

builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 0, 2)))
);

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddMvc();

builder.Services.AddHttpClient<IProductService, ProductService>(c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductApi"]));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping", Version =  "v1"});
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
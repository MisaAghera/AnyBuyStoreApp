
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.AddProductCategory;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetAllProductCategories;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProducts;
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<DatabaseContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));
// Add services to the container.
builder.Services.AddMediatR(
    typeof(GetAllProductsRequest).Assembly,
    typeof(GetAllProductCetgoriesRequest).Assembly,
    typeof(AddProductCategoryCommand).Assembly);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
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
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.Run();

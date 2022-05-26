using Microsoft.EntityFrameworkCore;
using stock_manager.Persistence.Context;
using stock_manager.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("LiberaTudo", builder => builder
        .WithOrigins(
            "http://localhost:3000", 
            "https://localhost:3000", 
            "https://localhost:7003",
            "http://localhost:5217"
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("DatabaseLocal")
    )
);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("LiberaTudo");//usado somente para facilitar, essa política não é segura para ambiente de produção
app.UseAuthorization();

app.MapControllers();

app.Run();

using Domain_Layer.Data;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Repository_layer.IRepository;
using Repository_layer.Repository;
using Service_Layer.CustomServices;
using Service_Layer.ICustomServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Con")));
// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomServices<Complaint>, ComplaintService>();
builder.Services.AddScoped<ICustomServices<User>, UserService>();
builder.Services.AddScoped<ICustomServices<Demand>, DemandService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:7134")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();

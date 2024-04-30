using Microsoft.EntityFrameworkCore;
using Model.Data;
using Repository;
using Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUser, User>();
builder.Services.AddControllers();
builder.Services.AddDbContext<typescript_demoContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();   
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowOrigin");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();

//API Automapper kullanýmý ile çalýþmýyordu ben de program.cs dosyasýna bu kod satýrýný ekleyerek bu sorunu çözdüm.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




builder.Services.AddScoped<ILocationService, LocationManager>();
builder.Services.AddScoped<ILocationDal, EFLocationDal>();

builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationDal>();

builder.Services.AddScoped<IOhsReportService, OhsReportManager>();
builder.Services.AddScoped<IOhsReportDal, EfOhsReportDal>();

builder.Services.AddScoped<IPersonelService, PersonelManager>();
builder.Services.AddScoped<IPersonelDal,EfPersonelDal>();

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

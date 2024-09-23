using Api.Extensions;
using Identity;
using Identity.DAL.Users;
using Identity.Helpers.Extensions;
using Shared;
using Shared.DAL;
using Shared.Helpers.Constants.AppSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();

//add modules
builder.Services.AddSharedModule();
builder.Services.AddIdentityModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

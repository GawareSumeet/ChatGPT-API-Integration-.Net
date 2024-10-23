using AutomatedResponseSystem.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();// is included to ensure the controller services are registered.
builder.Services.AddSingleton(new ChatGPTService(new HttpClient(), "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"));


var app = builder.Build();
// Map controllers

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();//call is in place to map attribute-routed API controllers.

app.Run();


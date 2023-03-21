using Microsoft.AspNetCore.Mvc;
using MinimalApp.Models;
using MinimalApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICoffeeService, CoffeeService>(); // this is about register the product service with the product interface

var app = builder.Build();

app.MapPost("/create", (CoffeeModel coffee, ICoffeeService service) => 
    {
        var result = service.Create(coffee);
        return Results.Ok(result); //this is how we call the create method.
    });


app.Run();

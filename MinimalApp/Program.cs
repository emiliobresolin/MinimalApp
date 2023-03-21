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


app.MapGet("/get", (int id, ICoffeeService service) =>
{
    var coffee = service.Get(id);
    if (coffee is null) return Results.NotFound("Coffee not found");
    return Results.Ok(coffee); //this is how we call the get method.
});

app.MapGet("/list", (ICoffeeService service) =>
{
    var coffees = service.List();
    
    return Results.Ok(coffees); //this is how we call the list method.
});

app.MapPut("/update", (CoffeeModel newCoffee, ICoffeeService service) =>
{
    var updatedCoffee = service.Update(newCoffee);

    if (updatedCoffee is null) return Results.NotFound("Coffee not found");

    return Results.Ok(updatedCoffee); //this is how we call the update method.
});

app.Run();

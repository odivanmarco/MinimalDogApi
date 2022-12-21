using DogAPIproject;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var dogs = new List<Dog>()
{
    new Dog("Shih Tzu","Brasil"),
    new Dog("Bulldog Inglês", "Argentina"),
    new Dog("Yorkshire Terrie", "Chile"),
    new Dog("Boxer", "Reino Unido")
};

app.MapGet("/dogs", () =>
{
    return Results.Ok(dogs);
})
.WithName("dogs");

app.MapGet("/dog", ([FromQuery] string name) =>
{
    var dog = dogs.FirstOrDefault(dog => dog.Breed.ToLower() == name.ToLower());

    if (dog == default)
    {
        return Results.NotFound();
    }

    return Results.Ok(dog);
});

app.MapPost("/dog", ([FromBody] Dog dog) =>
{
    dogs.Add(dog);

    return Results.Created($"dog/{dog.Breed}", dog);
});

app.MapDelete("/dogs", ([FromQuery] string name) =>
{
    var dog = dogs.Find(dog => dog.Breed.ToLower() == name.ToLower());
    dogs.Remove(dog);
    return Results.Ok();
});

app.Run();


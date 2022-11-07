using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FundaDb>(opt => opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/houses", async (FundaDb db) =>
    await db.Houses.ToListAsync());

app.MapGet("/houses/{id}", async (string id, FundaDb db) =>
    await db.Houses.FindAsync(id)
        is House house
            ? Results.Ok(house)
            : Results.NotFound());

app.MapPost("/houses", async (House house, FundaDb db) =>
{
    house.PriceDate = DateTime.Now;

    db.Houses.Add(house);
    await db.SaveChangesAsync();

    Console.WriteLine($"House added: {house.ToString()}");

    return Results.Created($"/houses/{house.Id}", house);
});

app.Run();



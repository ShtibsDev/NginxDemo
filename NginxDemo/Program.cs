using NginxDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

var people = new List<Person>{
    new Person { Id = 1, FirstName = "Ofir", LastName = "Stiber Voronzov" },
    new Person { Id = 2, FirstName = "Ellie", LastName = "Stiber Voronzov" },
    new Person { Id = 3, FirstName = "Steven", LastName = "Stiber Voronzov" },
    new Person { Id = 4, FirstName = "Connie", LastName = "Stiber Voronzov" },
    new Person { Id = 5, FirstName = "Michel", LastName = "Stiber Voronzov" }
};

app.MapGet("people", () => people);

app.MapGet("people/{id}", (int id) =>
{
  return people.FirstOrDefault(p => p.Id == id);
});

app.Run();

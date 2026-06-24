using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SIMS.Application;
using SIMS.Application.Products.Commands;
using SIMS.Application.Products.Queries;
using SIMS.Application.Addresses.Queries;
using SIMS.Application.Countries.Queries;
using SIMS.Application.Customers.Queries;
using SIMS.Infrastructure;
using SIMS.Infrastructure.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIMS API v1"));
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/products", async (CreateProductCommand command, ISender mediatr, CancellationToken ct) => 
{
    var result = await mediatr.Send(command, ct);
    if (result?.Value is null || Guid.Empty == result.Value.id) return Results.BadRequest();
    return Results.Created($"/products/{result.Value.id}", new { id = result.Value.id });
});

app.MapGet("/products", async (ISender mediatr, CancellationToken ct) =>
{
    var result = await mediatr.Send(new GetListProductsQuery(), ct);
    return Results.Ok(result.Value);
});

app.MapGet("/addresses", async (ISender mediatr, CancellationToken ct) =>
{
    var result = await mediatr.Send(new GetListAddressesQuery(), ct);
    return Results.Ok(result.Value);
});

app.MapGet("/countries", async (ISender mediatr, CancellationToken ct) =>
{
    var result = await mediatr.Send(new GetListCountriesQuery(), ct);
    return Results.Ok(result.Value);
});

app.MapGet("/customers", async (ISender mediatr, CancellationToken ct) =>
{
    var result = await mediatr.Send(new GetListCustomersQuery(), ct);
    return Results.Ok(result.Value);
});

app.MapGet("/", () =>
{
    return "ok";
});

app.Run();



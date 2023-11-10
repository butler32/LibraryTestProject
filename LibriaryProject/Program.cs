using LibraryProject.API.Extensions;
using LibraryProject.Application.Middlware;
using LibraryProject.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.SwaggerOptionsSet();

builder.Services.AddPersistence(builder.Configuration);

builder.Services.DISet(builder.Configuration);

builder.Services.AuthSet(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

await app.RolesSetAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var myDependency = services.GetRequiredService<IDataBaseSeeder>();
    myDependency.Seed(app).Wait();

    app.MapControllers();
}

app.Run();

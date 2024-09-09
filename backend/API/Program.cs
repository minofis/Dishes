using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IDishesRepository, DishesRepository>();
builder.Services.AddDbContext<DishesDbContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DishesDbContext)));
});

var app = builder.Build();

using(var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    try{
        var context = services.GetRequiredService<DishesDbContext>();
        await DishContextSeed.SeedAsync(context);
        await context.Database.MigrateAsync();
    }
    catch{}
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.MapControllers();
app.UseHttpsRedirection();
app.Run();

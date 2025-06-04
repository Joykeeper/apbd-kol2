using Kol2Preparation.Data;
using Kol2Preparation.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();

builder.Services.AddScoped<IDbService, DbService>();


var app = builder.Build();

app.MapControllers();

app.Run();
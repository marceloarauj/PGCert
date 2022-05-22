using api;
using api.Models.ServiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Pagcerto")));

#region Services
builder.Services.AddTransient<TransactionService>();
builder.Services.AddTransient<InstallmentService>();
builder.Services.AddTransient<AnticipationService>();
#endregion

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    swagger => {
        swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio PagCerto", Version = "V1" });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        swagger.IncludeXmlComments(xmlPath);
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

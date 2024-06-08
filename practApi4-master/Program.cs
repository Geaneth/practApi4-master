using Microsoft.Extensions.ML;
using practApi4.Data;
using practApi4.Service;
using Microsoft.OpenApi.Models;
using practApi4_ML;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPredictionEnginePool<ProductoRating, ProductoRatingPrediction>()
    .FromFile("MLRecomendation.mlnet");

builder.Services.AddSingleton<Productos>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Description = "Docs for my API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.MapPost("/predict",
    async (PredictionEnginePool<ProductoRating, ProductoRatingPrediction> predictionEnginePool, ProductoRating input) =>
        await Task.FromResult(predictionEnginePool.Predict(input)));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

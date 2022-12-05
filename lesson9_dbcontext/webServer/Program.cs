using lesson6;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Startup.GatherServices(builder.Services, builder.Configuration);

var app = builder.Build();

Startup.MigrateDB(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllerRoute(
    name: "Common",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();

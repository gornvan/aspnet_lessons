using lesson11_serilog.ErrorHandling;
using lesson11_serilog.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

SerilogConfigurator.ConfigureSerilog(builder, LogLevel.Warning, "log.txt");

var app = builder.Build();

var exceptionHandlingMiddleware = new LessonExceptionHandlerMiddleware(Log.Logger);

// FOR DEMONSTRATION, DO IT IN ANY MODE
app.UseExceptionHandler(options =>
{
    app.UseExceptionHandler(options =>
    {
        options.Run(exceptionHandlingMiddleware.HandleException);
    });
});
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default with id=0",
    pattern: "{controller=Home}/{action=Index}/{id=0}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();

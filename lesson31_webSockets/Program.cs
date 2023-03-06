using lesson31_webSockets;
using lesson31_webSockets.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// SIGNALR
// ####
builder.Services.AddSignalR();
// ####

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// RAW SOCKETS
// ####
var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};
app.UseWebSockets(webSocketOptions);
WebSocketPathBinder.BindWebSocketPath(app, "/ws");
// ####




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// SIGNALR 
// ####
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/notification");
});
// ####

app.Run();

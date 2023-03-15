using GreeterGrpcService.Services;

namespace GreeterGrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.

            builder.Services.AddControllers(); // for webapi/mvc controllers

            builder.Services.AddGrpc(); // GRPC


            var app = builder.Build();

            // UseRouting is required if we specify endpoints via app.UseEndpoints (...
            //app.UseRouting();

            app.MapControllers().RequireHost("*:5139");

            //Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>().RequireHost("*:7098");

            app.MapGet("/",
                () =>
                {
                    return "Communication with gRPC endpoints is on port 7098," +
                    " and it must be made through a gRPC client." +
                    " To learn how to create a client," +
                    "visit: https://go.microsoft.com/fwlink/?linkid=2086909";
                })
                .RequireHost("*:5139");

            app.Run();
        }
    }
}

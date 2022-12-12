using Serilog;
using Serilog.Events;

namespace lesson11_serilog.Logging
{
    public class SerilogConfigurator
    {
        public static void ConfigureSerilog(WebApplicationBuilder builder, LogLevel minimumLogLevel, string filename)
        {
            var outputTemplate = 
                $"{{Timestamp:HH:mm}} [l:{{Level}}] (th:{{ThreadId}}) " +
                $"Message: {{Message}}{{NewLine}}Esception: {{Exception}}";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.File(filename, outputTemplate: outputTemplate)
                .MinimumLevel.Is((LogEventLevel)minimumLogLevel)
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}

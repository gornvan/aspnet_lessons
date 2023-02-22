using lesson28_Configuration.ConfigModels;
using Microsoft.AspNetCore.Mvc;

namespace lesson28_Configuration.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigController : ControllerBase
{
    private readonly ILogger<ConfigController> _logger;
    private readonly EncryptionConfig? _encryptionConfig;
    private readonly List<PaypalAccountConfig>? _paypalAccounts;

    public ConfigController(ILogger<ConfigController> logger, IConfiguration configuration)
    {
        // bad way:
        //var key = configuration.GetChildren().First(cs => cs.Key == "EncryptionKey");
        
        // good way, with container classes:
        var appConfig = configuration.Get<ApplicationConfig>();

        // ignore nulls - just for demonstration
        _encryptionConfig = appConfig?.EncryptionConfig;
        _paypalAccounts = appConfig?.PayPalAccounts;
        _logger = logger;
    }

    [HttpGet("/Encription")]
    public EncryptionConfig Encription()
    {
        return _encryptionConfig ?? new EncryptionConfig { };
    }

    [HttpGet("/PayPal")]
    public List<PaypalAccountConfig> PayPal()
    {
        return _paypalAccounts ?? new List<PaypalAccountConfig>();
    }
}

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

    public ConfigController(
        ILogger<ConfigController> logger,
        EncryptionConfig encConfig,
        List<PaypalAccountConfig> paypalAccounts
        //, IConfiguration configuration
        )
    {
        // bad way:
        //var key = configuration.GetChildren().First(cs => cs.Key == "EncryptionKey");

        // better way, with container classes:
        // var appConfig = configuration.Get<ApplicationConfig>();

        // ignore nulls - just for demonstration
        //_encryptionConfig = appConfig?.EncryptionConfig;
        //_paypalAccounts = appConfig?.PayPalAccounts;

        // best way - depend and use exactly the classes that configure the service:
        _encryptionConfig = encConfig;
        _paypalAccounts = paypalAccounts;

        _logger = logger;
    }

    [HttpGet("Encryption")]
    public EncryptionConfig Encryption()
    {
        _encryptionConfig.EncryptionKey += "!";
        return _encryptionConfig ?? new EncryptionConfig { };
    }

    [HttpGet("PayPal")]
    public List<PaypalAccountConfig> PayPal()
    {
        return _paypalAccounts ?? new List<PaypalAccountConfig>();
    }
}

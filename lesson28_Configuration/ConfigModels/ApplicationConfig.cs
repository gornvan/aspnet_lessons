namespace lesson28_Configuration.ConfigModels
{
    public class ApplicationConfig
    {
        public List<PaypalAccountConfig>? PayPalAccounts { get; set; }

        public EncryptionConfig? EncryptionConfig { get; set; }

    }
}

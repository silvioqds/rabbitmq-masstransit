namespace API.RabbitMQ.MassTransit.Providers
{
    using Microsoft.Extensions.Configuration;

    public static class SettingsProvider
    {
        private static IConfiguration _configuration;

        // Método para inicializar a configuração
        public static void Initialize()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = configurationBuilder.Build();
        }

        public static string GetHostRabbitMQ()
        {
            return _configuration["RabbitMQ:Host"] ?? string.Empty;
        }
        public static string GetUsernameRabbitMQ()
        {
            return _configuration["RabbitMQ:Username"] ?? string.Empty;
        }
        public static string GetPasswordRabbitMQ()
        {
            return _configuration["RabbitMQ:Password"] ?? string.Empty;
        }
    }

}

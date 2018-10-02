using Microsoft.Extensions.Configuration;
using System;

namespace Estoque.DAO
{
    public class AppSettingsManager
    {
        private static IConfiguration _config;

        public static void ConfigureSettings(IConfiguration config)
        {
            try
            {
                _config = config ?? throw new ArgumentNullException("config");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string LancheWebConnection => _config.GetConnectionString("LancheDb");

    }
}
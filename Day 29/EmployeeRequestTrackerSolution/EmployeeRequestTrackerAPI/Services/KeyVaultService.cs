using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;



namespace EmployeeRequestTrackerAPI.Services
{

    public class KeyVaultService
    {
        private readonly SecretClient _secretClient;

        public KeyVaultService(IConfiguration configuration)
        {
            var keyVaultUri = new Uri(configuration["KeyVault:VaultUri"]);
            _secretClient = new SecretClient(keyVaultUri, new DefaultAzureCredential());
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);
            return secret.Value;
        }
    }
}
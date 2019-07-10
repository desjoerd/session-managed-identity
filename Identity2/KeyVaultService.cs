using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2
{
    public class KeyVaultService
    {
        private AzureServiceTokenProvider tokenProvider;
        private KeyVaultClient kvClient;

        public KeyVaultService()
        {
            tokenProvider = new AzureServiceTokenProvider();
            kvClient = new KeyVaultClient((authority, resource, scope) => tokenProvider.KeyVaultTokenCallback(authority, resource, scope));
        }

        public async Task<string> GetSecret(string baseUri, string name)
        {
            var secret = await kvClient.GetSecretAsync(baseUri, name);

            return secret.Value;
        }

    }
}

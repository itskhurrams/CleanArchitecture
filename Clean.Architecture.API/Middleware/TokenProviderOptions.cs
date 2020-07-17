using Microsoft.IdentityModel.Tokens;

using System;

namespace Clean.Architecture.API.Middleware {
    public class TokenProviderOptions {
        public string Path { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; }

        public SigningCredentials SigningCredentials { get; set; }
    }
}

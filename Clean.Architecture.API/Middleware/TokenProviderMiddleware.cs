using Clean.Architecture.Application.Interfaces.Application.User;
using Clean.Architecture.Domain.User;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clean.Architecture.API.Middleware {
    public class TokenProviderMiddleware {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;

        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options) {
            _next = next;
            _options = options.Value;
        }

        public Task Invoke(HttpContext context, IUserAccountService userAccountService) {
            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal)) {
                return _next(context);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType) {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request.");
            }

            return GenerateToken(context, userAccountService);
        }
        public static long ToUnixEpochDate(DateTime date) {
            return new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();
        }

        private async Task GenerateToken(HttpContext context, IUserAccountService userAccountService) {
            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];

            UserAccount _userAccount = null;
            var identity = await GetIdentity(username, password, userAccountService, _userAccount);
            _userAccount = identity.userAccount;
            if (identity.claimsIdentity == null || _userAccount == null) {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
            };

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds,
                UserId = _userAccount.ID,
                UserName = _userAccount.UserName ?? "",
            };

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
        private Task<(ClaimsIdentity claimsIdentity, UserAccount userAccount)> GetIdentity(string username, string password, IUserAccountService userAccountService, UserAccount UserAccountObject) {
            try {
                UserAccount userAccount = userAccountService.Login(username, password);
                if (userAccount != null) {
                    return Task.FromResult((
                        new ClaimsIdentity(
                            new System.Security.Principal.GenericIdentity(username, "Token"), new Claim[] { }),
                        userAccount));
                }

                return Task.FromResult< (ClaimsIdentity, UserAccount) >((null, null));
            }
            catch (Exception) {
                throw;
            }
        }
    }
}

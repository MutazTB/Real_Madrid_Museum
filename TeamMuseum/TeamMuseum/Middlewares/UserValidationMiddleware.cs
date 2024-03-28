using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeamMuseum.Services.Dtos;

namespace TeamMuseum.Middlewares
{
    public class UserValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public UserValidationMiddleware(RequestDelegate next) 
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                token = token.Split(" ").Last();
                //var claimsIdentity = httpContext.User.Identity as ClaimsIdentity;
                //if (claimsIdentity != null)
                //{

                //}
                if (!ValidateToken(token))
                {
                    httpContext.Response.StatusCode = 401;
                    await httpContext.Response.WriteAsync("User not authorize");
                }
            }
            await _next(httpContext);
        }

        private bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JWT_Secret.Issuer,
                ValidAudience = JWT_Secret.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_Secret.Key))
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);                
                return true;
            }
            catch (SecurityTokenException)
            {
                return false;
            }
        }

    }
}

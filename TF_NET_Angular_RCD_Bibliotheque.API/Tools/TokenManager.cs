using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Cutomers;

namespace TF_NET_Angular_RCD_Bibliotheque.API.Tools
{
    public class TokenManager
    {
        private IConfiguration _config;
        public TokenManager(IConfiguration config)
        {
                _config = config;
        }
        public string GenerateToken(CustomerLoginDTO customer)
        {
            string secretKey = _config.GetSection("TokenInfo").GetSection("secretKey").Value;

            //Création de la signature du token
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Création du Payload == Info contenue dans le token
            Claim[] myclaims = new[]
            {
                new Claim(ClaimTypes.Sid, customer.Id.ToString()),
                new Claim(ClaimTypes.GivenName, customer.Pseudo)
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                claims : myclaims,
                signingCredentials : credentials,
                expires : DateTime.Now.AddHours(1),
                issuer : "monServeur.com",
                audience : "monClient.com"
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}

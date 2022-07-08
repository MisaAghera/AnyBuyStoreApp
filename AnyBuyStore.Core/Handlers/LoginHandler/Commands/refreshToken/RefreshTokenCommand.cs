using AnyBuyStore.Data.Data;
using AnyBuyStore.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AnyBuyStore.Core.Handlers.LoginHandler.Commands.refreshToken
{
    public class RefreshTokenCommand : IRequest<TokenModel?>
    {
        public RefreshTokenCommand(RefreshModel @in)
        {
            In = @in;
        }
        public RefreshModel In { get; set; }
    }

    public class LoginHandler : IRequestHandler<RefreshTokenCommand, TokenModel?>
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public LoginHandler(DatabaseContext context, UserManager<User> userManager,
           RoleManager<IdentityRole<int>> roleManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<TokenModel?> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var tokenHandler  = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(command.In.Token);
            var userId = command.In.UserId;

            var refTable = _context.RefreshToken.FirstOrDefault(o => o.UserId == int.Parse(userId));
            if (refTable == null)
            {
                return null;
            }
            else
            {
                var token = GetToken(securityToken.Claims.ToList());
                var valss = new TokenModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = int.Parse(userId),
                    Expiration = DateTime.Now.AddSeconds(3),
                    IsAuthSuccessful = true,
                    Refreshtoken = GenerateRefreshToken(int.Parse(userId)),
                };
                return valss;
            }

            return null;

        }


        private string GenerateRefreshToken(int userId)
        {
            var randomnumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomnumber);
                string RefreshToken = Convert.ToBase64String(randomnumber);
                var user = _context.RefreshToken.FirstOrDefault(o => o.UserId == userId);
                if (user != null)
                {
                    user.Refreshtoken = RefreshToken;
                    _context.SaveChanges();
                }
                else
                {
                    var newRefreshToken = new RefreshToken()
                    {
                        UserId = userId,
                        Refreshtoken = RefreshToken,
                    };
                    _context.RefreshToken.Add(newRefreshToken);
                    _context.SaveChanges();
                }

                return RefreshToken;
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddSeconds(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }

    public class RefreshModel

    {
        public string? Token { get; set; }

        public string? Refreshtoken { get; set; }

        public string? UserId { get; set; }
    }


    public class TokenModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string? Token { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime? Expiration { get; set; }
        public string? Refreshtoken { get; set; }
    }


}




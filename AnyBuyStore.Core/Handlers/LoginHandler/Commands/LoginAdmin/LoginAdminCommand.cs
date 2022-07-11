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

namespace AnyBuyStore.Core.Handlers.LoginHandler.Commands.LoginAdminCommand
{
    public class LoginAdminCommand : IRequest<TokenModel?>
    {
        public LoginAdminCommand(LoginAdminModel @in)
        {
            In = @in;
        }
        public LoginAdminModel In { get; set; }
    }

    public class LoginHandler : IRequestHandler<LoginAdminCommand, TokenModel?>
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

        public async Task<TokenModel?> Handle(LoginAdminCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(command.In.Username);
            if(user == null || await _userManager.CheckPasswordAsync(user, command.In.Password)==false)
            {
                return null;
            }
            
            if (user != null && await _userManager.CheckPasswordAsync(user, command.In.Password))
            {
                var IsRoleAvailable = _context.UserRoles.Where(a => a.RoleId == 1 && a.UserId == user.Id).FirstOrDefault();

                if (IsRoleAvailable != null)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = GetToken(authClaims);

                    var valss = new TokenModel
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        UserId = user.Id,
                        UserName = user.UserName,
                        Expiration = DateTime.Now.AddMinutes(30),
                        IsAuthSuccessful = true,
                        Refreshtoken = GenerateRefreshToken(user.Id),
                    };
                    return valss;
                }
                return null;
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
                if(user != null)
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
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }

    public class LoginAdminModel

    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }


    public class TokenModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string? Token { get; set; }
        public int? UserId { get ; set; }
        public string? UserName { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime Expiration { get; set; }
        public string? Refreshtoken { get; set; }
    }


}




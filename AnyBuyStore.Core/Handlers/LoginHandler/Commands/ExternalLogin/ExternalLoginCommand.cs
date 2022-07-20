using AnyBuyStore.Core.Handlers.LoginHandler.Commands.ExternalLogin;
using AnyBuyStore.Data.Data;
using AnyBuyStore.Data.Models;

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Google.Apis.Auth;

namespace AnyBuyStore.Core.Handlers.LoginHandler.Commands.ExternalLogin
{
    public class ExternalLoginCommand : IRequest<TokenModel?>
    {
        public ExternalAuthModel model { get; set; }
    }



    public class LoginHandler : IRequestHandler<ExternalLoginCommand, TokenModel?>
    {
        private readonly IConfigurationSection _jwtSettings;
        private readonly IConfigurationSection _goolgeSettings;
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
            _jwtSettings = _configuration.GetSection("JWT");
            _goolgeSettings = _configuration.GetSection("GoogleAuthSettings");
        }

        public async Task<TokenModel?> Handle(ExternalLoginCommand command, CancellationToken cancellationToken)
        {


            var payload = await VerifyGoogleToken(command.model);

            if (payload == null)
                {
                    return null;
                }
                var info = new UserLoginInfo(command.model.Provider, payload.Subject, command.model.Provider);
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(payload.Email);
                    if (user == null)
                    {
                        user = new User { Email = payload.Email, UserName = payload.Email };
                        await _userManager.CreateAsync(user);
                        if (await _roleManager.RoleExistsAsync(UserRoles.Customer))
                        {
                            await _userManager.AddToRoleAsync(user, UserRoles.Customer);
                        }
                        await _userManager.AddLoginAsync(user, info);

                    }
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
                if (user == null)
                {
                    return null;
                }

                var IsRoleAvailable = _context.UserRoles.Where(a => a.RoleId == 2 && a.UserId == user.Id).FirstOrDefault();
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
                        Expiration = token.ValidTo,
                        IsAuthSuccessful = true,
                        Refreshtoken = GenerateRefreshToken(user.Id),


                    };
                    return valss;
                }
                return null;
            }
        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthModel externalAuth)
        {
            try
            {

                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _goolgeSettings.GetSection("clientId").Value }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                return payload;
            }
            catch (Exception )
            {
                //log an exception
                return null;
            }
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
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }

    public class ExternalAuthModel
    {
        public string? Provider { get; set; }
        public string? IdToken { get; set; }
    }
    public class TokenModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string? Token { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime Expiration { get; set; }
        public string? Refreshtoken { get; set; }
    }


}
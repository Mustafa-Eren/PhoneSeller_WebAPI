using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhoneSeller_WebAPI.App.Security;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PhoneSeller_WebAPI.Security
{
    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public TokenCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public Task<TokenResponseModel> Handle (TokenCommand request,CancellationToken cancellationToken)
        {
            var user = DbContext.Users.Where(user => user.Username == request.Username && user.Password == request.Password).FirstOrDefault();
            
            var permission = DbContext.UserPermissions.Include(x => x.Permission).FirstOrDefault(x => x.UserId == user.Id);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,permission.Permission.PermissionName)
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:SecurityKey"])
                );
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(Convert.ToInt16(configuration["JWT:Expiration"])),
                notBefore: DateTime.Now,
                claims: claims,
                signingCredentials: credentials
                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(jwtSecurityToken);
            
            if(user == null)
            {
                throw new BadHttpRequestException("user not found");
            }
            

         
            return Task.FromResult(new TokenResponseModel
            {
                Token = token,
                ID = user.Id,
                Permission= permission.Permission.PermissionName
            });
        }
    }
}
//public static TokenCommand CreateToken(IConfiguration configuration)
//{
//    TokenCommand token = new();

//    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
//        Encoding.UTF8.GetBytes(configuration["JWT:SecurityKey"])
//        );
//    SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


//    JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
//        issuer: configuration["JWT:Issuer"],
//        audience: configuration["JWT:Audience"],
//        expires: DateTime.Now.AddMinutes(Convert.ToInt16(configuration["JWT:Expiration"])),
//        notBefore: DateTime.Now,
//        signingCredentials: credentials
//        );
//    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
//    string tok = tokenHandler.WriteToken(jwtSecurityToken);

//    //byte[] numbers = new byte[32];
//    //using RandomNumberGenerator rand = RandomNumberGenerator.Create();
//    //rand.GetBytes(numbers);
//    //token.RefreshToken = Convert.ToBase64String(numbers);


//    return token;
//}
using APIIdentity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIIdentity.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public class TokenGenerator
    {
        private ApiContext _context;
        private IConfiguration _config;
        private CustomUser _user;

        public TokenGenerator(ApiContext context, IConfiguration config, CustomUser user)
        {
            _context = context;
            _config = config;
            _user = user;
        }

        public CustomUserToken GetToken()
        {
            CustomUserToken _userToken = null;
            TokenModel result = null;

            if (_context.CustomUserTokens.Count(x => x.UserId == _user.Id) > 0)
            {
                _userToken = _context.CustomUserTokens.FirstOrDefault(x => x.UserId == _user.Id);

                if (_userToken.ExpireDate <= DateTime.Now)
                {
                    result = Generate();
                    _userToken.Value = result.Token;
                    _userToken.ExpireDate = result.ExpireDate;
                    _context.CustomUserTokens.Update(_userToken);
                }
            }
            else
            {
                result = Generate();
                _userToken = new CustomUserToken
                {
                    UserId = _user.Id,
                    LoginProvider = "SystemAPI",
                    Name = _user.Fullname,
                    ExpireDate = result.ExpireDate,
                    Value = result.Token
                };

                _context.CustomUserTokens.Add(_userToken);
            }
            _context.SaveChanges();
            return _userToken;
        }

        private TokenModel Generate()
        {
            DateTime expDate = DateTime.Now.AddMinutes(1);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _config["Application:Audience"],
                Issuer = _config["Application:Issuer"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, _user.Id),
                    new Claim(ClaimTypes.Name, _user.Fullname),
                    new Claim(ClaimTypes.Email, _user.Email)
                }),
                Expires = expDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var token_str = tokenHandler.WriteToken(token);
            TokenModel result = new TokenModel();
            result.Token = token_str;
            result.ExpireDate = expDate;
            return result;
        }
    }
}

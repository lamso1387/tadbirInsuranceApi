using tadbirInsuranceApi.Domain;
using tadbirInsuranceApi.Models;
using tadbirInsuranceApi.Repository; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace tadbirInsuranceApi.Services
{
    public class UserService : GenericService<User>
    {
        private readonly string? jwt_secret = AppConstants.Setting.jwt?.secret;
        private readonly int? jwt_token_expire_minutes = AppConstants.Setting.jwt?.token_expire_minutes;
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public override async Task Add(User entity)
        {
            await _unitOfWork._userRepo.Add(entity); 
        }

        public async Task<User?> Authenticate(string username, string password)
        {
            User? user = await _unitOfWork._userRepo.GetByUsername(username);
            if (user == null)
            {
                return null;
            }
            else if (!VerifyPasswordHash(password, user.password_hash!, user.password_salt!))
            {
                return null;
            }
            user.jwt_token = GenerateJwtToken(user);
            user.permissions = await GetPermissions(user);
            return user;

        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwt_secret!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(nameof(User),
                Newtonsoft.Json.JsonConvert.SerializeObject(AuthenticateUserSelector.selector(user))) }),
                Expires = DateTime.UtcNow.AddMinutes((double)jwt_token_expire_minutes!),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public User? ValidateJwtToken(string? token)
        {
            if (token == null) return null;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwt_secret!);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var user = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<User>(jwtToken.Claims
                    .First(x => x.Type == nameof(User)).Value);

                // return user id from JWT token if validation successful
                return user;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
        public async Task<List<string>> GetPermissions(User user)
        {
            return await _unitOfWork._userRepo.GetPermissions(user);

        }
    }


}
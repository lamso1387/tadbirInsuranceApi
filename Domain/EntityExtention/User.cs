using tadbirInsuranceApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tadbirInsuranceApi.Domain
{
    public partial class User
    {
        [NotMapped]
        public string? password { get; set; }
        [NotMapped]
        public string full_name => $"{first_name} {last_name}";
        [NotMapped]
        public string? jwt_token { get; set; }
        [NotMapped]
        public List<string>? permissions { get; set; }

        public static void CreatePasswordHashS(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public void UpdatePasswordHash()
        {
            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHashS(password, out byte[] passwordHash, out byte[] passwordSalt);
                password_hash = passwordHash;
                password_salt = passwordSalt;
            }
        }
    }

}

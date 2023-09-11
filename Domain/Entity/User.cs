using tadbirInsuranceApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tadbirInsuranceApi.Domain
{
    public partial class User : GenericEntity
    {
        public virtual ICollection<UserRole>? user_roles { get; set; }
        [Required]
        public string? national_code { get; set; }
        [Required]
        public string? first_name { get; set; }
        [Required]
        public string? last_name { get; set; }
        [Required]
        public string? mobile { get; set; }
        [Required]
        public byte[]? password_hash { get; set; }
        [Required]
        public byte[]? password_salt { get; set; }
        [Required]
        public string username { get; set; } = null!;
        public bool? change_pass_next_login { get; set; } = true;
        public DateTime? last_login { get; set; }
        public bool is_admin { get; set; } = false;
    }

}

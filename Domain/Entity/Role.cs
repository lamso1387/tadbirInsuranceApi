
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.Data;
using System.IO;
using tadbirInsuranceApi.Data;

namespace tadbirInsuranceApi.Domain
{
    public partial class Role : GenericEntity
    {
        public virtual ICollection<UserRole>? user_roles { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? permissions { get; set; } 
    }
}

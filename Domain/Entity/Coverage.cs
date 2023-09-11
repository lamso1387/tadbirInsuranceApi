using System.ComponentModel.DataAnnotations;

namespace tadbirInsuranceApi.Domain
{
    public partial class Coverage : GenericEntity
    {
        public virtual ICollection<InsurancePolicyCoverage>? insurance_policies { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public long min_capial { get; set; }
        [Required]
        public long max_capial { get; set; }
        [Required]
        public double rate { get; set; }
    }
}

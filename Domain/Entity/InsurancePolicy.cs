using System.ComponentModel.DataAnnotations;

namespace tadbirInsuranceApi.Domain
{
    public partial class InsurancePolicy : GenericEntity
    {
        public virtual ICollection<InsurancePolicyCoverage>? coverages { get; set; }
        [Required]
        public string? title { get; set; }
        public long total_premium { get; set; }
    }
}

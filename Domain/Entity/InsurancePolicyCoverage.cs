

namespace tadbirInsuranceApi.Domain;

public partial class InsurancePolicyCoverage : GenericEntity
{
    public long insurance_policy_id { get; set; }
    public  virtual InsurancePolicy? insurance_policy { get; set; }
    public long coverage_id { get; set; }
    public virtual Coverage? coverage { get; set; }
    public long capital { get; set; }
    public double rate { get; set; }
    public long coverage_premium { get; set; }
}

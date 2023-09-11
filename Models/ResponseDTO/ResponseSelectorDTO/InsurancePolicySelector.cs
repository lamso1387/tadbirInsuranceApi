using tadbirInsuranceApi.Domain;  

namespace tadbirInsuranceApi.Models
{
    public class InsurancePolicySelector
    {
        public static Func<InsurancePolicy, object> selector => x => new
        {
            x.id, 
            x.create_date,
            x.creator_id,  
            x.status,
            x.status_enum,
            x.title,
            x.total_premium,
            x.coverages,
            coverages_types=x.coverages!.Select(x=>x.coverage).ToList() 
        };
    }
}

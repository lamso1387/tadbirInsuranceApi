using System.ComponentModel.DataAnnotations;
using tadbirInsuranceApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tadbirInsuranceApi.Domain
{
    public partial class InsurancePolicy
    {
        public void CreateFromDTO(AddInsurancePolicyRequestDTO request)
        {
            creator_id = request.user_session_id;
            title = request.title;
            coverages = new List<InsurancePolicyCoverage>();
            foreach (var item in request.coverage_list!)
                coverages.Add(new InsurancePolicyCoverage
                {
                    insurance_policy = this,
                    coverage_id = (long)item.id!,
                    capital = (long)item.capital!,
                    creator_id = request.user_session_id
                });
        }

        public void CalcTotalPermium() =>
        total_premium = coverages!.Sum(x => x.coverage_premium);
    }
}

using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tadbirInsuranceApi.Models
{
    public class AddInsurancePolicyRequestDTO  : GenericAddRequest
    {
        [Required(ErrorMessage = Models.MessageText.RequiredFieldErrorDynamic), DisplayName("عنوان درخواست")]
        public string? title { get; set; } 
        public List<AddCovaregeRequestDTO>? coverage_list { get; set; } 

        protected override void CheckPropertyValidation()
        { 
            if (coverage_list == null)
                validation_errors.Add(Models.MessageText.covarage_is_required);
            else if(coverage_list.Count==0)
                validation_errors.Add(Models.MessageText.covarage_is_required);
            else if(coverage_list.GroupBy(x=>x.id)
                    .Select(x=>new { count = x.Count(), id = x.Key }).Any(x=>x.count>1))
                    validation_errors.Add(Models.MessageText.covarage_must_be_unique);
            else if(coverage_list.Any(x=>x.capital==null))
                validation_errors.Add(Models.MessageText.covarage_capital_required);
            else if (coverage_list.Any(x => x.id == null))
                validation_errors.Add(Models.MessageText.covarage_id_required);

        }

    }
}

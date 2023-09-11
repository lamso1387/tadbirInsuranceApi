using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tadbirInsuranceApi.Models
{
    public class AddCovaregeRequestDTO : GenericAddRequest
    {
        public long? capital { get; set; }
    }
}

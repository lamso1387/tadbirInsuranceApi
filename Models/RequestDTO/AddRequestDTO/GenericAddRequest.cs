using tadbirInsuranceApi.Models;
using System.ComponentModel.DataAnnotations;

namespace tadbirInsuranceApi.Models
{
    public abstract class GenericAddRequest
    {
        public long? id { get; set; }
        public long user_session_id { get; set; } 
        protected List<string> validation_errors { get; set; } = new List<string>();
        public void CheckValidation()
        {
            if (CheckAttrbuteValidation())
                CheckPropertyValidation();
            if (validation_errors.Any())
                throw new GlobalException(ErrorCode.BadRequest, validation_errors.First());

        }
        public bool CheckAttrbuteValidation()
        {
            validation_errors = Tools.TypeTools.CheckValidationAttribute(this);
            return validation_errors.Count == 0 ? true : false;
        }
        protected virtual void CheckPropertyValidation() { }
    }
}

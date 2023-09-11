using tadbirInsuranceApi.Models;

namespace tadbirInsuranceApi.Models
{
    public class GlobalException : Exception
    {
        public GlobalException(ErrorCode error_code) : base(error_code.ToString())
        {
        }
        public GlobalException(ErrorCode error_code, string message) :
            base(error_code.ToString(), new Exception(message))
        {
        }
        public GlobalException(ErrorCode error_code, object message_object_to_json) :
           base(error_code.ToString(), new Exception(Newtonsoft.Json.JsonConvert.SerializeObject(message_object_to_json, Newtonsoft.Json.Formatting.Indented)))
        {
        }
    }
}

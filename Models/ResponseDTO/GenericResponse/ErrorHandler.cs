using tadbirInsuranceApi.Models;
using System.Net; 

namespace tadbirInsuranceApi.Models 
{
    
    public class ErrorHandler
    {
        public string message { get; set; } = MessageText.ErrorNotSet;
        //  public int code { get; set; } = -1;
        public HttpStatusCode status { get; set; } = HttpStatusCode.Unused;

        public static ErrorHandler GetError(ErrorCode key, string? message = null)
        {
            string enum_des_str = Tools.EnumTools.GetEnumDescription(key);
            ErrorHandler enum_des = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorHandler>(enum_des_str)!;
            if (message != null) enum_des!.message = message;
            return enum_des!;
        }
    }
}

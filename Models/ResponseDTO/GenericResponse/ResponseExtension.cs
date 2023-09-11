using tadbirInsuranceApi.Models; 
using Microsoft.AspNetCore.Mvc;
using System.Net; 

namespace tadbirInsuranceApi.Models
{
    public static class ResponseExtension
    {  
        public static IActionResult ToResponse<T>(this GenericResponse response, T entity, Func<T, object> selector)
        {
            var model = new List<T> { entity }.Select(selector).First();
            return ToResponse(response, model);
        } 
        public static IActionResult ToResponse<T>(this GenericResponse response, T model)
        {
            (response as dynamic).Model = model;
            return ToResponse(response);
        }

        public static IActionResult ToResponse(this GenericResponse response)
        {
            ErrorCode error_code = ErrorCode.OK;
            response.ErrorCode = (int)error_code;
            var error = ErrorHandler.GetError(error_code);
            response.ErrorMessage = error.message;
            return CreateHttpObject(response, error.status);
        }

        private static IActionResult CreateHttpObject(object response, HttpStatusCode status)
        {
            ObjectResult result = new ObjectResult(response);
            result.StatusCode = (int)status;
            return result;
        }


    }
}

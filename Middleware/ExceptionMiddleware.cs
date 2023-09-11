 
using tadbirInsuranceApi.Models; 
using Microsoft.EntityFrameworkCore; 

namespace tadbirInsuranceApi.Middleware
{
    public class ExceptionMiddleware
    {
        protected readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);

            }

            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }

        }

        protected Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            string output = string.Empty;
            if (!context.Response.HasStarted)
            {
                GenericResponse mes_res = new GenericResponse();
                mes_res.ErrorMessage = error.Message;
                mes_res.ErrorDetail = error.InnerException?.Message;
                mes_res.ErrorCode = (int)ErrorCode.UnexpectedError;
                context.Response.StatusCode = (int)ErrorCode.UnexpectedError;
                ErrorCode error_code = ErrorCode.UnexpectedError;
                ErrorHandler error_prop = new ErrorHandler();
                switch (error.GetType().Name)
                {
                    case nameof(GlobalException):
                        error_code = Tools.ConvertorTools.StringToEnum<ErrorCode>(error.Message);
                        error_prop = ErrorHandler.GetError(error_code);
                        mes_res.ErrorMessage = error_prop.message;
                        if (!string.IsNullOrWhiteSpace(mes_res.ErrorDetail)) mes_res.ErrorMessage = mes_res.ErrorMessage + ". " + mes_res.ErrorDetail;
                        break;
                    case nameof(InvalidOperationException):
                        error_code = ErrorCode.InvalidOperationException;
                        error_prop = ErrorHandler.GetError(error_code);
                        mes_res.ErrorDetail = $"{mes_res.ErrorMessage}. {mes_res.ErrorDetail}";
                        mes_res.ErrorMessage = error_prop.message;
                        break;
                    case nameof(DbUpdateException):
                        error_code = ErrorCode.DbUpdateException;
                        error_prop = ErrorHandler.GetError(error_code);
                        mes_res.ErrorMessage = error_prop.message;
                        break;
                }


                context.Response.StatusCode = (int)error_prop.status;
                mes_res.ErrorCode = (int)error_code;
                context.Response.ContentType = "application/json";
                output = System.Text.Json.JsonSerializer.Serialize(mes_res);
            }
            return context.Response.WriteAsync(output);
        }

       
    } 
}


using System.ComponentModel;
using System.Net;

namespace tadbirInsuranceApi.Models
{
    public enum ErrorCode
    {
        [Description(@"{""message"":""عملیات با موفقیت انجام شد"" ,""status"": ""OK""}")]
        OK = HttpStatusCode.OK,
        [Description(@"{""message"":""ورودی اشتباه است"" ,""status"": ""BadRequest""}")]
        BadRequest = HttpStatusCode.BadRequest,
        [Description(@"{""message"":""خطای غیرمنتظره رخ داده است لطفا مجددا تلاش کنید یا با پشتیبان تماس بگیرید"" ,""status"": ""ExpectationFailed""}")]
        UnexpectedError = HttpStatusCode.ExpectationFailed,
        [Description(@"{""message"":""اطلاعات ذخیره نشد مجددا تلاش کنید یا با پشتیبان تماس بگیرید"" ,""status"": ""ExpectationFailed""}")]
        DbSaveNotDone = 3,
        [Description(@"{""message"":""خطا در ذخیره سازی اطلاعات رخ داد  با پشتیبان تماس بگیرید"" ,""status"": ""UnprocessableEntity""}")]
        DbUpdateException = 4,
        [Description(@"{""message"":""اطلاعات تکراری است"" ,""status"": ""Conflict""}")]
        AddRepeatedEntity = 5,
        [Description(@"{""message"":""مورد یافت نشد"" ,""status"": ""NoContent""}")]
        NoContent = HttpStatusCode.NoContent,
        [Description(@"{""message"":""مورد یافت نشد"" ,""status"": ""BadRequest""}")]
        ItemNotExists = 499,  
        [Description(@"{""message"":""دسترسی به اطلاعات وجود ندارد"" ,""status"": ""Forbidden""}")]
        Forbidden = HttpStatusCode.Forbidden,
        [Description(@"{""message"":""نام کاربری یا رمز عبور اشتباه است"" ,""status"": ""Unauthorized""}")]
        Unauthorized = HttpStatusCode.Unauthorized,
        [Description(@"{""message"":""خطا در سرویس وابسته رخ داد"" ,""status"": ""FailedDependency""}")]
        FailedDependency = HttpStatusCode.FailedDependency,
        [Description(@"{""message"":""شرایط لازم برای انجام این عملیات رعایت نشده است"" ,""status"": ""PreconditionFailed""}")]
        PreconditionFailed = HttpStatusCode.PreconditionFailed,
        [Description(@"{""message"":""مغایرت در انجام عملیات"" ,""status"": ""Conflict""}")]
        Conflict = HttpStatusCode.Conflict,
        [Description(@"{""message"":""خطا در انجام عملیات رخ داده است با پشتیبان تماس بگیرید"" ,""status"": ""UnprocessableEntity""}")]
        InvalidOperationException = HttpStatusCode.UnprocessableEntity,
        [Description(@"{""message"":""ورودی بدرستی تنظیم نشده است"" ,""status"": ""Gone""}")]
        InvalidRequest = HttpStatusCode.Gone,
        [Description(@"{""message"":""اطلاعات ثبت شد ولی خطایی در ادامه عملیات رخ داد"" ,""status"": ""Created""}")]
        Created = HttpStatusCode.Created,
        [Description(@"{""message"":""آدرس درخواستی اشتباه است"" ,""status"": ""NotFound""}")]
        NotFound = HttpStatusCode.NotFound,
        [Description(@"{""message"":""انجام این عملیات غیر مجاز است"" ,""status"": ""MethodNotAllowed""}")]
        MethodNotAllowed = HttpStatusCode.MethodNotAllowed
    }
}

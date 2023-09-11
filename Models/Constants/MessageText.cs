namespace tadbirInsuranceApi.Models
{
    //massages can be set in db
    public class MessageText
    {
        public const string covarage_is_required = "انتخاب پوشش اجباری است";
        public const string covarage_must_be_unique = "پوشش نباید تکراری باشد";
        public const string covarage_capital_required = "سرمایه پوشش اجباری است";
        public const string covarage_id_required = "ارسال کد پوشش اجباری است";
        public const string covarage_id_wrong = " کد پوشش اشتباه است";
        public const string covarage_capital_not_in_valid_range = " سرمایه پوشش در بازه مجاز قرار ندارد";

        public const string PasswordMustBeChanged = "تغییر رمز عبور کاربر الزامی است"; 
        public const string ErrorNotSet = "خطا تعیین نشده است";
        public const string RequiredFieldErrorDynamic = "فیلد اجباری {0} تکمیل نشده است";
      }
}

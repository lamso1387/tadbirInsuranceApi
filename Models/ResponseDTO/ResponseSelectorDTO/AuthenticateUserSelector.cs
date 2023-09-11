using tadbirInsuranceApi.Domain;

namespace tadbirInsuranceApi.Models
{
    public class AuthenticateUserSelector
    {
        public static Func<User, object> selector => x => new
        {
            x.id,
            x.first_name,
            x.last_name,
            x.create_date,
            x.full_name,
            x.mobile,
            x.permissions,
            x.is_admin,
            x.jwt_token
        };
    }
}

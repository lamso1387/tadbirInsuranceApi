

namespace tadbirInsuranceApi.Domain;

public class UserRole : GenericEntity
{
    public long user_id { get; set; }
    public  virtual User? user { get; set; }
    public long role_id { get; set; }
    public virtual Role? role { get; set; }
}

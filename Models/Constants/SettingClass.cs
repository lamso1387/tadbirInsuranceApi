
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tadbirInsuranceApi.Models
{
    public class SettingClass
    {
        public DbSetting? db { get; set; }
        public Seeder? seeder { get; set; } 
        public JwtSetting? jwt { get; set; }
        public class JwtSetting
        {
            public string? secret { get; set; }
            public int? token_expire_minutes { get; set; }
        }
        public class DbSetting
        {
            public string? insurance_db_query_connection { get; set; }
            public string? insurance_db_command_connection { get; set; }
        }
        public class Seeder
        {
            public string? admin_seeder_username { get; set; }
            public string? admin_seeder_password { get; set; }
            public string? admin_seeder_role_name { get; set; }
            public string? admin_seeder_national_code { get; set; }

        }  
    }
}

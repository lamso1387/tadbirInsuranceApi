

using tadbirInsuranceApi.Models;

namespace tadbirInsuranceApi
{
    public sealed class AppConstants
    {
        private static readonly object setting_locker = new object();
        private static SettingClass? setting = null;
        static void InitialSetting()
        {
            TextReader tr = new StreamReader(@"setting.json");
            string k = tr.ReadToEnd();
            setting = Newtonsoft.Json.JsonConvert.DeserializeObject<SettingClass>(k);
        }

        public static SettingClass Setting
        {
            get
            {
                if (setting == null)
                {
                    lock (setting_locker)
                    {
                        if (setting == null)
                        {
                            InitialSetting();
                        }
                    }
                }
                return setting!;
            }
        }
    }
}

using System.Configuration;

namespace TestNotepad
{
    public static class AppConfiguration
    {
        public static string GetSetting(string key)
        {
            try { return ConfigurationManager.AppSettings[key]; }
            catch (ConfigurationErrorsException) { return ""; }
        }
        public static void SetSettings(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var entry = config.AppSettings.Settings[key];
            if (entry == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}

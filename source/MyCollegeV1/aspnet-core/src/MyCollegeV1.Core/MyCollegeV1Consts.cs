using MyCollegeV1.Debugging;

namespace MyCollegeV1
{
    public class MyCollegeV1Consts
    {
        public const string LocalizationSourceName = "MyCollegeV1";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "6f44ff0a5d4f4c1b9b7920f3e86354cf";
    }
}

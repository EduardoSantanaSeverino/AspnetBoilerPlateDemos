using MyCollegeV2.Debugging;

namespace MyCollegeV2
{
    public class MyCollegeV2Consts
    {
        public const string LocalizationSourceName = "MyCollegeV2";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "f2654aebd11041439c55f5e1070f1530";
    }
}

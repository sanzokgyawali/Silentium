using AnonymousChat.Debugging;

namespace AnonymousChat
{
    public class AnonymousChatConsts
    {
        public const string LocalizationSourceName = "AnonymousChat";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "e6115a5914e04a2198c714bd2502afaa";
    }
}

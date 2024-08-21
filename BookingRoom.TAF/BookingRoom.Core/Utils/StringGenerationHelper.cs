using BookingRoom.Core.Utils.Logger;
using NUnit.Framework.Internal;
using ILogger = BookingRoom.Core.Utils.Logger.ILogger;

namespace BookingRoom.Core.Utils
{
    public static class StringGenerationHelper
    {
        #region 

        private const string NumericChars = "0123456789";
        private const string UpperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerCaseChars = "abcdefghijklmnopqrstuvwxyz";

        #endregion

        private static readonly Randomizer Random = new();

        private static ILogger Logger => LoggerInstance.Instance(typeof(StringGenerationHelper));

        private static string GetRandomStringFromCharacters(string chars, int length) => Random.GetString(length, chars);

        public static string GenerateRandomString(int length) => GetRandomStringFromCharacters(UpperCaseChars + LowerCaseChars, length);

        public static string GenerateUniqueRandomEmail() => $"{DateTime.UtcNow:yy_MM_dd_HH_mm_ss}@test.com";

        public static string GenerateRandomEmail(int length) => $"{GenerateRandomString(length)}@test.com";

        public static string GenerateRandomNumericString(int length) => GetRandomStringFromCharacters(NumericChars, length);
    }
}

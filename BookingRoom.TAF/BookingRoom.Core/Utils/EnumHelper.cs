namespace BookingRoom.Core.Utils
{
    public static class EnumHelper
    {
        /// <summary>
        /// Parses string to enum
        /// </summary>
        /// <typeparam name="T">expected enum type</typeparam>
        /// <param name="value">expected string</param>
        /// <param name="ignoreSpaces">should spaces be ignored → true/false</param>
        /// <param name="ignoreCase">should case be ignored → true/false</param>
        /// <returns>parsed enum value</returns>
        public static T ToEnum<T>(this string value, bool ignoreSpaces = true, bool ignoreCase = true) where T : Enum
        {
            value = ignoreSpaces ? value.Replace(" ", string.Empty) : value;
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}

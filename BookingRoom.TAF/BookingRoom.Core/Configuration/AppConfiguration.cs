using BookingRoom.Core.Utils.Logger;
using System.Reflection;

namespace BookingRoom.Core.Configuration
{
    public static class AppConfiguration
    {
        public static AppSettingsEntity? TestSettings { get; set; }

        /// <summary>
        /// Gets test data files folder
        /// </summary>
        /// <returns>folder path</returns>
        public static string TestDataFilesFolder =>
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "TestDataFiles");

        /// <summary>
        /// Represents Logger type needed
        /// Logger initializer gets type of logger presented in config and uses it for logging
        /// </summary>
        public static NLogLogger Logger => new();
    }
}

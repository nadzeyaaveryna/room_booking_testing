using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;

namespace BookingRoom.Core.Utils.Logger
{
    public class NLogLogger : ILogger
    {
        private ILogger _instance;

        private NLog.Logger Log { get; set; }

        public ILogger Instance(Type type) => _instance ??= InitializeConfig(type);

        /// <inheritdoc cref="ILogger.Info(string)"/>
        public void Info(string message) => Log.Info(message);

        /// <inheritdoc cref="ILogger.Info(Exception)"/>
        public void Info(Exception exception) => Log.Info(exception);

        /// <inheritdoc cref="ILogger.Debug"/>
        public void Debug(string message) => Log.Debug(message);

        /// <inheritdoc cref="ILogger.Warn(string)"/>
        public void Warn(string message) => Log.Warn(message);

        /// <inheritdoc cref="ILogger.Warn(Exception)"/>
        public void Warn(Exception exception) => Log.Warn(exception);

        /// <inheritdoc cref="ILogger.Error(string)"/>
        public void Error(string message) => Log.Error(message);

        /// <inheritdoc cref="ILogger.Error(Exception)"/>
        public void Error(Exception exception) => Log.Error(exception);

        /// <summary>
        /// Initializes NLog configuration
        /// </summary>
        /// <param name="type">type typeof <see cref="Type"/></param>
        /// <returns>new instance of <see cref="ILogger"/></returns>
        public ILogger InitializeConfig(Type type)
        {
            var config = new LoggingConfiguration();

            var target = new NLog.Targets.ConsoleTarget($"Log_{DateTime.UtcNow:yyyy-MM-ddTHH-mm}")
            {
                Layout =
                    "${level:uppercase=true}|${date:universalTime=true:format=HH\\:mm\\:ss}UTC|${logger}|${message}|${exception:format=tostring}"
            };

            config.AddRule(LogLevel.Debug, LogLevel.Error, target);

            LogManager.Configuration = config;

            Log = LogManager.GetLogger(type.Name);

            _instance = this;
            return this;
        }
    }
}

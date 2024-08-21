using BookingRoom.Core.Configuration;
using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BookingRoom.Core.Utils.Logger
{
    /// <summary>
    /// Represents class for logger initializer
    /// </summary>
    public static class LoggerInstance
    {
        private static ILogger _logger;

        private static readonly List<ILogger> _loggers = new();

        public static ILogger Instance(Type type = null)
        {
            type ??= new StackTrace().GetFrame(1)?.GetMethod()?.ReflectedType;

            lock (type)
            {
                var testProperties = TestContext.CurrentContext.Test.Properties.Keys;

                if (_logger == null || !testProperties.Any(e => e.Contains($"{type}_logger")) ||
                    testProperties.FirstOrDefault(e =>
                        e.Contains($"{type}_logger")) == null)
                {
                    _logger = InitializeLogger(type);
                    TestExecutionContext.CurrentContext.CurrentTest.Properties.Set($"{type}_logger", _logger);
                    _loggers.Add(_logger);
                }

            }
            return (ILogger)TestContext.CurrentContext.Test.Properties.Get(
                $"{type}_logger");
        }

        /// <summary>
        /// Initializes logger according value from app.config
        /// </summary>
        /// <param name="type">item type typeof <see cref="Type"/></param>
        /// <returns>new instance of <see cref="ILog"/></returns>
        private static ILogger InitializeLogger(Type type)
        {
            var expectedLoggerType = AppConfiguration.Logger.GetType();
            var logger = Activator.CreateInstance(expectedLoggerType) as ILogger;

            return logger!.Instance(type);
        }
    }
}

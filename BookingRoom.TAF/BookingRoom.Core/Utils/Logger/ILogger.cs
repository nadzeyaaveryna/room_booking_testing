namespace BookingRoom.Core.Utils.Logger
{
    /// <summary>
    /// Represents general interface for all loggers
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Instance of a logger
        /// </summary>
        /// <param name="type">item type typeof <see cref="Type"/></param>
        /// <returns>new instance of <see cref="ILogger"/></returns>
        public ILogger Instance(Type type);

        /// <summary>
        /// General Info message
        /// </summary>
        /// <param name="message">message typeof <see cref="string"/></param>
        public void Info(string message);

        /// <summary>
        /// General Info message
        /// </summary>
        /// <param name="exception">message typeof <see cref="Exception"/></param>
        public void Info(Exception exception);

        /// <summary>
        /// General Debug message
        /// </summary>
        /// <param name="message">message typeof <see cref="string"/></param>
        public void Debug(string message);

        /// <summary>
        /// General Warn message
        /// </summary>
        /// <param name="message">message typeof <see cref="string"/></param>
        public void Warn(string message);

        /// <summary>
        /// General Warn message
        /// </summary>
        /// <param name="exception">message typeof <see cref="Exception"/></param>
        public void Warn(Exception exception);

        /// <summary>
        /// General Error message
        /// </summary>
        /// <param name="message">message typeof <see cref="string"/></param>
        public void Error(string message);

        /// <summary>
        /// General Error message
        /// </summary>
        /// <param name="exception">message typeof <see cref="Exception"/></param>
        public void Error(Exception exception);
    }
}

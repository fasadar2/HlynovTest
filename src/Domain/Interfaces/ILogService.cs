namespace Domain.Interfaces
{
    /// <summary>
    /// Сервис логирования действий.
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Логирование действий
        /// </summary>
        /// <param name="message">Сообщение логирования.</param>
        void Log(string message);

    }
}

using System;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    /// <summary>
    /// Сущность логирования действий.
    /// </summary>
    public class ActionLog
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        [Key]
        public int LogId { get; set; }
        /// <summary>
        /// Произведенное действие.
        /// </summary>
        public string Action {  get; set; }
        /// <summary>
        /// Время произведения действия.
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}

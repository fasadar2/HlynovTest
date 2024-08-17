using System;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class ActionLog
    {
        [Key]
        public int LogId { get; set; }
        public string Action {  get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

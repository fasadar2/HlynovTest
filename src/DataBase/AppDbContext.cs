using System;
using System.Data.Entity;

namespace HlynovTestv2
{
    /// <summary>
    /// Контекст базы данных приложения
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Конструктор базы данных приложения
        /// </summary>
        public AppDbContext() : base("AppDbConnectionString") { }
        public DbSet<Domain.Entities.ActionLog> ActionLog { get; set; }
    }
}

using HlynovTestv2;
using System.Data.Entity;

namespace DataBase
{
    /// <summary>
    /// Инициализатор базы данных.
    /// </summary>
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
    }
}

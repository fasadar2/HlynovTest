using DataBase;
using System.Data.Entity;
using System.Windows;

namespace HlynovTestv2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Database.SetInitializer(new AppDbInitializer());
        }
    }
}

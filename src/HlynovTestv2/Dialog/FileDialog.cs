using Microsoft.Win32;



namespace HlynovTestv2
{
    /// <summary>
    /// Класс выбора шаблона
    /// </summary>
    class FileDialog
    {
        /// <summary>
        /// Имя файла.
        /// </summary>
        private string _fileName;
        /// <summary>
        /// Фильтр окна.
        /// </summary>
        private string _filter;
        /// <summary>
        /// Заголовок окна.
        /// </summary>
        private string _title;
        public string FileName { get => _fileName; set => _fileName = value; }
        public string Filter { get => _filter; set => _filter = value; }
        public string Title { get => _title; set => _title = value; }
        /// <summary>
        /// Конструктор файлового диалога.
        /// </summary>
        /// <param name="filter">Фильтр.</param>
        /// <param name="title">Название окна.</param>
        public FileDialog(string filter, string title)
        {
            Filter = filter;
            Title = title;
        }
        
        /// <summary>
        /// Открываем файловый диалог.
        /// </summary>
        public  void OpenDialog()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Filter, 
                Title = Title
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true) 
            {
                FileName = openFileDialog.FileName; 
            }
        }
        /// <summary>
        /// Открываем диалог сохранения файла.
        /// </summary>
        public void OpenSaveDialog()
        {
            var openFileDialog = new SaveFileDialog
            {
                Filter = Filter,
                Title = Title
            };
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                FileName = openFileDialog.FileName;
            }
        }
    }
    
}

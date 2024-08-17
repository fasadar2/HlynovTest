using Microsoft.Win32;



namespace HlynovTestv2
{
    /// <summary>
    /// Класс выбора шаблона
    /// </summary>
    class FileDialog
    {
        private string _fileName;
        private string _filter;
        private string _title;
        public string FileName { get => _fileName; set => _fileName = value; }
        public string Filter { get => _filter; set => _filter = value; }
        public string Title { get => _title; set => _title = value; }

        public FileDialog(string filter, string title)
        {
            Filter = filter;
            Title = title;
        }
        
        /// <summary>
        /// Открываем файловый диалог
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

using Infrastructure.Services;
using System;
using System.Linq;
using System.Windows;


namespace HlynovTestv2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string templateName = "";
        string filePath = "";
        string createdDoc = "";
        LogService logService = new LogService();
        private TagController _tagController;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            FileDialog dialog = new FileDialog("Word Documents|*.docx", "Выберите шаблон для заполнения");
            dialog.OpenDialog();
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                filePath = dialog.FileName;
                templateName = filePath.Split('\\').LastOrDefault() ?? "";
                TemplateName.Content = templateName;
                var wordController = new WordController(filePath);
                wordController.ReadDocument();
                _tagController = wordController.TagControllerField;
                var tagCollection = _tagController.TagModels;
                foreach (var tag in tagCollection)
                {
                    stackPanel.Children.Add(tag.ViewName);
                    stackPanel.Children.Add(tag.TextControl);
                }
                logService.Log($"Выбран шаблон {templateName}");
            }

        }
        private void SendEmailButton_Click(Object sender, RoutedEventArgs e)
        {
            EmailSender emailSender = new EmailSender(EmailTextBox.Text, createdDoc);
            if (emailSender.SendEmail())
            {
                MessageBox.Show("Сообщение отправлено");
            }
            logService.Log($"Отправлен документ по адресу: {EmailTextBox.Text}");
        }

        private void CreateDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            FileDialog dialog = new FileDialog("Word Documents|*.docx", "Выберите куда сохранится заполненный по шаблону документ");
            dialog.OpenSaveDialog();
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                createdDoc = dialog.FileName;
                var wordController = new WordController(filePath);
                wordController.TagControllerField = _tagController;
                wordController.CreateDocument(createdDoc);
            }
            logService.Log($"Сформирован документ {templateName}");
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Загрузите шаблон нажав на кнопку \"Выбрать шаблон\"\n" +
                "ВАЖНО: тег для заполнения должен начинаться с templateField\n" +
                "Далее заполните все необходимые поля\n" +
                "Нажмите кнопку сформировать документ");
        }
    }
}

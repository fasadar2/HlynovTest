using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.Office.Interop.Word;

namespace HlynovTestv2
{
    
    class WordController
    {
        private const string keyName = "templateField";
        private string _fileName;
        private TagController _tagController;

        public string FileName { get => _fileName; set => _fileName = value; }
        public TagController TagControllerField { get => _tagController; set => _tagController = value; }
        public WordController(string fileName)
        {
            FileName = fileName;
            TagControllerField = new TagController();
        }
        public void ReadDocument()
        {
            var wordApp = new  Microsoft.Office.Interop.Word.Application();
            Document doc = null;
            try
            {
                doc =  wordApp.Documents.Open(FileName);
                var documentText = doc.Content.Text;
                Regex regex = new Regex(@"\btemplateField\w*\b");
                MatchCollection matches = regex.Matches(documentText);
                foreach (Match  match in matches)
                {
                    TagControllerField.AddTagModel(match.Value.Replace(keyName,""));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при работе с документом: {ex.Message}");
            }
            finally
            {
                doc?.Close();
                wordApp.Quit();
            }
        }
        public void CreateDocument(string createDocPath)
        {


            // Создаем объект приложения Word
            var wordApp = new Microsoft.Office.Interop.Word.Application();
            Document doc = null;

            try
            {
                // Открываем документ
                doc = wordApp.Documents.Open(FileName);
                var tagControllerDict = TagControllerField.GetDictTagModel();
                foreach (Range range in doc.Words)
                {
                    string word = range.Text.Trim();

                    // Проверяем, начинается ли слово на < и заканчивается на >
                    if (word.StartsWith("templateField"))
                    {
                        // Убираем угловые скобки
                        string key = word.Trim();
                        key = key.Replace(keyName, "");
                        // Проверяем, существует ли ключ в словаре
                        if (tagControllerDict.ContainsKey(key))
                        {
                            // Заменяем слово
                            range.Text = tagControllerDict[key];
                        }
                    }
                }
                // Сохраняем изменения в документе
                doc.SaveAs2(createDocPath);
                MessageBox.Show($"Документ успешно сохранен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при работе с документом: {ex.Message}");
            }
            finally
            {
                // Закрываем документ и приложение Word
                if (doc != null)
                {
                    doc.Close();
                }
                wordApp.Quit();
            }
        }
    }
    
}


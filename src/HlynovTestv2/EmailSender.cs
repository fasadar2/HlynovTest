namespace HlynovTestv2
{
    class EmailSender
    {
        private string _email;
        private string _file_path;
        ///<summary>Основной констркутор</summary>
        ///<param name="email">Адрес электронной почты на который нужно отправить значение</param>
        ///<param name="file_path">Путь до файла который нужно отправить</param>
        public EmailSender(string email, string file_path)
        {
            Email = email;
            File_path = file_path;
        }
        public string Email { get => _email; set => _email = value; }
        public string File_path { get => _file_path; set => _file_path = value; }

        ///<summary>Отправляем сформированное письмо по email</summary>
        public bool SendEmail()
        {
            //Для упрощения разрабтки метод был уменьшен до возврата true значения
            return true;
        }
    }
}

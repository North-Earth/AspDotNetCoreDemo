namespace Learn.Views.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string SendMessage()
        {
            return "Сообщение отправлено на email";
        }
    }
}

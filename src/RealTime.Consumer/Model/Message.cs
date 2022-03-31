namespace RealTime.Consumer.Model;

public class Message
{
    public Message(string userName, string text)
    {
        UserName = userName;
        Text = text;
    }

    public string UserName { get; set; }
    public string Text { get; set; }
}

using System.Net.Http;

namespace GpsScanDotnet.Services;

public class TelegramService
{
    private readonly string _botToken = "";
    private readonly string _chatId = "";

    public void SendLocation(double latitude, double longitude)
    {
        using var client = new HttpClient();
        var url = $"https://api.telegram.org/bot{_botToken}/sendMessage";
        var text = $"📍 Localização: https://maps.google.com/?q={latitude},{longitude}";

        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("chat_id", _chatId),
            new KeyValuePair<string, string>("text", text)
        });

        client.PostAsync(url, content).Wait();
    }
}

namespace formatcard_core;

public class BaiduOcrConfig
{
    public string AppId { get; set; }
    public string ApiKey { get; set; }

    public string SecretKEY { get; set; }

    public int TimeOut { get; set; } = 60000;
}
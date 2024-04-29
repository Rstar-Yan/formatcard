using Microsoft.Extensions.Options;

namespace formatcard_core;

public class BaiduOcrGenerate : IOCRGenerate
{
    private BaiduOcrConfig _baiduOcrConfig;

    public BaiduOcrGenerate(IOptions<BaiduOcrConfig> baiduOcrConfig)
    {
        _baiduOcrConfig = baiduOcrConfig.Value;
    }

    public void RecognitionWithLocation(LocationInfo info)
    {

        var client = new Baidu.Aip.Ocr.Ocr(_baiduOcrConfig.ApiKey, _baiduOcrConfig.SecretKEY);

        client.Timeout = _baiduOcrConfig.TimeOut;// 修改超时时间

        try
        {
            var image = File.ReadAllBytes("D:\\行为准则.png");
            // 调用通用文字识别（含位置信息版）, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.General(image);

            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    private bool isRectContain(LocationInfo rect1, LocationInfo rect2)
    {
        return (
                   rect1.Left <= rect2.Left &&
                   rect1.Left + rect1.Width >= rect2.Left + rect2.Width &&
                   rect1.Right <= rect2.Right &&
                   rect1.Right + rect1.Height >= rect2.Right + rect2.Height
               );
    }
}
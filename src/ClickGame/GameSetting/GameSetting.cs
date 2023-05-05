using System.Text.Json;

namespace ClickGame;

internal class GameSetting
{
    public readonly Setting Setting;

    public GameSetting(string fileName)
    {
        using (var str = new StreamReader(fileName))
        {
            var jsonStr = str.ReadToEnd();

            var result = JsonSerializer.Deserialize<Setting>(jsonStr);
            if (result == null)
                throw new Exception("Jsonファイルの読み込みに失敗しました。");

            Setting = result;
        }
    }
}
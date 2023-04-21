namespace ClickGame.Helper;

internal static class GrowHelper
{
    private static Random _random = new(72);

    public static byte[] CreateGrowArray(int length)
    {
        var growArray = new byte[length];

        for (int i = 0; i < length; i++)
            growArray[i] = GetOpacity();

        return growArray;
    }

    private static byte GetOpacity()
    {
        var random = _random.Next(0, 11);

        switch (random)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
                return 255;

            case 8:
                return 230;

            case 9:
                return 190;

            case 10:
                return 245;

            default:
                return 255;
        }
    }
}
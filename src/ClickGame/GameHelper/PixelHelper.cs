namespace ClickGame.Helper;

internal static class PixelHelper
{
    public static float GetCenter(float parent, float target)
        => (parent - target) / 2.0f;

    public static float GetPercent(float parent, float percent)
        => (parent / 100.0f) * percent;
}
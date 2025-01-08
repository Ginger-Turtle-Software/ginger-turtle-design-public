using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Extensions;

public static class PaddingSizeExtensions
{
    public static string GetCss(this PaddingSize padding)
    {
        return padding switch
        {
            PaddingSize.None => "padding-0",
            PaddingSize.Half => "padding-05",
            PaddingSize.One => "padding-1",
            _ => throw new ArgumentOutOfRangeException(nameof(padding), padding, null)
        };
    }
}
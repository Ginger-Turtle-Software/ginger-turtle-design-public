using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Extensions;

public static class ElementSizeExtensions
{
    public static string GetCssClass(this ElementSize size)
    {
        return size switch
        {
            ElementSize.ExtraSmall => "xs",
            ElementSize.Small => "sm",
            ElementSize.Medium => "md",
            ElementSize.Large => "lg",
            ElementSize.ExtraLarge => "xl",
            _ => "md"
        };
    }
}
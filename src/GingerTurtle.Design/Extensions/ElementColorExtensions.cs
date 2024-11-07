using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Extensions;

public static class ElementColorExtensions
{
    public static string GetColorClass(this ElementColor color) =>
        color switch
        {
            ElementColor.Blue => "blue",
            ElementColor.Default => "",
            ElementColor.Green => "green",
            ElementColor.Red => "red",
            ElementColor.Yellow => "yellow",
            ElementColor.Orange => "orange",
            _ => ""
        };
}

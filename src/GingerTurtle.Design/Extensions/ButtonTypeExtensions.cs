using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Extensions;

public static class ButtonTypeExtensions
{
    public static string GetButtonTypeCssClass(this ButtonType type) =>
        type switch
        {
            ButtonType.Primary => "btn btn-primary",
            ButtonType.Secondary => "btn btn-secondary",
            ButtonType.PrimaryLink => "btn btn-link",
            ButtonType.SecondaryLink => "btn btn-link-secondary",
            ButtonType.BorderedIcon => "btn btn-icon",
            ButtonType.FlatIcon => "btn btn-icon",
            ButtonType.Square => "btn btn-square",
            ButtonType.BorderedSquare => "btn btn-square",
            ButtonType.TileButton => "btn btn-tile",
            ButtonType.Action => "btn btn-action",
            _ => ""
        };
    
    public static bool HasText(this ButtonType t) =>
        t switch
        {
            ButtonType.BorderedIcon => false,
            ButtonType.FlatIcon => false,
            ButtonType.Primary => true,
            ButtonType.Secondary => true,
            ButtonType.PrimaryLink => true,
            ButtonType.SecondaryLink => true,
            ButtonType.Square => false,
            ButtonType.BorderedSquare => false,
            _ => true
        };

    public static bool HasIconBorder(this ButtonType t) =>  t is ButtonType.BorderedIcon or ButtonType.BorderedSquare or ButtonType.TileButton;
    
}
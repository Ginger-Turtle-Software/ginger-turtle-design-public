using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Extensions;

public static class RowTypeExtensions
{
    public static string GetRowCss(this RowType d)
    {
        return d switch
        {
            RowType.Default => "",
            RowType.Header => "header",
            RowType.Info => "info",
            RowType.Heading => "heading",
            RowType.Error => "error",
            RowType.Success => "success",
            RowType.Warning => "warning",
            RowType.NotificationError => "error",
            _ => ""
        };
    }
}
using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Extensions;

public static class ColumnSizeExtensions
{
   
    public static string GetMobileCss(this ColumnSize c)
    {
        return c switch
        {
            ColumnSize.ColAuto => "col-mobile-auto",
            ColumnSize.ColGrow => "col-mobile-grow",
            ColumnSize.ColHide => "col-mobile-hide",
            _ => $"col-mobile-{(int)c}"
        };
    }
    
    
    public static string GetDesktopCss(this ColumnSize c)
    {
        return c switch
        {
            ColumnSize.ColAuto => "col-desktop-auto",
            ColumnSize.ColGrow => "col-desktop-grow",
            ColumnSize.ColHide => "col-desktop-hide",
            _ => $"col-desktop-{(int)c}"
        };
    }
    
}
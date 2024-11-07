using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Extensions;


public static class DrawerAlignmentExtensions
{
    public static string GetCssClass(this DrawerAlignment d)
    {
        switch (d)
        {
            case DrawerAlignment.Left:
                return "left";
            default:
                return "right";
        }
    }
}
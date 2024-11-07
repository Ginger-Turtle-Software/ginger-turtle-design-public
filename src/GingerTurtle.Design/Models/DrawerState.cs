using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Models;

public sealed class DrawerState
{
    public bool IsOpen { get; set; }
    public bool IsInitialized { get; set; }
    public int YOffset { get; set; }
}
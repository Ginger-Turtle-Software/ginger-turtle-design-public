using GingerTurtle.Design.Types;

namespace GingerTurtle.Design.Extensions;

public static class TextInputTypeExtensions
{
    public static string GetInputType(this TextInputType textInputType)
    {
        return textInputType switch
        {
            TextInputType.Text => "text",
            TextInputType.Password => "password",
            TextInputType.Tel => "tel",
            _ => "text"
        };
    }
}
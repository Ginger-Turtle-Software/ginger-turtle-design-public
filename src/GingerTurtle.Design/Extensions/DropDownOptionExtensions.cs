using GingerTurtle.Design.Models;

namespace GingerTurtle.Design.Extensions;

public static class DropDownOptionExtensions
{
    public static QuestionOption GetNext(this List<QuestionOption> options, QuestionOption option)
    {
        if (option == null)
            return options.FirstOrDefault();
        
        var currentOption = options.Find(x=>x.Id == option.Id);
        var index = options.IndexOf(currentOption);

        if(index < 0 || index == options.Count - 1)
            return options.FirstOrDefault();
        
        return options[index + 1];
    }

    public static QuestionOption GetPrevious(this List<QuestionOption> options, QuestionOption option)
    {
        if (option == null)
            return options.FirstOrDefault();

        var currentOption = options.Find(x => x.Id == option.Id);
        var index = options.IndexOf(currentOption);
        
        if(index < 0)
            return options.FirstOrDefault();

        if (index == 0)
            return options.LastOrDefault();
        
        return options[index - 1];
        
    }
}
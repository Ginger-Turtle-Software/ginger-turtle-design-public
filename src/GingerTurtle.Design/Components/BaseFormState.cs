namespace GingerTurtle.Design.Components;

public abstract class BaseFormState
{
    public bool RenderErrors { get; set; }
    
    public List<Func<bool>> Validators { get; } = new();
    
    public Action TriggerStateChange { get; init; }
    
    public bool Processing { get; set; }
    
    public void ValidateApplication()
    {
        foreach (var validate in Validators)
            validate();
        TriggerStateChange.Invoke();
    }

    public virtual bool IsFormValid()
    {
        var isValid = true; 
            
        foreach (var validator in Validators)
        {
            if (!validator())
                isValid = false;
        }
        return isValid;
    }
}
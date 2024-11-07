using Microsoft.AspNetCore.Components;

namespace GingerTurtle.Design.Components;


public abstract class BaseQuestionRenderer : ComponentBase
{
    [CascadingParameter]
    public BaseFormState BaseFormState { get; set; }
    
    [Parameter]
    public EventCallback QuestionAnsweredCallback { get; set; }
    
    protected abstract string GroupName { get; set; }
    
    protected bool IsValid { get; set; }
    
    protected override void OnInitialized()
    {
        IsValid = Validate();
        BaseFormState.Validators.Add(() =>
        {
            if (!ShouldAskQuestion())
                return true;
            
            IsValid = Validate();
            
            return IsValid;
        });
    }
    
    protected Task ValidateApplication()
    {
        BaseFormState.ValidateApplication();
        return Task.CompletedTask;
    }
    
    protected abstract bool Validate();
    protected abstract bool ShouldAskQuestion();

    protected virtual void ResetAnswer() { }
}
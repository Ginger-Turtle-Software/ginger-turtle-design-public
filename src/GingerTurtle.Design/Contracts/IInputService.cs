namespace GingerTurtle.Design.Contracts;

public interface IInputService
{
    Task Mask(string id, string mask, string pattern, string characterPattern);
    Task PadDate(string id);
    Task FormatDateInputAndShiftFocus(string id, int inputLength, string nextId);
    Task FocusInput(string elementId);
    Task FocusAfterTimeout(string elementId);
    Task FormatInput(string id, string pattern, string inputLength);
    Task FormatMoney(string id, string pattern, int timeout);
    Task FormatMoneyToFloat(string id);
    Task HideChars(string id, string pattern);
    Task ScrollToCurrentSelected(string firstOptionElementId, string containerElementId, int itemPosition);
    Task ScrollIntoModalView(string elementId);
    Task ClearInput(string elementId);
    // Task RemoveFocus();
    Task<string> RestrictInput(string id, string characterPattern);
}
using GingerTurtle.Design.Constants;
using GingerTurtle.Design.Contracts;
using Microsoft.JSInterop;

namespace GingerTurtle.Design.Services;


public sealed class InputService(IJSRuntime jsRuntime) : IInputService
{
    public async Task Mask(string id, string mask, string pattern, string characterPattern) =>
        await jsRuntime.InvokeVoidAsync(Functions.Mask, id, mask, pattern, characterPattern);
    
    public async Task PadDate(string id) =>
        await jsRuntime.InvokeVoidAsync(Functions.PadDate, id);
    
    public async Task FormatDateInputAndShiftFocus(string id,int inputLength, string nextId) => 
        await jsRuntime.InvokeVoidAsync(Functions.FormatDateInputAndShiftFocus, id, inputLength, nextId);

    public async Task FocusInput(string elementId) => 
        await jsRuntime.InvokeVoidAsync(Functions.FocusInput, elementId);

    public async Task FocusAfterTimeout(string elementId) => 
        await jsRuntime.InvokeVoidAsync(Functions.FocusInputAfterTimeout, elementId);
    
    public async Task FormatInput(string id, string pattern, string inputLength) => 
        await jsRuntime.InvokeVoidAsync(Functions.FormatInput, id, pattern, inputLength);

    public async Task FormatMoney(string id, string pattern, int timeout) => 
        await jsRuntime.InvokeVoidAsync(Functions.FormatMoney, id, pattern, timeout);

    public async Task FormatMoneyToFloat(string id) => 
        await jsRuntime.InvokeVoidAsync(Functions.FormatMoneyToFloat, id);

    public async Task HideChars(string id, string pattern) => 
        await jsRuntime.InvokeVoidAsync(Functions.HideChars, pattern, id);

    public async Task ScrollToCurrentSelected(string firstOptionElementId, string containerElementId, int itemPosition) => 
        await jsRuntime.InvokeVoidAsync(Functions.ScrollToCurrentSelected, firstOptionElementId, containerElementId, itemPosition);

    public async Task ScrollIntoModalView(string elementId) => 
        await jsRuntime.InvokeVoidAsync(Functions.ScrollToElementIfOffModal, elementId);
   
    public async Task ClearInput(string elementId) => 
        await jsRuntime.InvokeVoidAsync(Functions.ClearInput, elementId);

    public async Task RemoveFocus() => await jsRuntime.InvokeVoidAsync(Functions.RemoveFocus);

    public async Task<string> RestrictInput(string id, string characterPattern) => await jsRuntime.InvokeAsync<string>(Functions.RestrictInput, id,characterPattern);
    public async Task<string> GetValue(string id) => await jsRuntime.InvokeAsync<string>(Functions.GetValue, id);
}
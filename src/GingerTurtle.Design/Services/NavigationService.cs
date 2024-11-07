using GingerTurtle.Design.Constants;
using GingerTurtle.Design.Contracts;
using Microsoft.JSInterop;

namespace GingerTurtle.Design.Services;

public class NavigationService(IJSRuntime jsRuntime) : INavigationService
{
    public async Task ScrollToTop() => await jsRuntime.InvokeVoidAsync(Functions.ScrollToTop);

    public async Task DisableBodyScrolling() => await jsRuntime.InvokeVoidAsync(Functions.DisableBodyScrolling);
    
    public async Task EnableBodyScrolling() => await jsRuntime.InvokeVoidAsync(Functions.EnableBodyScrolling);

    public async Task ScrollToFirstError() => await jsRuntime.InvokeVoidAsync(Functions.ScrollToFirstError);
    public async Task<int> GetBodyScrollPosition() => await jsRuntime.InvokeAsync<int>(Functions.GetBodyScrollPosition);
    public async Task SetBodyScrollPosition(int yOffset) => await jsRuntime.InvokeVoidAsync(Functions.SetBodyScrollPosition, yOffset);
    public async Task NavigateToNewTab(string url) => await jsRuntime.InvokeVoidAsync(Functions.NavigateToNewTab,url);
    public async Task ScrollOptionIntoView(string elementId, string containerId) => await jsRuntime.InvokeVoidAsync(Functions.ScrollOptionIntoView, elementId,containerId);
}
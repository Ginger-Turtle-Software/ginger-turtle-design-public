namespace GingerTurtle.Design.Contracts;

public interface INavigationService
{
    Task ScrollToTop();
    Task EnableBodyScrolling();
    Task DisableBodyScrolling();
    Task ScrollToFirstError();
    Task<int> GetBodyScrollPosition();
    Task SetBodyScrollPosition(int yOffset);
    Task NavigateToNewTab(string url);
    Task ScrollOptionIntoView(string elementId, string containerId);
}
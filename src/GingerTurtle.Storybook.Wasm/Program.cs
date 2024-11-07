using GingerTurtle.Design.Contracts;
using GingerTurtle.Design.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GingerTurtle.Storybook.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<INavigationService, NavigationService>();
await builder.Build().RunAsync();
using System.Text.Json;
using GingerTurtle.Design.Contracts;
using Microsoft.JSInterop;

namespace GingerTurtle.Design.Services;

public class LocalStore(IJSRuntime jsRuntime) : ILocalStore
{
    private const string SetStoreValueFunction = "setStoreValue";
    private const string GetStoreValueFunction = "getStoreValue";
    private const string RemoveStoreValueFunction = "removeStoreValue";
    
    public async Task<T> GetValue<T>(string keyName)
    {
        var result = await jsRuntime.InvokeAsync<string>(GetStoreValueFunction, keyName);
        return string.IsNullOrEmpty(result) ? default :  JsonSerializer.Deserialize<T>(result);
    }

    public async Task SetValue(string keyName, object value)
    {
        var storeValue = JsonSerializer.Serialize(value);
        await jsRuntime.InvokeVoidAsync(SetStoreValueFunction, keyName, storeValue);
    }
        

    public async Task RemoveValue(string keyName) => await jsRuntime.InvokeVoidAsync(RemoveStoreValueFunction, keyName);
}
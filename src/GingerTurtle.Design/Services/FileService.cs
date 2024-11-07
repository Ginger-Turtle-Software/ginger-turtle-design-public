using GingerTurtle.Design.Constants;
using GingerTurtle.Design.Contracts;
using Microsoft.JSInterop;

namespace GingerTurtle.Design.Services;

public class FileService(IJSRuntime jsRuntime) : IFileService
{
    public async Task DownloadFile(string fileName, byte[] data)
    {
        await jsRuntime.InvokeAsync<object>(
            Functions.SaveFile,
            fileName,
            Convert.ToBase64String(data));
    }
}
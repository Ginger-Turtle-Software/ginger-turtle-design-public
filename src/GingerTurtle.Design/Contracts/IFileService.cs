namespace GingerTurtle.Design.Contracts;

public interface IFileService
{
    Task DownloadFile(string fileName, byte[] data);
}
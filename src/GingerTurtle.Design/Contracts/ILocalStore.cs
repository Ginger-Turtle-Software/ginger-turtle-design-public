namespace GingerTurtle.Design.Contracts;

public interface ILocalStore
{
    Task<T> GetValue<T>(string keyName);
    Task SetValue(string keyName, object value);
    Task RemoveValue(string keyName);
}
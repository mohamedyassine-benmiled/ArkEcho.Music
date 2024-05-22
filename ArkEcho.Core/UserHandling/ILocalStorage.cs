using System;
using System.Threading.Tasks;

namespace ArkEcho.Core
{
    public interface ILocalStorage
    {
        Task<string> GetStringAsync(string key);
        Task<Guid> GetGuidAsync(string key);

        Task RemoveItemAsync(string key);

        Task SetStringAsync(string key, string data);
        Task SetGuidAsync(string key, Guid data);
    }

    public abstract class LocalStorageBase : ILocalStorage
    {
        public abstract Task<Guid> GetGuidAsync(string key);
        public abstract Task<string> GetStringAsync(string key);
        public abstract Task RemoveItemAsync(string key);
        public abstract Task SetGuidAsync(string key, Guid data);
        public abstract Task SetStringAsync(string key, string data);
    }
}

using ArkEcho.Core;
using Blazored.LocalStorage;

namespace ArkEcho.WebPage.Data
{
    public class WebLocalStorage : LocalStorageBase
    {
        private ILocalStorageService blazorLocalStorage = null;

        public WebLocalStorage(ILocalStorageService blazorLocalStorage)
        {
            this.blazorLocalStorage = blazorLocalStorage;
        }

        public override async Task<Guid> GetGuidAsync(string key)
        {
            return await blazorLocalStorage.GetItemAsync<Guid>(key);
        }

        public override async Task<string> GetStringAsync(string key)
        {
            return await blazorLocalStorage.GetItemAsync<string>(key);
        }

        public override async Task RemoveItemAsync(string key)
        {
            await blazorLocalStorage.RemoveItemAsync(key);
        }

        public override async Task SetGuidAsync(string key, Guid data)
        {
            await blazorLocalStorage.SetItemAsync(key, data);
        }

        public override async Task SetStringAsync(string key, string data)
        {
            await blazorLocalStorage.SetItemAsync(key, data);
        }
    }
}

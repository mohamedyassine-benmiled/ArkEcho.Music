using ArkEcho.Core;
using ArkEcho.RazorPage.Data;

namespace ArkEcho.Maui
{
    public class MauiLocalStorage : LocalStorageBase
    {
        private IMauiHelper helper;

        public MauiLocalStorage(IMauiHelper helper)
        {
            this.helper = helper;
        }

        public override async Task<Guid> GetGuidAsync(string key)
        {
            string value = await GetStringAsync(key);
            return Guid.Parse(value);
        }

        public override async Task<string> GetStringAsync(string key)
        {
            return await Task.FromResult(helper.GetStringFromSettings(key));
        }

        public override async Task RemoveItemAsync(string key)
        {
            helper.RemoveKeyFromSettings(key);
        }

        public override async Task SetGuidAsync(string key, Guid data)
        {
            await SetStringAsync(key, data.ToString());
        }

        public override async Task SetStringAsync(string key, string data)
        {
            helper.SaveStringToSettings(key, data);
        }
    }
}

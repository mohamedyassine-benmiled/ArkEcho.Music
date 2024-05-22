using ArkEcho.Core;

namespace ArkEcho.RazorPage.Data
{
    public interface IMauiHelper
    {
        public event Action MediaPlayPauseKeyPressed;
        public event Action MediaStopKeyPressed;
        public event Action MediaPreviousTrackKeyPressed;
        public event Action MediaNextTrackKeyPressed;

        string GetPlatformSpecificMusicFolder(User user);
        Task<string> PickFolder();

        string ApplicationTitle { get; set; }
        bool DarkMode { set; }
        void SetDragArea(bool fullTitlebar);

        void SaveStringToSettings(string key, string value);
        bool CheckSettingsForKey(string key);
        void RemoveKeyFromSettings(string key);
        string GetStringFromSettings(string key);
    }
}

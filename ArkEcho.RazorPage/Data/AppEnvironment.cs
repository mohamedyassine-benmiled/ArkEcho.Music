﻿namespace ArkEcho.RazorPage.Data
{
    public class AppEnvironment
    {
        public bool Development { get; set; } = false;

        public Resources.Platform Platform { get; set; } = Resources.Platform.None;

        public string AppName { get; set; } = string.Empty;

        public string MusicPathAndroid { get; set; } = string.Empty;

        public AppEnvironment(string appName, bool development, Resources.Platform platform)
        {
            AppName = appName;
            Development = development;
            Platform = platform;
        }
    }
}

﻿using Android.App;
using Android.Content;
using ArkEcho.App.Connection;
using ArkEcho.Core;
using ArkEcho.Player;
using System;
using System.Threading.Tasks;

namespace ArkEcho.App
{
    public class AppModel : IDisposable
    {
        public static AppModel Instance { get; } = new AppModel();

        public ArkEchoRest Rest { get; private set; } = null;

        public ArkEchoVLCPlayer Player { get; private set; } = null;

        private AppModel()
        {
        }

        public async Task<bool> Init()
        {
            // TODO: From App.Config
            string url = "https://192.168.178.20:5001/api";
            //string url = "https://arkecho.de/api";

            Rest = new Connection.ArkEchoRest(url);

            Player = new Player.ArkEchoVLCPlayer();
            Player.InitPlayer(Log);

            await Task.Delay(5);
            return true;
        }

        public bool Log(string Text, Resources.LogLevel Level)
        {
            // TODO
            return true;
        }

        public static string GetAndroidMediaAppSDFolderPath()
        {
            string baseFolderPath = string.Empty;
            try
            {
                Context context = Application.Context;

                Java.IO.File[] dirs = context.GetExternalMediaDirs();//.GetExternalFilesDirs(null);

                foreach (Java.IO.File folder in dirs)
                {
                    bool IsRemovable = Android.OS.Environment.InvokeIsExternalStorageRemovable(folder);
                    bool IsEmulated = Android.OS.Environment.InvokeIsExternalStorageEmulated(folder);

                    if (IsRemovable && !IsEmulated)
                    {
                        baseFolderPath = folder.Path.Substring(0, folder.Path.IndexOf("Android/") + 8);
                        baseFolderPath += "media/ArkEcho.App/";
                        //break;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("GetBaseFolderPath caused the following exception: {0}", ex);
            }

            return baseFolderPath;
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
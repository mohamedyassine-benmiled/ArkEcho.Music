﻿using ArkEcho.Core;
using System;
using System.Collections.Generic;

namespace ArkEcho.Player
{
    // TODO: JSONBase -> Einstellungen nach Nutzer speichern
    public abstract class ArkEchoPlayer
    {
        public List<MusicFile> ListToPlay { get; private set; } = null;
        public int SongIndex { get; private set; }

        public MusicFile PlayingFile
        {
            get
            {
                return ListToPlay != null ? ListToPlay.Count > SongIndex && SongIndex >= 0 ? ListToPlay[SongIndex] : null : null;
            }
        }


        public event Action TitleChanged;
        public event Action PositionChanged;
        public event Action PlayingChanged;

        /// <summary>
        /// Audio Volume, 0 - 100
        /// </summary>
        public int Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                setVolumeImpl();
            }
        }
        private int volume = 50;

        /// <summary>
        /// Audio Muted
        /// </summary>
        public bool Mute
        {
            get { return muted; }
            set
            {
                muted = value;
                setMuteImpl();
            }
        }
        private bool muted = false;

        /// <summary>
        /// Audio Muted
        /// </summary>
        public bool Playing
        {
            get { return playing; }
            protected set
            {
                playing = value;
                PlayingChanged?.Invoke();
            }
        }
        private bool playing = false;

        /// <summary>
        /// Audio Position of Playback
        /// </summary>
        public int Position
        {
            get { return position; }
            protected set
            {
                if (value != position)
                {
                    position = value;
                    PositionChanged?.Invoke();
                }
            }
        }
        private int position = 0;

        // TODO: Shuffle
        public bool Shuffle { get; set; } = false;

        public ArkEchoPlayer()
        {
        }

        public void Start(List<MusicFile> MusicFiles, int Index)
        {
            // TODO: Liste und Position während wiedergabe ändern? -> Playlist starten, dann anders ordnen und trotzdem den nächsten Abspielen
            ListToPlay = MusicFiles;
            SongIndex = Index;

            load(true);
        }

        private void load(bool StartOnLoad)
        {
            disposeImpl();
            Position = 0;

            loadImpl(StartOnLoad);
            TitleChanged?.Invoke();
        }

        public void Play()
        {
            playImpl();
        }

        public void Pause()
        {
            pauseImpl();
        }

        public void PlayPause()
        {
            if (playing)
                Pause();
            else
                Play();
        }

        public void Stop()
        {
            stopImpl();
            Position = 0;
        }

        public void Forward()
        {
            SongIndex++;
            if (SongIndex == ListToPlay.Count)
            {
                SongIndex = 0;
                load(false);
            }
            else
                load(true);
        }

        //private long lastBackwards = 0;
        public void Backward()
        {
            if (Position > 5 || SongIndex == 0)
            {
                Stop();
                Play();
            }
            else
            {
                SongIndex--;
                load(true);
            }
        }

        public void SetPosition(int NewPosition)
        {
            setPositionImpl(NewPosition);
        }

        public void AudioEnd()
        {
            Forward();
        }

        protected abstract void loadImpl(bool StartOnLoad);
        protected abstract void disposeImpl();
        protected abstract void playImpl();
        protected abstract void pauseImpl();
        protected abstract void stopImpl();
        protected abstract void setMuteImpl();
        protected abstract void setVolumeImpl();
        protected abstract void setPositionImpl(int NewPosition);
    }
}

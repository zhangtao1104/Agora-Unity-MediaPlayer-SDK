namespace agora {
    namespace mediaPlayer {
        class MediaPlayerImp : public IMediaPlayer {
            
            public override MediaPlayer CreateMediaPlayer() {

            }
            public abstract int Open(string url, int64 startPos);
            public abstract int Play();
            public abstract int Pause();
            public abstract int Stop();
            public abstract int TakeScreenshot(string fileName);
            public abstract int Mute(bool mute);
            public abstract bool GetMute();
            public abstract int RegisterVideoFrameObserver();
            public abstract int UnregisterVideoFrameObserver();
            public abstract RegisterPlayerSourceObserver();
            public abstract UnregisterPlayerSourceObserver();
            public abstract void Release(bool sync);
        }
    }
}
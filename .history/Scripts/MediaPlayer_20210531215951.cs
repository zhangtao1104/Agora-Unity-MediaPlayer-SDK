using System.Runtime.InteropServices;
using System;
using AOT;

namespace agora
{
namespace mediaPlayer
{
struct MediaPlayerSourceEvent {
    Action<int, int> OnPlayerSourceStateChanged;
    Action<int64> OnPositionChanged;
    Action<int, int64> OnPlayerEvent;
    Action<IntPtr, int> OnMetaData;
    Action<int64> OnPlayerBufferUpdated;
    Action<string, event> OnPreloadevent;
    Action OnCompleted;
    Action OnAgoraCDNTokenNeedRenew;
}


class MediaPlayerImp : public IMediaPlayer
{
    private IntPtr _engine;
    private IntPtr _media_player;
    public MediaPlayerImp() {
        _engine = IntPtr.Zero;
        _media_player = IntPtr.Zero;
    }

    public override MediaPlayer CreateMediaPlayer()
    {
        _engine = IMediaPlayerNative.createAgoraRtcEngine_();
        _media_player = IMediaPlayerNative.createMediaPlayer(_engine);
    }
    public override int Open(string url, int64 startPos)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
            
        return IMediaPlayerNative.open(_);
    }
    public override int Play()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
    }
    public override int Pause()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
    }
    public override int Stop()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
    }
    public override int TakeScreenshot(string fileName)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
    }
    public override int Mute(bool mute)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
    }
    public override bool GetMute()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
    }
    public override int RegisterVideoFrameObserver()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
    }
    public override int UnregisterVideoFrameObserver()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
    }
    public override RegisterPlayerSourceObserver()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;
    }
    public override UnregisterPlayerSourceObserver()
    {
    }
    public override void Release(bool sync)
    {
    }
}
}
}
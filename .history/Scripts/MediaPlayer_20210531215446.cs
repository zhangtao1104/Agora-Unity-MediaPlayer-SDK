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
    private Int
    public MediaPlayerImp() {

    }

    public override MediaPlayer CreateMediaPlayer()
    {

    }
    public override int Open(string url, int64 startPos)
    {
    }
    public override int Play()
    {
    }
    public override int Pause()
    {
    }
    public override int Stop()
    {
    }
    public override int TakeScreenshot(string fileName)
    {
    }
    public override int Mute(bool mute)
    {
    }
    public override bool GetMute()
    {
    }
    public override int RegisterVideoFrameObserver()
    {
    }
    public override int UnregisterVideoFrameObserver()
    {
    }
    public override RegisterPlayerSourceObserver()
    {
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
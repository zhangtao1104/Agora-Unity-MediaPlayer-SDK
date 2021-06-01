using System.Runtime.InteropServices;
using System;
using AOT;

namespace agora
{
namespace mediaPlayer
{

class MediaPlayerImp : IMediaPlayer
{
    private IntPtr _engine;
    private IntPtr _media_player;
    private IntPtr _player_source_handler;

    public MediaPlayerImp()
    {
        _engine = IntPtr.Zero;
        _media_player = IntPtr.Zero;
    }

    public override IMediaPlayer CreateMediaPlayer(MediaPlayerSourceEvent sourceEvent)
    {
        _engine = IMediaPlayerNative.createAgoraRtcEngine_();
        _media_player = IMediaPlayerNative.createMediaPlayer(_engine);
        IMediaPlayerNative.registerPlayerSourceObserver(_media_player, sourceEvent);
        return this;
    }
    public override int Open(string url, long startPos)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.open(_media_player, url, startPos);
    }
    public override int Play()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.play(_media_player);
    }
    public override int Pause()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.pause(_media_player);
    }
    public override int Stop()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.stop(_media_player);
    }
    public override int TakeScreenshot(string fileName)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.takeScreenshot(_media_player, fileName);
    }
    public override int Mute(bool mute)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.mute(_media_player, mute);
    }
    public override bool GetMute()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return false;

        return IMediaPlayerNative.getMute(_media_player);
    }
    public override int RegisterVideoFrameObserver()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.registerVideoFrameObserver(_media_player);
    }
    public override int UnregisterVideoFrameObserver()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.unregisterVideoFrameObserver(_media_player);
    }
    public override void Release(bool sync)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;

        IMediaPlayerNative.unregisterPlayerSourceObserver(_media_player, _player_source_handler);
        IMediaPlayerNative.release(_engine, _media_player, sync);
    }
}
}
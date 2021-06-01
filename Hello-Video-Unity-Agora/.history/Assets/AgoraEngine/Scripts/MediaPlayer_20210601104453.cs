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

    private MediaPlayerImp(MediaPlayerSourceEvent sourceEvent)
    {
        _engine = IMediaPlayerNative.createAgoraRtcEngine_();
        _media_player = IMediaPlayerNative.createMediaPlayer(_engine);
        IMediaPlayerNative.media_player_registerPlayerSourceObserver(_media_player, sourceEvent);
    }

    public static IMediaPlayer CreateMediaPlayer(MediaPlayerSourceEvent sourceEvent, string appId)
    {
        return new MediaPlayerImp(sourceEvent);
    }
    public override int Open(string url, long startPos)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.media_player_open(_media_player, url, startPos);
    }
    public override int Play()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.media_player_play(_media_player);
    }
    public override int Pause()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.media_player_pause(_media_player);
    }
    public override int Stop()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.media_player_stop(_media_player);
    }
    public override int TakeScreenshot(string fileName)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.media_player_takeScreenshot(_media_player, fileName);
    }
    public override int Mute(bool mute)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.media_player_mute(_media_player, mute);
    }
    public override bool GetMute()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return false;

        return IMediaPlayerNative.media_player_getMute(_media_player);
    }
    public override int RegisterVideoFrameObserver()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.media_player_registerVideoFrameObserver(_media_player);
    }
    public override int UnregisterVideoFrameObserver()
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return (int)ERROR_CODE.ERROR_NOT_INIT;

        return IMediaPlayerNative.media_player_unregisterVideoFrameObserver(_media_player);
    }
    public override void Release(bool sync)
    {
        if (_engine == IntPtr.Zero || _media_player == IntPtr.Zero)
            return;

        IMediaPlayerNative.media_player_unregisterPlayerSourceObserver(_media_player, _player_source_handler);
        IMediaPlayerNative.media_player_release(_engine, _media_player, sync);
        _engine = IntPtr.Zero;
        _media_player = IntPtr.Zero;
        _player_source_handler = IntPtr.Zero;
    }
}
}
}
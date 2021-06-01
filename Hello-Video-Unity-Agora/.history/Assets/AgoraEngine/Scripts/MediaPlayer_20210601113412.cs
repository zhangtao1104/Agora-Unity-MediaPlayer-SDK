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
    private MediaPlayerSourceEvent _source_event;

    [StructLayout(LayoutKind.Sequential)]
    internal struct MediaPlayerSourceEventNative {
        internal FUNC_onPlayerSourceStateChanged _OnPlayerSourceStateChanged;
        internal FUNC_onPositionChanged _OnPositionChanged;

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
internal delegate void FUNC_onPlayerEvent(MEDIA_PLAYER_EVENT @event, long elapsedTime, string message);

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
internal delegate void FUNC_onMetaData(IntPtr data, int length);
[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
internal delegate void FUNC_onPlayBufferUpdated(long playCachedBuffer);

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
internal delegate void FUNC_onPreloadEvent(string src, PLAYER_PRELOAD_EVENT @event);

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
internal delegate void FUNC_onCompleted();

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
internal delegate void FUNC_onAgoraCDNTokenNeedRenew();
    }

    private MediaPlayerImp(string appId, MediaPlayerSourceEvent sourceEvent)
    {
        _source_event = sourceEvent;
        _engine = IMediaPlayerNative.createAgoraRtcEngine_(appId);
        _media_player = IMediaPlayerNative.createMediaPlayer(_engine);
        IMediaPlayerNative.media_player_registerPlayerSourceObserver(_media_player, sourceEvent);
    }

    public static IMediaPlayer CreateMediaPlayer(string appId, MediaPlayerSourceEvent sourceEvent)
    {
        return new MediaPlayerImp(appId, sourceEvent);
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
using System.Runtime.InteropServices;
using System;
using AOT;
using UnityEngine;

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
    private EventListener _source_event_native;

    private static MediaPlayerImp _player_instance;

    private MediaPlayerImp(string appId, MediaPlayerSourceEvent sourceEvent)
    {
        _source_event = sourceEvent;
        InitHandler();
        _engine = IMediaPlayerNative.createAgoraRtcEngine_(appId);
        _media_player = IMediaPlayerNative.createMediaPlayer(_engine);
        IMediaPlayerNative.media_player_registerPlayerSourceObserver(_media_player, ref _source_event_native);
    }

    private EventListener InitHandler()
    {
        _source_event_native = new EventListener { 
            _OnPlayerSourceStateChanged = Marshal.GetFunctionPointerForDelegate(new FUNC_onPlayerSourceStateChanged(OnPlayerSourceStateChanged))

            _OnPositionChanged = Marshal.GetFunctionPointerForDelegate(new FUNC_onPositionChanged(OnPositionChanged)),

            _OnPlayerEvent = Marshal.GetFunctionPointerForDelegate(new FUNC_onPlayerEvent(OnPlayerEvent)),

            _OnMetaData = Marshal.GetFunctionPointerForDelegate(new FUNC_onMetaData(OnMetaData)),

            _OnPlayBufferUpdated = Marshal.GetFunctionPointerForDelegate(new FUNC_onPlayerBufferUpdated(OnPlayerBufferUpdated)),

            _OnPreloadEvent = Marshal.GetFunctionPointerForDelegate(new FUNC_onPreloadEvent(OnPreloadEvent)),

            _OnCompleted = Marshal.GetFunctionPointerForDelegate(new FUNC_onCompleted(OnCompleted)),

            _OnAgoraCDNTokenNeedRenew = Marshal.GetFunctionPointerForDelegate(new FUNC_onAgoraCDNTokenNeedRenew(OnAgoraCDNTokenNeedRenew)) 
            };

        return _source_event_native;
    }

    public void OnPlayerSourceStateChanged(int state, int ec)
    {
        Debug.Log("CWrapper: _OnPlayerSourceStateChanged state " + state + " ec " + ec);
        _player_instance._source_event?.OnPlayerSourceStateChanged(state, ec);
    }

    private void OnPositionChanged(long position)
    {
        _player_instance._source_event?.OnPositionChanged(position);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onPlayerEvent))]
    private static void OnPlayerEvent(MEDIA_PLAYER_EVENT @event, long elapsedTime, string message)
    {
        Debug.Log("CWrapper: _OnPlayerEvent");
        _player_instance._source_event?.OnPlayerEvent(@event, elapsedTime, message);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onMetaData))]
    private static void OnMetaData(IntPtr data, int length)
    {
        Debug.Log("CWrapper: OnMetaData");
        _player_instance._source_event?.OnMetaData(data, length);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onPlayBufferUpdated))]
    private static void OnPlayerBufferUpdated(long playCachedBuffer)
    {
        Debug.Log("CWrapper: OnPlayerBufferUpdated");
        _player_instance._source_event?.OnPlayBufferUpdated(playCachedBuffer);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onPreloadEvent))]
    private static void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT @event)
    {
        Debug.Log("CWrapper: OnPreloadEvent");
        _player_instance._source_event?.OnPreloadEvent(src, @event);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onCompleted))]
    private static void OnCompleted()
    {
        Debug.Log("CWrapper: _OnCompleted");
        _player_instance._source_event?.OnCompleted();
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onAgoraCDNTokenNeedRenew))]
    private static void OnAgoraCDNTokenNeedRenew()
    {
        _player_instance._source_event?.OnAgoraCDNTokenNeedRenew();
    }

    public static IMediaPlayer CreateMediaPlayer(string appId, MediaPlayerSourceEvent sourceEvent)
    {
        if (_player_instance == null)
        {
            _player_instance = new MediaPlayerImp(appId, sourceEvent);
        }
        return _player_instance;
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
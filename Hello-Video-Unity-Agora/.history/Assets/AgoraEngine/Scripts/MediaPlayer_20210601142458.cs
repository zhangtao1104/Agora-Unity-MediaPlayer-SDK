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
        _source_event_native =
            new EventListener { _OnPlayerSourceStateChanged =

                                    _OnPositionChanged =

                                        _OnPlayerEvent =

                                            _OnMetaData = _OnPlayBufferUpdated =

                                                _OnPreloadEvent =

                                                    _OnCompleted =

                                                        _OnAgoraCDNTokenNeedRenew =
                                                             } };

        return _source_event_native;
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onPlayerSourceStateChanged))]
    private void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
    {
        Debug.Log("CWrapper: _OnPlayerSourceStateChanged");
        _source_event?.OnPlayerSourceStateChanged(state, ec);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onPositionChanged))]
    private void OnPositionChanged(long position)
    {
        Debug.Log("CWrapper: _OnPositionChanged");
        _source_event?.OnPositionChanged(position);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onPlayerEvent))]
    private void OnPlayerEvent(MEDIA_PLAYER_EVENT @event, long elapsedTime, string message)
    {
        Debug.Log("CWrapper: _OnPlayerEvent");
        _source_event?.OnPlayerEvent(@event, elapsedTime, message);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onMetaData))]
    private void OnMetaData(IntPtr data, int length)
    {
        _source_event?.OnMetaData(data, length);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onPlayBufferUpdated))]
    private void OnPlayerBufferUpdated(long playCachedBuffer)
    {
        _source_event?.OnPlayBufferUpdated(playCachedBuffer);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onPreloadEvent))]
    private void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT @event)
    {
        _source_event?.OnPreloadEvent(src, @event);
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onCompleted))]
    private void OnCompleted()
    {
        Debug.Log("CWrapper: _OnCompleted");
        _source_event?.OnCompleted();
    }

    [AOT.MonoPInvokeCallback(typeof(FUNC_onAgoraCDNTokenNeedRenew))]
    private void OnAgoraCDNTokenNeedRenew() { _source_event?.OnAgoraCDNTokenNeedRenew()}

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
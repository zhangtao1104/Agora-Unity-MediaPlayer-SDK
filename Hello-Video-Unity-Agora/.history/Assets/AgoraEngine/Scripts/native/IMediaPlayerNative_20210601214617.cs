using System.Runtime.InteropServices;
using System;
using AOT;

namespace agora
{
namespace mediaPlayer
{

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
internal delegate void FUNC_onPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec);

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
internal delegate void FUNC_onPositionChanged(long position);

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

[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
internal delegate void FUNC_onFrame();


[StructLayout(LayoutKind.Sequential)]
internal struct EventListener
{
    internal IntPtr _OnFrame;
    internal IntPtr _OnPlayerSourceStateChanged;
    internal IntPtr _OnPositionChanged;
    internal IntPtr _OnPlayerEvent;
    internal IntPtr _OnMetaData;
    internal IntPtr _OnPlayBufferUpdated;
    internal IntPtr _OnPreloadEvent;
    internal IntPtr _OnCompleted;
    internal IntPtr _OnAgoraCDNTokenNeedRenew;
}

internal class IMediaPlayerNative
{
#region
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    internal const string LibraryName = "mediaPlayerCWrapper";
#else

#if UNITY_IPHONE
    internal const string LibraryName = "__Internal";
#else
    internal const string LibraryName = "mediaPlayerCWrapper";
#endif
#endif
#endregion

    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern IntPtr createAgoraRtcEngine_(string appId);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern IntPtr createMediaPlayer(IntPtr engine);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern int media_player_open(IntPtr mediaPlayer, string url, long startPos);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern int media_player_play(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern int media_player_pause(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern int media_player_stop(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern int media_player_takeScreenshot(IntPtr mediaPlayer, string filename);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern int media_player_mute(IntPtr mediaPlayer, bool mute);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern bool media_player_getMute(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern int media_player_registerVideoFrameObserver(IntPtr mediaPlayer, IntPtr media_player_event);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern int media_player_unregisterVideoFrameObserver(IntPtr mediaPlayer, IntPtr media_player_event);
    [DllImport(LibraryName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr media_player_registerPlayerSourceObserver(IntPtr mediaPlayer, ref EventListener on);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern int media_player_unregisterPlayerSourceObserver(IntPtr mediaPlayer, IntPtr observer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    internal static extern void media_player_release(IntPtr engine, IntPtr mediaPlayer, bool sync);
}
}
}
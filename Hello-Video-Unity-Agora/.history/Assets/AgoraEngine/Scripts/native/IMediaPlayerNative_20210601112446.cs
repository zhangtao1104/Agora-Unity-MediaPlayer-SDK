using System.Runtime.InteropServices;
using System;
using AOT;

namespace agora
{
namespace mediaPlayer
{

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnEvent(string @event, string data);


internal class IMediaPlayerNative
{
#region
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    public const string LibraryName = "mediaPlayerCWrapper";
#else

#if UNITY_IPHONE
    public const string LibraryName = "__Internal";
#else
    public const string LibraryName = "mediaPlayerCWrapper";
#endif
#endif
#endregion

    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    public static extern IntPtr createAgoraRtcEngine_(string appId);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern IntPtr createMediaPlayer(IntPtr engine);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int media_player_open(IntPtr mediaPlayer, string url, long startPos);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int media_player_play(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int media_player_pause(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int media_player_stop(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int media_player_takeScreenshot(IntPtr mediaPlayer, string filename);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int media_player_mute(IntPtr mediaPlayer, bool mute);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern bool media_player_getMute(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int media_player_registerVideoFrameObserver(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int media_player_unregisterVideoFrameObserver(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern IntPtr media_player_registerPlayerSourceObserver(IntPtr mediaPlayer, MediaPlayerSourceEvent observer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int media_player_unregisterPlayerSourceObserver(IntPtr mediaPlayer, IntPtr observer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern void media_player_release(IntPtr engine, IntPtr mediaPlayer, bool sync);
}
}
}
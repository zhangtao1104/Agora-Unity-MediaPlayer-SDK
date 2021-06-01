using System.Runtime.InteropServices;
using System;
using AOT;

namespace agora
{
namespace mediaPlayer
{
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
    public static extern IntPtr createAgoraRtcEngine_();
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern IntPtr createMediaPlayer(IntPtr engine);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int open(IntPtr mediaPlayer, string url, long startPos);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int play(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int pause(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int stop(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int takeScreenshot(IntPtr mediaPlayer, string filename);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int mute(IntPtr mediaPlayer, bool mute);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern bool getMute(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int registerVideoFrameObserver(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int unregisterVideoFrameObserver(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern IntPtr registerPlayerSourceObserver(IntPtr mediaPlayer, MediaPlayerSourceEvent observer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern int unregisterPlayerSourceObserver(IntPtr mediaPlayer, IntPtr observer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
            public static extern void release(IntPtr engine, IntPtr mediaPlayer, bool sync);
}
}
}
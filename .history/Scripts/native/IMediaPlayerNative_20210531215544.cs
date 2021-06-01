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
    IntPtr createAgoraRtcEngine_();
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    IntPtr createMediaPlayer(IntPtr engine);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    int open(IntPtr mediaPlayer, string url, int64_t startPos);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    int play(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    int pause(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    int stop(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    int takeScreenshot(IntPtr mediaPlayer, string filename);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    int mute(IntPtr mediaPlayer, bool mute);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    bool getMute(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    int registerVideoFrameObserver(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    int unregisterVideoFrameObserver(IntPtr mediaPlayer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    IntPtr registerPlayerSourceObserver(IntPtr mediaPlayer, IntPtr observer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    int unregisterPlayerSourceObserver(IntPtr mediaPlayer, IntPtr observer);
    [DllImport(LibraryName, CharSet = CharSet.Ansi)]
    void release(IntPtr engine, IntPtr mediaPlayer, bool sync);
}
}
}
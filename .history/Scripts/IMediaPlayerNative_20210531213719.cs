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

[DllImport(LibraryName, CharSet=CharSet.Ansi)]
IntPtr createAgoraRtcEngine_();
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
IntPtr createMediaPlayer(IntPtr);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
int open(IntPtr mediaPlayer, string url, int64_t startPos);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
int play(IntPtr mediaPlayer);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
int pause(void *mediaPlayer);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
AGORA_API int stop(void *mediaPlayer);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
AGORA_API int takeScreenshot(void *mediaPlayer, const char* filename);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
AGORA_API int mute(void *mediaPlayer, bool mute);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
AGORA_API bool getMute(void *mediaPlayer);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
AGORA_API int registerVideoFrameObserver(void *mediaPlayer);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
AGORA_API int unregisterVideoFrameObserver(void *mediaPlayer);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
AGORA_API void* registerPlayerSourceObserver(void* mediaPlayer, void* observer);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
AGORA_API int unregisterPlayerSourceObserver(void* mediaPlayer, void* observer);
[DllImport(LibraryName, CharSet=CharSet.Ansi)]
AGORA_API void release(void *engine, void *mediaPlayer, bool sync);

}
}
}
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
IntPtr createMediaPlayer(IntPtr);
int open(IntPtr mediaPlayer, string url, int64_t startPos);
AGORA_API int play(void *mediaPlayer);
AGORA_API int pause(void *mediaPlayer);
AGORA_API int stop(void *mediaPlayer);
AGORA_API int takeScreenshot(void *mediaPlayer, const char* filename);
AGORA_API int mute(void *mediaPlayer, bool mute);
AGORA_API bool getMute(void *mediaPlayer);
AGORA_API int registerVideoFrameObserver(void *mediaPlayer);
AGORA_API int unregisterVideoFrameObserver(void *mediaPlayer);
AGORA_API void* registerPlayerSourceObserver(void* mediaPlayer, void* observer);
AGORA_API int unregisterPlayerSourceObserver(void* mediaPlayer, void* observer);
AGORA_API void release(void *engine, void *mediaPlayer, bool sync);

}
}
}
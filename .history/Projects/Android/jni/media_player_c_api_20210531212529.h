#pragma once
#include "base.h"

extern "C" {
AGORA_API void *createAgoraRtcEngine_();
AGORA_API void *createMediaPlayer(void *engine);
AGORA_API int open(void *mediaPlayer, const char* url, int64_t startPos);
AGORA_API int play(void *mediaPlayer);
AGORA_API int pause(void *mediaPlayer);
AGORA_API int stop(void *mediaPlayer);
AGORA_API int takeScreenshot(void *mediaPlayer, const char* filename);
AGORA_API int mute(void *mediaPlayer, bool mute);
AGORA_API bool getMute(void *mediaPlayer);
AGORA_API int registerVideoFrameObserver(void *mediaPlayer);
AGORA_API int unregisterVideoFrameObserver(void *mediaPlayer);
AGORA_API void* registerPlayerSourceObserver(void* observer);
AGORA_API int unregisterPlayerSourceObserver(void* observer);
AGORA_API void release(void *engine, void *mediaPlayer, bool sync);
}
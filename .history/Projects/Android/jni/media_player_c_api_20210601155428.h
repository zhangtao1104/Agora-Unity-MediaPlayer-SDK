#pragma once
#include "base.h"

extern "C" {
AGORA_API void *createAgoraRtcEngine_(const char *appId);
AGORA_API void *createMediaPlayer(void *engine);
AGORA_API int media_player_open(void *mediaPlayer, const char *url,
                                int64_t startPos);
AGORA_API int media_player_play(void *mediaPlayer);
AGORA_API int media_player_pause(void *mediaPlayer);
AGORA_API int media_player_stop(void *mediaPlayer);
AGORA_API int media_player_takeScreenshot(void *mediaPlayer,
                                          const char *filename);
AGORA_API int media_player_mute(void *mediaPlayer, bool mute);
AGORA_API bool media_player_getMute(void *mediaPlayer);
AGORA_API int media_player_registerVideoFrameObserver(void *mediaPlayer);
AGORA_API int media_player_unregisterVideoFrameObserver(void *mediaPlayer);
AGORA_API void *media_player_registerPlayerSourceObserver(void *mediaPlayer,
                                                          EventListener* sourceStateChanged);
AGORA_API int media_player_unregisterPlayerSourceObserver(void *mediaPlayer,
                                                          void *observer);
AGORA_API void media_player_release(void *engine, void *mediaPlayer, bool sync);
}
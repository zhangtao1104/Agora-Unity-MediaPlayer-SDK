#include "media_player_c_api.h"
#include "IAgoraRtcEngine.h"

extern "C" {
void *createEngine()
{

}

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
}
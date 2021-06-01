#include "media_player_c_api.h"

void *createEngine()
{
    
}
AGORA_API void *createMediaPlayer(void *engine);
AGORA_API int open(const char* url, int64_t startPos);
AGORA_API int play();
AGORA_API int pause();
AGORA_API int stop();
AGORA_API int takeScreenshot(const char* filename);
AGORA_API int mute(bool mute);
AGORA_API bool getMute();
AGORA_API int registerVideoFrameObserver();
AGORA_API int unregisterVideoFrameObserver();
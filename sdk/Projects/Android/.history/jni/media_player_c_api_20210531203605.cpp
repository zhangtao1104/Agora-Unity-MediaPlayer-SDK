#include "media_player_c_api.h"
#include "IAgoraRtcEngine.h"
#include "IAgoraMediaPlayer.h"

extern "C" {
    using namespace agora::rtc;
void *createAgoraRtcEngine_()
{
    return createAgoraRtcEngine();
}

void *createMediaPlayer(void *engine)
{
    auto _engine = reinterpret_cast<IRtcEngine*>(engine);
    _engine->createMediaPlayer();
}
 int open(void *mediaPlayer, const char* url, int64_t startPos)
{

}
 int play(void *mediaPlayer);
 int pause(void *mediaPlayer);
 int stop(void *mediaPlayer);
 int takeScreenshot(void *mediaPlayer, const char* filename);
 int mute(void *mediaPlayer, bool mute);
 bool getMute(void *mediaPlayer);
 int registerVideoFrameObserver(void *mediaPlayer);
 int unregisterVideoFrameObserver(void *mediaPlayer);
}
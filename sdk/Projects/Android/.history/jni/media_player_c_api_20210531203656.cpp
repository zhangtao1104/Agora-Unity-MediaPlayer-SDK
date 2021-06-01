#include "media_player_c_api.h"
#include "IAgoraMediaPlayer.h"
#include "IAgoraRtcEngine.h"

extern "C" {
using namespace agora::rtc;
void *createAgoraRtcEngine_() { return createAgoraRtcEngine(); }

void *createMediaPlayer(void *engine) {
  auto _engine = reinterpret_cast<IRtcEngine *>(engine);
  _engine->createMediaPlayer();
}
int open(void *mediaPlayer, const char *url, int64_t startPos) {
    auto _media_player = reinterpret_cast<IAgoraMediaPlayer *>(mediaPlayer);
}
int play(void *mediaPlayer);
int pause(void *mediaPlayer);
int stop(void *mediaPlayer);
int takeScreenshot(void *mediaPlayer, const char *filename);
int mute(void *mediaPlayer, bool mute);
bool getMute(void *mediaPlayer);
int registerVideoFrameObserver(void *mediaPlayer);
int unregisterVideoFrameObserver(void *mediaPlayer);
}
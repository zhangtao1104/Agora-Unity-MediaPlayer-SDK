#include "media_player_c_api.h"
#include "../prebuilt/high_level_api/include/IAgoraMediaPlayer.h"
#include "../prebuilt/high_level_api/include/IAgoraRtcEngine.h"

extern "C" {
using namespace agora::rtc;
void *createAgoraRtcEngine_() { return createAgoraRtcEngine(); }

void *createMediaPlayer(void *engine) {
  auto _engine = reinterpret_cast<IRtcEngine *>(engine);
  auto _media_player = _engine->createMediaPlayer();
  return _media_player;
}
int open(void *mediaPlayer, const char *url, int64_t startPos) {
    auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
    return _media_player->open(url, startPos);
}
int play(void *mediaPlayer)
{
    auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
    return _media_player->play();
}
int pause(void *mediaPlayer)
{
    auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
    return _media_player->pause();
}
int stop(void *mediaPlayer);
int takeScreenshot(void *mediaPlayer, const char *filename);
int mute(void *mediaPlayer, bool mute);
bool getMute(void *mediaPlayer);
int registerVideoFrameObserver(void *mediaPlayer);
int unregisterVideoFrameObserver(void *mediaPlayer);
}
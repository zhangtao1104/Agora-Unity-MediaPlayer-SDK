#include "media_player_c_api.h"
#include "../prebuilt/high_level_api/include/IAgoraMediaPlayer.h"
#include "../prebuilt/high_level_api/include/IAgoraRtcEngine.h"

extern "C" {
using namespace agora::rtc;
void *createAgoraRtcEngine_() { return createAgoraRtcEngine(); }

void *createMediaPlayer(void *engine) {
  auto _engine = reinterpret_cast<IRtcEngine *>(engine);
  auto _media_player_ref = _engine->createMediaPlayer();
    auto _media_player_ptr = _media_player_ref.move();
  return _media_player;
}
int open(void *mediaPlayer, const char *url, int64_t startPos) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  return _media_player->open(url, startPos);
}
int play(void *mediaPlayer) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  return _media_player->play();
}
int pause(void *mediaPlayer) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  return _media_player->pause();
}
int stop(void *mediaPlayer) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  return _media_player->stop();
}
int takeScreenshot(void *mediaPlayer, const char *filename) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  return _media_player->takeScreenshot(filename);
}
int mute(void *mediaPlayer, bool mute) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  return _media_player->mute(mute);
}

bool getMute(void *mediaPlayer) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  bool mute;
  _media_player->getMute(mute);
  return mute;
}
int registerVideoFrameObserver(void *mediaPlayer) { return 0; }
int unregisterVideoFrameObserver(void *mediaPlayer) { return 0; }
}
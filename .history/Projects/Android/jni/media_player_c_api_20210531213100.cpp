#include "media_player_c_api.h"
#include "../prebuilt/high_level_api/include/IAgoraMediaPlayer.h"
#include "../prebuilt/high_level_api/include/IAgoraRtcEngine.h"
#include "agora_media_player_source.h"

extern "C" {
using namespace agora::rtc;
void *createAgoraRtcEngine_() { return createAgoraRtcEngine(); }

void *createMediaPlayer(void *engine) {
  auto _engine = reinterpret_cast<IRtcEngine *>(engine);
  auto _media_player_ref = _engine->createMediaPlayer();
  auto _media_player_ptr = _media_player_ref.move();
  return _media_player_ptr;
}

void* registerPlayerSourceObserver(void* mediaPlayer, void* observer)
{
  auto _event_listener = reinterpret_cast<EventListener *>(observer);
  auto _media_player_source = new AgoraMediaPlayerSource(_event_listener);
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  _media_player->registerPlayerSourceObserver(_media_player_source);
  return _media_player_source;
}

int unregisterPlayerSourceObserver(void* mediaPlayer, void* observer)
{
  auto _media_player_source = new AgoraMediaPlayerSource(_event_listener);
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  _media_player->unregisterPlayerSourceObserver(_media_player);
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

void release(void *engine, void *mediaPlayer, bool sync)
{
    auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
    _media_player->Release();

    auto _engine = reinterpret_cast<IRtcEngine *>(engine);
    _engine->release(sync);
}

int registerVideoFrameObserver(void *mediaPlayer) { return 0; }
int unregisterVideoFrameObserver(void *mediaPlayer) { return 0; }
}
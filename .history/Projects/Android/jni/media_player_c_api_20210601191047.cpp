#include "media_player_c_api.h"
#include "../prebuilt/high_level_api/include/IAgoraMediaPlayer.h"
#include "../prebuilt/high_level_api/include/IAgoraRtcEngine.h"
#include "../prebuilt/high_level_api/include/IAgoraRtcEngineEx.h"
#include "agora_media_player_source.h"

extern "C" {
using namespace agora::rtc;

class RtcEngineEventHandler : public IRtcEngineEventHandler {};

class RtcEngineEventHandlerEx : public IRtcEngineEventHandlerEx {};

void *createAgoraRtcEngine_(const char *appId) {
  PRINTF("createAgoraRtcEngine_ enter");
  RtcEngineContext _context;
  _context.appId = appId;
  _context.eventHandler = new RtcEngineEventHandler();
  _context.eventHandlerEx = new RtcEngineEventHandlerEx();
  auto _rtcEngine = createAgoraRtcEngine();
  auto ret = _rtcEngine->initialize(_context);
  PRINTF("createAgoraRtcEngine_ end ret: %d", ret);
  return _rtcEngine;
}

void *createMediaPlayer(void *engine) {
  PRINTF("createMediaPlayer enter");
  auto _engine = reinterpret_cast<IRtcEngine *>(engine);
  auto _media_player_ref = _engine->createMediaPlayer();
  auto _media_player_ptr = _media_player_ref.move();
  PRINTF("createMediaPlayer end");
  return _media_player_ptr;
}

void *media_player_registerPlayerSourceObserver(void *mediaPlayer,
                                                EventListener *listener) {
  PRINTF("media_player_registerPlayerSourceObserver enter");
  auto _media_player_source = new AgoraMediaPlayerSourceObserver(listener);
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  auto ret = _media_player->registerPlayerSourceObserver(_media_player_source);
  PRINTF("media_player_registerPlayerSourceObserver end ret: %d", ret);
  return _media_player_source;
}

int media_player_unregisterPlayerSourceObserver(void *mediaPlayer,
                                                void *observer) {
  PRINTF("media_player_unregisterPlayerSourceObserver enter");
  auto _media_player_source =
      reinterpret_cast<AgoraMediaPlayerSourceObserver *>(observer);
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  auto ret =
      _media_player->unregisterPlayerSourceObserver(_media_player_source);
  delete _media_player_source;
  _media_player_source = nullptr;
  PRINTF("media_player_unregisterPlayerSourceObserver end ret: %d", ret);
  return 0;
}

int media_player_registerVideoFrameObserver(void *mediaPlayer,
                                            void *_media_player_source) {
  PRINTF("media_player_registerVideoFrameObserver enter");  
        
  auto _media_player_event =
      reinterpret_cast<AgoraMediaPlayerSourceObserver *>(_media_player_source);
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);

  auto _observer = new AgoraMediaPlayerSourceObserver(nullptr);
  auto ret = _media_player->registerVideoFrameObserver(_observer);
  PRINTF("media_player_registerVideoFrameObserver end");
  return ret;
}

int media_player_unregisterVideoFrameObserver(void *mediaPlayer,
                                              void *_media_player_source) {
  PRINTF("media_player_unregisterVideoFrameObserver enter");  
  auto _media_player_event =
      reinterpret_cast<AgoraMediaPlayerSourceObserver *>(_media_player_source);
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  auto ret = _media_player->unregisterVideoFrameObserver(_media_player_event);
  PRINTF("media_player_unregisterVideoFrameObserver end");  
  return 0;
}

int media_player_open(void *mediaPlayer, const char *url, int64_t startPos) {
  PRINTF("media_player_open enter");
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  auto ret = _media_player->open(url, startPos);
  PRINTF("media_player_open end ret: %d", ret);
  return ret;
}

int media_player_play(void *mediaPlayer) {
  PRINTF("media_player_play enter");
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  auto ret = _media_player->play();
  PRINTF("media_player_play end ret: %d", ret);
  return ret;
}

int media_player_pause(void *mediaPlayer) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  auto ret = _media_player->pause();
  return ret;
}
int media_player_stop(void *mediaPlayer) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  auto ret = _media_player->stop();
  return ret;
}
int media_player_takeScreenshot(void *mediaPlayer, const char *filename) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  auto ret = _media_player->takeScreenshot(filename);
  return ret;
}

int media_player_mute(void *mediaPlayer, bool mute) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  auto ret = _media_player->mute(mute);
  return ret;
}

bool media_player_getMute(void *mediaPlayer) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  bool mute;
  _media_player->getMute(mute);
  return mute;
}

void media_player_release(void *engine, void *mediaPlayer, bool sync) {
  auto _media_player = reinterpret_cast<IMediaPlayer *>(mediaPlayer);
  _media_player->Release();

  auto _engine = reinterpret_cast<IRtcEngine *>(engine);
  _engine->release(sync);
}
}
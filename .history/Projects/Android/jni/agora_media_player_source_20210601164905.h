#pragma once
#include "../prebuilt/high_level_api/include/IAgoraMediaPlayerSource.h"
#include "base.h"

namespace agora {
namespace rtc {

class AgoraMediaPlayerSource : public IMediaPlayerSourceObserver, media::base::IVideoFrameObserver {
private:
  EventListener *_event;

public:
  AgoraMediaPlayerSource(EventListener *event);
  virtual ~AgoraMediaPlayerSource();

  void onPlayerSourceStateChanged(media::base::MEDIA_PLAYER_STATE state,
                                  media::base::MEDIA_PLAYER_ERROR ec) override;

  void onPositionChanged(int64_t position) override;

  void onPlayerEvent(media::base::MEDIA_PLAYER_EVENT event, int64_t elapsedTime,
                     const char *message) override;

  void onMetaData(const void *data, int length) override;

  void onPlayBufferUpdated(int64_t playCachedBuffer) override;

  void onPreloadEvent(const char *src,
                      media::base::PLAYER_PRELOAD_EVENT event) override;

  void onCompleted() override;

  void onAgoraCDNTokenNeedRenew() override;

  void onFrame(const media::base::IVideoFrameObserver::VideoFrame* frame) override;
};
} // namespace rtc
} // namespace agora
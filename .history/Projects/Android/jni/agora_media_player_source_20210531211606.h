#pragma once
#include "../prebuilt/high_level_api/include/IAgoraMediaPlayerSource.h"
#include "base.h"

namespace agora {
namespace rtc {

struct Event {
    FUNC_OnPlayerSourceStateChanged _onPlayerSourceChanged;
    FUNC_OnPositionChanged _onPositionChanged;
    FUNC_OnPlayerEvent _onPlayerEvent;
    FUNC_OnMetaData _onMetaData;
    FUNC_OnPlayBufferUpdated _onPlayBufferUpdated;
    FUNC_OnPreloadEvent _onPreloadEvent;
    FUNC_OnCompleted _onCompleted;
    FUNC_OnAgoraCDNTokenNeedRenew _onAgoraCDNTokenNeedRenew;
}


class AgoraMediaPlayerSource : public IMediaPlayerSourceObserver {
private:
    

public:
  AgoraMediaPlayerSource();
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
};
} // namespace rtc
} // namespace agora
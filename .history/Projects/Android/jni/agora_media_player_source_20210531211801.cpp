#include "agora_media_player_source.h"

namespace agora {
namespace rtc {


AgoraMediaPlayerSource::AgoraMediaPlayerSource(EventListener* event)
{
    _event = event;
}

AgoraMediaPlayerSource::~AgoraMediaPlayerSource() {
    _event = nullptr;
}

void AgoraMediaPlayerSource::onPlayerSourceStateChanged(
    media::base::MEDIA_PLAYER_STATE state, media::base::MEDIA_PLAYER_ERROR ec) {
        if (_event)
            _event->onPlayerSta
}

void AgoraMediaPlayerSource::onPositionChanged(int64_t position) {}

void AgoraMediaPlayerSource::onPlayerEvent(
    media::base::MEDIA_PLAYER_EVENT event, int64_t elapsedTime,
    const char *message) {}

void AgoraMediaPlayerSource::onMetaData(const void *data, int length) {}

void AgoraMediaPlayerSource::onPlayBufferUpdated(int64_t playCachedBuffer) {}

void AgoraMediaPlayerSource::onPreloadEvent(
    const char *src, media::base::PLAYER_PRELOAD_EVENT event) {}

void AgoraMediaPlayerSource::onCompleted() {}

void AgoraMediaPlayerSource::onAgoraCDNTokenNeedRenew() {}
} // namespace rtc
} // namespace agora
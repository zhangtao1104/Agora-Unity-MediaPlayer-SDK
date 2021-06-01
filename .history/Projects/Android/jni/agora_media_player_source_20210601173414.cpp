#include "agora_media_player_source.h"

namespace agora {
namespace rtc {

AgoraMediaPlayerSource::AgoraMediaPlayerSource(EventListener *event) {
  _event = event;
}

AgoraMediaPlayerSource::~AgoraMediaPlayerSource() { _event = nullptr; }

void AgoraMediaPlayerSource::onPlayerSourceStateChanged(
    media::base::MEDIA_PLAYER_STATE state, media::base::MEDIA_PLAYER_ERROR ec) {
  if (_event && _event->_onPlayerSourceStateChanged) {
    _event->_onPlayerSourceStateChanged(state, ec);
  }
}

void AgoraMediaPlayerSource::onPositionChanged(int64_t position) {
  if (_event && _event->_onPositionChanged)
    _event->_onPositionChanged(position);
}

void AgoraMediaPlayerSource::onPlayerEvent(
    media::base::MEDIA_PLAYER_EVENT event, int64_t elapsedTime,
    const char *message) {
  if (_event && _event->_onPlayerEvent)
    _event->_onPlayerEvent(event, elapsedTime, message);
}

void AgoraMediaPlayerSource::onMetaData(const void *data, int length) {
  if (_event && _event->_onMetaData)
    _event->_onMetaData(data, length);
}

void AgoraMediaPlayerSource::onPlayBufferUpdated(int64_t playCachedBuffer) {
  if (_event && _event->_onPlayBufferUpdated)
    _event->_onPlayBufferUpdated(playCachedBuffer);
}

void AgoraMediaPlayerSource::onPreloadEvent(
    const char *src, media::base::PLAYER_PRELOAD_EVENT event) {
  PRINTF("AgoraMediaPlayerSource::onPreloadEvent");
  if (_event && _event->_onPreloadEvent)
    _event->_onPreloadEvent(src, event);
}

void AgoraMediaPlayerSource::onCompleted() {
  PRINTF("AgoraMediaPlayerSource::onCompleted");
  if (_event && _event->_onCompleted)
    _event->_onCompleted();
}

void AgoraMediaPlayerSource::onAgoraCDNTokenNeedRenew() {
  if (_event && _event->_onAgoraCDNTokenNeedRenew)
    _event->_onAgoraCDNTokenNeedRenew();
}

void AgoraMediaPlayerSource::onFrame(const media::base::VideoFrame *frame) {
  if (_event && _event->_onFrame) {
    VideoFrame _video_frame;
    _video_frame.width = frame->width;
    _video_frame.height = frame->height;
    _video_frame.yStride = frame->yStride;
    _video_frame.uStride = frame->uStride;
    _video_frame.vStride = frame->vStride;
    _video_frame.yBuffer = frame->yBuffer;
    _video_frame.uBuffer = frame->uBuffer;
    _video_frame.vBuffer = frame->vBuffer;
    _video_frame.rotation = frame->rotation;
    _event->_onFrame(&_video_frame);
  }
}
} // namespace rtc
} // namespace agora
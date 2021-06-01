#include "agora_media_player_source.h"

namespace agora {
namespace rtc {

AgoraMediaPlayerSourceObserver::AgoraMediaPlayerSourceObserver(EventListener *event) {
  _event = event;
}

AgoraMediaPlayerSourceObserver::~AgoraMediaPlayerSourceObserver() { _event = nullptr; }

void AgoraMediaPlayerSourceObserver::onPlayerSourceStateChanged(
    media::base::MEDIA_PLAYER_STATE state, media::base::MEDIA_PLAYER_ERROR ec) {
  if (_event && _event->_onPlayerSourceStateChanged) {
    _event->_onPlayerSourceStateChanged(state, ec);
  }
}

void AgoraMediaPlayerSourceObserver::onPositionChanged(int64_t position) {
  if (_event && _event->_onPositionChanged)
    _event->_onPositionChanged(position);
}

void AgoraMediaPlayerSourceObserver::onPlayerEvent(
    media::base::MEDIA_PLAYER_EVENT event, int64_t elapsedTime,
    const char *message) {
  if (_event && _event->_onPlayerEvent)
    _event->_onPlayerEvent(event, elapsedTime, message);
}

void AgoraMediaPlayerSourceObserver::onMetaData(const void *data, int length) {
  if (_event && _event->_onMetaData)
    _event->_onMetaData(data, length);
}

void AgoraMediaPlayerSourceObserver::onPlayBufferUpdated(int64_t playCachedBuffer) {
  if (_event && _event->_onPlayBufferUpdated)
    _event->_onPlayBufferUpdated(playCachedBuffer);
}

void AgoraMediaPlayerSourceObserver::onPreloadEvent(
    const char *src, media::base::PLAYER_PRELOAD_EVENT event) {
  PRINTF("AgoraMediaPlayerSourceObserver::onPreloadEvent");
  if (_event && _event->_onPreloadEvent)
    _event->_onPreloadEvent(src, event);
}

void AgoraMediaPlayerSourceObserver::onCompleted() {
  PRINTF("AgoraMediaPlayerSourceObserver::onCompleted");
  if (_event && _event->_onCompleted)
    _event->_onCompleted();
}

void AgoraMediaPlayerSourceObserver::onAgoraCDNTokenNeedRenew() {
  if (_event && _event->_onAgoraCDNTokenNeedRenew)
    _event->_onAgoraCDNTokenNeedRenew();
}

void AgoraMediaPlayerSourceObserver::onFrame(const media::base::VideoFrame *frame) {
  PRINTF("AgoraMediaPlayerSourceObserver::onFrame");
  if (_event && _event->_onFrame) {
    PRINTF("AgoraMediaPlayerSourceObserver::onFrame width: %d, height: %d, yStride: %d, rotation: %d", frame->width, frame->height, frame->yStride, frame->rotation);
    // VideoFrame _video_frame;
    // _video_frame.width = frame->width;
    // _video_frame.height = frame->height;
    // _video_frame.yStride = frame->yStride;
    // _video_frame.uStride = frame->uStride;
    // _video_frame.vStride = frame->vStride;
    // _video_frame.yBuffer = frame->yBuffer;
    // _video_frame.uBuffer = frame->uBuffer;
    // _video_frame.vBuffer = frame->vBuffer;
    // _video_frame.rotation = frame->rotation;
    // _event->_onFrame(&_video_frame);
  }
}
} // namespace rtc
} // namespace agora
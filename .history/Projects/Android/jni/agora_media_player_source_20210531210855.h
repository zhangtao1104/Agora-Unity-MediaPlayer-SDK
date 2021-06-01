#pragma once

namespace agora {
    namespace rtc {
        class AgoraMediaPlayerSource : public IMediaPlayerSourceObserver {
            public: 
                AgoraMediaPlayerSource() = default;
                virtual ~AgoraMediaPlayerSource();

   void onPlayerSourceStateChanged(media::base::MEDIA_PLAYER_STATE state,
                                          media::base::MEDIA_PLAYER_ERROR ec) override;

   void onPositionChanged(int64_t position) override;

    void onPlayerEvent(media::base::MEDIA_PLAYER_EVENT event, int64_t elapsedTime, const char* message) override;

    void onMetaData(const void* data, int length) override;


    void onPlayBufferUpdated(int64_t playCachedBuffer) override;

    void onPreloadEvent(const char* src, media::base::PLAYER_PRELOAD_EVENT event) override;

  /**
   * @brief Occurs when one playback of the media file is completed.
   */
  virtual void onCompleted() = 0;

	/**
	 * @brief AgoraCDN Token has expired and needs to be set up with renewAgoraCDNSrcToken(const char* src).
	 */
	virtual void onAgoraCDNTokenNeedRenew() = 0;
        };
    }
}
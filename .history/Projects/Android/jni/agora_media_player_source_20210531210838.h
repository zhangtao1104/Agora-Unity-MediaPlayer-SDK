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


  /**
   * @brief Triggered when play buffer updated, once every 1 second
   *
   * @param int cached buffer during playing, in milliseconds
   */
  virtual void onPlayBufferUpdated(int64_t playCachedBuffer) = 0;

  /**
   * @brief Triggered when the player addPreloadSrc
   *
   * @param event
   */
  virtual void onPreloadEvent(const char* src, media::base::PLAYER_PRELOAD_EVENT event) = 0;

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
#pragma once

namespace agora {
    namespace rtc {
        class AgoraMediaPlayerSource : public IMediaPlayerSourceObserver {
            public: 
                AgoraMediaPlayerSource() = default;
                virtual ~AgoraMediaPlayerSource();

  virtual void onPlayerSourceStateChanged(media::base::MEDIA_PLAYER_STATE state,
                                          media::base::MEDIA_PLAYER_ERROR ec) = 0;

  /**
   * @brief Reports current playback progress.
   *
   * The callback occurs once every one second during the playback and reports the current playback progress.
   * @param position Current playback progress (second).
   */
  virtual void onPositionChanged(int64_t position) = 0;

  /**
   * @brief Reports the playback event.
   *
   * - After calling the `seek` method, the SDK triggers the callback to report the results of the seek operation.
   * - After calling the `selectAudioTrack` method, the SDK triggers the callback to report that the audio track changes.
   *
   * @param event The playback event. See {@link media::base::MEDIA_PLAYER_EVENT MEDIA_PLAYER_EVENT}.
   * @param elapsedTime The playback elapsed time.
   * @param message The playback message.
   */
  virtual void onPlayerEvent(media::base::MEDIA_PLAYER_EVENT event, int64_t elapsedTime, const char* message) = 0;

  /**
   * @brief Occurs when the metadata is received.
   *
   * The callback occurs when the player receives the media metadata and reports the detailed information of the media metadata.
   * @param data The detailed data of the media metadata.
   * @param length The data length (bytes).
   */
  virtual void onMetaData(const void* data, int length) = 0;


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
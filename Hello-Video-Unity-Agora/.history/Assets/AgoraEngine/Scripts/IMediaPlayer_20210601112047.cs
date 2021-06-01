using System;
namespace agora
{
namespace mediaPlayer
{
enum ERROR_CODE
{
    ERROR_NOT_INIT = -7
}

/**
 * @brief The playback state.
 *
 */
enum MEDIA_PLAYER_STATE
{
    /** Default state.
     */
    PLAYER_STATE_IDLE = 0,
    /** Opening the media file.
     */
    PLAYER_STATE_OPENING,
    /** The media file is opened successfully.
     */
    PLAYER_STATE_OPEN_COMPLETED,
    /** Playing the media file.
     */
    PLAYER_STATE_PLAYING,
    /** The playback is paused.
     */
    PLAYER_STATE_PAUSED,
    /** The playback is completed.
     */
    PLAYER_STATE_PLAYBACK_COMPLETED,
    /** All loops are completed.
     */
    PLAYER_STATE_PLAYBACK_ALL_LOOPS_COMPLETED,
    /** The playback is stopped.
     */
    PLAYER_STATE_STOPPED,
    /** Player pausing (internal)
     */
    PLAYER_STATE_PAUSING_INTERNAL = 50,
    /** Player stopping (internal)
     */
    PLAYER_STATE_STOPPING_INTERNAL,
    /** Player seeking state (internal)
     */
    PLAYER_STATE_SEEKING_INTERNAL,
    /** Player getting state (internal)
     */
    PLAYER_STATE_GETTING_INTERNAL,
    /** None state for state machine (internal)
     */
    PLAYER_STATE_NONE_INTERNAL,
    /** Do nothing state for state machine (internal)
     */
    PLAYER_STATE_DO_NOTHING_INTERNAL,
    /** The playback fails.
     */
    PLAYER_STATE_FAILED = 100,
}
;
/**
 * @brief Player error code
 *
 */
enum MEDIA_PLAYER_ERROR
{
    /** No error.
     */
    PLAYER_ERROR_NONE = 0,
    /** The parameter is invalid.
     */
    PLAYER_ERROR_INVALID_ARGUMENTS = -1,
    /** Internel error.
     */
    PLAYER_ERROR_INTERNAL = -2,
    /** No resource.
     */
    PLAYER_ERROR_NO_RESOURCE = -3,
    /** Invalid media source.
     */
    PLAYER_ERROR_INVALID_MEDIA_SOURCE = -4,
    /** The type of the media stream is unknown.
     */
    PLAYER_ERROR_UNKNOWN_STREAM_TYPE = -5,
    /** The object is not initialized.
     */
    PLAYER_ERROR_OBJ_NOT_INITIALIZED = -6,
    /** The codec is not supported.
     */
    PLAYER_ERROR_CODEC_NOT_SUPPORTED = -7,
    /** Invalid renderer.
     */
    PLAYER_ERROR_VIDEO_RENDER_FAILED = -8,
    /** An error occurs in the internal state of the player.
     */
    PLAYER_ERROR_INVALID_STATE = -9,
    /** The URL of the media file cannot be found.
     */
    PLAYER_ERROR_URL_NOT_FOUND = -10,
    /** Invalid connection between the player and the Agora server.
     */
    PLAYER_ERROR_INVALID_CONNECTION_STATE = -11,
    /** The playback buffer is insufficient.
     */
    PLAYER_ERROR_SRC_BUFFER_UNDERFLOW = -12,
    /** The audio mixing file playback is interrupted.
     */
    PLAYER_ERROR_INTERRUPTED = -13,
}
;

/**
 * @brief The playback speed.
 *
 */
enum MEDIA_PLAYER_PLAYBACK_SPEED
{
    /** The original playback speed.
     */
    PLAYBACK_SPEED_ORIGINAL = 100,
    /** 0.5 times the original playback speed.
     */
    PLAYBACK_SPEED_50_PERCENT = 50,
    /** 0.75 times the original playback speed.
     */
    PLAYBACK_SPEED_75_PERCENT = 75,
    /** 1.25 times the original playback speed.
     */
    PLAYBACK_SPEED_125_PERCENT = 125,
    /** 1.5 times the original playback speed.
     */
    PLAYBACK_SPEED_150_PERCENT = 150,
    /** 2.0 times the original playback.
     */
    PLAYBACK_SPEED_200_PERCENT = 200,
}
;

/**
 * @brief The type of the media stream.
 *
 */
enum MEDIA_STREAM_TYPE
{
    /** The type is unknown.
     */
    STREAM_TYPE_UNKNOWN = 0,
    /** The video stream.
     */
    STREAM_TYPE_VIDEO = 1,
    /** The audio stream.
     */
    STREAM_TYPE_AUDIO = 2,
    /** The subtitle stream.
     */
    STREAM_TYPE_SUBTITLE = 3,
}
;

/**
 * @brief The playback event.
 *
 */
enum MEDIA_PLAYER_EVENT
{
    /** The player begins to seek to the new playback position.
     */
    PLAYER_EVENT_SEEK_BEGIN = 0,
    /** The seek operation completes.
     */
    PLAYER_EVENT_SEEK_COMPLETE = 1,
    /** An error occurs during the seek operation.
     */
    PLAYER_EVENT_SEEK_ERROR = 2,
    /** The player publishes a video track.
     */
    PLAYER_EVENT_VIDEO_PUBLISHED = 3,
    /** The player publishes an audio track.
     */
    PLAYER_EVENT_AUDIO_PUBLISHED = 4,
    /** The player changes the audio track for playback.
     */
    PLAYER_EVENT_AUDIO_TRACK_CHANGED = 5,
    /** player buffer low
     */
    PLAYER_EVENT_BUFFER_LOW = 6,
    /** player buffer recover
     */
    PLAYER_EVENT_BUFFER_RECOVER = 7,
    /** The video or audio is interrupted
     */
    PLAYER_EVENT_FREEZE_START = 8,
    /** Interrupt at the end of the video or audio
     */
    PLAYER_EVENT_FREEZE_STOP = 9,
    /** switch source begin
     */
    PLAYER_EVENT_SWITCH_BEGIN = 10,
    /** switch source complete
     */
    PLAYER_EVENT_SWITCH_COMPLETE = 11,
    /** switch source error
     */
    PLAYER_EVENT_SWITCH_ERROR = 12,
    /** An application can render the video to less than a second
     */
    PLAYER_EVENT_FIRST_DISPLAYED = 13,
}
;

/**
 * @brief The play preload another source event.
 *
 */
enum PLAYER_PRELOAD_EVENT
{
    /** preload source begin
     */
    PLAYER_PRELOAD_EVENT_BEGIN = 0,
    /** preload source complete
     */
    PLAYER_PRELOAD_EVENT_COMPLETE = 1,
    /** preload source error
     */
    PLAYER_PRELOAD_EVENT_ERROR = 2,
}
;


class MediaPlayerSourceEvent {
  public virtual void onPlayerSourceStateChanged(MEDIA_PLAYER_STATE state,
                                          MEDIA_PLAYER_ERROR ec) {}

  public virtual void onPositionChanged(long position){}

  public virtual void onPlayerEvent(MEDIA_PLAYER_EVENT events, long elapsedTime, string message){}

  public virtual void onMetaData(IntPtr data, int length) {}


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
}


abstract class IMediaPlayer
{
    public abstract int Open(string url, long startPos);
    public abstract int Play();
    public abstract int Pause();
    public abstract int Stop();
    public abstract int TakeScreenshot(string fileName);
    public abstract int Mute(bool mute);
    public abstract bool GetMute();
    public abstract int RegisterVideoFrameObserver();
    public abstract int UnregisterVideoFrameObserver();
    public abstract void Release(bool sync);
}
}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora.mediaPlayer;

class EventHandler : MediaPlayerSourceEvent {

    IMediaPlayer player;
    public override void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
    {
        Debug.Log("CWrapper :  OnPlayerSourceStateChanged state = " + (int)state + "  err: " + (int)ec);
        if (state == MEDIA_PLAYER_STATE.PLAYER_STATE_OPEN_COMPLETED) {
            var ret = player.Play();
            // player.RegisterVideoFrameObserver();
            Debug.Log("CWrapper : ret " + ret);
        }
    }

    public override void OnPositionChanged(long position)
    {
        Debug.Log("CWrapper :  OnPositionChanged position = " + position);
    }

    public override void OnPlayerEvent(MEDIA_PLAYER_EVENT events, long elapsedTime, string message)
    {
    }

    public override void OnMetaData(IntPtr data, int length)
    {
    }

    public override void OnPlayBufferUpdated(long playCachedBuffer)
    {
    }

    public override void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT events)
    {
    }

    public override void OnCompleted()
    {
    }

    public override void OnAgoraCDNTokenNeedRenew()
    {
    }

    public override void OnFrame(VideoFrame frame)
    {
    }
}

public class Test : MonoBehaviour
{
    IMediaPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = MediaPlayerImp.CreateMediaPlayer("5db0d12c40354100abd7a8a0adaa1fb8", new EventHandler());
        var ret = player.Open("http://114.236.93.153:8080/download/video/wudao1.flv", 0);
        // player.Play();
        Debug.Log("CWrapper player.Open  ret = " + ret);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

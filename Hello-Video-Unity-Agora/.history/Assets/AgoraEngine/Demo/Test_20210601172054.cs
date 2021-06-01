using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora.mediaPlayer;

class EventHandler : MediaPlayerSourceEvent {
       public virtual void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
    {
    }

    public virtual void OnPositionChanged(long position)
    {
    }

    public virtual void OnPlayerEvent(MEDIA_PLAYER_EVENT events, long elapsedTime, string message)
    {
    }

    public virtual void OnMetaData(IntPtr data, int length)
    {
    }

    public virtual void OnPlayBufferUpdated(long playCachedBuffer)
    {
    }

    public virtual void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT events)
    {
    }

    public virtual void OnCompleted()
    {
    }

    public virtual void OnAgoraCDNTokenNeedRenew()
    {
    }

    public virtual void OnFrame(VideoFrame frame)
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

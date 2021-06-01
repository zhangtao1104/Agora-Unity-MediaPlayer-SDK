using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora.mediaPlayer;
using System;

class EventHandler : MediaPlayerSourceEvent {

    public IMediaPlayer player;
    public override void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
    {
        Debug.Log("CWrapper customer:  OnPlayerSourceStateChanged state = " + (int)state + "  err: " + (int)ec);
        if (state == MEDIA_PLAYER_STATE.PLAYER_STATE_OPEN_COMPLETED) {
            var ret = player.Play();
            var ret2 = player.RegisterVideoFrameObserver();
            Debug.Log("CWrapper customer: ret Play : " + ret + " registerVideoFrameObserver ret = " + ret2);
        }
    }

    public override void OnPositionChanged(long position)
    {
        Debug.Log("CWrapper customer:  OnPositionChanged position = " + position);
    }

    public override void OnPlayerEvent(MEDIA_PLAYER_EVENT events, long elapsedTime, string message)
    {
        Debug.Log("CWrapper customer:  OnPlayerEvent events = " + (int)events);
    }

    public override void OnMetaData(IntPtr data, int length)
    {
    }

    public override void OnPlayBufferUpdated(long playCachedBuffer)
    {
        Debug.Log("CWrapper customer:  OnPlayBufferUpdated playCachedBuffer = " + playCachedBuffer);
    }

    public override void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT events)
    {
    }

    public override void OnCompleted()
    {
        Debug.Log("CWrapper customer:  OnCompleted");
    }

    public override void OnAgoraCDNTokenNeedRenew()
    {
    }

    public override void OnFrame(VideoFrame frame)
    {
        Debug.Log("CWrapper customer:  OnFrame width: " + frame.width + " ,height: " + frame.height + " yStride: " + frame.yStride + " rotation: " + frame.rotation);
    }
}

public class Test : MonoBehaviour
{
    IMediaPlayer player;
    EventHandler eventHandler;

    // Start is called before the first frame update
    void Start()
    {
        eventHandler = new EventHandler();
        player = MediaPlayerImp.CreateMediaPlayer("5db0d12c40354100abd7a8a0adaa1fb8", eventHandler);
        eventHandler.player = player;

        var ret = player.Open("https://big-class-test.oss-cn-hangzhou.aliyuncs.com/61726.1593419122615.mp4", 0);
        Debug.Log("CWrapper player.Open  ret = " + ret);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

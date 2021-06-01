using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora.mediaPlayer;

class EventHandler : MediaPlayerSourceEvent {
    
}

public class Test : MonoBehaviour
{
    IMediaPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = MediaPlayerImp.CreateMediaPlayer("5db0d12c40354100abd7a8a0adaa1fb8",);
        var ret = player.Open("http://114.236.93.153:8080/download/video/wudao1.flv", 0);
        Debug.Log("CWrapper player.Open  ret = " + ret);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

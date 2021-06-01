using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora.mediaPlayer;

public class Test : MonoBehaviour
{
    IMediaPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = MediaPlayerImp.CreateMediaPlayer("5db0d12c40354100abd7a8a0adaa1fb8", new MediaPlayerSourceEvent() {
            OnPlayerSourceStateChanged = (MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR error)=> {
                Debug.Log("CWrapper OnPlayerSourceStateChanged  " + state + "  " + error);
                if (state == MEDIA_PLAYER_STATE.PLAYER_STATE_OPEN_COMPLETED) {
                    var ret1 = player.Play();
                    Debug.Log("CWrapper player.Play  ret = " + ret1);
                }
            }
        });
        var ret = player.Open("http://114.236.93.153:8080/download/video/wudao1.flv", 0);
        Debug.Log("CWrapper player.Open  ret = " + ret);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

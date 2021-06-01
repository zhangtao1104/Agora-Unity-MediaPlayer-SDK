using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora.mediaPlayer;

public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var player = MediaPlayerImp.CreateMediaPlayer("5db0d12c40354100abd7a8a0adaa1fb8", new MediaPlayerSourceEvent() {
            OnPlayerSourceStateChanged = (MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR error)=> {
                Debug.Log("OnPlayerSourceStateChanged  " + state + "  " + error);
                if (state == 2) {
                    player.Play();
                }
            }
        });
        player.Open("http://114.236.93.153:8080/download/video/wudao1.flv", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
            }
        });
        player.Open();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

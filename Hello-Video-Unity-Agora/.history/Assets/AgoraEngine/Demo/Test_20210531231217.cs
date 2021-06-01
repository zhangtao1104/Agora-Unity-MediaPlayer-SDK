using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora.mediaPlayer;

public class Test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        MediaPlayerImp.CreateMediaPlayer(new MediaPlayerSourceEvent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FMODController : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string selectSound;
    FMOD.Studio.EventInstance soundEvent;

    public HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        soundEvent = FMODUnity.RuntimeManager.CreateInstance(selectSound);
        soundEvent.start();
    }

    float transition = 0;
    // Update is called once per frame
    void Update()
    {
        if(hud.score == 1000)
        {
            soundEvent.setParameterByName("level", 1);
        }
        if(hud.score == 2000)
        {
            soundEvent.setParameterByName("level", 2);
        }
        if (hud.score == 3000)
        {
            soundEvent.setParameterByName("level", 3);
            soundEvent.setParameterByName("transition", 1);
        }

        float level;
        soundEvent.getParameterByName("level", out level);
        float transition;
        soundEvent.getParameterByName("transition", out transition );
        print("LEVEL:" + level.ToString());
        print("Trans:" + transition.ToString());

        FMOD.Studio.PLAYBACK_STATE playbackState;
        soundEvent.getPlaybackState(out playbackState);
        if (playbackState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
            hud.playerDead = true;

            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        print("PLAYBACK:" + playbackState.ToString());
    }
}

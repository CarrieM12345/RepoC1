using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{ 
    
    public AudioMixer masterMixer;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume(float volume)
    {


        masterMixer.SetFloat("MusicVol", volume);
    }

    public void SetAmbienceVolume(float volume)
    {

        masterMixer.SetFloat("AmbienceVol", volume);

    }

}

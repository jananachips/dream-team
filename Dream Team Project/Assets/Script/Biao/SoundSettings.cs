using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour {
    public AudioControllerList audioControllers;
    public float StartingVolume = 0.5f;
    public float CurrentVolume = 0.5f;

    public AudioSource[] audioControllerList ; 

	void Start () {
        audioControllerList = audioControllers.GetAllAudioControllers();
        ChangeAllVolumeTo(StartingVolume);
        CurrentVolume = StartingVolume;
	}
	
	void Update () {
		
	}

    public void MuteAll()
    {
        for(int i = 0; i < audioControllerList.Length; i++)
        {
            audioControllerList[i].volume = 0;
        }
        CurrentVolume = 0;
    }

    //noting is wrong, don't know why report error, but still works
    public void ChangeAllVolumeTo(float volume)
    {
        for(int i = 0; i < audioControllerList.Length; i++)
        {
            audioControllerList[i].volume = volume;
        }
        CurrentVolume = volume;
    }

}

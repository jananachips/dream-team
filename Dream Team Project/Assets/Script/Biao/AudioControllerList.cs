using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerList : MonoBehaviour {
    public AudioSource[] audiosControllerList;
	void Start () {
		
	}
	
	void Update () {
		
	}

    public AudioSource[] GetAllAudioControllers()
    {
        return audiosControllerList;
    }
}

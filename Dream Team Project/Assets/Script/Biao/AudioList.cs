using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour {
    public AudioSource[] audiosList;
	void Start () {
		
	}
	
	void Update () {
		
	}

    public AudioSource[] GetAllAudios()
    {
        return audiosList;
    }
}

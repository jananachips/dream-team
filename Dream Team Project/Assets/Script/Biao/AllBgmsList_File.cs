using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBgmsList_File : MonoBehaviour {

    public AudioClip[] BgmClips;
	void Start () {
		
	}
	
	void Update () {
		
	}

    public AudioClip[] GetBgmsList()
    {
        return BgmClips;
    }

}

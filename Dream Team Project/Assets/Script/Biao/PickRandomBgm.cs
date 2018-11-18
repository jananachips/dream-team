using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRandomBgm : MonoBehaviour {

    public AllBgmsList_File allBgmsList_File;

    private AudioClip[] bgms_List;
    private AudioClip aBgm;
    //public AudioSource audioController;
	void Awake() {
        AssignRandomClip();
	}
	
	void Update () {
		
	}

    public void AssignRandomClip()
    {
        bgms_List = allBgmsList_File.GetBgmsList();
        aBgm = GetRandomAudioClip();

        AudioSource audioController = GetComponent<AudioSource>();
        audioController.clip = aBgm;
        audioController.Play();
        Debug.Log("bgm works");
    }

    public AudioClip GetRandomAudioClip()
    {
        int i;
        int AudioListSize = bgms_List.Length;
        i = Random.Range(0, AudioListSize);
        return bgms_List[i];
    }
}

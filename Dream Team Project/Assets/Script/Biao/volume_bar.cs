using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume_bar : MonoBehaviour {
    public Scrollbar volumnBar;
    public SoundSettings soundSetting;

    private float volume;
	void Start () {
        volumnBar.value = soundSetting.CurrentVolume;
	}
	
	// Update is called once per frame
	void Update () {
        		
	}

    public void BarVolumeChange()
    {
        //Debug.Log(volumnBar.value);
        volume = volumnBar.value;
        soundSetting.ChangeAllVolumeTo(volume);
        soundSetting.CurrentVolume = volume;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume_bar : MonoBehaviour {
    public Scrollbar volumeBar;
    public SoundSettings soundSetting;

    private float volume;
	void Start () {
        soundSetting = FindObjectOfType<SoundSettings>();
        volumeBar.value = soundSetting.CurrentVolume;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(soundSetting.CurrentVolume != volumeBar.value)
        {
            volumeBar.value = soundSetting.CurrentVolume;
        }
	}

    public void BarVolumeChange()
    {
        volume = volumeBar.value;
        soundSetting.ChangeAllVolumeTo(volume);
        soundSetting.CurrentVolume = volume;

    }
}

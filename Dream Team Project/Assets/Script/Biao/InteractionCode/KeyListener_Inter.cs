using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener_Inter : MonoBehaviour {

    public bool ContinueListeningKeys = false;
    public KeyCode KeyToListen = KeyCode.E;
    private bool KeyDetected = false;
    private bool StopNow = false;
	void Start () {
		
	}
	
	void Update () {
        if (ContinueListeningKeys)
        {
            //may be shouldn't be here
            KeyDetected = false;
            if(Input.GetKeyDown(KeyToListen))
            {
                KeyDetected = true;
            }else if (Input.GetKeyDown(KeyCode.N))
            {
                StopNow = true;
            }
        }else if (!ContinueListeningKeys)
        {
            KeyDetected = false;
            StopNow = false;
        }
	}

    public bool GetIsKeyPressed()
    {
        if (KeyDetected)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool StopTalkNow()
    {
        if (StopNow)
        {
            StopNow = false;
            ContinueListeningKeys = false;
            return true;
        }
        else
        {
            return false;
        }
    }

}

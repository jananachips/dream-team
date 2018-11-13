using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener_Inter : MonoBehaviour {

    public bool ContinueListeningKeys = false;
    public KeyCode KeyToListen = KeyCode.E;
    private bool KeyDetected = false;
    private bool StopNow = false;
    public bool WorkingNow = false;
	void Start () {
		
	}
	
	void Update () {

        if (StopNow)
        {
            StopNow = false;
            ContinueListeningKeys = false;
            WorkingNow = false;
        }

        if (ContinueListeningKeys)
        {
            WorkingNow = true;
            //KeyDetected = false;

            if(Input.GetKeyDown(KeyToListen))
            {
                Debug.Log("key pressed");
                KeyDetected = true;
            }else if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("skipped");
                StopNow = true;
            }
        }else if (!ContinueListeningKeys)
        {
            KeyDetected = false;
            StopNow = false;
            WorkingNow = false;
        }
	}

    public bool GetIsKeyPressed()
    {
        if (KeyDetected)
        {
            //
            KeyDetected = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetIsWorkNow()
    {
        return WorkingNow;
    }

    public void StopActionNow()
    {
        ContinueListeningKeys = false;
        StopNow = true;
        
    }

    public bool IsStopActionNow()
    {
        if (StopNow)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

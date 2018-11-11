using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWindowsActive : MonoBehaviour {

    //stop the conflict between hotkey during game and key that go to pause menu

    public bool OtherWindowsExist = false;

    public bool GetStatuesOtherWindow()
    {
        return OtherWindowsExist; 
    }
}

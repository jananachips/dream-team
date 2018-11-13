using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_OneWay_Manager : MonoBehaviour {
    public KeyListener_Inter keyListener;
    public float checkInputPeriod = 0.005f;

    private Teleport_OneWay_Action teleport_OneWay_Action;
    private bool jobDone = false;

    
    private void Start()
    {
        teleport_OneWay_Action = FindObjectOfType<Teleport_OneWay_Action>();
        keyListener = FindObjectOfType<KeyListener_Inter>();
    }

    public void ReadyToTeleport(Transform from, Transform to)
    {
        jobDone = false;
        keyListener.ContinueListeningKeys = true;

        //will pause here
        StartCoroutine(doTeleport(checkInputPeriod, from, to));

    }


    IEnumerator doTeleport(float checkPeriod, Transform from, Transform to)
    {
        while(!jobDone)
        {
            /*
            if(keyListener.ContinueListeningKeys == false)
            {
                keyListener.ContinueListeningKeys = true;
            }
            */
            if (keyListener.GetIsKeyPressed())
            {
                teleport_OneWay_Action.DoTeleport(from, to);
                jobDone = true;
                Debug.Log("teleport got key");
            }
            yield return new WaitForSeconds(checkPeriod);
        }

        keyListener.ContinueListeningKeys = false;

    }

    public void TeleportExpire()
    {
        Debug.Log("expire called");
        keyListener.StopActionNow();
    }


}

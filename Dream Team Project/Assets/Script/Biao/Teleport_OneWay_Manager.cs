using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_OneWay_Manager : MonoBehaviour {
    [Header("Time interval to check the user input")]
    public float checkInputInterval = 0.005f;
    //public bool explodeAfterUse = true;
    //public bool followPlayerTeleport = true;


    private KeyListener_Inter keyListener;
    private Teleport_OneWay_Action teleport_OneWay_Action;
    private bool jobDone = false;
    private IEnumerator IEnumerator_temp;
    
    private void Start()
    {
        teleport_OneWay_Action = FindObjectOfType<Teleport_OneWay_Action>();
        keyListener = FindObjectOfType<KeyListener_Inter>();
    }

    public void ReadyToTeleport(Transform from, Transform to, Transform teleportTransform)
    {
        jobDone = false;
        keyListener.ContinueListeningKeys = true;

        //will pause here
        IEnumerator_temp = doTeleport(checkInputInterval, from, to, teleportTransform); 
        StartCoroutine(IEnumerator_temp);

    }


    IEnumerator doTeleport(float checkPeriod, Transform from, Transform to, Transform teleportTransform)
    {
        while(!jobDone)
        {
            if (keyListener.GetIsKeyPressed())
            {
                teleport_OneWay_Action.DoTeleport(from, to);
                //teleport_OneWay_Action.FollowAndExplode(teleportTransform, to,explodeAfterUse, followPlayerTeleport);
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
        //stop the coroutine that is wait to teleport
        StopCoroutine(IEnumerator_temp);
    }


}

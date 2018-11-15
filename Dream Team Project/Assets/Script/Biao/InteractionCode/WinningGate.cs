using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningGate : MonoBehaviour {
    public float triggerDelay = 0.5f;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(WinTheGame());
        }
    }

    IEnumerator WinTheGame()
    {
        yield return new WaitForSecondsRealtime(triggerDelay);
        gameManager.WinTheGame();
    }
}

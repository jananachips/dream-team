using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConditions_Manager : MonoBehaviour {

    [Header("Use value I provided, not default")]
    public bool UseMyValue = false;
    public float PlayerCurrentHealth = 5;
    public float healthBarXOffset = 0;
    public float healthBarYOffset = 10;
    [Space]
    private GameManager gameManager;
    //private Canvas PlayerHealthBar_Window;
    public Slider PlayerHealthSlider;
    public Transform PlayerTransform;
    public Transform DeathHeight;


    private float PlayerMaxHealth;
    private Vector3 DesiredHealthBarPosition;

	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        PlayerTransform = transform;

        if (!UseMyValue)
        {
            PlayerCurrentHealth = 5;
        }

        PlayerMaxHealth = PlayerCurrentHealth;

        //for test
	}
	
	void Update () {

        PlayerHealthSlider.value = PlayerCurrentHealth / PlayerMaxHealth;
        if(PlayerCurrentHealth <= 0)
        {
            gameManager.LostTheGame();
            this.enabled = false;
        }

        if(PlayerTransform.position.y <= DeathHeight.position.y)
        {
            //PlayerCurrentHealth = 0;
            DecreasePlayerHealthBy(1f);
        }
	}



    public void DecreasePlayerHealthBy(float damage)
    {
        PlayerCurrentHealth = PlayerCurrentHealth - damage;
    }

    public void AddPlayerHealthBy(float health)
    {
        PlayerCurrentHealth = PlayerCurrentHealth + health;
    }

    public float GetPlayerCurrentHealth()
    {
        return PlayerCurrentHealth;
    }
}

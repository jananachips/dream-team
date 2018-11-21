using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FightSystem : MonoBehaviour {
    public float playerDamage = 0.5f;
    public AssignProperties_Inter objectProperties;
    private bool IDoDamages = true;
    private bool IReceiveDamage = true;
    //private bool IDoHeal = false;
    private float MyDamage;
    //private float MyHeal;
    public float myHealth;

	void Start () {
        IDoDamages = objectProperties.DoesDamage;
        IReceiveDamage = objectProperties.ReceiveDamage;
        MyDamage = objectProperties.Damage;
        myHealth = objectProperties.healthAmt;
	}
	
	// Update is called once per frame
	void Update () {
	}

    //because weapon uses trigger
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("the tag : " + collision.tag);
        if (IReceiveDamage && otherCollider.tag == "Weapon")
        {
            myHealth = myHealth - playerDamage;
        } 

        if(myHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D otherCollider = collision.collider;
        Debug.Log("the tag: " + otherCollider.tag);
        if (IDoDamages &&  otherCollider.tag == "Player")
        {
            otherCollider.GetComponentInChildren<PlayerConditions_Manager>().DecreasePlayerHealthBy(MyDamage);
        }



    }
}
